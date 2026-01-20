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
        Random rand = new Random();
        int randomNumber1;
        int randomNumber2;
        int randomNumber3;

        Image[] zdjecia = new Image[]
        {
            Hipcio.Properties.Resources.krewetka,
            Hipcio.Properties.Resources.dzwonek1,
            Hipcio.Properties.Resources.pomarancza1,
            Hipcio.Properties.Resources.wisnia1,
            Hipcio.Properties.Resources.hipopotam,
            Hipcio.Properties.Resources.sliwka1
        };

        private Timer timerAnimacji;
        private int krokiAnimacji1 = 0;
        private int krokiAnimacji2 = 0;
        private int krokiAnimacji3 = 0;
        private int aktualnyIndex1 = 0;
        private int aktualnyIndex2 = 0;
        private int aktualnyIndex3 = 0;
        private bool czyGraWTrakcie = false;
        private int tickCounter = 0;
        private int aktualneSaldo = 1000;
        private int aktualnyZaklad = 0;
        private string sciezkaPliku = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wartosc.txt");
        private string tekstZakladu = "0";

        public OknoBandyta()
        {
            InitializeComponent();

            timerAnimacji = new Timer();
            timerAnimacji.Interval = 50;
            timerAnimacji.Tick += TimerAnimacji_Tick;

            obrazWynik1.Image = Hipcio.Properties.Resources.puste;
            obrazWynik2.Image = Hipcio.Properties.Resources.puste;
            obrazWynik3.Image = Hipcio.Properties.Resources.puste;

            aktualneSaldo = WczytajLubUtworzPlik();

            if (saldo != null)
                saldo.Text = aktualneSaldo.ToString();

            if (zaklad != null)
            {
                zaklad.Text = tekstZakladu;
                zaklad.Cursor = Cursors.IBeam;
            }

            // Obsługa klawiatury na poziomie formy
            this.KeyPreview = true;
            this.KeyPress -= OknoBandyta_KeyPress;
            this.KeyPress += OknoBandyta_KeyPress;
            this.KeyDown -= OknoBandyta_KeyDown;
            this.KeyDown += OknoBandyta_KeyDown;
        }

        private void OknoBandyta_KeyDown(object sender, KeyEventArgs e)
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
                button1_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void OknoBandyta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (czyGraWTrakcie)
            {
                e.Handled = true;
                return;
            }

            // Akceptuj tylko cyfry
            if (char.IsDigit(e.KeyChar))
            {
                if (tekstZakladu == "0")
                {
                    tekstZakladu = e.KeyChar.ToString();
                }
                else
                {
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (czyGraWTrakcie)
                return;

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

                aktualneSaldo -= aktualnyZaklad;
                if (saldo != null)
                    saldo.Text = aktualneSaldo.ToString();

                ZapiszSaldoDoPliku();
            }

            RozpocznijAnimacje();
        }

        private void RozpocznijAnimacje()
        {
            czyGraWTrakcie = true;
            przyciskKrec.Enabled = false;

            if (infoWynik != null)
            {
                infoWynik.Text = "Losowanie...";
                infoWynik.ForeColor = Color.FromArgb(188, 188, 188);
            }

            randomNumber1 = rand.Next(0, zdjecia.Length);
            randomNumber2 = rand.Next(0, zdjecia.Length);
            randomNumber3 = rand.Next(0, zdjecia.Length);

            krokiAnimacji1 = 15;
            krokiAnimacji2 = 25;
            krokiAnimacji3 = 35;

            tickCounter = 0;
            timerAnimacji.Start();
        }

        private void TimerAnimacji_Tick(object sender, EventArgs e)
        {
            tickCounter++;

            if (krokiAnimacji1 > 0)
            {
                aktualnyIndex1 = rand.Next(0, zdjecia.Length);
                obrazWynik1.Image = zdjecia[aktualnyIndex1];
                krokiAnimacji1--;

                if (krokiAnimacji1 == 0)
                {
                    obrazWynik1.Image = zdjecia[randomNumber1];
                }
            }

            if (krokiAnimacji2 > 0)
            {
                aktualnyIndex2 = rand.Next(0, zdjecia.Length);
                obrazWynik2.Image = zdjecia[aktualnyIndex2];
                krokiAnimacji2--;

                if (krokiAnimacji2 == 0)
                {
                    obrazWynik2.Image = zdjecia[randomNumber2];
                }
            }

            if (krokiAnimacji3 > 0)
            {
                aktualnyIndex3 = rand.Next(0, zdjecia.Length);
                obrazWynik3.Image = zdjecia[aktualnyIndex3];
                krokiAnimacji3--;

                if (krokiAnimacji3 == 0)
                {
                    obrazWynik3.Image = zdjecia[randomNumber3];
                }
            }

            if (krokiAnimacji1 == 0 && krokiAnimacji2 == 0 && krokiAnimacji3 == 0)
            {
                timerAnimacji.Stop();

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
            if (randomNumber1 == randomNumber2 && randomNumber1 == randomNumber3)
            {
                int wygrana = aktualnyZaklad * 5;
                aktualneSaldo += wygrana;

                if (saldo != null)
                    saldo.Text = aktualneSaldo.ToString();

                ZapiszSaldoDoPliku();

                if (infoWynik != null)
                {
                    infoWynik.Text = $"WYGRANA! +{wygrana}";
                    infoWynik.ForeColor = Color.FromArgb(34, 111, 84);
                }

                AnimujWygrana();
            }
            else
            {
                ZapiszSaldoDoPliku();

                if (infoWynik != null)
                {
                    infoWynik.Text = "Przegrana";
                    infoWynik.ForeColor = Color.FromArgb(218, 44, 56);
                }

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

                if (infoWynik != null)
                {
                    if (miganiaLicznik % 2 == 0)
                    {
                        infoWynik.ForeColor = Color.FromArgb(74, 255, 28);
                    }
                    else
                    {
                        infoWynik.ForeColor = Color.FromArgb(34, 111, 84);
                    }
                }

                if (miganiaLicznik >= 6)
                {
                    migTimer.Stop();
                    migTimer.Dispose();

                    if (infoWynik != null)
                        infoWynik.ForeColor = Color.FromArgb(74, 255, 28);

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

            if (infoWynik != null)
            {
                infoWynik.Text = "Zagraj!";
                infoWynik.ForeColor = Color.FromArgb(188, 188, 188);
            }

            // Reset zakładu do domyślnej wartości
            tekstZakladu = "10";
            if (zaklad != null)
                zaklad.Text = tekstZakladu;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Properties.Resources.background != null)
            {
                e.Graphics.DrawImage(Properties.Resources.background, this.ClientRectangle);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }
    }
}