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
    public partial class OknoBlackJack : Form
    {
        int[] taliaKart = new int[]
        {

        };

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

        private void Losuj()
        {

        }
    }
}
