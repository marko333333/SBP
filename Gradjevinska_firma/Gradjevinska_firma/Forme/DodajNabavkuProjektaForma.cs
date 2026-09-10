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

            NabavkeBasic nabavka = new NabavkeBasic(
                0, dtpDatum.Value, projekat);

            NabavkeDTOManager.dodajNabavku(nabavka);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
