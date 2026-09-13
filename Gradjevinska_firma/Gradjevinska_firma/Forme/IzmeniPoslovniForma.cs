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
    public partial class IzmeniPoslovniForma : Form
    {
        int idPoslovni;
        public IzmeniPoslovniForma(int idPoslovni)
        {
            InitializeComponent();
            this.idPoslovni = idPoslovni;
        }

        private void IzmeniPoslovniForma_Load(object sender, EventArgs e)
        {
            PoslovniBasic poslovni = ProjekatDTOManager.vratiPoslovni(idPoslovni);

            tbNaziv.Text = poslovni.Naziv;
            tbOpis.Text = poslovni.Opis;
            tbOpis.Text = poslovni.Opis;
            tbLokacija.Text = poslovni.Lokacija;
            dtpDatumPocetka.Value = poslovni.Datum_pocetka;
            nudBudzet.Value = (int)poslovni.Budzet;
            cbStatus.Text = poslovni.Status;
            dtpPlaniraniZavrsetak.Value = poslovni.Planirani_zavrsetak;
            if (poslovni.Stvarni_zavrsetak.HasValue)
            {
                dtpStvarniZavrsetak.Value = poslovni.Stvarni_zavrsetak.Value;
                dtpStvarniZavrsetak.Checked = true;
            }
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {
            PoslovniBasic poslovni = new PoslovniBasic(
              idPoslovni,
              tbNaziv.Text,
              tbOpis.Text,
              tbLokacija.Text,
              dtpDatumPocetka.Value,
              (int)nudBudzet.Value,
              cbStatus.SelectedItem.ToString(),
              dtpPlaniraniZavrsetak.Value,
              dtpStvarniZavrsetak.Value
          );

            ProjekatDTOManager.izmeniPoslovni(poslovni);

            MessageBox.Show("Poslovni projekat je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
