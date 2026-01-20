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
    public partial class OknoKoloFortuny : Form
    {
        // Generator liczb losowych
        private Random rand = new Random();

        // Tablica z możliwymi wygranych (mnożniki)
        private int[] wygraneWartosci = { 0, 100, 0, 2, 0, 10, 0, 2 };

        // Tablica z etykietami wygranych
        private Label[] wygraneLabels;

        // Aktualnie podświetlone pole
        private int aktualnyIndex = 0;

        // Timer do animacji kręcenia
        private Timer timerAnimacji;

        // Licznik kroków animacji
        private int krokiAnimacji = 0;

        // Docelowy index (gdzie koło się zatrzyma)
        private int docelowyIndex = 0;

        // Opóźnienie między krokami (ms)
        private int opoznienie = 50;

        // Czy gra jest w trakcie
        private bool czyGraWTrakcie = false;

        // Zmienne do zarządzania saldem i zakładami
        private int aktualneSaldo = 1000;
        private int aktualnyZaklad = 0;

        // Ścieżka do pliku z saldem
        private string sciezkaPliku = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wartosc.txt");

        // Zmienna do edycji zakładu
        private string tekstZakladu = "0";

        public OknoKoloFortuny()
        {
            InitializeComponent();

            // Inicjalizacja tablicy etykiet
            wygraneLabels = new Label[]
            {
                wygrana0, wygrana1, wygrana2, wygrana3,
                wygrana4, wygrana5, wygrana6, wygrana7
            };

            // Inicjalizacja timera
            timerAnimacji = new Timer();
            timerAnimacji.Interval = opoznienie;
            timerAnimacji.Tick += TimerAnimacji_Tick;

            // Dodanie obsługi kliknięcia przycisku
            przyciskGraj.Click += PrzyciskGraj_Click;

            // Wczytanie salda z pliku
            aktualneSaldo = WczytajLubUtworzPlik();

            // Aktualizacja kontrolek saldo i zaklad
            if (saldo != null)
                saldo.Text = aktualneSaldo.ToString();

            if (zaklad != null)
            {
                zaklad.Text = "0";
                zaklad.Cursor = Cursors.IBeam;
            }

            // Obsługa klawiatury na poziomie formy
            this.KeyPreview = true;
            this.KeyDown += OknoKoloFortuny_KeyDown;
        }

        private void OknoKoloFortuny_KeyDown(object sender, KeyEventArgs e)
        {
            if (czyGraWTrakcie)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            // Delete - wyczyść zakład
            if (e.KeyCode == Keys.Delete)
            {
                tekstZakladu = "0";
                if (zaklad != null)
                    zaklad.Text = tekstZakladu;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            // Backspace
            else if (e.KeyCode == Keys.Back)
            {
                if (tekstZakladu.Length > 1)
                {
                    tekstZakladu = tekstZakladu.Substring(0, tekstZakladu.Length - 1);
                }
                else
                {
                    tekstZakladu = "0";
                }

                if (zaklad != null)
                    zaklad.Text = tekstZakladu;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            // Enter - rozpocznij grę
            else if (e.KeyCode == Keys.Enter)
            {
                PrzyciskGraj_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void OknoKoloFortuny_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (czyGraWTrakcie)
            {
                e.Handled = true;
                return;
            }

            // Akceptuj tylko cyfry
            if (char.IsDigit(e.KeyChar))
            {
                // Jeśli zakład to "0", zastąp go nową cyfrą
                if (tekstZakladu == "0")
                {
                    tekstZakladu = e.KeyChar.ToString();
                }
                else
                {
                    // Dodaj cyfrę (z limitem aby uniknąć przepełnienia)
                    string nowyTekst = tekstZakladu + e.KeyChar;
                    if (long.TryParse(nowyTekst, out long wartoscTest) && wartoscTest <= int.MaxValue)
                    {
                        tekstZakladu = nowyTekst;
                    }
                }

                if (zaklad != null)
                    zaklad.Text = tekstZakladu;

                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        int WczytajLubUtworzPlik()
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

        private void ZapiszSaldoDoPliku()
        {
            try
            {
                File.WriteAllText(sciezkaPliku, aktualneSaldo.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisywania salda: {ex.Message}",
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OknoKoloFortuny_Load(object sender, EventArgs e)
        {
            // Ustawienie wartości wygranych na etykietach
            for (int i = 0; i < wygraneLabels.Length; i++)
            {
                if (wygraneWartosci[i] == 0)
                {
                    wygraneLabels[i].Text = "BANKRUT";
                    wygraneLabels[i].ForeColor = Color.FromArgb(255, 74, 28);
                }
                else
                {
                    wygraneLabels[i].Text = "x" + wygraneWartosci[i];
                    wygraneLabels[i].ForeColor = Color.FromArgb(188, 188, 188);
                }
                wygraneLabels[i].BackColor = Color.FromArgb(27, 27, 27);
            }

            // Podświetl pierwszy element
            PodswietlElement(0);
        }

        private void PrzyciskGraj_Click(object sender, EventArgs e)
        {
            if (wygraneLabels == null || czyGraWTrakcie)
                return;

            // Walidacja zakładu
            if (zaklad != null)
            {
                if (!int.TryParse(zaklad.Text, out aktualnyZaklad))
                {
                    MessageBox.Show("Wprowadź poprawny zakład (liczba całkowita)!");
                    zaklad.Text = "0";
                    tekstZakladu = "0";
                    return;
                }

                if (aktualnyZaklad <= 0)
                {
                    MessageBox.Show("Zakład musi być większy niż 0!");
                    return;
                }

                if (aktualnyZaklad > aktualneSaldo)
                {
                    MessageBox.Show($"Nie masz wystarczająco środków!\nTwoje saldo: {aktualneSaldo}\nZakład: {aktualnyZaklad}");
                    return;
                }

                // Pobranie zakładu z salda
                aktualneSaldo -= aktualnyZaklad;
                if (saldo != null)
                    saldo.Text = aktualneSaldo.ToString();

                ZapiszSaldoDoPliku();
            }

            RozpocznijGre();
        }

        private void RozpocznijGre()
        {
            czyGraWTrakcie = true;
            przyciskGraj.Enabled = false;
            if (infoGra != null)
                infoGra.Text = "Kręcę...";

            // Losuj wynik
            docelowyIndex = rand.Next(wygraneLabels.Length);

            // Ustaw liczbę kroków (minimum 20 + rotacje do celu)
            krokiAnimacji = 20 + docelowyIndex;

            // Resetuj opóźnienie
            opoznienie = 50;
            timerAnimacji.Interval = opoznienie;

            timerAnimacji.Start();
        }

        private void TimerAnimacji_Tick(object sender, EventArgs e)
        {
            // Przejdź do następnego pola
            aktualnyIndex = (aktualnyIndex + 1) % wygraneLabels.Length;
            PodswietlElement(aktualnyIndex);

            krokiAnimacji--;

            // Zwolnij pod koniec
            if (krokiAnimacji < 10)
            {
                opoznienie += 20;
                timerAnimacji.Interval = opoznienie;
            }

            // Zatrzymaj się
            if (krokiAnimacji <= 0)
            {
                timerAnimacji.Stop();
                ZakonczGre();
            }
        }

        private void PodswietlElement(int index)
        {
            // Przywróć normalny wygląd
            for (int i = 0; i < wygraneLabels.Length; i++)
            {
                if (wygraneWartosci[i] == 0)
                {
                    wygraneLabels[i].ForeColor = Color.FromArgb(255, 74, 28);
                }
                else
                {
                    wygraneLabels[i].ForeColor = Color.FromArgb(188, 188, 188);
                }
                wygraneLabels[i].BackColor = Color.FromArgb(27, 27, 27);
                wygraneLabels[i].Font = new Font("Arial", 12F, FontStyle.Bold);
            }

            // Podświetl aktualny element
            wygraneLabels[index].BackColor = Color.FromArgb(255, 74, 28);
            wygraneLabels[index].ForeColor = Color.White;
            wygraneLabels[index].Font = new Font("Arial", 14F, FontStyle.Bold);
        }

        private void ZakonczGre()
        {
            int mnoznik = wygraneWartosci[aktualnyIndex];

            if (infoGra != null)
            {
                if (mnoznik == 0)
                {
                    // BANKRUT
                    infoGra.Text = "BANKRUT!";
                    infoGra.ForeColor = Color.FromArgb(255, 74, 28);
                }
                else
                {
                    // Wygrana
                    int wygrana = aktualnyZaklad * mnoznik;
                    aktualneSaldo += wygrana;

                    if (saldo != null)
                        saldo.Text = aktualneSaldo.ToString();

                    infoGra.Text = $"Wygrałeś {wygrana}! (x{mnoznik})";
                    infoGra.ForeColor = Color.FromArgb(74, 255, 28);
                }
            }

            ZapiszSaldoDoPliku();

            // Reset po 2 sekundach
            Timer resetTimer = new Timer();
            resetTimer.Interval = 2000;
            resetTimer.Tick += (s, args) =>
            {
                resetTimer.Stop();
                resetTimer.Dispose();
                ResetujGre();
            };
            resetTimer.Start();
        }

        private void ResetujGre()
        {
            czyGraWTrakcie = false;
            przyciskGraj.Enabled = true;

            if (infoGra != null)
            {
                infoGra.Text = "Koło Fortuny";
                infoGra.ForeColor = Color.FromArgb(188, 188, 188);
            }

            aktualnyIndex = 0;
            PodswietlElement(0);

            // Reset zakładu
            tekstZakladu = "0";
            if (zaklad != null)
                zaklad.Text = tekstZakladu;
        }

        private void infoWynik_Click(object sender, EventArgs e)
        {
            // Placeholder
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Placeholder
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Properties.Resources.background != null)
            {
                e.Graphics.DrawImage(
                    Properties.Resources.background,
                    this.ClientRectangle);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }
    }
}