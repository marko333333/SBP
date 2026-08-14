using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;
using Oracle.ManagedDataAccess.Types;
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
    public partial class IzmeniStavkuForma : Form
    {
        private int idStavke;
        private int idKontrole;
        public IzmeniStavkuForma(int id, int idkontrola)
        {
            InitializeComponent();
            idStavke = id;
            idKontrole = idkontrola;
        }

        private void IzmeniStavkuForma_Load(object sender, EventArgs e)
        {
            dtpRok.ShowCheckBox = true;
            dtpRok.Checked = false;

            StavkaKontroleBasic stavka=DTOManager.vratiStavku(idStavke);
            tbRbStavke.Text = stavka.RedniBrojStavke.ToString();
            tbUzorci.Text = stavka.Uzorci;
            tbLabNalaz.Text = stavka.LabNalazi;
            tbRezultatIspit.Text = stavka.RezultatiIspitivanja;
            tbKorektivneMere.Text = stavka.KorektivneMere;

            if (stavka.RokZaOtklanjanje.HasValue)
            {   
                dtpRok.Value=stavka.RokZaOtklanjanje.Value;
                dtpRok.Checked = true;
            }
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {

            DateTime? rokZaOtklanjanje = null;

            if (dtpRok.Checked)
                rokZaOtklanjanje = dtpRok.Value;

            KontrolaKvalitetaBasic kontrola = DTOManager.vratiKontroluKvaliteta(idKontrole);

            StavkaKontroleBasic stavka = new StavkaKontroleBasic(
                idStavke, kontrola, int.Parse(tbRbStavke.Text), tbUzorci.Text, tbLabNalaz.Text, tbRezultatIspit.Text, tbKorektivneMere.Text, rokZaOtklanjanje);

            DTOManager.izmeniStavku(stavka);

            MessageBox.Show("Uspesna izmena.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
