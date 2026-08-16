using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Forme
{
    public partial class DetaljiIndustrijskiForma : Form
    {
        private int IdIndustrijski;
        public DetaljiIndustrijskiForma(int idProjekta)
        {
            InitializeComponent();
            IdIndustrijski = idProjekta;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DetaljiIndustrijskiForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void popuniPodacima()
        {
            ProjekatBasic projekat = DTOManager.vratiProjekat(IdIndustrijski);

            if (projekat == null)
                return;

            lbNaziv.Text = projekat.Naziv;
            lbOpis.Text = projekat.Opis;
            lbLokacija.Text = projekat.Lokacija;
            lbBudzet.Text = projekat.Budzet.ToString();
            lbStatus.Text = projekat.Status;
            lbDatumPocetka.Text = projekat.Datum_pocetka.ToShortDateString();
            lbPlaniraniZavrsetak.Text = projekat.Planirani_zavrsetak.ToShortDateString();
            lbStvarniZavrsetak.Text = projekat.Stvarni_zavrsetak.ToShortDateString();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                List<UgovorBasic> ugovori = DTOManager.vratiUgovoreProjekta(IdIndustrijski);
                popuniPodacimaUgovora(ugovori);

            }
            else if (tabControl1.SelectedIndex == 2) 
            {
                List<BezbednosniIncidentBasic> bezbednosniIncidenti = DTOManager.vratiBezbednosniIncidenteProjekta(IdIndustrijski);
                popuniPodacimaBezbednosnihIncidenta(bezbednosniIncidenti);
            }
        }

        private void popuniPodacimaUgovora(List<UgovorBasic> ugovori)
        {
            Ugovori.Items.Clear();

            foreach (UgovorBasic u in ugovori)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        u.Id.ToString(),
                        u.DatumPotpisivanja.ToShortDateString(),
                        u.Vrednost.ToString(),
                        u.PredmetUgovora,
                        u.Valuta,
                        u.Rok.ToShortDateString(),

                    });

                Ugovori.Items.Add(item);
            }
            Ugovori.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Ugovori.Refresh();
        }
        private void popuniPodacimaBezbednosnihIncidenta(List<BezbednosniIncidentBasic> incidenti)
        {
            Incidenti.Items.Clear();

            foreach(BezbednosniIncidentBasic inc in incidenti)
            {
                ListViewItem item = new ListViewItem(
                     new string[]
                     {
                        inc.ID.ToString(),
                        inc.Opis,
                        inc.Datum.ToShortDateString(),
                        inc.Lokacija,
                        inc.Preduzete_mere,
                        inc.Posledice,
                        inc.Tip_incidenta

                     });

                Incidenti.Items.Add(item);
            }
            Incidenti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Incidenti.Refresh();
        }
    }
}
