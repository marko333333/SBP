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
            dtpStvarniP.ShowCheckBox = true;
            dtpStvarniZ.ShowCheckBox = true;

            dtpStvarniP.Checked = false;
            dtpStvarniZ.Checked = false;

            cbStatus.SelectedIndex = 0;
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

            cbFaza.SelectedIndex = 0;

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
            if (string.IsNullOrWhiteSpace(tbNaziv.Text))
            {
                MessageBox.Show("Morate uneti naziv zadatka.");
                return;
            }

            if (cbFaza.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati fazu.");
                return;
            }

            FazaPregled izabranaFaza = (FazaPregled)cbFaza.SelectedItem;

            FazaBasic faza = new FazaBasic();
            faza.Id = izabranaFaza.Id;
            faza.Naziv = izabranaFaza.Naziv;


            ZadatakBasic roditelj = null;

            if (cbNadzadatak.SelectedIndex != 0)
            {
                ZadatakPregled izabraniRoditelj = (ZadatakPregled)cbNadzadatak.SelectedItem;

                roditelj = new ZadatakBasic();
                roditelj.Id = izabraniRoditelj.Id;
                roditelj.Naziv = izabraniRoditelj.Naziv;
            }


            DateTime? stvarniPocetak = null;
            DateTime? stvarniZavrsetak = null;

            if (dtpStvarniP.Checked)
                stvarniPocetak = dtpStvarniP.Value;

            if (dtpStvarniZ.Checked)
                stvarniZavrsetak = dtpStvarniZ.Value;


            ZadatakBasic zadatak = new ZadatakBasic(
                0,
                tbNaziv.Text,
                tbOpis.Text,
                decimal.Parse(tbTrosak.Text),
                dtpPlaniraniZ.Value,
                stvarniZavrsetak,
                dtpPlaniraniP.Value,
                stvarniPocetak,
                (int)prioritet.Value,
                cbStatus.SelectedItem.ToString(),
                faza,
                roditelj
            );

            DTOManager.dodajZadatak(zadatak);

            MessageBox.Show("Zadatak je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbFaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFaza.SelectedItem == null)
            {
                lbProjekat.Text = "";
                return;
            }

            FazaPregled faza = (FazaPregled)cbFaza.SelectedItem;

            if (faza.Projekat != null)
            {
                lbProjekat.Text = faza.Projekat.Naziv;
            }
        }

        private void tbNaziv_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
