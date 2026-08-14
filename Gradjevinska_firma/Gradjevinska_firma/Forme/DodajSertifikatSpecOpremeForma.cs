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
    public partial class DodajSertifikatSpecOpremeForma : Form
    {
        private int idOsobe;
        public DodajSertifikatSpecOpremeForma(int id)
        {
            InitializeComponent();
            idOsobe = id;
        }

        private void DodajSertifikatSpecOpremeForma_Load(object sender, EventArgs e)
        {

        }

        private void btDodaj_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSertifikatSpec.Text))
            {
                MessageBox.Show("Unesite sertifikat");
                tbSertifikatSpec.Focus();
                return;
            }

            SertifikatSpecOpremeBasic sertifikatspec = new SertifikatSpecOpremeBasic(
                0, idOsobe, tbSertifikatSpec.Text);

            DTOManager.dodajSertifikatSpecOpreme(sertifikatspec);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
