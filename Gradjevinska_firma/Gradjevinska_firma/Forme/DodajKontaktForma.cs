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
    public partial class DodajKontaktForma : Form
    {
        private int idOsobe;
        public DodajKontaktForma(int id)
        {
            InitializeComponent();
            idOsobe = id;
        }

        private void btDodajKontakt_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbKontakt.Text))
            {
                MessageBox.Show("Polje za kontakt ne sme biti prazno!");
                tbKontakt.Focus();
                return;
            }

            KontaktBasic kontakt = new KontaktBasic(
                    0,idOsobe,tbKontakt.Text);

            DTOManager.dodajKontakt(kontakt);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void DodajKontaktForma_Load(object sender, EventArgs e)
        {

        }
    }
}
