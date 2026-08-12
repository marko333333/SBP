using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;
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
    public partial class IzmeniObukuForma : Form
    {
        private int idObuke;
        private int idOsobe;
        public IzmeniObukuForma(int id, int idosoba)
        {
            InitializeComponent();
            idObuke = id;
            idOsobe = idosoba;
        }

        private void IzmeniObukuForma_Load(object sender, EventArgs e)
        {
            BezbednosnaObukaBasic obuka = DTOManager.vratiObuku(idObuke);
            tbObuka.Text = obuka.NazivObuke;
            dtpDatum.Value=obuka.Datum;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            BezbednosnaObukaBasic obuka = new BezbednosnaObukaBasic(idObuke,idOsobe,tbObuka.Text,dtpDatum.Value);
            
            DTOManager.izmeniBezbednosnuObuku(obuka);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
