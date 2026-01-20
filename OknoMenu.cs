using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hipcio
{
    // Główne okno menu aplikacji
    public partial class OknoMenu : Form
    {
        // Konstruktor okna menu
        public OknoMenu()
        {
            InitializeComponent(); // Inicjalizacja komponentów formularza
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //wczytywanie salda z pliku lub tworzenie pliku z domyślną wartością
        int WczytajLubUtworzPlik()
        {
            string sciezka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wartosc.txt");

            if (!File.Exists(sciezka))
            {
                File.WriteAllText(sciezka, "1000");
                return 1000;
            }

            if (int.TryParse(File.ReadAllText(sciezka), out int wartosc))
                return wartosc;

            // jeśli plik uszkodzony
            File.WriteAllText(sciezka, "1000");
            return 1000;
        }

        // Obsługa kliknięcia przycisku Blackjack
        private void bjack_Click(object sender, EventArgs e)
        {
            // Tworzenie nowej instancji za każdym razem
            OknoBlackJack bj = new OknoBlackJack();

            // Ustawienie ręcznej pozycji nowego okna
            bj.StartPosition = FormStartPosition.Manual;
            // Ustawienie nowego okna w tym samym miejscu co menu
            bj.Location = this.Location;
            // Ukrycie okna menu
            this.Hide();
            // Wyświetlenie okna blackjacka
            bj.Show();
            // Przeniesienie okna na pierwszy plan
            bj.BringToFront();
            // Po zamknięciu okna blackjacka ponownie pokaż menu
            bj.FormClosed += (s, args) => { this.Show(); ustawSaldo(); };
        }

        // Obsługa kliknięcia przycisku Ruletka
        private void ruletka_Click(object sender, EventArgs e)
        {
            OknoRuletka rl = new OknoRuletka();

            rl.StartPosition = FormStartPosition.Manual;
            rl.Location = this.Location;
            this.Hide();
            rl.Show();
            // Po zamknięciu ruletki wracamy do menu
            rl.FormClosed += (s, args) => { this.Show(); ustawSaldo(); };
        }

        // Obsługa kliknięcia przycisku Koło Fortuny
        private void kolo_Click(object sender, EventArgs e)
        {
            OknoKoloFortuny kl = new OknoKoloFortuny();

            kl.StartPosition = FormStartPosition.Manual;
            kl.Location = this.Location;
            this.Hide();
            kl.Show();
            // Po zamknięciu koła fortuny pokaż menu
            kl.FormClosed += (s, args) => { this.Show(); ustawSaldo(); };
        }

        // Obsługa kliknięcia przycisku Jednoręki Bandyta
        private void bandyta_Click(object sender, EventArgs e)
        {
            OknoBandyta bt = new OknoBandyta();

            bt.StartPosition = FormStartPosition.Manual;
            bt.Location = this.Location;
            this.Hide();
            bt.Show();
            // Po zamknięciu bandyty wróć do menu
            bt.FormClosed += (s, args) => { this.Show(); ustawSaldo(); };
        }

        // Obsługa kliknięcia przycisku doładowania
        private void doladuj_Click(object sender, EventArgs e)
        {
            doladuj dol = new doladuj();

            dol.StartPosition = FormStartPosition.Manual;
            dol.Location = this.Location;
            this.Hide();
            dol.Show();
            // Po zamknięciu bandyty wróć do menu
            dol.FormClosed += (s, args) => { this.Show(); ustawSaldo(); };
        }

        // Obsługa kliknięcia przycisku "Autorzy"
        private void autorzy_Click(object sender, EventArgs e)
        {
            autorzy au = new autorzy();

            au.StartPosition = FormStartPosition.Manual;
            au.Location = this.Location;
            this.Hide();
            au.Show();
            // Po zamknięciu bandyty wróć do menu
            au.FormClosed += (s, args) => { this.Show();ustawSaldo(); };
        }
        void ustawSaldo()
        {
            int saldo = WczytajLubUtworzPlik();
            this.saldo.Text = saldo.ToString();
        }
        private void OknoMenu_Load(object sender, EventArgs e)
        {
            ustawSaldo();
        }
    }
}