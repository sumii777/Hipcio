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
    public partial class OknoMenu : Form
    {
        public OknoMenu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        OknoRuletka rl = new OknoRuletka();
        OknoBlackJack bj = new OknoBlackJack();
        OknoKoloFortuny kl = new OknoKoloFortuny();
        OknoBandyta bt = new OknoBandyta();
        
        private void bjack_Click(object sender, EventArgs e)
        {
            bj.StartPosition = FormStartPosition.Manual;
            bj.Location = this.Location;

            this.Hide();
            bj.Show();
            bj.BringToFront();

            bj.FormClosed += (s, args) => this.Show();
        }

        private void ruletka_Click(object sender, EventArgs e)
        {
            rl.StartPosition = FormStartPosition.Manual;
            rl.Location = this.Location;

            this.Hide();
            rl.Show();

            rl.FormClosed += (s, args) => this.Show();
        }

        private void kolo_Click(object sender, EventArgs e)
        {
            kl.StartPosition = FormStartPosition.Manual;
            kl.Location = this.Location;

            this.Hide();
            kl.Show();

            kl.FormClosed += (s, args) => this.Show();
        }

        private void bandyta_Click(object sender, EventArgs e)
        {
            bt.StartPosition = FormStartPosition.Manual;
            bt.Location = this.Location;

            this.Hide();
            bt.Show();

            bt.FormClosed += (s, args) => this.Show();
        }

        private void doladuj_Click(object sender, EventArgs e)
        {

        }

        private void autorzy_Click(object sender, EventArgs e)
        {

        }
    }
}
