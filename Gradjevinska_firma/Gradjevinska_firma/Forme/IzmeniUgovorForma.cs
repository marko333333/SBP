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
    public partial class IzmeniUgovorForma : Form
    {
        private int idUgovor;
        public IzmeniUgovorForma(int id)
        {
            InitializeComponent();
            idUgovor = id;
        }

        private void IzmeniUgovorForma_Load(object sender, EventArgs e)
        {
            rbMaterijal.Checked = false;
            rbOprema.Checked = false;
            rbProjekat.Checked = false;

            UgovorBasic ugovor = DTOManager.vratiUgovor(idUgovor);

            dtpDatumPotpisivanja.Value = ugovor.DatumPotpisivanja;
            tbVrednost.Text = ugovor.Vrednost.ToString();
            tbPredmetUgovora.Text = ugovor.PredmetUgovora;
            tbValuta.Text = ugovor.Valuta;
            dtpRok.Value = ugovor.Rok;

            if (ugovor.Projekat != null)
            {
                rbProjekat.Checked = true;

                popuniProjekte();
                izaberiProjekat(ugovor.Projekat.ID);
            }
            else if (ugovor.Materijal != null)
            {
                rbMaterijal.Checked = true;

                popuniMaterijale();
                izaberiMaterijal(ugovor.Materijal.ID);
            }
            else if (ugovor.Oprema != null)
            {
                rbOprema.Checked = true;

                popuniOpremu();
                izaberiOpremu(ugovor.Oprema.Id);
            }

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

        private void izaberiProjekat(int idProjekta)
        {
            for (int i = 0; i < cbTipUgovora.Items.Count; i++)
            {
                ProjekatPregled p = (ProjekatPregled)cbTipUgovora.Items[i];

                if (p.ID == idProjekta)
                {
                    cbTipUgovora.SelectedIndex = i;
                    break;
                }
            }
        }

        private void izaberiOpremu(int idOprema)
        {
            for (int i = 0; i < cbTipUgovora.Items.Count; i++)
            {
                OpremaPregled p = (OpremaPregled)cbTipUgovora.Items[i];

                if (p.Id == idOprema)
                {
                    cbTipUgovora.SelectedIndex = i;
                    break;
                }
            }
        }

        private void izaberiMaterijal(int idMaterijal)
        {
            for (int i = 0; i < cbTipUgovora.Items.Count; i++)
            {
                MaterijalPregled p = (MaterijalPregled)cbTipUgovora.Items[i];

                if (p.ID == idMaterijal)
                {
                    cbTipUgovora.SelectedIndex = i;
                    break;
                }
            }
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

        private void btIzmeni_Click(object sender, EventArgs e)
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
                idUgovor, dtpDatumPotpisivanja.Value, decimal.Parse(tbVrednost.Text), tbPredmetUgovora.Text, tbValuta.Text, dtpRok.Value, materijal, projekat, oprema);

            DTOManager.izmeniUgovor(ugovor);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
