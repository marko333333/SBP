using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
    public partial class IzmeniNapredakForma : Form
    {
        private int idNapredak;
        public IzmeniNapredakForma(int id)
        {
            InitializeComponent();
            idNapredak = id;
        }

        private void IzmeniNapredakForma_Load(object sender, EventArgs e)
        {
            NapredakBasic napredak = NapredakDTOManager.vratiNapredak(idNapredak);
            dtpDatum.Value = napredak.Datum;
            tbDnevniIzvestaj.Text = napredak.DnevniIzvestaj;
            tbProcenatRealizacije.Text = napredak.ProcenatRealizacije.ToString();
            tbPrimedbaNadzora.Text = napredak.PrimedbaNadzora;
            tbKorektivnaMera.Text=napredak.KorektivnaMera;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            NapredakBasic napredak = new NapredakBasic();
            napredak.Id = idNapredak;
            napredak.Datum = dtpDatum.Value;
            napredak.DnevniIzvestaj = tbDnevniIzvestaj.Text;
            napredak.ProcenatRealizacije = int.Parse(tbProcenatRealizacije.Text);
            napredak.PrimedbaNadzora = tbPrimedbaNadzora.Text;
            napredak.KorektivnaMera = tbKorektivnaMera.Text;

            NapredakDTOManager.izmeniNapredak(napredak);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
