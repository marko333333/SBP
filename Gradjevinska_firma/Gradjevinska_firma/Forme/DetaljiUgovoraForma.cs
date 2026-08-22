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
            UgovorBasic ugovor = DTOManager.vratiUgovor(idUgovora);

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
            UgovorBasic ugovor = DTOManager.vratiUgovor(idUgovora);

            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                popuniUgovorneStrane(ugovor);
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                popuniPosebneKlauzule(ugovor);
            }
        }
    }
}
