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
    public partial class IzmeniNapredakForma : Form
    {
        private int idNapredak;
        private int idZadatka;
        public IzmeniNapredakForma(int id, int idzadatak)
        {
            InitializeComponent();
            idNapredak = id;
            idZadatka = idzadatak;
        }

        private void IzmeniNapredakForma_Load(object sender, EventArgs e)
        {
            NapredakBasic napredak = DTOManager.vratiNapredak(idNapredak);
            dtpDatum.Value = napredak.Datum;
            tbDnevniIzvestaj.Text = napredak.DnevniIzvestaj;
            tbProcenatRealizacije.Text = napredak.ProcenatRealizacije.ToString();
            tbPrimedbaNadzora.Text = napredak.PrimedbaNadzora;
            tbKorektivnaMera.Text=napredak.KorektivnaMera;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
            NapredakBasic napredak=new NapredakBasic(
                idNapredak,dtpDatum.Value,zadatak,tbDnevniIzvestaj.Text,int.Parse(tbProcenatRealizacije.Text),tbPrimedbaNadzora.Text,tbKorektivnaMera.Text);

            DTOManager.izmeniNapredak(napredak);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
