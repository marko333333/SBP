using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Forme
{
    public partial class ProjekatForma : Form
    {
        public ProjekatForma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IndustrijskiForma forma = new IndustrijskiForma();
            forma.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InfrastrukturaForma forma = new InfrastrukturaForma();
            forma.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            PoslovniForma forma = new PoslovniForma();
            forma.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StambeniForma forma = new StambeniForma();
            forma.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SanacijaForma forma = new SanacijaForma();
            forma.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RekonstrukcijaForma forma = new RekonstrukcijaForma();
            forma.ShowDialog();
        }
    }
}
