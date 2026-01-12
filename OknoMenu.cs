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

        private void bjack_Click(object sender, EventArgs e)
        {
            OknoBlackJack bj = new OknoBlackJack();

            bj.StartPosition = FormStartPosition.Manual;
            bj.Location = this.Location;

            this.Hide();
            bj.Show();

            bj.FormClosed += (s, args) => this.Show();
        }

        private void ruletka_Click(object sender, EventArgs e)
        {

        }

        private void kolo_Click(object sender, EventArgs e)
        {

        }

        private void bandyta_Click(object sender, EventArgs e)
        {

        }

        private void doladuj_Click(object sender, EventArgs e)
        {

        }

        private void autorzy_Click(object sender, EventArgs e)
        {

        }
    }
}
