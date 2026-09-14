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

namespace Gradjevinska_firma.Forme
{
    public partial class IzmeniStambeniObjekatForma : Form
    {
        private int idObjekta;
        private int idStambeni;
        public IzmeniStambeniObjekatForma(int idObjekta, int idStambeni)
        {
            InitializeComponent();
            this.idObjekta = idObjekta;
            this.idStambeni = idStambeni;
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {
            StambeniBasic stan = ProjekatDTOManager.vratiStambeni(idStambeni);
            ObjekatStambeniBasic stambeni = new ObjekatStambeniBasic(
               idObjekta,
               (int)numBrObjekta.Value,
               (int)numSpratnost.Value,
               (int)numBrJedinica.Value,
               stan
            );

            ProjekatDTOManager.izmeniObjekatStambeni(stambeni);

            MessageBox.Show("Stambeni objekat je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IzmeniStambeniObjekatForma_Load(object sender, EventArgs e)
        {
            ObjekatStambeniBasic stambeni = ProjekatDTOManager.vratiObjekatStambeni(idObjekta);

            numBrObjekta.Value = stambeni.Br_objekta;
            numSpratnost.Value = stambeni.Spratnost;
            numBrJedinica.Value = stambeni.Br_jedinica;
        }
    }
}
