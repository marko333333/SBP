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
    public partial class DodajObukuForma : Form
    {
        private int idOsobe;
        public DodajObukuForma(int id)
        {
            InitializeComponent();
            idOsobe = id;
        }

        private void DodajObukuForma_Load(object sender, EventArgs e)
        {

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbObuka.Text))
            {
                MessageBox.Show("Unesite obuku");
                tbObuka.Focus();
                return;
            }
            BezbednosnaObukaBasic obuka=new BezbednosnaObukaBasic(
                0,idOsobe,tbObuka.Text,dtpDatum.Value);

            DTOManager.dodajBezbednosnuObuku(obuka);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
