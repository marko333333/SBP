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
    public partial class DodajZastitnuOpremuForma : Form
    {
        private int idOsobe;
        public DodajZastitnuOpremuForma(int id)
        {
            InitializeComponent();
            idOsobe = id;
        }

        private void DodajZastitnuOpremuForma_Load(object sender, EventArgs e)
        {

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbZastitnaOprema.Text))
            {
                MessageBox.Show("Unesite zastitnu opremu");
                tbZastitnaOprema.Focus();
                return;
            }
            ZastitnaOpremaBasic zastitnaOprema = new ZastitnaOpremaBasic(
                0, idOsobe, tbZastitnaOprema.Text);

            DTOManager.dodajZastitnuOpremu(zastitnaOprema);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
