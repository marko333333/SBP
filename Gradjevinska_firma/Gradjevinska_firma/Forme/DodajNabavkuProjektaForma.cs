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
    public partial class DodajNabavkuProjektaForma : Form
    {
        int idProjekta;
        public DodajNabavkuProjektaForma(int idProjekta)
        {
            InitializeComponent();
            this.idProjekta = idProjekta;
        }

        private void btnDodajNabavkuProjekta_Click(object sender, EventArgs e)
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
                0, dtpDatum.Value, projekat, dobavljac);

            NabavkeDTOManager.dodajNabavku(nabavka);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void DodajNabavkuProjektaForma_Load(object sender, EventArgs e)
        {
            popuniDobavljace();
        }
    }
}
