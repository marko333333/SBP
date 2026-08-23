using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
    public partial class DodajUgovornuStranuForma : Form
    {
        private int idUgovora;
        public DodajUgovornuStranuForma(int id)
        {
            InitializeComponent();
            idUgovora = id;
        }

        private void DodajUgovornuStranuForma_Load(object sender, EventArgs e)
        {
            popuniOsobe();
        }

        private void popuniOsobe()
        {
            cbOsoba.Items.Clear();

            UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);

            List<OsobaPregled> osobe = OsobaDTOManager.vratiSveOsobe();

            foreach (OsobaPregled o in osobe)
            {
                bool vecAngazovan = false;

                foreach (ImaUgovornuStranuBasic u in ugovor.UgovorneStrane)
                {
                    if (u.Osoba != null && u.Osoba.Id == o.Id)
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

            if (string.IsNullOrWhiteSpace(tbUloga.Text))
            {
                MessageBox.Show("Unesite ulogu osobe!");
                tbUloga.Focus();
                return;
            }

            OsobaPregled izabranaOsoba = (OsobaPregled)cbOsoba.SelectedItem;

            OsobaBasic osoba = new OsobaBasic();

            osoba.Id = izabranaOsoba.Id;
            osoba.Ime = izabranaOsoba.Ime;
            osoba.Prezime = izabranaOsoba.Prezime;

            UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);

            ImaUgovornuStranuBasic ugovornaStrana = new ImaUgovornuStranuBasic(
                0,osoba,ugovor,tbUloga.Text
            );

            ImaUgovorneStraneDTOManager.dodajUgovornuStranu(ugovornaStrana);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
