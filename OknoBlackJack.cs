using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

            // Inicjalizacja salda i ustawienie domyślnego zakładu
            saldo.Text = aktualneSaldo.ToString();
            zaklad.Text = "10";
        }

        // Metoda tworząca kontrolkę PictureBox dla karty
        private PictureBox UtworzKarte(Point location)
        {
            return new PictureBox
            {
                Size = new Size(70, 100),      // Standardowy rozmiar karty
                Location = location,           // Pozycja początkowa
                SizeMode = PictureBoxSizeMode.Zoom,  // Dopasowanie obrazka
                BackColor = Color.Transparent, // Przezroczyste tło
                Visible = false                // Początkowo ukryta
            };
        }

        // Inicjalizacja tablic PictureBoxów dla kart gracza i krupiera
        private void InicjalizujObrazkiKart()
        {
            obrazkiKartGracza = new PictureBox[12];    // Maksymalnie 12 kart (teoretycznie)
            obrazkiKartKrupiera = new PictureBox[12];

            for (int i = 0; i < 12; i++)
            {
                // Tworzenie kontrolek dla krupiera
                obrazkiKartKrupiera[i] = UtworzKarte(new Point(0, 0));

                // Tworzenie kontrolek dla gracza
                obrazkiKartGracza[i] = UtworzKarte(new Point(0, 0));

                // Dodanie kontrolek do formularza
                this.Controls.Add(obrazkiKartKrupiera[i]);
                this.Controls.Add(obrazkiKartGracza[i]);

                // Ustawienie na wierzchu innych kontrolek
                obrazkiKartKrupiera[i].BringToFront();
                obrazkiKartGracza[i].BringToFront();
            }
        }

        // Oblicza wartość punktową ręki (listy kart)
        private int ObliczWartoscReki(List<int> karty)
        {
            int suma = 0;
            int liczbaAsow = 0;

            // Pierwsze przejście - sumowanie wartości
            foreach (int indeksKarty in karty)
            {
                int wartosc = taliaKart[indeksKarty].Wartosc;
                if (wartosc == 0) // As - traktowany początkowo jako 11
                {
                    liczbaAsow++;
                    suma += 11;
                }
                else
                {
                    suma += wartosc;
                }
            }

            // Korekta wartości Asów jeśli suma > 21
            while (suma > 21 && liczbaAsow > 0)
            {
                suma -= 10;  // Zmiana wartości Asa z 11 na 1
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
            if (!int.TryParse(zaklad.Text, out aktualnyZaklad) || aktualnyZaklad <= 0)
            {
                MessageBox.Show("Wprowadź poprawny zakład!");
                return;
            }

            if (aktualnyZaklad > aktualneSaldo)
            {
                MessageBox.Show("Nie masz wystarczająco środków!");
                return;
            }

            // Pobranie zakładu z salda
            aktualneSaldo -= aktualnyZaklad;
            saldo.Text = aktualneSaldo.ToString();

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
            // Czyszczenie list kart
            kartyGracza.Clear();
            kartyKrupiera.Clear();
            uzyteKarty.Clear();

            // Resetowanie zmiennych stanu
            sumaGracza = 0;
            sumaKrupiera = 0;
            indeksKartyGracza = 0;
            indeksKartyKrupiera = 0;
            koniecGry = false;
            runda = true;
            pierwszaKartaKrupieraZakryta = true;

            // Ukrycie wszystkich obrazków kart
            for (int i = 0; i < 12; i++)
            {
                if (obrazkiKartGracza != null && obrazkiKartGracza[i] != null)
                    obrazkiKartGracza[i].Visible = false;

                if (obrazkiKartKrupiera != null && obrazkiKartKrupiera[i] != null)
                    obrazkiKartKrupiera[i].Visible = false;
            }

            // Resetowanie etykiet z wynikami
            labelGracz.Text = "0";
            labelKrupier.Text = "0";
        }

        // Rozdanie początkowych 2 kart graczowi i 2 kart krupierowi
        private void RozdajPoczatkoweKarty()
        {
            // Rozdanie 2 kart graczowi
            for (int i = 0; i < 2; i++)
            {
                int los = LosujKarte();
                kartyGracza.Add(los);
                DodajKarteGraczowi(los);
            }

            // Obliczenie i wyświetlenie sumy gracza
            sumaGracza = ObliczWartoscReki(kartyGracza);
            labelGracz.Text = sumaGracza.ToString();

            // Rozdanie 2 kart krupierowi
            for (int i = 0; i < 2; i++)
            {
                int los = LosujKarte();
                kartyKrupiera.Add(los);
                DodajKarteKrupierowi(los);
            }

            // Obliczenie sumy krupiera (tylko widoczna karta)
            sumaKrupiera = ObliczWartoscReki(kartyKrupiera);
            // Wyświetlenie tylko wartości drugiej (widocznej) karty krupiera
            labelKrupier.Text = (taliaKart[kartyKrupiera[1]].Wartosc == 0 ? 11 :
                           taliaKart[kartyKrupiera[1]].Wartosc).ToString();

            // Sprawdzenie czy gracz ma natychmiastowego blackjacka
            SprawdzBlackJack();
        }

        // Losowanie karty z talii (unikając powtórzeń w rundzie)
        private int LosujKarte()
        {
            // 52 karty + back, więc -1
            int maxKart = taliaKart.Length - 1;

            // ZABEZPIECZENIE – nie ma już kart
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

            // Wyświetlenie karty w interfejsie
            if (indeksKartyGracza < obrazkiKartGracza.Length)
            {
                obrazkiKartGracza[indeksKartyGracza].Image = karta.Obraz;
                obrazkiKartGracza[indeksKartyGracza].Visible = true;
                UlozKartyGracza();  // Przegrupowanie kart
                indeksKartyGracza++;
            }

            // Przeliczenie i wyświetlenie nowej sumy
            sumaGracza = ObliczWartoscReki(kartyGracza);
            labelGracz.Text = sumaGracza.ToString();
        }

        // Dodanie karty do ręki krupiera i aktualizacja interfejsu
        private void DodajKarteKrupierowi(int indeksKarty)
        {
            Karta karta = taliaKart[indeksKarty];

            // Wyświetlenie karty w interfejsie
            if (indeksKartyKrupiera < obrazkiKartKrupiera.Length)
            {
                if (indeksKartyKrupiera == 0 && pierwszaKartaKrupieraZakryta)
                {
                    // Pierwsza karta krupiera - pokazanie tyłu karty
                    obrazkiKartKrupiera[indeksKartyKrupiera].Image = taliaKart[taliaKart.Length - 1].Obraz;
                }
                else
                {
                    // Pozostałe karty - pokazanie awersu
                    obrazkiKartKrupiera[indeksKartyKrupiera].Image = karta.Obraz;
                }

                obrazkiKartKrupiera[indeksKartyKrupiera].Visible = true;
                UlozKartyKrupiera();  // Przegrupowanie kart
                indeksKartyKrupiera++;
            }
        }

        // Układanie kart krupiera w poziomie
        private void UlozKartyKrupiera()
        {
            int cardWidth = 70;      // Szerokość karty (jak w UtworzKarte)
            int spacing = 10;        // Odstęp między kartami
            int margin = 40;         // Margines od krawędzi

            // Policz WIDOCZNE karty
            int count = 0;
            for (int i = 0; i < obrazkiKartKrupiera.Length; i++)
            {
                if (obrazkiKartKrupiera[i] != null && obrazkiKartKrupiera[i].Visible)
                    count++;
                else
                    break;
            }

            if (count == 0) return;

            // Obliczanie pozycji startowej dla wyśrodkowania
            int zoneWidth = (ClientSize.Width / 2) - margin;
            int totalWidth = count * cardWidth + (count - 1) * spacing;
            int startX = margin + (zoneWidth - totalWidth) / 2;
            int y = 30;  // Stała pozycja Y dla krupiera

            // Ustawianie pozycji każdej karty
            for (int i = 0; i < count; i++)
            {
                obrazkiKartKrupiera[i].Location = new Point(startX + i * (cardWidth + spacing), y);
                obrazkiKartKrupiera[i].BringToFront();
            }
        }

        // Układanie kart gracza w poziomie
        private void UlozKartyGracza()
        {
            int cardWidth = 70;      // Szerokość karty (jak w UtworzKarte)
            int spacing = 10;        // Odstęp między kartami
            int margin = 40;         // Margines od krawędzi

            // Policz WIDOCZNE karty
            int count = 0;
            for (int i = 0; i < obrazkiKartGracza.Length; i++)
            {
                if (obrazkiKartGracza[i] != null && obrazkiKartGracza[i].Visible)
                    count++;
                else
                    break;
            }

            if (count == 0) return;

            // Obliczanie pozycji startowej (prawa połowa ekranu)
            int zoneStartX = ClientSize.Width / 2;
            int zoneWidth = (ClientSize.Width / 2) - margin;
            int totalWidth = count * cardWidth + (count - 1) * spacing;
            int startX = zoneStartX + (zoneWidth - totalWidth) / 2;
            int y = 30;  // Pozycja Y dla gracza

            // Ustawianie pozycji każdej karty
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
                // Zamiana obrazka z tyłu karty na właściwą kartę
                if (kartyKrupiera.Count == 0 || obrazkiKartKrupiera[0] == null)
                    return;

                obrazkiKartKrupiera[0].Image = taliaKart[kartyKrupiera[0]].Obraz;
                pierwszaKartaKrupieraZakryta = false;

                // Przeliczenie i wyświetlenie pełnej sumy krupiera
                sumaKrupiera = ObliczWartoscReki(kartyKrupiera);
                labelKrupier.Text = sumaKrupiera.ToString();
            }
        }

        // Automatyczna gra krupiera (dobieranie kart według zasad)
        private void DobierzKartyKrupiera()
        {
            runda = false;  // Zakończenie tury gracza
            PokazUkrytaKarteKrupiera();  // Odkrycie pierwszej karty

            // Krupier dobiera karty aż osiągnie co najmniej 17 punktów
            while (sumaKrupiera < 17 && !koniecGry)
            {
                int los = LosujKarte();
                kartyKrupiera.Add(los);
                DodajKarteKrupierowi(los);

                sumaKrupiera = ObliczWartoscReki(kartyKrupiera);
                labelKrupier.Text = sumaKrupiera.ToString();

                // Sprawdzenie czy krupier przekroczył 21 punktów
                if (sumaKrupiera > 21)
                {
                    KoniecGry("Krupier bust! Wygrałeś!", true);
                    return;
                }
            }

            // Porównanie wyników jeśli gra się nie zakończyła
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
                    // Remis – zwrot zakładu
                    aktualneSaldo += aktualnyZaklad;  // Zwrot zakładu
                    KoniecGry("Remis – oboje mają Blackjacka!", false, true, true);
                }
                else
                {
                    // Blackjack = 3:2 (gracz już zapłacił zakład na starcie)
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
            // Zapobiegaj wielokrotnemu wywołaniu
            if (koniecGry) return;

            koniecGry = true;
            dobierz.Enabled = false;
            hold.Enabled = false;

            // Wypłata tylko jeśli nie została już obsłużona
            if (!payoutHandled)
            {
                if (wygrana)
                    aktualneSaldo += aktualnyZaklad * 2;
                else if (remis)
                    aktualneSaldo += aktualnyZaklad;
            }


            // Tylko jeśli jeszcze nie pokazano
            if (pierwszaKartaKrupieraZakryta)
                PokazUkrytaKarteKrupiera();

            // Przywrócenie menu
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
            if (koniecGry || !runda) return;  // Sprawdzenie czy można grać

            // Dodanie karty
            int los = LosujKarte();
            kartyGracza.Add(los);
            DodajKarteGraczowi(los);

            // Sprawdzenie BUST po dodaniu karty
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
            InicjalizujObrazkiKart();  // Przygotowanie kontrolek kart

            // Ustawienia początkowej widoczności elementów
            przyciskGraj.Visible = true;
            dobierz.Visible = false;
            hold.Visible = false;
            labelGracz.Visible = false;
            labelKrupier.Visible = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OknoBlackJack_Load(object sender, EventArgs e)
        {

        }
    }
}