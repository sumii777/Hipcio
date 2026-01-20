using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Hipcio
{
    public partial class OknoBlackJack : Form
    {
        // Generator liczb losowych do tasowania kart
        Random rand = new Random();

        // Lista przechowująca indeksy już użytych kart w bieżącej rundzie
        private List<int> uzyteKarty = new List<int>();

        // Flaga określająca czy gra została zakończona
        private bool koniecGry = false;

        // Tablice PictureBoxów do wyświetlania kart gracza i krupiera
        private PictureBox[] obrazkiKartGracza;
        private PictureBox[] obrazkiKartKrupiera;

        // Indeksy określające aktualną liczbę kart gracza i krupiera
        private int indeksKartyGracza = 0;
        private int indeksKartyKrupiera = 0;

        // Flaga określająca czy pierwsza karta krupiera jest zakryta
        private bool pierwszaKartaKrupieraZakryta = true;

        // Listy przechowujące indeksy kart gracza i krupiera
        private List<int> kartyGracza = new List<int>();
        private List<int> kartyKrupiera = new List<int>();

        // Zmienne do zarządzania saldem i zakładami
        private int aktualneSaldo = 1000;  // Początkowe saldo gracza
        private int aktualnyZaklad = 0;    // Aktualny zakład w rundzie

        // Ścieżka do pliku z saldem
        private string sciezkaPliku = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wartosc.txt");

        // Sumy punktów gracza i krupiera
        private int sumaGracza;
        private int sumaKrupiera;

        // Flaga określająca czy trwa tura gracza (true = gracz może dobierać)
        private bool runda = true;

        // Struktura reprezentująca pojedynczą kartę
        public struct Karta
        {
            public int Wartosc;    // Wartość punktowa karty (0 = As)
            public Image Obraz;    // Obrazek karty

            public Karta(int wartosc, Image obraz)
            {
                Wartosc = wartosc;
                Obraz = obraz;
            }
        }

        // Talia kart - tablica wszystkich kart w grze
        // Ostatnia karta (indeks 52) to tył karty
        Karta[] taliaKart =
        {
            // Karty od 2 do 10 (każda po 4 kolory)
            new Karta(2, Properties.Resources._2_of_clubs),
            new Karta(2, Properties.Resources._2_of_diamonds),
            new Karta(2, Properties.Resources._2_of_hearts),
            new Karta(2, Properties.Resources._2_of_spades),

            new Karta(3, Properties.Resources._3_of_clubs),
            new Karta(3, Properties.Resources._3_of_diamonds),
            new Karta(3, Properties.Resources._3_of_hearts),
            new Karta(3, Properties.Resources._3_of_spades),

            new Karta(4, Properties.Resources._4_of_clubs),
            new Karta(4, Properties.Resources._4_of_diamonds),
            new Karta(4, Properties.Resources._4_of_hearts),
            new Karta(4, Properties.Resources._4_of_spades),

            new Karta(5, Properties.Resources._5_of_clubs),
            new Karta(5, Properties.Resources._5_of_diamonds),
            new Karta(5, Properties.Resources._5_of_hearts),
            new Karta(5, Properties.Resources._5_of_spades),

            new Karta(6, Properties.Resources._6_of_clubs),
            new Karta(6, Properties.Resources._6_of_diamonds),
            new Karta(6, Properties.Resources._6_of_hearts),
            new Karta(6, Properties.Resources._6_of_spades),

            new Karta(7, Properties.Resources._7_of_clubs),
            new Karta(7, Properties.Resources._7_of_diamonds),
            new Karta(7, Properties.Resources._7_of_hearts),
            new Karta(7, Properties.Resources._7_of_spades),

            new Karta(8, Properties.Resources._8_of_clubs),
            new Karta(8, Properties.Resources._8_of_diamonds),
            new Karta(8, Properties.Resources._8_of_hearts),
            new Karta(8, Properties.Resources._8_of_spades),

            new Karta(9, Properties.Resources._9_of_clubs),
            new Karta(9, Properties.Resources._9_of_diamonds),
            new Karta(9, Properties.Resources._9_of_hearts),
            new Karta(9, Properties.Resources._9_of_spades),

            new Karta(10, Properties.Resources._10_of_clubs),
            new Karta(10, Properties.Resources._10_of_diamonds),
            new Karta(10, Properties.Resources._10_of_hearts),
            new Karta(10, Properties.Resources._10_of_spades),
            
            // Figury (wszystkie wartość 10)
            new Karta(10, Properties.Resources.jack_of_clubs2),
            new Karta(10, Properties.Resources.jack_of_diamonds2),
            new Karta(10, Properties.Resources.jack_of_hearts2),
            new Karta(10, Properties.Resources.jack_of_spades2),

            new Karta(10, Properties.Resources.queen_of_clubs2),
            new Karta(10, Properties.Resources.queen_of_diamonds2),
            new Karta(10, Properties.Resources.queen_of_hearts2),
            new Karta(10, Properties.Resources.queen_of_spades2),

            new Karta(10, Properties.Resources.king_of_clubs2),
            new Karta(10, Properties.Resources.king_of_diamonds2),
            new Karta(10, Properties.Resources.king_of_hearts2),
            new Karta(10, Properties.Resources.king_of_spades2),
            
            // Asy (wartość 0 - specjalna obsługa)
            new Karta(0, Properties.Resources.ace_of_clubs),
            new Karta(0, Properties.Resources.ace_of_diamonds),
            new Karta(0, Properties.Resources.ace_of_hearts),
            new Karta(0, Properties.Resources.ace_of_spades),
            
            // Tył karty (ostatni element tablicy)
            new Karta(0, Properties.Resources.back),
        };

        public int tokeny;

        // Konstruktor głównego okna gry
        public OknoBlackJack()
        {
            InitializeComponent();

            // Podpięcie obsługi zdarzeń
            this.Load += OknoBlackJack_Load;
            this.Resize += (s, e) =>
            {
                if (obrazkiKartGracza != null && obrazkiKartKrupiera != null)
                {
                    UlozKartyGracza();
                    UlozKartyKrupiera();
                }
            };

            // Wczytanie salda z pliku
            aktualneSaldo = WczytajLubUtworzPlik();
            saldo.Text = aktualneSaldo.ToString();
            zaklad.Text = "10";

            // Dodanie walidacji pola zakładu
            zaklad.Leave += Zaklad_Leave;
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

        // Metoda tworząca kontrolkę PictureBox dla karty
        private PictureBox UtworzKarte(Point location)
        {
            return new PictureBox
            {
                Size = new Size(70, 100),
                Location = location,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Visible = false
            };
        }

        // Inicjalizacja tablic PictureBoxów dla kart gracza i krupiera
        private void InicjalizujObrazkiKart()
        {
            obrazkiKartGracza = new PictureBox[12];
            obrazkiKartKrupiera = new PictureBox[12];

            for (int i = 0; i < 12; i++)
            {
                obrazkiKartKrupiera[i] = UtworzKarte(new Point(0, 0));
                obrazkiKartGracza[i] = UtworzKarte(new Point(0, 0));

                this.Controls.Add(obrazkiKartKrupiera[i]);
                this.Controls.Add(obrazkiKartGracza[i]);

                obrazkiKartKrupiera[i].BringToFront();
                obrazkiKartGracza[i].BringToFront();
            }
        }

        // Oblicza wartość punktową ręki (listy kart)
        private int ObliczWartoscReki(List<int> karty)
        {
            int suma = 0;
            int liczbaAsow = 0;

            foreach (int indeksKarty in karty)
            {
                int wartosc = taliaKart[indeksKarty].Wartosc;
                if (wartosc == 0)
                {
                    liczbaAsow++;
                    suma += 11;
                }
                else
                {
                    suma += wartosc;
                }
            }

            while (suma > 21 && liczbaAsow > 0)
            {
                suma -= 10;
                liczbaAsow--;
            }

            return suma;
        }

        // Obsługa przycisku rozpoczęcia nowej gry
        private void przyciskGraj_Click(object sender, EventArgs e)
        {
            NowaGra();
        }

        // Rozpoczęcie nowej rundy gry
        private void NowaGra()
        {
            // Walidacja i pobranie zakładu
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
            saldo.Text = aktualneSaldo.ToString();

            // Zapisanie zaktualizowanego salda do pliku
            ZapiszSaldoDoPliku();

            // Ukrycie elementów menu głównego
            przyciskGraj.Visible = false;
            infoSaldo.Visible = false;
            infoZaklad.Visible = false;
            saldo.Visible = false;
            zaklad.Visible = false;
            infoGra.Visible = false;

            // Pokazanie elementów interfejsu gry
            dobierz.Enabled = true;
            dobierz.Visible = true;
            hold.Enabled = true;
            hold.Visible = true;
            labelGracz.Visible = true;
            labelKrupier.Visible = true;

            // Resetowanie stanu gry
            ResetujGre();

            // Rozdanie początkowych kart
            RozdajPoczatkoweKarty();
        }

        // Resetowanie wszystkich zmiennych gry do stanu początkowego
        private void ResetujGre()
        {
            kartyGracza.Clear();
            kartyKrupiera.Clear();
            uzyteKarty.Clear();

            sumaGracza = 0;
            sumaKrupiera = 0;
            indeksKartyGracza = 0;
            indeksKartyKrupiera = 0;
            koniecGry = false;
            runda = true;
            pierwszaKartaKrupieraZakryta = true;

            for (int i = 0; i < 12; i++)
            {
                if (obrazkiKartGracza != null && obrazkiKartGracza[i] != null)
                    obrazkiKartGracza[i].Visible = false;

                if (obrazkiKartKrupiera != null && obrazkiKartKrupiera[i] != null)
                    obrazkiKartKrupiera[i].Visible = false;
            }

            labelGracz.Text = "0";
            labelKrupier.Text = "0";
        }

        // Rozdanie początkowych 2 kart graczowi i 2 kart krupierowi
        private void RozdajPoczatkoweKarty()
        {
            for (int i = 0; i < 2; i++)
            {
                int los = LosujKarte();
                kartyGracza.Add(los);
                DodajKarteGraczowi(los);
            }

            sumaGracza = ObliczWartoscReki(kartyGracza);
            labelGracz.Text = sumaGracza.ToString();

            for (int i = 0; i < 2; i++)
            {
                int los = LosujKarte();
                kartyKrupiera.Add(los);
                DodajKarteKrupierowi(los);
            }

            sumaKrupiera = ObliczWartoscReki(kartyKrupiera);
            labelKrupier.Text = (taliaKart[kartyKrupiera[1]].Wartosc == 0 ? 11 :
                           taliaKart[kartyKrupiera[1]].Wartosc).ToString();

            SprawdzBlackJack();
        }

        // Losowanie karty z talii (unikając powtórzeń w rundzie)
        private int LosujKarte()
        {
            int maxKart = taliaKart.Length - 1;

            if (uzyteKarty.Count >= maxKart)
            {
                throw new InvalidOperationException("Brak kart w talii!");
            }

            int los;
            do
            {
                los = rand.Next(maxKart);
            }
            while (uzyteKarty.Contains(los));

            uzyteKarty.Add(los);
            return los;
        }

        // Dodanie karty do ręki gracza i aktualizacja interfejsu
        private void DodajKarteGraczowi(int indeksKarty)
        {
            Karta karta = taliaKart[indeksKarty];

            if (indeksKartyGracza < obrazkiKartGracza.Length)
            {
                obrazkiKartGracza[indeksKartyGracza].Image = karta.Obraz;
                obrazkiKartGracza[indeksKartyGracza].Visible = true;
                UlozKartyGracza();
                indeksKartyGracza++;
            }

            sumaGracza = ObliczWartoscReki(kartyGracza);
            labelGracz.Text = sumaGracza.ToString();
        }

        // Dodanie karty do ręki krupiera i aktualizacja interfejsu
        private void DodajKarteKrupierowi(int indeksKarty)
        {
            Karta karta = taliaKart[indeksKarty];

            if (indeksKartyKrupiera < obrazkiKartKrupiera.Length)
            {
                if (indeksKartyKrupiera == 0 && pierwszaKartaKrupieraZakryta)
                {
                    obrazkiKartKrupiera[indeksKartyKrupiera].Image = taliaKart[taliaKart.Length - 1].Obraz;
                }
                else
                {
                    obrazkiKartKrupiera[indeksKartyKrupiera].Image = karta.Obraz;
                }

                obrazkiKartKrupiera[indeksKartyKrupiera].Visible = true;
                UlozKartyKrupiera();
                indeksKartyKrupiera++;
            }
        }

        // Układanie kart krupiera w poziomie
        private void UlozKartyKrupiera()
        {
            int cardWidth = 70;
            int spacing = 10;
            int margin = 40;

            int count = 0;
            for (int i = 0; i < obrazkiKartKrupiera.Length; i++)
            {
                if (obrazkiKartKrupiera[i] != null && obrazkiKartKrupiera[i].Visible)
                    count++;
                else
                    break;
            }

            if (count == 0) return;

            int zoneWidth = (ClientSize.Width / 2) - margin;
            int totalWidth = count * cardWidth + (count - 1) * spacing;
            int startX = margin + (zoneWidth - totalWidth) / 2;
            int y = 30;

            for (int i = 0; i < count; i++)
            {
                obrazkiKartKrupiera[i].Location = new Point(startX + i * (cardWidth + spacing), y);
                obrazkiKartKrupiera[i].BringToFront();
            }
        }

        // Układanie kart gracza w poziomie
        private void UlozKartyGracza()
        {
            int cardWidth = 70;
            int spacing = 10;
            int margin = 40;

            int count = 0;
            for (int i = 0; i < obrazkiKartGracza.Length; i++)
            {
                if (obrazkiKartGracza[i] != null && obrazkiKartGracza[i].Visible)
                    count++;
                else
                    break;
            }

            if (count == 0) return;

            int zoneStartX = ClientSize.Width / 2;
            int zoneWidth = (ClientSize.Width / 2) - margin;
            int totalWidth = count * cardWidth + (count - 1) * spacing;
            int startX = zoneStartX + (zoneWidth - totalWidth) / 2;
            int y = 30;

            for (int i = 0; i < count; i++)
            {
                obrazkiKartGracza[i].Location = new Point(startX + i * (cardWidth + spacing), y);
                obrazkiKartGracza[i].BringToFront();
            }
        }

        // Odkrycie zakrytej karty krupiera
        private void PokazUkrytaKarteKrupiera()
        {
            if (pierwszaKartaKrupieraZakryta && indeksKartyKrupiera > 0)
            {
                if (kartyKrupiera.Count == 0 || obrazkiKartKrupiera[0] == null)
                    return;

                obrazkiKartKrupiera[0].Image = taliaKart[kartyKrupiera[0]].Obraz;
                pierwszaKartaKrupieraZakryta = false;

                sumaKrupiera = ObliczWartoscReki(kartyKrupiera);
                labelKrupier.Text = sumaKrupiera.ToString();
            }
        }

        // Automatyczna gra krupiera (dobieranie kart według zasad)
        private void DobierzKartyKrupiera()
        {
            runda = false;
            PokazUkrytaKarteKrupiera();

            while (sumaKrupiera < 17 && !koniecGry)
            {
                int los = LosujKarte();
                kartyKrupiera.Add(los);
                DodajKarteKrupierowi(los);

                sumaKrupiera = ObliczWartoscReki(kartyKrupiera);
                labelKrupier.Text = sumaKrupiera.ToString();

                if (sumaKrupiera > 21)
                {
                    KoniecGry("Krupier bust! Wygrałeś!", true);
                    return;
                }
            }

            if (!koniecGry)
            {
                PorownajWyniki();
            }
        }

        // Porównanie wyników gracza i krupiera po zakończeniu rundy
        private void PorownajWyniki()
        {
            if (sumaGracza > sumaKrupiera)
                KoniecGry($"Wygrałeś! {sumaGracza} vs {sumaKrupiera}", true);
            else if (sumaGracza < sumaKrupiera)
                KoniecGry($"Przegrałeś! {sumaGracza} vs {sumaKrupiera}", false);
            else
                KoniecGry($"Remis! {sumaGracza} vs {sumaKrupiera}", false, true);
        }

        // Sprawdzenie czy gracz ma blackjacka (As + 10 punktowa karta)
        private void SprawdzBlackJack()
        {
            if (sumaGracza == 21 && kartyGracza.Count == 2)
            {
                PokazUkrytaKarteKrupiera();

                if (sumaKrupiera == 21 && kartyKrupiera.Count == 2)
                {
                    aktualneSaldo += aktualnyZaklad;
                    KoniecGry("Remis – oboje mają Blackjacka!", false, true, true);
                }
                else
                {
                    aktualneSaldo += (int)(aktualnyZaklad * 2.5);
                    KoniecGry("Blackjack! Wygrana 3:2", true, false, true);
                }
            }
        }

        // Zakończenie rundy gry z odpowiednim komunikatem i wypłatą
        private void KoniecGry(
            string wiadomosc,
            bool wygrana,
            bool remis = false,
            bool payoutHandled = false)
        {
            if (koniecGry) return;

            koniecGry = true;
            dobierz.Enabled = false;
            hold.Enabled = false;

            if (!payoutHandled)
            {
                if (wygrana)
                    aktualneSaldo += aktualnyZaklad * 2;
                else if (remis)
                    aktualneSaldo += aktualnyZaklad;
            }

            // Zapisanie zaktualizowanego salda do pliku
            saldo.Text = aktualneSaldo.ToString();
            ZapiszSaldoDoPliku();

            if (pierwszaKartaKrupieraZakryta)
                PokazUkrytaKarteKrupiera();

            przyciskGraj.Visible = true;
            infoSaldo.Visible = true;
            infoZaklad.Visible = true;
            saldo.Visible = true;
            zaklad.Visible = true;

            dobierz.Visible = false;
            hold.Visible = false;

            MessageBox.Show(wiadomosc, "Koniec gry",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Obsługa przycisku dobierania karty przez gracza
        private void dobierz_Click(object sender, EventArgs e)
        {
            if (koniecGry || !runda) return;

            int los = LosujKarte();
            kartyGracza.Add(los);
            DodajKarteGraczowi(los);

            if (sumaGracza > 21)
            {
                KoniecGry("Bust! Przegrałeś!", false);
                return;
            }
        }

        // Obsługa przycisku zakończenia tury przez gracza
        private void hold_Click(object sender, EventArgs e)
        {
            try
            {
                if (koniecGry || !runda) return;

                runda = false;
                DobierzKartyKrupiera();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd aplikacji",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Inicjalizacja po załadowaniu formularza
        private void OknoBlackJack_Load(object sender, EventArgs e)
        {
            InicjalizujObrazkiKart();

            przyciskGraj.Visible = true;
            dobierz.Visible = false;
            hold.Visible = false;
            labelGracz.Visible = false;
            labelKrupier.Visible = false;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
        // Ustawienie tła formularza na obraz bez migania
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImage(
                Properties.Resources.jackblackbg,
                this.ClientRectangle);
        }
    }
}