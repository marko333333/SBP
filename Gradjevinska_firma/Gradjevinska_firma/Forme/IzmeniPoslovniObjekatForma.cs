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
    public partial class IzmeniPoslovniObjekatForma : Form
    {
        private int idObjekta;
        private int idPoslovni;
        public IzmeniPoslovniObjekatForma(int idObjekta, int idPoslovni)
        {
            InitializeComponent();
            this.idObjekta = idObjekta;
            this.idPoslovni = idPoslovni;
        }

        private void IzmeniPoslovniObjekatForma_Load(object sender, EventArgs e)
        {
            ObjekatPoslovniBasic poslovni = ProjekatDTOManager.vratiObjekatPoslovni(idObjekta);

            numBrObjekta.Value = poslovni.Br_objekta;
            numSpratnost.Value = poslovni.Spratnost;
            numBrJedinica.Value = poslovni.Br_jedinica;
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {
            PoslovniBasic stan = ProjekatDTOManager.vratiPoslovni(idPoslovni);
            ObjekatPoslovniBasic poslovni = new ObjekatPoslovniBasic(
               idObjekta,
               (int)numBrObjekta.Value,
               (int)numSpratnost.Value,
               (int)numBrJedinica.Value,
               stan
            );

            ProjekatDTOManager.izmeniObjekatPoslovni(poslovni);

            MessageBox.Show("Poslovni objekat je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
