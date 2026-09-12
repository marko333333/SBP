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
            dtpStvarniZavrsetak.ShowCheckBox = true;

            dtpStvarniZavrsetak.Checked = false;
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
