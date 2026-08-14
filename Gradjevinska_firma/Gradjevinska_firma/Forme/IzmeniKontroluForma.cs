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
    public partial class IzmeniKontroluForma : Form
    {
        private int idKontrole;
        private int idZadatka;
        public IzmeniKontroluForma(int id, int idzadatak)
        {
            InitializeComponent();
            idKontrole = id;
            idZadatka = idzadatak;
        }

        private void IzmeniKontroluForma_Load(object sender, EventArgs e)
        {
            dtpDatumOtklananja.ShowCheckBox = true;
            dtpDatumOtklananja.Checked = false;
            KontrolaKvalitetaBasic kontrola = DTOManager.vratiKontroluKvaliteta(idKontrole);

            dtpDatumInspekcije.Value = kontrola.DatumInspekcije;
            tbPrimedba.Text = kontrola.PrimedbeNadzora;
            tbZapisnik.Text = kontrola.Zapisnik;
            cbZabrana.Checked = kontrola.ZabranaNastavkaRadova;
            tbRazlogZabrane.Text = kontrola.RazlogZabrane;

            if (kontrola.DatumOtklanjanjaZabrane.HasValue)
            {
                dtpDatumOtklananja.Value = kontrola.DatumOtklanjanjaZabrane.Value;
                dtpDatumOtklananja.Checked = true;
            }

        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            DateTime? datumOtklananja = null;

            if (dtpDatumOtklananja.Checked == true)
            {
                datumOtklananja = dtpDatumOtklananja.Value;
            }
            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
            KontrolaKvalitetaBasic kontrola = new KontrolaKvalitetaBasic(
                idKontrole,dtpDatumInspekcije.Value,tbPrimedba.Text,tbZapisnik.Text,cbZabrana.Checked,tbRazlogZabrane.Text,datumOtklananja,zadatak);

            DTOManager.izmeniKontrolu(kontrola);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
