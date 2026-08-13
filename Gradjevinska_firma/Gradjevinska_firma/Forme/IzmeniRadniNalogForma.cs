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
    public partial class IzmeniRadniNalogForma : Form
    {
        private int idRadniNalog;
        private int idZadatka;
        public IzmeniRadniNalogForma(int id,int idzadatak)
        {
            InitializeComponent();
            idRadniNalog = id;
            idZadatka = idzadatak;
        }

        private void IzmeniRadniNalogForma_Load(object sender, EventArgs e)
        {

        }
    }
}
