using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;
using Gradjevinska_firma.Mapiranja;
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

        private void popuniKoristi(ZadatakBasic zadatak)
        {
            koriscenje.Items.Clear();

            foreach (KoristiBasic k in zadatak.Koristi)
            {
                string materijal = "";
                if (k.Materijal != null)
                {
                    materijal = k.Materijal.Naziv;
                }

                ListViewItem item =
                    new ListViewItem(new string[]
                    {
                       k.ID.ToString(),
                       materijal,
                       k.Kolicina.ToString()

                    });
                koriscenje.Items.Add(item);
            }

            koriscenje.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            koriscenje.Refresh();
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
        private void popuniAngazuj(ZadatakBasic zadatak)
        {
            angazujeOpremu.Items.Clear();

            foreach (AngazujeBasic a in zadatak.AngazovanaOprema)
            {
                string oprema = "";
                if (a.Oprema != null)
                {
                    oprema = a.Oprema.Naziv;
                }

                ListViewItem item =
                    new ListViewItem(new string[]
                    {
                       oprema,
                        a.DatumOd.ToShortDateString(),
                        a.DatumDo.HasValue ? a.DatumDo.Value.ToShortDateString() : "",
                        a.BrojSati.ToString()
                    });
                item.Tag = a;
                angazujeOpremu.Items.Add(item);
            }

            angazujeOpremu.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            angazujeOpremu.Refresh();
        }
        private void popuniAngazovanja(ZadatakBasic zadatak)
        {
            angazovaneOsobe.Items.Clear();

            foreach (AngazovanBasic a in zadatak.Angazovani)
            {
                string osoba = "";
                string idOsobe = "";
                if (a.Osoba != null)
                {
                    osoba = a.Osoba.Ime + " " + a.Osoba.Prezime;
                }

                ListViewItem item =
                    new ListViewItem(new string[]
                    {
                        osoba,
                        a.DatumOd.ToShortDateString(),
                        a.DatumDo.HasValue ? a.DatumDo.Value.ToShortDateString() : "",
                        a.StatusAngazovanja
                    });
                item.Tag = a;
                angazovaneOsobe.Items.Add(item);
            }

            angazovaneOsobe.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            angazovaneOsobe.Refresh();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                popuniPodzadacima(zadatak);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                popuniRadneNaloge(zadatak);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                popuniNapretke(zadatak);
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                popuniKontroluKvaliteta(zadatak);
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                popuniAngazovanja(zadatak);
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                popuniAngazuj(zadatak);
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                popuniKoristi(zadatak);
            }
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

            using (StavkeKontroleForma forma = new StavkeKontroleForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniKontroluKvaliteta(zadatak);
                }
            }
        }

        private void btObrisiRadniNalog_Click(object sender, EventArgs e)
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
            string poruka = "Da li zelite da obrisete izabrani radni nalog?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiRadniNalog(id);
                MessageBox.Show("Brisanje radni naloga je uspesno obavljeno!");
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniRadneNaloge(zadatak);

            }
            else
            {

            }
        }

        private void btObrisiNapredak_Click(object sender, EventArgs e)
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
            string poruka = "Da li zelite da obrisete izabrani napredak?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiNapredak(id);
                MessageBox.Show("Brisanje napretka je uspesno obavljeno!");
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniNapretke(zadatak);

            }
            else
            {

            }
        }

        private void btObrisiKontrolu_Click(object sender, EventArgs e)
        {
            ListView tabela = kontrolaKvaliteta;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati kontrolu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu kontrolu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKontrolu(id);
                MessageBox.Show("Brisanje kontrole je uspesno obavljeno!");
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniKontroluKvaliteta(zadatak);

            }
            else
            {

            }
        }

        private void btFotografije_Click(object sender, EventArgs e)
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

            using (FotografijeForma forma = new FotografijeForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniNapretke(zadatak);
                }
            }
        }

        private void btObrisi_Click(object sender, EventArgs e)
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
            string poruka = "Da li zelite da obrisete izabrani podzadatak?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiPodzadatak(id);
                MessageBox.Show("Brisanje podzadatka je uspesno obavljeno!");
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniPodzadacima(zadatak);

            }
            else
            {

            }
        }

        private void btDodajAngazovanje_Click(object sender, EventArgs e)
        {
            using (DodajAngazovanForma forma = new DodajAngazovanForma(idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniAngazovanja(zadatak);
                }
            }
        }

        private void btObrisiAngazovanje_Click(object sender, EventArgs e)
        {
            ListView tabela = angazovaneOsobe;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati angazovanje iz tabele.");
                return;
            }

            ListViewItem item = angazovaneOsobe.SelectedItems[0];

            AngazovanBasic angazovanje = (AngazovanBasic)item.Tag;

            int idOsobe = angazovanje.Osoba.Id;

            string poruka = "Da li zelite da obrisete izabrano angazovanje?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiAngazovanje(idZadatka, idOsobe);
                MessageBox.Show("Brisanje angazovanja je uspesno obavljeno!");
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniAngazovanja(zadatak);

            }
            else
            {

            }
        }

        private void btIzmeniAngazovanje_Click(object sender, EventArgs e)
        {
            ListView tabela = angazovaneOsobe;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati angazovanje iz tabele.");
                return;
            }

            ListViewItem item = angazovaneOsobe.SelectedItems[0];

            AngazovanBasic angazovanje = (AngazovanBasic)item.Tag;

            int idOsobe = angazovanje.Osoba.Id;

            using (IzmeniAngazovanjeForma forma = new IzmeniAngazovanjeForma(idOsobe, idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniAngazovanja(zadatak);
                }
            }
        }

        private void btDodajAngazuj_Click(object sender, EventArgs e)
        {
            using (AngazujOpremu forma = new AngazujOpremu(idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniAngazovanja(zadatak);
                }
            }
        }

        private void btIzmeniAngazuj_Click(object sender, EventArgs e)
        {
            ListView tabela = angazujeOpremu;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati opremu iz tabele.");
                return;
            }

            ListViewItem item = angazujeOpremu.SelectedItems[0];

            AngazujeBasic angazovanje = (AngazujeBasic)item.Tag;

            int idOprema = angazovanje.Oprema.Id;

            using (IzmeniAngazujForma forma = new IzmeniAngazujForma(idOprema, idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniAngazuj(zadatak);
                }
            }
        }

        private void btObrisiAngazuj_Click(object sender, EventArgs e)
        {
            ListView tabela = angazujeOpremu;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati opremu iz tabele.");
                return;
            }

            ListViewItem item = angazujeOpremu.SelectedItems[0];

            AngazujeBasic angazuje = (AngazujeBasic)item.Tag;

            int idOprema = angazuje.Oprema.Id;

            string poruka = "Da li zelite da obrisete izabranu opremu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiAngazuje(idZadatka, idOprema);
                MessageBox.Show("Brisanje opreme je uspesno obavljeno!");
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniAngazuj(zadatak);

            }
            else
            {

            }
        }

        private void btKoristiMaterijal_Click(object sender, EventArgs e)
        {
            using (DodajKoristiMaterijalForma forma = new DodajKoristiMaterijalForma(idZadatka))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniKoristi(zadatak);
                }
            }
        }

        private void btIzmeniKoriscenje_Click(object sender, EventArgs e)
        {
            ListView tabela = koriscenje;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniKoristiMaterijalForma forma = new IzmeniKoristiMaterijalForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                    popuniKoristi(zadatak);
                }
            }
        }

        private void btObrisiKoriscenje_Click(object sender, EventArgs e)
        {
            ListView tabela = koriscenje;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani materijal?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiKoristi(id);
                MessageBox.Show("Brisanje materijala je uspesno obavljeno!");
                ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
                popuniKoristi(zadatak);

            }
            else
            {

            }
        }
    }
}
