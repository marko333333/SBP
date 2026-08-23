using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
    public partial class DodajOpremuForma : Form
    {
        public DodajOpremuForma()
        {
            InitializeComponent();
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTip.Text))
            {
                MessageBox.Show("Unesite tip opreme!");
                tbTip.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbNaziv.Text))
            {
                MessageBox.Show("Unesite naziv opreme!");
                tbNaziv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbProizvodjac.Text))
            {
                MessageBox.Show("Unesite proizvodjaca!");
                tbProizvodjac.Focus();
                return;
            }


            OpremaBasic oprema = new OpremaBasic(
                0, tbNaziv.Text, tbTip.Text, dtpdatumUvoza.Value, tbProizvodjac.Text, tbRasponOdrzavanja.Text, tbLokacija.Text, cbStatus.SelectedItem.ToString());

            OpremaDTOManager.dodajOpremu(oprema);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DodajOpremuForma_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
        }
    }
}
