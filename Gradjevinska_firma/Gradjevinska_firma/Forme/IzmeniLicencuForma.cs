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
    public partial class IzmeniLicencuForma : Form
    {
        private int idLicenca;
        private int idOsoba;
        public IzmeniLicencuForma(int id, int idosoba)
        {
            InitializeComponent();
            idLicenca = id;
            idOsoba = idosoba;
        }

        private void IzmeniLicencuForma_Load(object sender, EventArgs e)
        {
            LicencaBasic licenca=DTOManager.vratiLicencu(idLicenca);

            tbLicenca.Text=licenca.NazivLicence;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            LicencaBasic licenca = new LicencaBasic(idLicenca, idOsoba, tbLicenca.Text);

            DTOManager.izmeniLicencu(licenca);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
