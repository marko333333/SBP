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
    public partial class IzmeniKontroluForma : Form
    {
        private int idKontrole;
        private int idZadatka;
        public IzmeniKontroluForma(int id,int idzadatak)
        {
            InitializeComponent();
            idKontrole = id;
            idZadatka= idzadatak;
        }

        private void IzmeniKontroluForma_Load(object sender, EventArgs e)
        {

        }
    }
}
