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
    public partial class DetaljiUgovoraForma : Form
    {
        private int idUgovora;
        public DetaljiUgovoraForma(int id)
        {
            InitializeComponent();
            idUgovora = id;
        }

        private void DetaljiUgovoraForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void popuniUgovorneStrane(UgovorBasic ugovor)
        {
            ugovorneStrane.Items.Clear();

            foreach (ImaUgovornuStranuBasic i in ugovor.UgovorneStrane)
            {
                string osoba = "";

                if (i.Osoba != null)
                {
                    osoba = i.Osoba.Ime + " " + i.Osoba.Prezime;
                }

                ListViewItem item =
                    new ListViewItem(new string[]
                    {
                        i.Id.ToString(),
                        osoba,
                        i.Uloga
                    });

                ugovorneStrane.Items.Add(item);
            }

            ugovorneStrane.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            ugovorneStrane.Refresh();
        }

        private void popuniPosebneKlauzule(UgovorBasic ugovor)
        {
            posebneKlauzule.Items.Clear();

            foreach (PosebnaKlauzulaBasic p in ugovor.PosebneKlauzule)
            {

                ListViewItem item =
                    new ListViewItem(new string[]
                    {
                        p.Id.ToString(),
                        p.TekstKlauzule
                    });

                posebneKlauzule.Items.Add(item);
            }

            posebneKlauzule.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            posebneKlauzule.Refresh();
        }

        private void popuniPodacima()
        {
            UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);

            lbDatumPotpisivanja.Text = ugovor.DatumPotpisivanja.ToShortDateString();
            lbVrednost.Text = ugovor.Vrednost.ToString();
            lbPredmetUgovora.Text = ugovor.PredmetUgovora;
            lbValuta.Text = ugovor.Valuta;
            lbRok.Text = ugovor.Rok.ToShortDateString();

            if (ugovor.Projekat != null)
            {
                lbTipUgovora.Text = "Projekat:";
                lbNaziv.Text = ugovor.Projekat.Naziv;
            }
            else if (ugovor.Oprema != null)
            {
                lbTipUgovora.Text = "Oprema:";
                lbNaziv.Text = ugovor.Oprema.Naziv;
            }
            else if (ugovor.Materijal != null)
            {
                lbTipUgovora.Text = "Materijal:";
                lbNaziv.Text = ugovor.Materijal.Naziv;
            }


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);

            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                popuniUgovorneStrane(ugovor);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                popuniPosebneKlauzule(ugovor);
            }
        }

        private void btDodajUgovornuStranu_Click(object sender, EventArgs e)
        {
            using (DodajUgovornuStranuForma forma = new DodajUgovornuStranuForma(idUgovora))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);
                    popuniUgovorneStrane(ugovor);
                }
            }
        }

        private void btIzmeniUgovornuStranu_Click(object sender, EventArgs e)
        {
            ListView tabela = ugovorneStrane;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati ugovornu stranu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniUgovornuStranuForma forma = new IzmeniUgovornuStranuForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);
                    popuniUgovorneStrane(ugovor);
                }
            }
        }

        private void btObrisiUgovornuStranu_Click(object sender, EventArgs e)
        {
            ListView tabela = ugovorneStrane;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati ugovornu stranu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu ugovornu stranu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                ImaUgovorneStraneDTOManager.obrisiUgovornuStranu(id);
                MessageBox.Show("Brisanje ugovorne strane je uspesno obavljeno!");
                UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);
                popuniUgovorneStrane(ugovor);

            }
            else
            {

            }
        }

        private void btDodajKlauzulu_Click(object sender, EventArgs e)
        {
            using (DodajPosebnuKlauzuluForma forma = new DodajPosebnuKlauzuluForma(idUgovora))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);
                    popuniPosebneKlauzule(ugovor);
                }
            }
        }

        private void btizmeniKlauzulu_Click(object sender, EventArgs e)
        {
            ListView tabela = posebneKlauzule;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati posebnu klauzulu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniPosebnuKlauzuluForma forma = new IzmeniPosebnuKlauzuluForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);
                    popuniPosebneKlauzule(ugovor);
                }
            }
        }

        private void btObrisiPosebnuKlauzulu_Click(object sender, EventArgs e)
        {
            ListView tabela = posebneKlauzule;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati posebnu klauzulu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu posebnu klauzulu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                PosebnaKlauzulaDTOManager.obrisiPosebnuKlauzulu(id);
                MessageBox.Show("Brisanje posebne klauzule je uspesno obavljeno!");
                UgovorBasic ugovor = UgovorDTOManager.vratiUgovor(idUgovora);
                popuniPosebneKlauzule(ugovor);

            }
            else
            {

            }
        }
    }
}
