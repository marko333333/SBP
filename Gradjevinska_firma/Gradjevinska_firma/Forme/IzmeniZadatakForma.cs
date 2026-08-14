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
    public partial class IzmeniZadatakForma : Form
    {
        private int idZadatka;
        public IzmeniZadatakForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void IzmeniZadatakForma_Load(object sender, EventArgs e)
        {
            dtpStvarniP.ShowCheckBox = true;
            dtpStvarniZ.ShowCheckBox = true;

            dtpStvarniP.Checked = false;
            dtpStvarniZ.Checked = false;

            popuniFaze();
            popuniNadzadatke();
            popuniPodacima();



        }

        private void popuniPodacima()
        {
            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
            tbNaziv.Text = zadatak.Naziv;
            tbOpis.Text = zadatak.Opis;
            tbTrosak.Text = zadatak.ProcenjeniTrosak.ToString();
            prioritet.Value = zadatak.Prioritet;
            cbStatus.SelectedItem = zadatak.Status;

            
            if (zadatak.Faza != null)
            {
                for (int i = 0; i < cbFaza.Items.Count; i++)
                {
                    FazaPregled f = (FazaPregled)cbFaza.Items[i];

                    if (f.Id == zadatak.Faza.Id)
                    {
                        cbFaza.SelectedIndex = i;
                        break;
                    }
                }
            }

            if (zadatak.Roditelj == null)
            {
                cbNadzadatak.SelectedIndex = 0;
            }
            else
            {
                for (int i = 1; i < cbNadzadatak.Items.Count; i++)
                {
                    ZadatakPregled z =
                        (ZadatakPregled)cbNadzadatak.Items[i];

                    if (z.Id == zadatak.Roditelj.Id)
                    {
                        cbNadzadatak.SelectedIndex = i;
                        break;
                    }
                }
            }

            dtpPlaniraniP.Text = zadatak.PlaniraniPocetak.ToShortDateString();
            dtpPlaniraniZ.Text = zadatak.PlaniraniZavrsetak.ToShortDateString();

            if (zadatak.StvarniPocetak.HasValue)
            {
                dtpStvarniP.Value = zadatak.StvarniPocetak.Value;
                dtpStvarniP.Checked = true;
            }
            if (zadatak.StvarniZavrsetak.HasValue)
            {
                dtpStvarniZ.Value = zadatak.StvarniZavrsetak.Value;
                dtpStvarniZ.Checked = true;
            }
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
                if (z.Id == idZadatka)
                    continue;

                cbNadzadatak.Items.Add(z);
            }

            cbNadzadatak.DisplayMember = "Naziv";
            cbNadzadatak.SelectedIndex = 0;

        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            FazaPregled izabranaFaza =(FazaPregled)cbFaza.SelectedItem;

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
                idZadatka,
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

            DTOManager.izmeniZadatak(zadatak);

            MessageBox.Show("Zadatak je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
