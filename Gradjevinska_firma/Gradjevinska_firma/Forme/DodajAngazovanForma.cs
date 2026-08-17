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
    public partial class DodajAngazovanForma : Form
    {
        private int idZadatka;
        public DodajAngazovanForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }


        private void DodajAngazovanForma_Load(object sender, EventArgs e)
        {
            dtpDatumDo.ShowCheckBox = true;
            dtpDatumDo.Checked = false;

            popuniOsobe();
        }

        private void popuniOsobe()
        {
            cbOsoba.Items.Clear();

            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);

            List<OsobaPregled> osobe = DTOManager.vratiSveOsobe();

            foreach (OsobaPregled o in osobe)
            {
                bool vecAngazovan = false;

                foreach (AngazovanBasic a in zadatak.Angazovani)
                {
                    if (a.Osoba != null && a.Osoba.Id == o.Id)
                    {
                        vecAngazovan = true;
                        break;
                    }
                }

                if (!vecAngazovan)
                {
                    cbOsoba.Items.Add(o);
                }
                
            }

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (cbOsoba.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati osobu");
                return;
            }

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite status angazovanja");
                return;
            }

            OsobaPregled izabranaOsoba =(OsobaPregled)cbOsoba.SelectedItem;

            OsobaBasic osoba = new OsobaBasic();

            osoba.Id = izabranaOsoba.Id;
            osoba.Ime = izabranaOsoba.Ime;
            osoba.Prezime = izabranaOsoba.Prezime;

            ZadatakBasic zadatak =DTOManager.vratiZadatak(idZadatka);

            DateTime? datumDo = null;

            if (dtpDatumDo.Checked)
            {
                datumDo = dtpDatumDo.Value;
            }

            AngazovanBasic angazovan = new AngazovanBasic(
                zadatak,osoba,dtpDatumOd.Value,datumDo,cbStatus.SelectedItem.ToString()
            );

            DTOManager.dodajAngazovanje(angazovan);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
