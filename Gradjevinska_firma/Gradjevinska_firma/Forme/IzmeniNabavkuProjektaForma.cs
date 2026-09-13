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

        private void btnIzmeniNabavkuProjekta_Click(object sender, EventArgs e)
        {
            ProjekatBasic projekat = new ProjekatBasic();

            projekat.ID = idProjekta;

            NabavkeBasic nabavka = new NabavkeBasic(
                idNabavke, dtpDatum.Value, projekat);

            NabavkeDTOManager.izmeniNabavku(nabavka);

            MessageBox.Show("Uspesno izmenjena nabavka projekta.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IzmeniNabavkuProjektaForma_Load(object sender, EventArgs e)
        {
            NabavkeBasic nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
            dtpDatum.Value = nabavka.Datum;
        }
    }
}
