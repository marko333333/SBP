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
    public partial class DetaljiZadaciForma : Form
    {
        private int idZadatka;
        public DetaljiZadaciForma(int id)
        {
            InitializeComponent();

            idZadatka = id;
        }

        private void DetaljiZadaciForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void popuniPodacima()
        {
            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);

            if (zadatak == null)
                return;

            lbNaziv.Text = zadatak.Naziv;
            lbOpis.Text = zadatak.Opis;
            lbTrosak.Text = zadatak.ProcenjeniTrosak.ToString();
            lbPrioritet.Text = zadatak.Prioritet.ToString();
            lbStatus.Text = zadatak.Status;
            lbFaza.Text = zadatak.Faza.Naziv;
            if (zadatak.Roditelj == null)
                lbNadzadatak.Text = "";
            else
                lbNadzadatak.Text = zadatak.Roditelj.Naziv;
            
            lbPlaniraniPocetak.Text = zadatak.PlaniraniPocetak.ToShortDateString();
            
            lbPlaniraniZavrsetak.Text = zadatak.PlaniraniZavrsetak.ToShortDateString();

            if (zadatak.StvarniPocetak.HasValue)
                lbStvarniPocetak.Text = zadatak.StvarniPocetak.Value.ToShortDateString();
            else
                lbStvarniPocetak.Text = "";

            if (zadatak.StvarniZavrsetak.HasValue)
                lbStvarniZavrsetak.Text = zadatak.StvarniZavrsetak.Value.ToShortDateString();
            else
                lbStvarniZavrsetak.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniPodzadacima(zadatak);

            }
            else if (tabControl1.SelectedIndex == 2)
            {
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniRadneNaloge(zadatak);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniNapretke(zadatak);
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniKontroluKvaliteta(zadatak);
            }
        }

        private void popuniPodzadacima(ZadatakBasic zadatak)
        {
            podzadaci.Items.Clear();

            foreach (ZadatakBasic z in zadatak.Podzadaci)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        z.Id.ToString(),
                        z.Naziv
                    });

                podzadaci.Items.Add(item);
            }
            podzadaci.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.podzadaci.Refresh();
        }


        private void popuniRadneNaloge(ZadatakBasic zadatak)
        {
            radniNalozi.Items.Clear();

            foreach (RadniNalogBasic r in zadatak.RadniNalozi)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        r.BrNaloga.ToString(),
                        r.Status,
                        r.DatumIzdavanja.ToShortDateString()
                    });

                radniNalozi.Items.Add(item);
            }
            radniNalozi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.radniNalozi.Refresh();
        }

        private void popuniNapretke(ZadatakBasic zadatak)
        {
            napreci.Items.Clear();

            foreach (NapredakBasic n in zadatak.Napreci)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        n.Id.ToString(),
                        n.Datum.ToShortDateString(),
                        n.DnevniIzvestaj,
                        n.ProcenatRealizacije.ToString(),
                        n.PrimedbaNadzora,
                        n.KorektivnaMera
                    });

                napreci.Items.Add(item);
            }
            napreci.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.napreci.Refresh();
        }

        private void popuniKontroluKvaliteta(ZadatakBasic zadatak)
        {
            kontrolaKvaliteta.Items.Clear();

            foreach (KontrolaKvalitetaBasic n in zadatak.KontroleKvaliteta)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        n.Id.ToString(),
                        n.DatumInspekcije.ToShortDateString(),
                        n.PrimedbeNadzora,
                        n.Zapisnik,
                        n.ZabranaNastavkaRadova.ToString(),
                        n.RazlogZabrane,
                        n.DatumOtklanjanjaZabrane.HasValue ? n.DatumOtklanjanjaZabrane.Value.ToShortDateString() : ""

                    });

                kontrolaKvaliteta.Items.Add(item);
            }
            kontrolaKvaliteta.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.kontrolaKvaliteta.Refresh();
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            using (DodajPodzadatakForma forma = new DodajPodzadatakForma(idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniPodzadacima(zadatak);
                }
            }
        }

        private void btDodajRadniNalog_Click(object sender, EventArgs e)
        {
            using (DodajRadniNalogForma forma = new DodajRadniNalogForma(idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniRadneNaloge(zadatak);
                }
            }
        }

        private void btDodajNapredak_Click(object sender, EventArgs e)
        {
            using (DodajNapredakForma forma = new DodajNapredakForma(idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniNapretke(zadatak);
                }
            }
        }

        private void btDodajKontrolu_Click(object sender, EventArgs e)
        {
            using (DodajKontroluKvalitetaForma forma = new DodajKontroluKvalitetaForma(idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniKontroluKvaliteta(zadatak);
                }
            }
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            ListView tabela = podzadaci;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati podzadatak iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniPodzadatakForma forma = new IzmeniPodzadatakForma(id, idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniPodzadacima(zadatak);
                }
            }
        }

        private void btIzmeniRadniNalog_Click(object sender, EventArgs e)
        {
            ListView tabela = radniNalozi;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati radni nalog iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniRadniNalogForma forma = new IzmeniRadniNalogForma(id, idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniRadneNaloge(zadatak);
                }
            }
        }

        private void btIzmeniNapredak_Click(object sender, EventArgs e)
        {
            ListView tabela = napreci;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati napredak iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniNapredakForma forma = new IzmeniNapredakForma(id, idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniNapretke(zadatak);
                }
            }
        }

        private void btIzmeniKontrolu_Click(object sender, EventArgs e)
        {
            ListView tabela = kontrolaKvaliteta;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati kontrolu kvaliteta iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniKontroluForma forma = new IzmeniKontroluForma(id, idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniKontroluKvaliteta(zadatak);
                }
            }
        }

        private void btStavkaKontrole_Click(object sender, EventArgs e)
        {
            ListView tabela = kontrolaKvaliteta;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati kontrolu kvaliteta iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (StavkeKontroleForma forma = new StavkeKontroleForma(id, idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniKontroluKvaliteta(zadatak);
                }
            }
        }
    }
}
