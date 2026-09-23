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
using Gradjevinska_firma.DTOManager;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Forme
{
    public partial class DetaljiStambeniForma : Form
    {
        private int idStambeni;
        public DetaljiStambeniForma(int idStambeni)
        {
            InitializeComponent();
            this.idStambeni = idStambeni;
        }

        public void popuniPodacima()
        {
            ProjekatBasic projekat = ProjekatDTOManager.vratiProjekat(idStambeni);

            if (projekat == null)
                return;

            lbNaziv.Text = projekat.Naziv;
            lbOpis.Text = projekat.Opis;
            lbLokacija.Text = projekat.Lokacija;
            lbBudzet.Text = projekat.Budzet.ToString();
            lbStatus.Text = projekat.Status;
            lbDatumPocetka.Text = projekat.Datum_pocetka.ToShortDateString();
            lbPlaniraniZavrsetak.Text = projekat.Planirani_zavrsetak.ToShortDateString();
            lblTrosak.Text = projekat.Trosak.ToString();

            if (projekat.Stvarni_zavrsetak.HasValue)
                lbStvarniZavrsetak.Text = projekat.Stvarni_zavrsetak.Value.ToShortDateString();
            else
                lbStvarniZavrsetak.Text = "";
        }

        private void DetaljiStambeniForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void popuniPodacimaBezbednosnihIncidenta(List<BezbednosniIncidentBasic> incidenti)
        {
            Incidenti.Items.Clear();

            foreach (BezbednosniIncidentBasic inc in incidenti)
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

            foreach (FazaBasic f in faze)
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

        private void popuniPodacimaNabavke(List<NabavkeBasic> nabavke)
        {
            Nabavke.Items.Clear();

            foreach (NabavkeBasic n in nabavke)
            {
                ListViewItem item = new ListViewItem(
                     new string[]
                     {
                         n.Br_nabavke.ToString(),
                         n.Datum.ToShortDateString(),
                         n.Dobavljac.Ime.ToString() + " " + n.Dobavljac.Prezime.ToString()
                     });
                Nabavke.Items.Add(item);
            }
            Nabavke.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Nabavke.Refresh();
        }

        private void popuniPodacimaStambenihObjekata(List<ObjekatStambeniBasic> objekti)
        {
            StambeniObjekti.Items.Clear();

            foreach (ObjekatStambeniBasic n in objekti)
            {
                ListViewItem item = new ListViewItem(
                     new string[]
                     {
                         n.ID.ToString(),
                         n.Br_objekta.ToString(),
                         n.Spratnost.ToString(),
                         n.Br_jedinica.ToString()
                     });
                StambeniObjekti.Items.Add(item);
            }
            StambeniObjekti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.StambeniObjekti.Refresh();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                List<NabavkeBasic> nabavke = NabavkeDTOManager.vratiNabavkeProjekta(idStambeni);
                popuniPodacimaNabavke(nabavke);

            }
            else if (tabControl1.SelectedIndex == 2)
            {
                List<BezbednosniIncidentBasic> bezbednosniIncidenti = BezbednosniIncidentDTOManager.vratiBezbednosniIncidenteProjekta(idStambeni);
                popuniPodacimaBezbednosnihIncidenta(bezbednosniIncidenti);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                List<FakturaBasic> fakture = FakturaDTOManager.vratiFaktureProjekta(idStambeni);
                popuniPodacimaFakture(fakture);
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                List<FazaBasic> faze = FazaDTOManager.vratiFazeProjekta(idStambeni);
                popuniPodacimaFaza(faze);
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                List<ObjekatStambeniBasic> objekti = ProjekatDTOManager.vratiObjekteStambene(idStambeni);
                popuniPodacimaStambenihObjekata(objekti);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            using (DodajBezbednosniIncidentForma forma = new DodajBezbednosniIncidentForma(idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<BezbednosniIncidentBasic> incidenti = BezbednosniIncidentDTOManager.vratiBezbednosniIncidenteProjekta(idStambeni);
                    popuniPodacimaBezbednosnihIncidenta(incidenti);
                }
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            ListView tabela = Incidenti;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati bezbednosni incident iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniBezbednosniIncidentForma forma = new IzmeniBezbednosniIncidentForma(id, idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<BezbednosniIncidentBasic> incidenti = BezbednosniIncidentDTOManager.vratiBezbednosniIncidenteProjekta(idStambeni);
                    popuniPodacimaBezbednosnihIncidenta(incidenti);
                }
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            ListView tabela = Incidenti;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati incident iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani incident?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                BezbednosniIncidentDTOManager.obrisiBezbednosniIncident(id);
                MessageBox.Show("Brisanje incidenta je uspesno obavljeno!");
                List<BezbednosniIncidentBasic> inc = BezbednosniIncidentDTOManager.vratiBezbednosniIncidenteProjekta(idStambeni);
                popuniPodacimaBezbednosnihIncidenta(inc);

            }
            else
            {

            }
        }

        private void btnDodajFakturu_Click(object sender, EventArgs e)
        {
            using (DodajFakturuForma forma = new DodajFakturuForma(idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<FakturaBasic> fakture = FakturaDTOManager.vratiFaktureProjekta(idStambeni);
                    popuniPodacimaFakture(fakture);
                }
            }
        }

        private void btnIzmeniFakturu_Click(object sender, EventArgs e)
        {
            ListView tabela = Fakture;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati fakturu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniFakturuForma forma = new IzmeniFakturuForma(id, idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<FakturaBasic> fak = FakturaDTOManager.vratiFaktureProjekta(idStambeni);
                    popuniPodacimaFakture(fak);
                }
            }
        }

        private void btnObrisiFakturu_Click(object sender, EventArgs e)
        {
            ListView tabela = Fakture;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati fakturu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu fakturu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                FakturaDTOManager.obrisiFakturu(id);
                MessageBox.Show("Brisanje fakture je uspesno obavljeno!");
                List<FakturaBasic> fak = FakturaDTOManager.vratiFaktureProjekta(idStambeni);
                popuniPodacimaFakture(fak);

            }
            else
            {

            }
        }

        private void btnDodajFazu_Click(object sender, EventArgs e)
        {
            using (DodajFazuForma forma = new DodajFazuForma(idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<FazaBasic> faze = FazaDTOManager.vratiFazeProjekta(idStambeni);
                    popuniPodacimaFaza(faze);
                }
            }
        }

        private void btnIzmeniFazu_Click(object sender, EventArgs e)
        {
            ListView tabela = Faze;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati fazu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniFazuForma forma = new IzmeniFazuForma(id, idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<FazaBasic> faz = FazaDTOManager.vratiFazeProjekta(idStambeni);
                    popuniPodacimaFaza(faz);
                }
            }
        }

        private void btnObrisiFazu_Click(object sender, EventArgs e)
        {
            ListView tabela = Faze;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati fazu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu fazu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                FazaDTOManager.obrisiFazu(id);
                MessageBox.Show("Brisanje faze je uspesno obavljeno!");
                List<FazaBasic> faz = FazaDTOManager.vratiFazeProjekta(idStambeni);
                popuniPodacimaFaza(faz);

            }
            else
            {

            }
        }

        private void btnDodajNabavku_Click(object sender, EventArgs e)
        {
            using (DodajNabavkuProjektaForma forma = new DodajNabavkuProjektaForma(idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<NabavkeBasic> nab = NabavkeDTOManager.vratiNabavkeProjekta(idStambeni);
                    popuniPodacimaNabavke(nab);
                }
            }
        }

        private void btnIzmeniNabavku_Click(object sender, EventArgs e)
        {
            ListView tabela = Nabavke;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniNabavkuProjektaForma forma = new IzmeniNabavkuProjektaForma(id, idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<NabavkeBasic> nab = NabavkeDTOManager.vratiNabavkeProjekta(idStambeni);
                    popuniPodacimaNabavke(nab);
                }
            }
        }

        private void btnObrisiNabavku_Click(object sender, EventArgs e)
        {
            ListView tabela = Nabavke;

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
                NabavkeDTOManager.obrisiNabavku(id);
                MessageBox.Show("Brisanje nabavke je uspesno obavljeno!");
                List<NabavkeBasic> nab = NabavkeDTOManager.vratiNabavkeProjekta(idStambeni);
                popuniPodacimaNabavke(nab);

            }
            else
            {

            }
        }

        public void popuniNabavke()
        {
            this.Nabavke.Items.Clear();
            List<NabavkePregled> nabavke = NabavkeDTOManager.vratiSveNabavke();

            foreach (NabavkePregled n in nabavke)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   n.Br_nabavke.ToString(),
                   n.Datum.ToShortDateString(),
                   n.Projekat.Naziv

                   });
                this.Nabavke.Items.Add(item);

            }
            this.Nabavke.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Nabavke.Refresh();
        }
        private void btnDetaljiNabavke_Click(object sender, EventArgs e)
        {
            ListView tabela = Nabavke;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (DetaljiNabavkeForma forma = new DetaljiNabavkeForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniNabavke();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (DodajStambeniObjekatForma forma = new DodajStambeniObjekatForma(idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<ObjekatStambeniBasic> obj = ProjekatDTOManager.vratiObjekteStambene(idStambeni);
                    popuniPodacimaStambenihObjekata(obj);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListView tabela = StambeniObjekti;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati stambeni objekat iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniStambeniObjekatForma forma = new IzmeniStambeniObjekatForma(id, idStambeni))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    List<ObjekatStambeniBasic> obj = ProjekatDTOManager.vratiObjekteStambene(idStambeni);
                    popuniPodacimaStambenihObjekata(obj);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListView tabela = StambeniObjekti;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati stambeni objekat iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani stambeni objekat?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                ProjekatDTOManager.obrisiStambeniObjekat(id);
                MessageBox.Show("Brisanje stambenog objekta je uspesno obavljeno!");
                List<ObjekatStambeniBasic> nab = ProjekatDTOManager.vratiObjekteStambene(idStambeni);
                popuniPodacimaStambenihObjekata(nab);

            }
            else
            {

            }
        }
    }
}
