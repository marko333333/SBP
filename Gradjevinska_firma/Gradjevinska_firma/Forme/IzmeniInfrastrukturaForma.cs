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
    public partial class IzmeniInfrastrukturaForma : Form
    {
        private int idInfrastruktura;
        public IzmeniInfrastrukturaForma(int idInfrastruktura)
        {
            InitializeComponent();
            this.idInfrastruktura = idInfrastruktura;
        }

        private void IzmeniInfrastrukturaForma_Load(object sender, EventArgs e)
        {
            InfrastrukturaBasic stambeni = ProjekatDTOManager.vratiInfrastrukturu(idInfrastruktura);

            tbNaziv.Text = stambeni.Naziv;
            tbOpis.Text = stambeni.Opis;
            tbOpis.Text = stambeni.Opis;
            tbLokacija.Text = stambeni.Lokacija;
            dtpDatumPocetka.Value = stambeni.Datum_pocetka;
            nudBudzet.Value = (int)stambeni.Budzet;
            cbStatus.Text = stambeni.Status;
            dtpPlaniraniZavrsetak.Value = stambeni.Planirani_zavrsetak;
            if (stambeni.Stvarni_zavrsetak.HasValue)
            {
                dtpStvarniZavrsetak.Value = stambeni.Stvarni_zavrsetak.Value;
                dtpStvarniZavrsetak.Checked = true;
            }
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {
            InfrastrukturaBasic infrastruktura = new InfrastrukturaBasic(
               idInfrastruktura,
               tbNaziv.Text,
               tbOpis.Text,
               tbLokacija.Text,
               dtpDatumPocetka.Value,
               (int)nudBudzet.Value,
               cbStatus.SelectedItem.ToString(),
               dtpPlaniraniZavrsetak.Value,
               dtpStvarniZavrsetak.Value
           );

            ProjekatDTOManager.izmeniInfrastrukturu(infrastruktura);

            MessageBox.Show("Infrastrukturni projekat je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
