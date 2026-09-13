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
    public partial class DodajStambeniObjekatForma : Form
    {
        private int idStambeni;
        public DodajStambeniObjekatForma(int idStambeni)
        {
            InitializeComponent();
            this.idStambeni = idStambeni;
        }

        private void Dodaj_button_Click(object sender, EventArgs e)
        {
            StambeniBasic stan = ProjekatDTOManager.vratiStambeni(idStambeni);
            ObjekatStambeniBasic stambeni = new ObjekatStambeniBasic(
               0,
               (int)numBrObjekta.Value,
               (int)numSpratnost.Value,
               (int)numBrJedinica.Value,
               stan
            );

            ProjekatDTOManager.dodajObjekatStambeni(stambeni);

            MessageBox.Show("Stambeni objekat je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}