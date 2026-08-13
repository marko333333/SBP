using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradjevinska_firma.Forme
{
    public partial class DodajRadniNalogForma : Form
    {
        private int idZadatka;
        public DodajRadniNalogForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void DodajRadniNalogForma_Load(object sender, EventArgs e)
        {

        }
    }
}
