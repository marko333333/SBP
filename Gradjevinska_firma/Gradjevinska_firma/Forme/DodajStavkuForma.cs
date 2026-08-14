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
    public partial class DodajStavkuForma : Form
    {
        private int idKontrole;
        public DodajStavkuForma(int id)
        {
            InitializeComponent();
            idKontrole = id;
        }

        private void DodajStavkuForma_Load(object sender, EventArgs e)
        {
            dtpRok.ShowCheckBox = true;
            dtpRok.Checked = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRbStavke.Text))
            {
                MessageBox.Show("Unesite redni broj stavke");
                tbRbStavke.Focus();
                return;
            }

            DateTime? rokZaOtklanjanje = null;

            if (dtpRok.Checked)
                rokZaOtklanjanje = dtpRok.Value;

            KontrolaKvalitetaBasic kontrola = DTOManager.vratiKontroluKvaliteta(idKontrole);

            StavkaKontroleBasic stavka = new StavkaKontroleBasic(
                0,kontrola,int.Parse(tbRbStavke.Text),tbUzorci.Text,tbLabNalaz.Text,tbRezultatIspit.Text,tbKorektivneMere.Text,rokZaOtklanjanje);

            DTOManager.dodajStavku(stavka);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
