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
    public partial class IzmeniMehanizacijuForma : Form
    {
        private int idMehanizacije;
        public IzmeniMehanizacijuForma(int id)
        {
            InitializeComponent();
            idMehanizacije = id;
        }

        private void IzmeniMehanizacijuForma_Load(object sender, EventArgs e)
        {
            MehanizacijaBasic mehanizacija = DTOManager.vratiMehanizaciju(idMehanizacije);

            tbNaziv.Text = mehanizacija.Naziv;
            tbTip.Text = mehanizacija.Tip;
            dtpdatumUvoza.Value = mehanizacija.DatumUvoza;
            tbProizvodjac.Text = mehanizacija.Proizvodjac;
            tbRasponOdrzavanja.Text = mehanizacija.RasponOdrzavanja;
            tbLokacija.Text = mehanizacija.Lokacija;
            cbStatus.SelectedItem = mehanizacija.Status;
            cbTipMehanizacije.SelectedItem = mehanizacija.TipMehanizacije;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
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
                idMehanizacije, tbNaziv.Text, tbTip.Text, dtpdatumUvoza.Value, tbProizvodjac.Text, tbRasponOdrzavanja.Text, tbLokacija.Text, cbStatus.SelectedItem.ToString(),cbTipMehanizacije.SelectedItem.ToString());

            DTOManager.izmeniMehanizaciju(oprema);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
