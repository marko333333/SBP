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
        public DetaljiNabavkeForma(int id)
        {
            InitializeComponent();
            idNabavke = id;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                popuniOpremu();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                popuniMaterijale();
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
        private void popuniMaterijale()
        {
            nabavkeMaterijal.Items.Clear();

            List<NabavkaMaterijalPregled> lista = NabavkeDTOManager.vratiNabavkeMaterijala(idNabavke);

            foreach (NabavkaMaterijalPregled nm in lista)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        nm.ID.ToString(),
                        nm.Materijal.Naziv,
                        nm.Kolicina.ToString(),
                        nm.Cena.ToString(),
                        nm.Status_isporuke? "Isporuceno" : "Nije isporuceno"
                    });

                nabavkeMaterijal.Items.Add(item);
            }

            nabavkeMaterijal.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            nabavkeMaterijal.Refresh();
        }

        private void popuniOpremu()
        {
            nabavkeOprema.Items.Clear();

            List<NabavkaOpremaPregled> lista = NabavkeDTOManager.vratiNabavkeOpreme(idNabavke);

            foreach (NabavkaOpremaPregled no in lista)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        no.ID.ToString(),
                        no.Oprema.Naziv,
                        no.Kolicina.ToString(),
                        no.Cena.ToString(),
                        no.Status_isporuke ? "Isporuceno" : "Nije isporuceno"
                    });

                nabavkeOprema.Items.Add(item);
            }

            nabavkeOprema.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            nabavkeOprema.Refresh();
        }


    }
}
