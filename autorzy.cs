using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hipcio
{
    public partial class autorzy : Form
    {
        private Timer scrollTimer;
        private float yPosition;
        private string[] credits = new string[]
        {
            "",
            "",
            "",
            "IGOR BURIAN",
            "",
            "Udział w podejmowaniu decyzji odnośnie tematyki aplikacji, jej funkcjonalności oraz wyglądu.",
            " Zaprogramowanie kodu aplikacji, oraz jej funkcjonalności wliczając w to:",
            "gry interaktywne oraz responsywne okna.",
            " Założenie githuba w celu dzielenia się wersjami aplikacji z innymi.",
            " Projektowanie układu okien i głównych funkcji w aplikacji. Opisanie kodu aplikacji.",
            "",
            "",
            "MACIEJ MRÓWCZYŃSKI",
            "",
            "Udział w podejmowaniu decyzji odnośnie tematyki aplikacji,",
            "jej funkcjonalności oraz wyglądu. Zaprogramowanie kodu aplikacji,",
            "oraz jej funkcjonalności wliczając w to gry interaktywne",
            "oraz responsywne okna.",
            "",
            "",
            "OSKAR FORNALCZYK",
            "",
            "Udział w podejmowaniu decyzji odnośnie tematyki aplikacji,",
            "jej funkcjonalności oraz wyglądu.",
            " Implementacja grafik do aplikacji oraz projektowanie i tworzenie połączeń oraz tła w oknie Menu.",
            "",
            "",
            "WERONIKA CHRAPEK",
            "",
            "Udział w podejmowaniu decyzji odnośnie tematyki aplikacji,",
            "jej funkcjonalności oraz wyglądu.",
            "Testowanie aplikacji i pomoc w sporządzeniu jej dokumentacji.",
            "Robienie grafik do aplikacji. Sporządzenie wymagań aplikacji.",
            "",
            "",
            "DAWID GÓRSKI",
            "",
             "Udział w podejmowaniu decyzji odnośnie tematyki aplikacji,",
            "jej funkcjonalności oraz wyglądu.",
            "Testowanie aplikacji i pomoc w sporządzeniu jej dokumentacji.",
            "Robienie grafik do aplikacji. Sporządzenie wymagań aplikacji.",
            "",
            "",
            "SANDRA GARCZYŃSKA",
            "",
            "Udział w podejmowaniu decyzji odnośnie tematyki aplikacji,",
            "jej funkcjonalności oraz wyglądu.",
            "Tworzenie grafik do jednorękiego bandyty oraz napisów w menu.",
            "",
            "",
            "WIKTOR KLOC",
            "",
            "Udział w podejmowaniu decyzji odnośnie tematyki aplikacji,",
            "jej funkcjonalności oraz wyglądu.",
            "",
            "",
            "MATEUSZ ANTCZAK",
            "",
            "Testowanie aplikacji, udział w podejmowaniu decyzji",
            "odnośnie tematyki aplikacji, jej funkcjonalności oraz wyglądu.",
            "",
            "",
            "MATEUSZ SMOCZYŃSKI",
            "",
            "Testowanie aplikacji, udział w podejmowaniu decyzji",
            "odnośnie tematyki aplikacji, jej funkcjonalności oraz wyglądu.",
            "",
            "",
            "WOJTEK MIKOŁAJCZAK",
            "",
            "Testowanie aplikacji, udział w podejmowaniu decyzji",
            "odnośnie tematyki aplikacji, jej funkcjonalności oraz wyglądu,",
            "oraz walidacja projektu",
            "",
            "",
            "MAKSYMILIAN FERT",
            "",
            "Testowanie aplikacji, udział w podejmowaniu decyzji",
            "odnośnie tematyki aplikacji, jej funkcjonalności oraz wyglądu.",
            "",
            "",
            "MAKSYMILIAN JÓSKOWIAK",
            "",
            "Testowanie aplikacji, udział w podejmowaniu decyzji",
            "odnośnie tematyki aplikacji, jej funkcjonalności oraz wyglądu.",
            "",
            "",
            "",
            "",
            "DZIĘKUJEMY ZA UWAGĘ!!!",
            "",
            "",
            ""
        };

        public autorzy()
        {
            InitializeComponent();

            // Ustawienia formularza
            this.Size = new Size(816, 489);
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Autorzy";

            // Pozycja startowa (na dole ekranu, napisy zaczynają się od spodu)
            yPosition = this.ClientSize.Height;

            // Timer do animacji
            scrollTimer = new Timer();
            scrollTimer.Interval = 30;
            scrollTimer.Tick += ScrollTimer_Tick;
            scrollTimer.Start();

            // Event do rysowania
            this.Paint += Autorzy_Paint;

            // Zamknięcie po kliknięciu
            this.Click += (s, e) => this.Close();
            this.KeyPress += (s, e) => this.Close();
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            yPosition -= 1.5f; // Szybsze scrollowanie

            if (yPosition < -(credits.Length * 35 + 200))
            {
                scrollTimer.Stop();
                this.Close();
            }

            this.Invalidate();
        }

        private void Autorzy_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Font nameFont = new Font("Arial", 18, FontStyle.Bold);
            Font descFont = new Font("Arial", 12, FontStyle.Regular);
            Brush brush = Brushes.White;

            float currentY = yPosition;
            int centerX = this.ClientSize.Width / 2;

            for (int i = 0; i < credits.Length; i++)
            {
                string line = credits[i];
                Font currentFont = (line == line.ToUpper() && line.Trim() != "") ? nameFont : descFont;

                SizeF textSize = g.MeasureString(line, currentFont);
                float x = centerX - (textSize.Width / 2);

                g.DrawString(line, currentFont, brush, x, currentY);
                currentY += 35;
            }

            nameFont.Dispose();
            descFont.Dispose();
        }
    }
}
