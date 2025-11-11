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
        //tworzenie obiektu losowej
        Random rand = new Random();
        //deklaracja zmiennych do przechowywania liczb losowych
        int randomNumber1;
        int randomNumber2;
        int randomNumber3;
        //tablica przechowywująca zdjęcia, które mogą zostać wylsowoane
        Image[] zdjecia = new Image[]
        {
            Hipcio.Properties.Resources.bar,
            Hipcio.Properties.Resources.dzwonek,
            Hipcio.Properties.Resources.pomarancza,
            Hipcio.Properties.Resources.wisnia,
            Hipcio.Properties.Resources.siedem,
            Hipcio.Properties.Resources.sliwka
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
            pictureBox1.Image = zdjecia[randomNumber1];
            pictureBox2.Image = zdjecia[randomNumber2];
            pictureBox3.Image = zdjecia[randomNumber3];
        }
    }
}
