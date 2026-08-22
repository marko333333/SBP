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
    public partial class DodajMehanizacijuForma : Form
    {
        public DodajMehanizacijuForma()
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
            if (cbTipMehanizacije.SelectedItem == null)
            {
                MessageBox.Show("Unesite tip mehanizacije!");
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


            MehanizacijaBasic oprema = new MehanizacijaBasic(
                0, tbNaziv.Text, tbTip.Text, dtpdatumUvoza.Value, tbProizvodjac.Text, tbRasponOdrzavanja.Text, tbLokacija.Text, cbStatus.SelectedItem.ToString(), cbTipMehanizacije.SelectedItem.ToString());

            DTOManager.dodajMehanizaciju(oprema);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DodajMehanizacijuForma_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
        }
    }
}
