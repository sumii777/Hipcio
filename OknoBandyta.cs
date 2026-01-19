using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (czyGraWTrakcie)
                return;

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
                // Wyświetla się informacja o wygranej gdy symbole są identyczne
                infoWynik.Text = "WYGRANA!";
                infoWynik.ForeColor = Color.FromArgb(34, 111, 84);

                // Efekt migania
                AnimujWygrana();
            }
            else
            {
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
    }
}