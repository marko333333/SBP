using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
        public IzmeniStavkuForma(int id)
        {
            InitializeComponent();
            idStavke = id;
        }

        private void IzmeniStavkuForma_Load(object sender, EventArgs e)
        {
            dtpRok.ShowCheckBox = true;
            dtpRok.Checked = false;

            StavkaKontroleBasic stavka=StavkaKontroleDTOManager.vratiStavku(idStavke);
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
            if (string.IsNullOrWhiteSpace(tbRbStavke.Text))
            {
                MessageBox.Show("Unesite redni broj stavke");
                tbRbStavke.Focus();
                return;
            }
            DateTime? rokZaOtklanjanje = null;

            if (dtpRok.Checked)
                rokZaOtklanjanje = dtpRok.Value;

            StavkaKontroleBasic stavka = new StavkaKontroleBasic();
            stavka.Id = idStavke;
            stavka.RedniBrojStavke = int.Parse(tbRbStavke.Text);
            stavka.Uzorci = tbUzorci.Text;
            stavka.LabNalazi = tbLabNalaz.Text;
            stavka.RezultatiIspitivanja = tbRezultatIspit.Text;
            stavka.KorektivneMere = tbKorektivneMere.Text;
            stavka.RokZaOtklanjanje = rokZaOtklanjanje;

            StavkaKontroleDTOManager.izmeniStavku(stavka);

            MessageBox.Show("Uspesna izmena.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
