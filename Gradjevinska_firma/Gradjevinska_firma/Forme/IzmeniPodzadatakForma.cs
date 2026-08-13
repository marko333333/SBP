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
    public partial class IzmeniPodzadatakForma : Form
    {
        private int idZadatka;
        private int idPodZadatka;
        public IzmeniPodzadatakForma(int id,int idzadatak)
        {
            InitializeComponent();
            idPodZadatka = id;
            idZadatka = idzadatak;
        }

        private void IzmeniPodzadatakForma_Load(object sender, EventArgs e)
        {

        }
    }
}
