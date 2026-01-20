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
    public partial class OknoBandyta : Form
    {
        // Tworzenie obiektu losowego
        Random rand = new Random();

        // Deklaracja zmiennych do przechowywania liczb losowych
        int randomNumber1;
        int randomNumber2;
        int randomNumber3;

        // Tablica przechowywująca zdjęcia, które mogą zostać wylosowane
        Image[] zdjecia = new Image[]
        {
            Hipcio.Properties.Resources.krewetka,
            Hipcio.Properties.Resources.dzwonek1,
            Hipcio.Properties.Resources.pomarancza1,
            Hipcio.Properties.Resources.wisnia1,
            Hipcio.Properties.Resources.hipopotam,
            Hipcio.Properties.Resources.sliwka1
        };

        // Timer do animacji
        private Timer timerAnimacji;

        // Licznik kroków animacji dla każdego bębna
        private int krokiAnimacji1 = 0;
        private int krokiAnimacji2 = 0;
        private int krokiAnimacji3 = 0;

        // Aktualny indeks dla każdego bębna podczas animacji
        private int aktualnyIndex1 = 0;
        private int aktualnyIndex2 = 0;
        private int aktualnyIndex3 = 0;

        // Czy gra jest w trakcie
        private bool czyGraWTrakcie = false;

        // Licznik ticków timera
        private int tickCounter = 0;

        // Zmienne do zarządzania saldem i zakładami
        private int aktualneSaldo = 1000;  // Początkowe saldo gracza
        private int aktualnyZaklad = 0;    // Aktualny zakład w rundzie

        // Ścieżka do pliku z saldem
        private string sciezkaPliku = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wartosc.txt");

        public OknoBandyta()
        {
            InitializeComponent();

            // Inicjalizacja timera animacji
            timerAnimacji = new Timer();
            timerAnimacji.Interval = 50; // 50ms między klatkami
            timerAnimacji.Tick += TimerAnimacji_Tick;

            // Ustaw początkowe obrazy
            obrazWynik1.Image = Hipcio.Properties.Resources.puste;
            obrazWynik2.Image = Hipcio.Properties.Resources.puste;
            obrazWynik3.Image = Hipcio.Properties.Resources.puste;

            // Wczytanie salda z pliku
            aktualneSaldo = WczytajLubUtworzPlik();

            // Zakładam, że masz kontrolki saldo i zaklad (TextBox lub Label)
            // Jeśli nie masz, dodaj je w designerze
            if (saldo != null)
                saldo.Text = aktualneSaldo.ToString();

            if (zaklad != null)
            {
                zaklad.Text = "10";
                // Dodanie walidacji pola zakładu
                zaklad.Leave += Zaklad_Leave;
            }
        }

        // Walidacja pola zakładu - jeśli nie liczba, ustaw 0
        private void Zaklad_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(zaklad.Text, out int wartoscZakladu))
            {
                zaklad.Text = "0";
                MessageBox.Show("Nieprawidłowa wartość zakładu. Ustawiono 0.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (wartoscZakladu < 0)
            {
                zaklad.Text = "0";
                MessageBox.Show("Zakład nie może być ujemny. Ustawiono 0.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Wczytywanie salda z pliku lub tworzenie pliku z domyślną wartością
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

                // Jeśli plik uszkodzony lub wartość ujemna
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

        // Zapisywanie aktualnego salda do pliku
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (czyGraWTrakcie)
                return;

            // Walidacja i pobranie zakładu
            if (zaklad != null)
            {
                if (!int.TryParse(zaklad.Text, out aktualnyZaklad))
                {
                    MessageBox.Show("Wprowadź poprawny zakład (liczba całkowita)!");
                    zaklad.Text = "0";
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

                // Zapisanie zaktualizowanego salda do pliku
                ZapiszSaldoDoPliku();
            }

            // Rozpocznij animację
            RozpocznijAnimacje();
        }

        private void RozpocznijAnimacje()
        {
            czyGraWTrakcie = true;
            przyciskKrec.Enabled = false;
            infoWynik.Text = "Losowanie...";
            infoWynik.ForeColor = Color.FromArgb(188, 188, 188);

            // Wylosuj końcowe wartości
            randomNumber1 = rand.Next(0, zdjecia.Length);
            randomNumber2 = rand.Next(0, zdjecia.Length);
            randomNumber3 = rand.Next(0, zdjecia.Length);

            // Ustaw różne czasy zatrzymania dla każdego bębna
            krokiAnimacji1 = 15; // Pierwszy zatrzyma się po 15 krokach
            krokiAnimacji2 = 25; // Drugi po 25 krokach
            krokiAnimacji3 = 35; // Trzeci po 35 krokach

            // Resetuj licznik ticków
            tickCounter = 0;

            // Rozpocznij animację
            timerAnimacji.Start();
        }

        private void TimerAnimacji_Tick(object sender, EventArgs e)
        {
            tickCounter++;

            // Animuj pierwszy bęben
            if (krokiAnimacji1 > 0)
            {
                aktualnyIndex1 = rand.Next(0, zdjecia.Length);
                obrazWynik1.Image = zdjecia[aktualnyIndex1];
                krokiAnimacji1--;

                // Zatrzymaj na właściwym obrazie
                if (krokiAnimacji1 == 0)
                {
                    obrazWynik1.Image = zdjecia[randomNumber1];
                }
            }

            // Animuj drugi bęben
            if (krokiAnimacji2 > 0)
            {
                aktualnyIndex2 = rand.Next(0, zdjecia.Length);
                obrazWynik2.Image = zdjecia[aktualnyIndex2];
                krokiAnimacji2--;

                // Zatrzymaj na właściwym obrazie
                if (krokiAnimacji2 == 0)
                {
                    obrazWynik2.Image = zdjecia[randomNumber2];
                }
            }

            // Animuj trzeci bęben
            if (krokiAnimacji3 > 0)
            {
                aktualnyIndex3 = rand.Next(0, zdjecia.Length);
                obrazWynik3.Image = zdjecia[aktualnyIndex3];
                krokiAnimacji3--;

                // Zatrzymaj na właściwym obrazie
                if (krokiAnimacji3 == 0)
                {
                    obrazWynik3.Image = zdjecia[randomNumber3];
                }
            }

            // Sprawdź czy wszystkie bębny się zatrzymały
            if (krokiAnimacji1 == 0 && krokiAnimacji2 == 0 && krokiAnimacji3 == 0)
            {
                timerAnimacji.Stop();

                // Odczekaj chwilę przed wyświetleniem wyniku
                Timer wynikTimer = new Timer();
                wynikTimer.Interval = 300;
                wynikTimer.Tick += (s, args) =>
                {
                    wynikTimer.Stop();
                    wynikTimer.Dispose();
                    PokazWynik();
                };
                wynikTimer.Start();
            }
        }

        private void PokazWynik()
        {
            // Sprawdzanie czy wszystkie wylosowane symbole są takie same
            if (randomNumber1 == randomNumber2 && randomNumber1 == randomNumber3)
            {
                // Wygrana - zwrot zakładu x3 (lub inna mnożnik, np. x5, x10)
                int wygrana = aktualnyZaklad * 5; // Mnożnik wygranej x5
                aktualneSaldo += wygrana;

                if (saldo != null)
                    saldo.Text = aktualneSaldo.ToString();

                // Zapisanie zaktualizowanego salda do pliku
                ZapiszSaldoDoPliku();

                // Wyświetla się informacja o wygranej gdy symbole są identyczne
                infoWynik.Text = $"WYGRANA! +{wygrana}";
                infoWynik.ForeColor = Color.FromArgb(34, 111, 84);

                // Efekt migania
                AnimujWygrana();
            }
            else
            {
                // Przegrana - saldo już zostało zmniejszone przed grą
                // Zapisanie zaktualizowanego salda do pliku
                ZapiszSaldoDoPliku();

                // Wyświetla się informacja o przegranej gdy symbole są inne
                infoWynik.Text = "Przegrana";
                infoWynik.ForeColor = Color.FromArgb(218, 44, 56);

                // Przywróć możliwość gry
                Timer resetTimer = new Timer();
                resetTimer.Interval = 1500;
                resetTimer.Tick += (s, args) =>
                {
                    resetTimer.Stop();
                    resetTimer.Dispose();
                    ResetujGre();
                };
                resetTimer.Start();
            }
        }

        private void AnimujWygrana()
        {
            int miganiaLicznik = 0;
            Timer migTimer = new Timer();
            migTimer.Interval = 200;
            migTimer.Tick += (s, args) =>
            {
                miganiaLicznik++;

                // Zmień kolor co klatkę
                if (miganiaLicznik % 2 == 0)
                {
                    infoWynik.ForeColor = Color.FromArgb(74, 255, 28); // Jasny zielony
                }
                else
                {
                    infoWynik.ForeColor = Color.FromArgb(34, 111, 84); // Ciemny zielony
                }

                // Zatrzymaj po 6 migach
                if (miganiaLicznik >= 6)
                {
                    migTimer.Stop();
                    migTimer.Dispose();
                    infoWynik.ForeColor = Color.FromArgb(74, 255, 28);

                    // Reset po chwili
                    Timer resetTimer = new Timer();
                    resetTimer.Interval = 1500;
                    resetTimer.Tick += (s2, args2) =>
                    {
                        resetTimer.Stop();
                        resetTimer.Dispose();
                        ResetujGre();
                    };
                    resetTimer.Start();
                }
            };
            migTimer.Start();
        }

        private void ResetujGre()
        {
            czyGraWTrakcie = false;
            przyciskKrec.Enabled = true;
            infoWynik.Text = "Zagraj!";
            infoWynik.ForeColor = Color.FromArgb(188, 188, 188);
        }

        // Ustawienie tła formularza na obraz bez migania
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImage(
                Properties.Resources.background,
                this.ClientRectangle);
        }
    }
}