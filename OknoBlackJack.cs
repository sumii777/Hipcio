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

        private int Losuj()
        {
            int los;

            // Jeżeli posiadane nie istnieje, twórz pustą listę
            if (posiadane == null)
                posiadane = new int[0];

            do
            {
                los = rand.Next(taliaKart.Length);  // losuj kartę
            }
            while (posiadane.Contains(los));        // powtarzaj aż trafisz nieużytą

            // dodaj nową kartę do tablicy "posiadane"
            posiadane = posiadane.Concat(new int[] { los }).ToArray();
            return los;
        }
        private void wyświetl()
        { 
        
            
        
        }

        private void OknoBlackJack_Load(object sender, EventArgs e)
        {

        }
    }
}
