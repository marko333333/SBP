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

namespace Gradjevinska_firma.Forme
{
    public partial class IzmeniFakturuForma : Form
    {
        private int idFakture;
        private int idProjekta;
        public IzmeniFakturuForma(int idFakture, int idProjekta)
        {
            InitializeComponent();
            this.idFakture = idFakture;
            this.idProjekta = idProjekta;
        }

        private void IzmeniFakturuForma_Load(object sender, EventArgs e)
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

        private void IzmeniFakturu_button_Click(object sender, EventArgs e)
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
                idFakture,
                int.Parse(nudIznos.Text),
                tbValuta.Text,
                cbStatusPlacanja.Checked,
                dtpDatum.Value,
                projekat,
                izdavalac,
                primalac
           );

            DTOManager.izmeniFakturu(faktura);

            MessageBox.Show("Faktura je uspesno izmenjena.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
