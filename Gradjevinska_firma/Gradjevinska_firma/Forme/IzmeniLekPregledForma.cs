using Gradjevinska_firma.DTO;
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
    public partial class IzmeniLekPregledForma : Form
    {
        private int idLekPregled;
        private int idOsobe;
        public IzmeniLekPregledForma(int id, int idosobe)
        {
            InitializeComponent();
            idLekPregled = id;
            idOsobe = idosobe;

        }

        private void IzmeniLekPregledForma_Load(object sender, EventArgs e)
        {
            LekarskiPregledBasic lekpregled = DTOManager.vratiLekPregled(idLekPregled);
            tbLekPregled.Text = lekpregled.Rezultat;
            dtpDatum.Value= lekpregled.Datum;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            LekarskiPregledBasic lekpregled = new LekarskiPregledBasic(idLekPregled,idOsobe,tbLekPregled.Text,dtpDatum.Value);

            DTOManager.izmeniLekPregled(lekpregled);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
