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
    public partial class OknoRuletka : Form
    {
        public OknoRuletka()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // Ustawienie tła formularza na obraz bez migania
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.DrawImage(
                Properties.Resources.background,
                this.ClientRectangle);
        }
    }
}
