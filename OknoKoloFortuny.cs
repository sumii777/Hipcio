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
        private int aktualneSaldo = 1000;  // Początkowe saldo gracza
        private int aktualnyZaklad = 0;    // Aktualny zakład w rundzie

        // Ścieżka do pliku z saldem
        private string sciezkaPliku = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wartosc.txt");

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

            // Zakładam, że masz kontrolki saldo i zaklad (TextBox lub Label)
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

        private void OknoKoloFortuny_Load(object sender, EventArgs e)
        {
            // Ustawienie wartości wygranych na etykietach
            for (int i = 0; i < wygraneLabels.Length; i++)
            {
                if (wygraneWartosci[i] == 0)
                {
                    wygraneLabels[i].Text = "BANKRUT";
                    wygraneLabels[i].ForeColor = Color.FromArgb(255, 74, 28); // Czerwony
                }
                else
                {
                    wygraneLabels[i].Text = "x" + wygraneWartosci[i];
                    wygraneLabels[i].ForeColor = Color.FromArgb(188, 188, 188); // Szary
                }
                wygraneLabels[i].BackColor = Color.FromArgb(27, 27, 27);
            }

            // Podświetl pierwszy element na start
            PodswietlElement(0);
        }

        private void PrzyciskGraj_Click(object sender, EventArgs e)
        {
            // Sprawdź czy tablica została zainicjalizowana i czy gra nie jest w trakcie
            if (wygraneLabels == null || czyGraWTrakcie)
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

            // Rozpocznij grę
            RozpocznijGre();
        }

        private void RozpocznijGre()
        {
            czyGraWTrakcie = true;
            przyciskGraj.Enabled = false;
            infoGra.Text = "Kręcę...";

            // Losuj wynik (od 0 do 7)
            docelowyIndex = rand.Next(wygraneLabels.Length);

            // Ustaw liczbę kroków animacji (minimum 20 + dodatkowe do osiągnięcia celu)
            krokiAnimacji = 20 + docelowyIndex;

            // Resetuj opóźnienie
            opoznienie = 50;
            timerAnimacji.Interval = opoznienie;

            // Wystartuj timer
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
            // Przywróć normalny wygląd wszystkim etykietom
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
            wygraneLabels[index].BackColor = Color.FromArgb(255, 74, 28); // Pomarańczowy
            wygraneLabels[index].ForeColor = Color.White;
            wygraneLabels[index].Font = new Font("Arial", 14F, FontStyle.Bold);
        }

        private void ZakonczGre()
        {
            int mnoznik = wygraneWartosci[aktualnyIndex];

            if (mnoznik == 0)
            {
                // BANKRUT - gracz traci zakład (który już został pobrany)
                infoGra.Text = "BANKRUT!";
                infoGra.ForeColor = Color.FromArgb(255, 74, 28);
            }
            else
            {
                // Wygrana - zakład pomnożony przez mnożnik
                int wygrana = aktualnyZaklad * mnoznik;
                aktualneSaldo += wygrana;

                if (saldo != null)
                    saldo.Text = aktualneSaldo.ToString();

                infoGra.Text = $"Wygrałeś {wygrana}! (x{mnoznik})";
                infoGra.ForeColor = Color.FromArgb(74, 255, 28); // Zielony
            }

            // Zapisanie zaktualizowanego salda do pliku
            ZapiszSaldoDoPliku();

            // Odczekaj 2 sekundy i przywróć normalny stan
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
            infoGra.Text = "Koło Fortuny";
            infoGra.ForeColor = Color.FromArgb(188, 188, 188);
            aktualnyIndex = 0;
            PodswietlElement(0);
        }

        private void infoWynik_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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