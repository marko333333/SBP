using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
    public partial class DetaljiNabavkeForma : Form
    {
        private int idNabavke;
        private NabavkeBasic nabavka;
        public DetaljiNabavkeForma(int id)
        {
            InitializeComponent();
            idNabavke = id;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                popuniOpremu(nabavka);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                popuniMaterijale(nabavka);
            }
        }

        private void DetaljiNabavkeForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void popuniPodacima()
        {
            NabavkeBasic nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);

            lbDatum.Text = nabavka.Datum.ToString();
            lbProjekat.Text = nabavka.Projekat.Naziv;
        }
        private void popuniMaterijale(NabavkeBasic nabavka)
        {
            nabavkeMaterijal.Items.Clear();

            foreach (NabavkaMaterijalBasic nm in nabavka.NabavkaMaterijal)
            {
                string nazivMaterijala = "";

                if (nm.Materijal != null)
                    nazivMaterijala = nm.Materijal.Naziv;

                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        nm.ID.ToString(),
                        nazivMaterijala,
                        nm.Kolicina.ToString(),
                        nm.Cena.ToString(),
                        nm.Status_isporuke ? "Isporuceno" : "Nije isporuceno"
                    });

                nabavkeMaterijal.Items.Add(item);
            }

            nabavkeMaterijal.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            nabavkeMaterijal.Refresh();
        }

        private void popuniOpremu(NabavkeBasic nabavka)
        {
            nabavkeOprema.Items.Clear();

            foreach (NabavkaOpremaBasic no in nabavka.NabavkaOprema)
            {
                string nazivOpreme = "";

                if (no.Oprema != null)
                    nazivOpreme = no.Oprema.Naziv;

                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        no.ID.ToString(),
                        nazivOpreme,
                        no.Kolicina.ToString(),
                        no.Cena.ToString(),
                        no.Status_isporuke ? "Isporuceno" : "Nije isporuceno"
                    });

                nabavkeOprema.Items.Add(item);
            }

            nabavkeOprema.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            nabavkeOprema.Refresh();
        }

        private void btDodajNabavkuOprema_Click(object sender, EventArgs e)
        {
            using (DodajNabavkuOpremaForma forma = new DodajNabavkuOpremaForma(idNabavke))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
                    popuniOpremu(nabavka);
                }
            }
        }

        private void btObrisiNabavkuOprema_Click(object sender, EventArgs e)
        {
            ListView tabela = nabavkeOprema;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu nabavku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                NabavkeDTOManager.obrisiNabavkaOprema(id);
                MessageBox.Show("Brisanje nabavke je uspesno obavljeno!");
                nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
                popuniOpremu(nabavka);
            }
        }

        private void btDodajNabavkuMaterijal_Click(object sender, EventArgs e)
        {
            using (DodajNabavkuMaterijalForma forma = new DodajNabavkuMaterijalForma(idNabavke))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
                    popuniMaterijale(nabavka);
                }
            }
        }

        private void btIzmeniNabavkuOprema_Click(object sender, EventArgs e)
        {
            ListView tabela = nabavkeOprema;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniNabavkuOpremaForma forma = new IzmeniNabavkuOpremaForma(id,idNabavke))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
                    popuniOpremu(nabavka);
                }
            }
        }

        private void btIzmeniNabavkuMaterijal_Click(object sender, EventArgs e)
        {
            ListView tabela = nabavkeMaterijal;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniNabavkuMaterijalForma forma = new IzmeniNabavkuMaterijalForma(id,idNabavke))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
                    popuniMaterijale(nabavka);
                }
            }
        }

        private void btObrisiNabavkuMaterijal_Click(object sender, EventArgs e)
        {
            ListView tabela = nabavkeMaterijal;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu nabavku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                NabavkeDTOManager.obrisiNabavkaMaterijal(id);
                MessageBox.Show("Brisanje nabavke je uspesno obavljeno!");
                nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);
                popuniMaterijale(nabavka);
            }
        }
    }
}
