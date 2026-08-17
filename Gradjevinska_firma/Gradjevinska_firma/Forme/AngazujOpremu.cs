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
    public partial class AngazujOpremu : Form
    {
        private int idZadatka;
        public AngazujOpremu(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void AngazujOpremu_Load(object sender, EventArgs e)
        {
            dtpDatumDo.ShowCheckBox = true;
            dtpDatumDo.Checked = false;

            popuniOpremu();
        }
        private void popuniOpremu()
        {
            cbOprema.Items.Clear();

            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);

            List<OpremaPregled> oprema = DTOManager.vratiSvuOpremu();

            foreach (OpremaPregled o in oprema)
            {
                bool vecAngazovan = false;

                foreach (AngazujeBasic a in zadatak.AngazovanaOprema)
                {
                    if (a.Oprema != null && a.Oprema.Id == o.Id)
                    {
                        vecAngazovan = true;
                        break;
                    }
                }

                if (!vecAngazovan)
                {
                    cbOprema.Items.Add(o);
                }

            }

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (cbOprema.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati opremu");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbBrojSati.Text) || !tbBrojSati.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite broj sati i broj sati mora da bude broj!!!");
                tbBrojSati.Focus();
                return;
            }

            OpremaPregled izabranaOprema = (OpremaPregled)cbOprema.SelectedItem;

            OpremaBasic oprema = new OpremaBasic();

            oprema.Id = izabranaOprema.Id;
            oprema.Naziv = izabranaOprema.Naziv;

            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);

            DateTime? datumDo = null;

            if (dtpDatumDo.Checked)
            {
                datumDo = dtpDatumDo.Value;
            }

            AngazujeBasic angazujOpremu = new AngazujeBasic(
                    zadatak,oprema,dtpDatumOd.Value,datumDo,int.Parse(tbBrojSati.Text));

            DTOManager.dodajAngazuje(angazujOpremu);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
