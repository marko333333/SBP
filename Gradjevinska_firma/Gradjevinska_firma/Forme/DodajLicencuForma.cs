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
    public partial class DodajLicencuForma : Form
    {
        private int idOsobe;
        public DodajLicencuForma(int id)
        {
            InitializeComponent();
            idOsobe = id;
        }

        private void DodajLicencuForma_Load(object sender, EventArgs e)
        {
            
        }

        private void btDodajLicencu_Click(object sender, EventArgs e)
        {
            LicencaBasic licenca = new LicencaBasic(
                    0, idOsobe, tbLicenca.Text);

            DTOManager.dodajLicencu(licenca);
            MessageBox.Show("Uspesno dodavanje.");
        }
    }
}
