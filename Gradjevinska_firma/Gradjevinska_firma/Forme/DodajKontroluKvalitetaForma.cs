using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradjevinska_firma.Forme
{
    public partial class DodajKontroluKvalitetaForma : Form
    {
        private int idZadatka;
        public DodajKontroluKvalitetaForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void DodajKontroluKvalitetaForma_Load(object sender, EventArgs e)
        {
            dtpDatumOtklananja.ShowCheckBox = true;

            dtpDatumOtklananja.Checked = false;


        }

        private void btDodaj_Click(object sender, EventArgs e)
        {

            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);

            DateTime? datumOtklananja = null;

            if (dtpDatumOtklananja.Checked == true) {
                datumOtklananja = dtpDatumOtklananja.Value;
            }

            KontrolaKvalitetaBasic kontrola = new KontrolaKvalitetaBasic(
                0,dtpDatumInspekcije.Value,tbPrimedba.Text,tbZapisnik.Text,cbZabrana.Checked,tbRazlogZabrane.Text,datumOtklananja,zadatak);

            DTOManager.dodajKontrolu(kontrola);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
