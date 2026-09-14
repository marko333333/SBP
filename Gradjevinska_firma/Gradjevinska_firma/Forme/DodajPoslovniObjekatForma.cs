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
    public partial class DodajPoslovniObjekatForma : Form
    {
        private int idPoslovni;
        public DodajPoslovniObjekatForma(int idPoslovni)
        {
            InitializeComponent();
            this.idPoslovni = idPoslovni;
        }

        private void Dodaj_button_Click(object sender, EventArgs e)
        {
            PoslovniBasic stan = ProjekatDTOManager.vratiPoslovni(idPoslovni);
            ObjekatPoslovniBasic poslovni = new ObjekatPoslovniBasic(
               0,
               (int)numBrObjekta.Value,
               (int)numSpratnost.Value,
               (int)numBrJedinica.Value,
               stan
            );

            ProjekatDTOManager.dodajObjekatPoslovni(poslovni);

            MessageBox.Show("Poslovni objekat je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
