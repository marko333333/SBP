using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Forme
{
    public partial class IzmeniSanacijaForma : Form
    {
        private int idSanacija;
        public IzmeniSanacijaForma(int idSanacija)
        {
            InitializeComponent();
            this.idSanacija = idSanacija;
        }

        private void IzmeniSanacijaForma_Load(object sender, EventArgs e)
        {
            SanacijaBasic sanacija = ProjekatDTOManager.vratiSanaciju(idSanacija);

            tbNaziv.Text = sanacija.Naziv;
            tbOpis.Text = sanacija.Opis;
            tbOpis.Text = sanacija.Opis;
            tbLokacija.Text = sanacija.Lokacija;
            dtpDatumPocetka.Value = sanacija.Datum_pocetka;
            nudBudzet.Value = (int)sanacija.Budzet;
            cbStatus.Text = sanacija.Status;
            dtpPlaniraniZavrsetak.Value = sanacija.Planirani_zavrsetak;
            if (sanacija.Stvarni_zavrsetak.HasValue)
            {
                dtpStvarniZavrsetak.Value = sanacija.Stvarni_zavrsetak.Value;
                dtpStvarniZavrsetak.Checked = true;
            }
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {
            SanacijaBasic sanacij = new SanacijaBasic(
              idSanacija,
              tbNaziv.Text,
              tbOpis.Text,
              tbLokacija.Text,
              dtpDatumPocetka.Value,
              (int)nudBudzet.Value,
              cbStatus.SelectedItem.ToString(),
              dtpPlaniraniZavrsetak.Value,
              dtpStvarniZavrsetak.Value
          );

            ProjekatDTOManager.izmeniSanaciju(sanacij);

            MessageBox.Show("Projekat sanacije je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
