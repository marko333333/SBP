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
            dtpStvarniP.ShowCheckBox = true;
            dtpStvarniZ.ShowCheckBox = true;

            dtpStvarniP.Checked = false;
            dtpStvarniZ.Checked = false;
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

            FazaBasic faza = (FazaBasic)cbFaza.SelectedItem;

            ZadatakBasic roditelj = null;

            if (cbNadzadatak.SelectedIndex != 0)
            {
                roditelj = (ZadatakBasic)cbNadzadatak.SelectedItem;
            }

            DateTime? stvarniPocetak = null;
            DateTime? stvarniZavrsetak = null;

            if (dtpStvarniP.Checked)
                stvarniPocetak = dtpStvarniP.Value;

            if (dtpStvarniZ.Checked)
                stvarniZavrsetak = dtpStvarniZ.Value;

            ZadatakBasic zadatak = new ZadatakBasic(
                0, tbNaziv.Text, tbOpis.Text, decimal.Parse(tbTrosak.Text), dtpPlaniraniZ.Value, stvarniZavrsetak, dtpPlaniraniP.Value, stvarniZavrsetak, (int)prioritet.Value, 
                cbStatus.SelectedItem.ToString(), faza, roditelj);

            DTOManager.dodajZadatak(zadatak);

            MessageBox.Show("Zadatak je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
