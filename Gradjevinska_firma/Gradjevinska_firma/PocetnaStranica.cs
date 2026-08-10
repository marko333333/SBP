using Gradjevinska_firma.Forme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradjevinska_firma
{
    public partial class PocetnaStranica : Form
    {
        public PocetnaStranica()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PocetnaStranica_Load(object sender, EventArgs e)
        {
            lb1.Text = "Gradjevinska firma";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            ZaposleniForma forma =new ZaposleniForma();
            forma.ShowDialog();
        }
    }
}
