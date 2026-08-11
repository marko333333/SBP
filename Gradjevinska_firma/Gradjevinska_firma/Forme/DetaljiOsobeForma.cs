using Gradjevinska_firma.DTO;
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
                if(fizicko!=null)
                    popuniBezbednosneObuke(fizicko);
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
                if(fizicko!=null)
                    popuniLekPregled(fizicko);
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
                if(fizicko!=null)
                    popuniZastitnaOprema(fizicko);
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);
                if(fizicko!=null)
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
    }
}
