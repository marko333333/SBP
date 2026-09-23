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
    public partial class IzmeniNabavkuProjektaForma : Form
    {
        int idProjekta;
        int idNabavke;
        public IzmeniNabavkuProjektaForma(int idNabavke, int idProjekta)
        {
            InitializeComponent();
            this.idNabavke = idNabavke;
            this.idProjekta = idProjekta;
        }

        private void popuniDobavljace()
        {
            cbDobavljac.Items.Clear();
            cbDobavljac.Items.Add("Nema dobavljaca");

            List<PravnaLicaPregled> pravnaLica = OsobaDTOManager.vratiSveDobavljace();
            foreach (PravnaLicaPregled p in pravnaLica)
            {
                cbDobavljac.Items.Add(p);
            }

            cbDobavljac.SelectedIndex = 0;
        }

        private void btnIzmeniNabavkuProjekta_Click(object sender, EventArgs e)
        {
            ProjekatBasic projekat = new ProjekatBasic();

            projekat.ID = idProjekta;

            PravnaLicaBasic dobavljac = null;
            if (cbDobavljac.SelectedIndex != 0)
            {
                PravnaLicaPregled izabrani = (PravnaLicaPregled)cbDobavljac.SelectedItem;
                dobavljac = new PravnaLicaBasic();
                dobavljac.Id = izabrani.Id;
            }

            NabavkeBasic nabavka = new NabavkeBasic(
                idNabavke, dtpDatum.Value, projekat, dobavljac);

            NabavkeDTOManager.izmeniNabavku(nabavka);

            MessageBox.Show("Uspesno izmenjena nabavka projekta.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IzmeniNabavkuProjektaForma_Load(object sender, EventArgs e)
        {
            NabavkeBasic nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
            dtpDatum.Value = nabavka.Datum;
            popuniDobavljace();
        }
    }
}
