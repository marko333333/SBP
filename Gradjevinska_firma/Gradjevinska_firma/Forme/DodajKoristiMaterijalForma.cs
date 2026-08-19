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
    public partial class DodajKoristiMaterijalForma : Form
    {
        private int idZadatka;
        public DodajKoristiMaterijalForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void DodajKoristiMaterijalForma_Load(object sender, EventArgs e)
        {
            popuniMaterijal();
        }

        private void popuniMaterijal()
        {
            cbMaterijal.Items.Clear();

            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);

            List<MaterijalPregled> materijal = DTOManager.vratiSavMaterijal();

            foreach (MaterijalPregled m in materijal)
            {
                bool vecKoristi = false;

                foreach (KoristiBasic k in zadatak.Koristi)
                {
                    if (k.Materijal != null && k.Materijal.ID == m.ID)
                    {
                        vecKoristi = true;
                        break;
                    }
                }

                if (!vecKoristi)
                {
                    cbMaterijal.Items.Add(m);
                }

            }

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (cbMaterijal.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati materijal");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbKolicina.Text) || !tbKolicina.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite kolicinu i ona mora da bude broj!!!");
                tbKolicina.Focus();
                return;
            }

            MaterijalPregled izabraniMaterijal = (MaterijalPregled)cbMaterijal.SelectedItem;

            MaterijalBasic materijal = new MaterijalBasic();

            materijal.ID = izabraniMaterijal.ID;
            materijal.Naziv = izabraniMaterijal.Naziv;

            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);

            KoristiBasic koristi = new KoristiBasic(
                   0,int.Parse(tbKolicina.Text),zadatak,materijal);

            DTOManager.dodajKoristiZadatka(koristi);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
