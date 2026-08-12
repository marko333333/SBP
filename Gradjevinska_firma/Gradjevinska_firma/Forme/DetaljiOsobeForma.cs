using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;
using NHibernate.Cfg.MappingSchema;
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
    public partial class DetaljiOsobeForma : Form
    {
        private int idOsobe;
        public DetaljiOsobeForma(int id)
        {
            InitializeComponent();

            idOsobe = id;
        }

        private void DetaljiOsobeForma_Load(object sender, EventArgs e)
        {

            gbFizickoLice.Enabled = false;
            gbPravnoLice.Enabled = false;
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            popuniPodacima();
            FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
            if (fizicko != null)
            {
                tabControl1.TabPages.Add(tabPage5);
                tabControl1.TabPages.Add(tabPage6);
                tabControl1.TabPages.Add(tabPage7);

                if (fizicko.FlagR)
                    tabControl1.TabPages.Add(tabPage8);
            }
        }

        private void lbIme_Click(object sender, EventArgs e)
        {

        }
        private void popuniPodacima()
        {
            OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);

            if (osoba == null)
                return;

            lbJmbg.Text = osoba.Jmbg.ToString();
            lbIme.Text = osoba.Ime;
            lbPrezime.Text = osoba.Prezime;
            lbDatumRodjenja.Text = osoba.DatumRodjenja.ToShortDateString();
            lbStruka.Text = osoba.Struka;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                popuniPodacima();
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                gbFizickoLice.Visible = false;
                gbPravnoLice.Visible = false;

                lbK.Visible = false;
                lbKvalifikacija.Visible = false;
                lbOR.Visible = false;
                lbOblastRada.Visible = false;
                lbO.Visible = false;
                lbOdgovornosti.Visible = false;

                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);

                if (fizicko != null)
                {
                    gbFizickoLice.Visible = true;

                    cbBK.Checked = fizicko.FlagBK;
                    cbRadnik.Checked = fizicko.FlagR;
                    if (cbRadnik.Checked)
                    {
                        lbK.Visible = true;
                        lbKvalifikacija.Visible = true;
                        lbKvalifikacija.Text = fizicko.Kvalifikacija;
                    }
                    cbInzenjer.Checked = fizicko.FlagI;
                    if (cbInzenjer.Checked)
                    {
                        lbOR.Visible = true;
                        lbOblastRada.Visible = true;
                        lbO.Visible = true;
                        lbOdgovornosti.Visible = true;
                        lbOblastRada.Text = fizicko.OblastRada;
                        lbOdgovornosti.Text = fizicko.Odgovornosti;
                    }

                    cbArhitekta.Checked = fizicko.FlagA;
                    cbPoslovodja.Checked = fizicko.FlagP;
                    cbNadzorniOrgan.Checked = fizicko.FlagN;
                    cbAO.Checked = fizicko.FlagAO;

                }
                else
                {
                    PravnaLicaBasic pravno = DTOManager.vratiPravnoLice(idOsobe);

                    if (pravno != null)
                    {
                        gbPravnoLice.Visible = true;

                        cbPB.Checked = pravno.FlagPB;
                        cbInvenstitor.Checked = pravno.FlagInve;
                        cbIzvodjac.Checked = pravno.FlagIzv;
                        cbPodizvodjac.Checked = pravno.FlagP;
                        cbDobavljaci.Checked = pravno.FlagD;
                        cbNO.Checked = pravno.FlagN;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                popuniKontakte(osoba);
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                popuniLicence(osoba);
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
                if (fizicko != null)
                    popuniBezbednosneObuke(fizicko);
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
                if (fizicko != null)
                    popuniLekPregled(fizicko);
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
                if (fizicko != null)
                    popuniZastitnaOprema(fizicko);
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
                if (fizicko != null)
                    popuniSertifikatSpec(fizicko);
            }

        }
        private void popuniKontakte(OsobaBasic osoba)
        {
            kontakti.Items.Clear();

            foreach (KontaktBasic k in osoba.Kontakti)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                k.Id.ToString(),
                k.Broj
                    });

                kontakti.Items.Add(item);
            }
            kontakti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.kontakti.Refresh();
        }

        private void popuniLicence(OsobaBasic osoba)
        {
            licence.Items.Clear();

            foreach (LicencaBasic l in osoba.Licence)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                l.Id.ToString(),
                l.NazivLicence
                    });

                licence.Items.Add(item);
            }
            licence.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.licence.Refresh();
        }
        private void popuniBezbednosneObuke(FizickoLiceBasic fizicko)
        {
            bezObuke.Items.Clear();

            foreach (BezbednosnaObukaBasic b in fizicko.BezbednosneObuke)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        b.Id.ToString(),
                        b.Datum.ToShortDateString(),
                        b.NazivObuke
                    });

                bezObuke.Items.Add(item);
            }
            bezObuke.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.bezObuke.Refresh();
        }

        private void popuniLekPregled(FizickoLiceBasic fizicko)
        {
            lekpregledi.Items.Clear();

            foreach (LekarskiPregledBasic lp in fizicko.LekarskiPregledi)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                   lp.Id.ToString(),
                   lp.Rezultat,
                   lp.Datum.ToShortDateString()
                    });

                lekpregledi.Items.Add(item);
            }
            lekpregledi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.lekpregledi.Refresh();
        }
        private void popuniZastitnaOprema(FizickoLiceBasic fizicko)
        {
            zastitnaoprema.Items.Clear();

            foreach (ZastitnaOpremaBasic zo in fizicko.ZastitneOpreme)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                   zo.Id.ToString(),
                   zo.NazivOpreme

                    });

                zastitnaoprema.Items.Add(item);
            }
            zastitnaoprema.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.zastitnaoprema.Refresh();
        }

        private void popuniSertifikatSpec(FizickoLiceBasic fizicko)
        {
            sertifikatiSpec.Items.Clear();

            foreach (SertifikatSpecOpremeBasic sso in fizicko.SertifikatiSpecOpreme)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                   sso.Id.ToString(),
                   sso.Sertifikat
                    });

                sertifikatiSpec.Items.Add(item);
            }
            sertifikatiSpec.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.sertifikatiSpec.Refresh();
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btDodajKontakt_Click(object sender, EventArgs e)
        {
            using (DodajKontaktForma forma = new DodajKontaktForma(idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                    popuniKontakte(osoba);
                }
            }
        }

        private void btDodajLicencu_Click(object sender, EventArgs e)
        {
            using (DodajLicencuForma forma = new DodajLicencuForma(idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                    popuniLicence(osoba);
                }
            }
        }

        private void btDodajObuku_Click(object sender, EventArgs e)
        {
            using (DodajObukuForma forma = new DodajObukuForma(idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniBezbednosneObuke(osoba);
                }
            }
        }

        private void btDodajLekPregled_Click(object sender, EventArgs e)
        {
            using (DodajLekPregledForma forma = new DodajLekPregledForma(idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniLekPregled(osoba);
                }
            }
        }

        private void btDodajZasOpremu_Click(object sender, EventArgs e)
        {
            using (DodajZastitnuOpremuForma forma = new DodajZastitnuOpremuForma(idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniZastitnaOprema(osoba);
                }
            }
        }

        private void btDodajSertifikat_Click(object sender, EventArgs e)
        {
            using (DodajSertifikatSpecOpremeForma forma = new DodajSertifikatSpecOpremeForma(idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniSertifikatSpec(osoba);
                }
            }
        }

        private void btIzmeniKontakt_Click(object sender, EventArgs e)
        {
            ListView tabela = kontakti;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati kontakt iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniKontaktForma forma = new IzmeniKontaktForma(id, idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                    popuniKontakte(osoba);
                }
            }
        }

        private void btIzmeniLicencu_Click(object sender, EventArgs e)
        {
            ListView tabela = licence;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati licencu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniLicencuForma forma = new IzmeniLicencuForma(id, idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                    popuniLicence(osoba);
                }
            }
        }

        private void btIzmeniObuku_Click(object sender, EventArgs e)
        {
            ListView tabela = bezObuke;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati obuku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniObukuForma forma = new IzmeniObukuForma(id, idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniBezbednosneObuke(osoba);
                }
            }
        }

        private void btIzmeniLekPregled_Click(object sender, EventArgs e)
        {
            ListView tabela = lekpregledi;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati lekarski pregled iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniLekPregledForma forma = new IzmeniLekPregledForma(id, idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniLekPregled(osoba);
                }
            }
        }

        private void btIzmeniZasOpremu_Click(object sender, EventArgs e)
        {
            ListView tabela = zastitnaoprema;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati zastitnu opremu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniZastitnuOpremuForma forma = new IzmeniZastitnuOpremuForma(id, idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniZastitnaOprema(osoba);
                }
            }
        }

        private void btIzmeniSertifkat_Click(object sender, EventArgs e)
        {
            ListView tabela = sertifikatiSpec;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati sertifikat iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniSertifikatSpecOpremeFormacs forma = new IzmeniSertifikatSpecOpremeFormacs(id, idOsobe))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                    popuniSertifikatSpec(osoba);
                }
            }
        }

        private void btObrisiKontakt_Click(object sender, EventArgs e)
        {
            if (kontakti.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite kontakt kog zelite da obrisete!");
                return;
            }

            int idKontakt = Int32.Parse(kontakti.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani kontakt?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                
                DTOManager.obrisiKontakt(idKontakt);
                MessageBox.Show("Brisanje kontakta je uspesno obavljeno!");
                OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                popuniKontakte(osoba);
            }
            else
            {

            }
        }

        private void btObrisiLicencu_Click(object sender, EventArgs e)
        {
            if (licence.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite licencu koju zelite da obrisete!");
                return;
            }

            int idLicenca = Int32.Parse(licence.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu licencu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                
                DTOManager.obrisiLicencu(idLicenca);
                MessageBox.Show("Brisanje licence je uspesno obavljeno!");
                OsobaBasic osoba = DTOManager.vratiOsobu(idOsobe);
                popuniLicence(osoba);
            }
            else
            {

            }
        }

        private void btObrisiObuku_Click(object sender, EventArgs e)
        {
            if (bezObuke.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite obuku koju zelite da obrisete!");
                return;
            }

            int idObuke = Int32.Parse(bezObuke.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu obuku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                DTOManager.obrisiBezbednosnuObuku(idObuke);
                MessageBox.Show("Brisanje obuke je uspesno obavljeno!");
                FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                popuniBezbednosneObuke(osoba);
            }
            else
            {

            }
        }

        private void btObrisiLekPregled_Click(object sender, EventArgs e)
        {
            if (lekpregledi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite lekarski pregled koji zelite da obrisete!");
                return;
            }

            int idLekPregled = Int32.Parse(lekpregledi.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani lekarski pregled?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                DTOManager.obrisiLekPregled(idLekPregled);
                MessageBox.Show("Brisanje lekarskog pregleda je uspesno obavljeno!");
                FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                popuniLekPregled(osoba);
            }
            else
            {

            }
        }

        private void btObrisiZasOpremu_Click(object sender, EventArgs e)
        {
            if (zastitnaoprema.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zastitnu opremu koju zelite da obrisete!");
                return;
            }

            int idZastitnaOprema = Int32.Parse(zastitnaoprema.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabranu zastitnu opremu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                DTOManager.obrisiZastitnuOpremu(idZastitnaOprema);
                MessageBox.Show("Brisanje zastitne opreme je uspesno obavljeno!");
                FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                popuniZastitnaOprema(osoba);
            }
            else
            {

            }
        }

        private void btObrisiSertifikat_Click(object sender, EventArgs e)
        {
            if (sertifikatiSpec.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite sertifikat koji zelite da obrisete!");
                return;
            }

            int idSertifikatSpec = Int32.Parse(sertifikatiSpec.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani sertifikat?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                DTOManager.obrisiSertifikatSpecOpreme(idSertifikatSpec);
                MessageBox.Show("Brisanje sertifikata je uspesno obavljeno!");
                FizickoLiceBasic osoba = DTOManager.vratiFizickoLice(idOsobe);
                popuniSertifikatSpec(osoba);
            }
            else
            {

            }
        }
    }
}
