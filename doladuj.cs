using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hipcio
{
    public partial class doladuj : Form
    {
        // Ścieżka do pliku z saldem
        private string sciezkaPliku = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wartosc.txt");

        // Aktualne saldo
        private int aktualneSaldo = 0;

        public doladuj()
        {
            InitializeComponent();

            // Wczytaj aktualne saldo przy otwarciu formularza
            aktualneSaldo = WczytajSaldo();

            // Jeśli masz kontrolkę do wyświetlania salda (np. Label o nazwie labelSaldo)
            if (saldo != null)
            {
                saldo.Text = $"Aktualne saldo: {aktualneSaldo}";
            }
        }

        // Wczytywanie salda z pliku
        private int WczytajSaldo()
        {
            try
            {
                if (!File.Exists(sciezkaPliku))
                {
                    File.WriteAllText(sciezkaPliku, "1000");
                    return 1000;
                }

                string zawartosc = File.ReadAllText(sciezkaPliku).Trim();

                if (int.TryParse(zawartosc, out int wartosc) && wartosc >= 0)
                {
                    return wartosc;
                }

                // Jeśli plik uszkodzony
                File.WriteAllText(sciezkaPliku, "1000");
                return 1000;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd wczytywania salda: {ex.Message}\nUstawiono domyślne saldo 1000.",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1000;
            }
        }

        // Zapisywanie salda do pliku
        private void ZapiszSaldo(int noweAaldo)
        {
            try
            {
                File.WriteAllText(sciezkaPliku, noweAaldo.ToString());
                aktualneSaldo = noweAaldo;

                // Aktualizacja wyświetlanego salda
                if (saldo != null)
                {
                    saldo.Text = $"Aktualne saldo: {aktualneSaldo}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisywania salda: {ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Uniwersalna metoda doładowania
        private void DoladujSaldo(int kwota)
        {
            int noweSaldo = aktualneSaldo + kwota;
            ZapiszSaldo(noweSaldo);


        }

        // Button2: +10
        private void button2_Click(object sender, EventArgs e)
        {
            DoladujSaldo(10);
        }

        // Button1: +100
        private void button1_Click(object sender, EventArgs e)
        {
            DoladujSaldo(100);
        }

        // Button3: +50
        private void button3_Click(object sender, EventArgs e)
        {
            DoladujSaldo(50);
        }

        // Button4: +200
        private void button4_Click(object sender, EventArgs e)
        {
            DoladujSaldo(200);
        }
    }
}