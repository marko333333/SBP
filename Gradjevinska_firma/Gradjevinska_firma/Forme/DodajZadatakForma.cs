using Gradjevinska_firma.DTO;
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
    public partial class DodajZadatakForma : Form
    {
        public DodajZadatakForma()
        {
            InitializeComponent();
        }

        private void DodajZadatakForma_Load(object sender, EventArgs e)
        {
            popuniFaze();
            popuniNadzadatke();
        }
        private void popuniFaze()
        {
            cbFaza.Items.Clear();

            List<FazaPregled> faze = DTOManager.vratiSveFaze();

            foreach (FazaPregled f in faze)
            {
                cbFaza.Items.Add(f);
            }

            cbFaza.DisplayMember = "Naziv";

        }
        private void popuniNadzadatke()
        {
            cbNadzadatak.Items.Clear();

            cbNadzadatak.Items.Add("Nema nadzadatka");

            List<ZadatakPregled> zadaci = DTOManager.vratiSveZadatke();

            foreach (ZadatakPregled z in zadaci)
            {
                cbNadzadatak.Items.Add(z);
            }

            cbNadzadatak.DisplayMember = "Naziv";

            cbNadzadatak.SelectedIndex = 0;

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
           /* ZadatakBasic zadatak = new ZadatakBasic(
                0,tbNaziv.Text,tbOpis.Text,tbTrosak.Text.ToString(),
                dtpPlaniraniZ.Value,dtpStvarniZ.Value,dtpPlaniraniP.Value,dtpStvarniP.Value,prioritet.Value
                cbStatus.Text,cbFaza.Text,cbNadzadatak.Text);

            DTOManager.dodajSertifikatSpecOpreme(sertifikatspec);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();*/
        }
    }
}
