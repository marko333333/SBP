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
    public partial class IzmeniRekonstrukcijaForma : Form
    {
        private int idRekonstrukcija;
        public IzmeniRekonstrukcijaForma(int idRekonstrukcija)
        {
            InitializeComponent();
            this.idRekonstrukcija = idRekonstrukcija;
        }

        private void IzmeniRekonstrukcijaForma_Load(object sender, EventArgs e)
        {
            RekonstrukcijaBasic rekon = ProjekatDTOManager.vratiRekonstrukciju(idRekonstrukcija);

            tbNaziv.Text = rekon.Naziv;
            tbOpis.Text = rekon.Opis;
            tbOpis.Text = rekon.Opis;
            tbLokacija.Text = rekon.Lokacija;
            dtpDatumPocetka.Value = rekon.Datum_pocetka;
            nudBudzet.Value = (int)rekon.Budzet;
            cbStatus.Text = rekon.Status;
            dtpPlaniraniZavrsetak.Value = rekon.Planirani_zavrsetak;
            if (rekon.Stvarni_zavrsetak.HasValue)
            {
                dtpStvarniZavrsetak.Value = rekon.Stvarni_zavrsetak.Value;
                dtpStvarniZavrsetak.Checked = true;
            }
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {
            RekonstrukcijaBasic rekon = new RekonstrukcijaBasic(
               idRekonstrukcija,
               tbNaziv.Text,
               tbOpis.Text,
               tbLokacija.Text,
               dtpDatumPocetka.Value,
               (int)nudBudzet.Value,
               cbStatus.SelectedItem.ToString(),
               dtpPlaniraniZavrsetak.Value,
               dtpStvarniZavrsetak.Value
           );

            ProjekatDTOManager.izmeniRekonstrukciju(rekon);

            MessageBox.Show("Projekat rekonstrukcije je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
