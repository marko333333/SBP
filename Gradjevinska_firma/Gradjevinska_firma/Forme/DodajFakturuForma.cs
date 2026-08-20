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
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Forme
{
    public partial class DodajFakturuForma : Form
    {
        private int idProjekta;
        public DodajFakturuForma(int idProjekta)
        {
            InitializeComponent();
            this.idProjekta = idProjekta;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DodajFakturuForma_Load(object sender, EventArgs e)
        {
            PopuniPravnimLicima();
        }

        private void PopuniPravnimLicima()
        {
            cbPrimalac.Items.Clear();
            cbIzdavalac.Items.Clear();
            List<PravnaLicaPregled> pravnaLica = DTOManager.vratiPravnaLicaNaProjektu(idProjekta);

            foreach (PravnaLicaPregled osoba in pravnaLica)
            {
                cbPrimalac.Items.Add(osoba);
                cbIzdavalac.Items.Add(osoba);
            }

            if (cbIzdavalac.Items.Count > 0)
                cbIzdavalac.SelectedIndex = 0;

            if (cbPrimalac.Items.Count > 0)
                cbPrimalac.SelectedIndex = 0;
        }

        private void DodajFakturu_button_Click(object sender, EventArgs e)
        {
            if (cbIzdavalac.SelectedItem == null)
            {
                MessageBox.Show("Izaberite pravno lice koje izdaje fakturu");
                return;
            }

            if (cbPrimalac.SelectedItem == null)
            {
                MessageBox.Show("Izaberite pravno lice koje prima fakturu");
                return;
            }

            PravnaLicaPregled izabranIzdavalac = (PravnaLicaPregled)cbIzdavalac.SelectedItem;
            PravnaLicaPregled izabranPrimalac = (PravnaLicaPregled)cbPrimalac.SelectedItem;

            PravnaLicaBasic primalac = new PravnaLicaBasic();
            PravnaLicaBasic izdavalac = new PravnaLicaBasic();

            izdavalac.Id = izabranIzdavalac.Id;
            primalac.Id = izabranPrimalac.Id;

            ProjekatBasic projekat = DTOManager.vratiProjekat(idProjekta);

            FakturaBasic faktura = new FakturaBasic(
                0,
                int.Parse(nudIznos.Text),
                tbValuta.Text,
                cbStatusPlacanja.Checked,
                dtpDatum.Value,
                projekat,
                izdavalac,
                primalac
           );

            DTOManager.dodajFakturu(faktura);

            MessageBox.Show("Faktura je uspesno dodata.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
