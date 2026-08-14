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
    public partial class DodajNapredakForma : Form
    {
        private int idZadatka;
        public DodajNapredakForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void DodajNapredakForma_Load(object sender, EventArgs e)
        {

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbProcenatRealizacije.Text) || !tbProcenatRealizacije.Text.All(char.IsDigit))
            {
                MessageBox.Show("Procenat mora da ima cifre, polje ne sme da bude prazno!");
                tbProcenatRealizacije.Focus();
                return;
            }

            ZadatakBasic zadatak=DTOManager.vratiZadatak(idZadatka);
            NapredakBasic napredak=new NapredakBasic(
                0,dtpDatum.Value,zadatak,tbDnevniIzvestaj.Text,int.Parse(tbProcenatRealizacije.Text),tbPrimedbaNadzora.Text,tbKorektivnaMera.Text);

            DTOManager.dodajNapredak(napredak);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
