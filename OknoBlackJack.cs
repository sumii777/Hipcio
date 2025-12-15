using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hipcio.Properties;
using static Hipcio.OknoBlackJack;

namespace Hipcio
{
    public partial class OknoBlackJack : Form
    {
        Random rand = new Random();
        public int WartoscAsa;
        
        public struct Karta
        {
            public int Wartosc;
            public string Sciezka;

            public Karta(int wartosc, string sciezka)
            {
                Wartosc = wartosc;
                Sciezka = sciezka;
            }
        }

        Karta[] taliaKart =
        {
            // 2
            new Karta(2, "Resources/karty/2_of_clubs.png"),
            new Karta(2, "Resources/karty/2_of_diamonds.png"),
            new Karta(2, "Resources/karty/2_of_hearts.png"),
            new Karta(2, "Resources/karty/2_of_spades.png"),
        
            // 3
            new Karta(3, "Resources/karty/3_of_clubs.png"),
            new Karta(3, "Resources/karty/3_of_diamonds.png"),
            new Karta(3, "Resources/karty/3_of_hearts.png"),
            new Karta(3, "Resources/karty/3_of_spades.png"),
        
            // 4
            new Karta(4, "Resources/karty/4_of_clubs.png"),
            new Karta(4, "Resources/karty/4_of_diamonds.png"),
            new Karta(4, "Resources/karty/4_of_hearts.png"),
            new Karta(4, "Resources/karty/4_of_spades.png"),
        
            // 5
            new Karta(5, "Resources/karty/5_of_clubs.png"),
            new Karta(5, "Resources/karty/5_of_diamonds.png"),
            new Karta(5, "Resources/karty/5_of_hearts.png"),
            new Karta(5, "Resources/karty/5_of_spades.png"),
        
            // 6
            new Karta(6, "Resources/karty/6_of_clubs.png"),
            new Karta(6, "Resources/karty/6_of_diamonds.png"),
            new Karta(6, "Resources/karty/6_of_hearts.png"),
            new Karta(6, "Resources/karty/6_of_spades.png"),
        
            // 7
            new Karta(7, "Resources/karty/7_of_clubs.png"),
            new Karta(7, "Resources/karty/7_of_diamonds.png"),
            new Karta(7, "Resources/karty/7_of_hearts.png"),
            new Karta(7, "Resources/karty/7_of_spades.png"),
        
            // 8
            new Karta(8, "Resources/karty/8_of_clubs.png"),
            new Karta(8, "Resources/karty/8_of_diamonds.png"),
            new Karta(8, "Resources/karty/8_of_hearts.png"),
            new Karta(8, "Resources/karty/8_of_spades.png"),
        
            // 9
            new Karta(9, "Resources/karty/9_of_clubs.png"),
            new Karta(9, "Resources/karty/9_of_diamonds.png"),
            new Karta(9, "Resources/karty/9_of_hearts.png"),
            new Karta(9, "Resources/karty/9_of_spades.png"),
        
            // 10
            new Karta(10, "Resources/karty/10_of_clubs.png"),
            new Karta(10, "Resources/karty/10_of_diamonds.png"),
            new Karta(10, "Resources/karty/10_of_hearts.png"),
            new Karta(10, "Resources/karty/10_of_spades.png"),
        
            // JACK
            new Karta(10, "Resources/karty/jack_of_clubs2.png"),
            new Karta(10, "Resources/karty/jack_of_diamonds2.png"),
            new Karta(10, "Resources/karty/jack_of_hearts2.png"),
            new Karta(10, "Resources/karty/jack_of_spades2.png"),
        
            // QUEEN
            new Karta(10, "Resources/karty/queen_of_clubs2.png"),
            new Karta(10, "Resources/karty/queen_of_diamonds2.png"),
            new Karta(10, "Resources/karty/queen_of_hearts2.png"),
            new Karta(10, "Resources/karty/queen_of_spades2.png"),
        
            // KING
            new Karta(10, "Resources/karty/king_of_clubs2.png"),
            new Karta(10, "Resources/karty/king_of_diamonds2.png"),
            new Karta(10, "Resources/karty/king_of_hearts2.png"),
            new Karta(10, "Resources/karty/king_of_spades2.png"),
        
            // ACE
            new Karta(0, "Resources/karty/ace_of_clubs.png"),
            new Karta(0, "Resources/karty/ace_of_diamonds.png"),
            new Karta(0, "Resources/karty/ace_of_hearts.png"),
            new Karta(0, "Resources/karty/ace_of_spades.png")
        };
        int[] posiadane;
        int sumaGracza;
        int sumaKrupiera;
        Boolean runda = true;
        public OknoBlackJack()
        {
            InitializeComponent();
        }

        private void przyciskGraj_Click(object sender, EventArgs e)
        {
            przyciskGraj.Visible = false;
            infoSaldo.Visible = false;
            infoZaklad.Visible = false;
            saldo.Visible = false;
            zaklad.Visible = false;
        }

        public void Losuj()
        {
            int los;

            if (posiadane == null)
                posiadane = new int[0];

            do
            {
                los = rand.Next(taliaKart.Length);
                label4.Text = taliaKart[los].Wartosc.ToString();
            }
            while (posiadane.Contains(los));

            // zapamiętaj kartę
            posiadane = posiadane.Concat(new int[] { los }).ToArray();

            // ===== TURA GRACZA =====
            if (runda == true)
            {
                // AS
                if (taliaKart[los].Wartosc == 0)
                    sumaGracza += (sumaGracza + 11 <= 21) ? 11 : 1;
                else
                    sumaGracza += taliaKart[los].Wartosc;

                wynik.Text = sumaGracza.ToString();

                if (sumaGracza > 21)
                {
                    MessageBox.Show("Przegrałeś!");
                    button1.Enabled = false;
                    return;
                }

                // zmiana tury na krupiera
                runda = false;
                return;
            }

            // ===== TURA KRUPIERA =====
            if (runda == false)
            {
                if (taliaKart[los].Wartosc == 0)
                    sumaKrupiera += (sumaKrupiera + 11 <= 21) ? 11 : 1;
                else
                    sumaKrupiera += taliaKart[los].Wartosc;

                krukier.Text = sumaKrupiera.ToString();

                if (sumaKrupiera > 21)
                {
                    MessageBox.Show("Krupier bust! Wygrałeś!");
                    button1.Enabled = false;
                    return;
                }

                // krupier dobiera do 17
                if (sumaKrupiera < 17)
                {
                    Losuj(); // krupier dobiera dalej
                }
                else
                {
                    // porównanie wyników
                    if (sumaGracza > sumaKrupiera)
                        MessageBox.Show("Wygrałeś!");
                    else if (sumaGracza < sumaKrupiera)
                        MessageBox.Show("Przegrałeś!");
                    else
                        MessageBox.Show("Remis!");

                    button1.Enabled = false;
                }
            }
        }

        private void wyświetl()
        { 
        
            
        
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Losuj();
        }
    }
}
