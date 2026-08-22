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
    public partial class DodajUgovorForma : Form
    {
        public DodajUgovorForma()
        {
            InitializeComponent();
        }

        private void DodajUgovorForma_Load(object sender, EventArgs e)
        {
            rbProjekat.Checked = true;
            popuniProjekte();
        }

        private void popuniProjekte()
        {
            cbTipUgovora.Items.Clear();

            List<ProjekatPregled> projekti = DTOManager.vratiSveProjekte();

            foreach (ProjekatPregled p in projekti)
            {
                cbTipUgovora.Items.Add(p);
            }

            cbTipUgovora.DisplayMember = "Naziv";

            if (cbTipUgovora.Items.Count > 0)
                cbTipUgovora.SelectedIndex = 0;
        }

        private void popuniMaterijale()
        {
            cbTipUgovora.Items.Clear();

            List<MaterijalPregled> materijali = DTOManager.vratiSavMaterijal();

            foreach (MaterijalPregled m in materijali)
            {
                cbTipUgovora.Items.Add(m);
            }

            cbTipUgovora.DisplayMember = "Naziv";

            if (cbTipUgovora.Items.Count > 0)
                cbTipUgovora.SelectedIndex = 0;
        }

        private void popuniOpremu()
        {
            cbTipUgovora.Items.Clear();

            List<OpremaPregled> oprema = DTOManager.vratiSvuOpremu();

            foreach (OpremaPregled o in oprema)
            {
                cbTipUgovora.Items.Add(o);
            }

            cbTipUgovora.DisplayMember = "Naziv";

            if (cbTipUgovora.Items.Count > 0)
                cbTipUgovora.SelectedIndex = 0;
        }

        private void rbOprema_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOprema.Checked)
            {
                popuniOpremu();
            }
        }

        private void rbMaterijal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaterijal.Checked)
            {
                popuniMaterijale();
            }
        }

        private void rbProjekat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProjekat.Checked)
            {
                popuniProjekte();
            }
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPredmetUgovora.Text))
            {
                MessageBox.Show("Unesite predmet ugovora!");
                tbPredmetUgovora.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbVrednost.Text) || !tbVrednost.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite vrednost i vrednost mora da bude broj!");
                tbVrednost.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbValuta.Text))
            {
                MessageBox.Show("Unesite valutu!");
                tbValuta.Focus();
                return;
            }


            if (cbTipUgovora.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati tip ugovora.");
                return;
            }

            MaterijalBasic materijal = null;
            ProjekatBasic projekat = null;
            OpremaBasic oprema = null;

            if (rbProjekat.Checked)
            {
                ProjekatPregled p = (ProjekatPregled)cbTipUgovora.SelectedItem;

                projekat = new ProjekatBasic();
                projekat.ID = p.ID;
                projekat.Naziv = p.Naziv;
            }
            else if (rbMaterijal.Checked)
            {
                MaterijalPregled m = (MaterijalPregled)cbTipUgovora.SelectedItem;

                materijal = new MaterijalBasic();
                materijal.ID = m.ID;
                materijal.Naziv = m.Naziv;
            }
            else if (rbOprema.Checked)
            {
                OpremaPregled o = (OpremaPregled)cbTipUgovora.SelectedItem;

                oprema = new OpremaBasic();
                oprema.Id = o.Id;
                oprema.Naziv = o.Naziv;
            }
            else
            {
                MessageBox.Show("Izaberite tip ugovora.");
                return;
            }

            UgovorBasic ugovor = new UgovorBasic(
                0,dtpDatumPotpisivanja.Value,decimal.Parse(tbVrednost.Text),tbPredmetUgovora.Text,tbValuta.Text,dtpRok.Value,materijal,projekat,oprema);

            DTOManager.dodajUgovor(ugovor);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
