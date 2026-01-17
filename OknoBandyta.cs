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
        //tworzenie obiektu losowego
        Random rand = new Random();
        //deklaracja zmiennych do przechowywania liczb losowych
        int randomNumber1;
        int randomNumber2;
        int randomNumber3;
        //tablica przechowywująca zdjęcia, które mogą zostać wylsowoane
        Image[] zdjecia = new Image[]
        {
            Hipcio.Properties.Resources.krewetka,
            Hipcio.Properties.Resources.dzwonek1,
            Hipcio.Properties.Resources.pomarancza1,
            Hipcio.Properties.Resources.wisnia1,
            Hipcio.Properties.Resources.hipopotam,
            Hipcio.Properties.Resources.sliwka1
        };

        public OknoBandyta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //losowanie 3 numerów
            randomNumber1 = rand.Next(0, zdjecia.Length);
            randomNumber2 = rand.Next(0, zdjecia.Length);
            randomNumber3 = rand.Next(0, zdjecia.Length);
            //przypisanie do pictureBoxów zdjęć z losowym indeksem
            obrazWynik1.Image = zdjecia[randomNumber1];
            obrazWynik2.Image = zdjecia[randomNumber2];
            obrazWynik3.Image = zdjecia[randomNumber3];

            //sprawdzanie czy wszystkie wylosowane symbole są takie same
            if (randomNumber1 == randomNumber2 && randomNumber1 == randomNumber3)
            {
                //wyświetla sie informacja o wygranej gdy symbole są identyczne
                infoWynik.Text = "Wygrana";
                infoWynik.ForeColor = Color.FromArgb(34, 111, 84);
            }
            else
            {
                //wyświetla sie informacja o przegranej gdy symbole są inne
                infoWynik.Text = "Przegrana";
                infoWynik.ForeColor = Color.FromArgb(218, 44, 56);
            }
        }
    }
}
