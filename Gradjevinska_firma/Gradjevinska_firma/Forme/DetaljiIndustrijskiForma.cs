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

            if (projekat.Stvarni_zavrsetak.HasValue)
                lbStvarniZavrsetak.Text = projekat.Stvarni_zavrsetak.Value.ToShortDateString();
            else
                lbStvarniZavrsetak.Text = "";
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
            else if(tabControl1.SelectedIndex == 3)
            {
                List<FakturaBasic> fakture = DTOManager.vratiFaktureProjekta(IdIndustrijski);
                popuniPodacimaFakture(fakture);
            }
            else if(tabControl1.SelectedIndex == 4)
            {
                List<FazaBasic> faze = DTOManager.vratiFazeProjekta(IdIndustrijski);
                popuniPodacimaFaza(faze);
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
                        u.DatumPotpisivanja.ToShortDateString(),
                        u.Id.ToString(),
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

        private void popuniPodacimaFakture(List<FakturaBasic> fakture)
        {
            Fakture.Items.Clear();

            foreach (FakturaBasic f in fakture)
            {
                ListViewItem item = new ListViewItem(
                     new string[]
                     {
                        f.Br_fakture.ToString(),
                        f.Iznos.ToString(),
                        f.Valuta,
                        f.StatusPlacanja.ToString(),
                        f.Datum.ToShortDateString()

                     });

                Fakture.Items.Add(item);
            }
            Fakture.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Fakture.Refresh();
        }

        private void popuniPodacimaFaza(List<FazaBasic> faze)
        {
            Faze.Items.Clear();

            foreach(FazaBasic f in faze)
            {
                ListViewItem item = new ListViewItem(
                     new string[]
                     {
                        f.Id.ToString(),
                        f.Naziv,
                        f.DatumOd.ToShortDateString(),
                        f.DatumDo.HasValue ? f.DatumDo.Value.ToShortDateString() : "",
                        f.Status,
                        f.Budzet.ToString()
                     });
                Faze.Items.Add(item);
            }
            Faze.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Faze.Refresh();
        }
    }

}
