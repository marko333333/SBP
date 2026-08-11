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
    public partial class ZaposleniForma : Form
    {
        public ZaposleniForma()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void popuniFizickaLica()
        {
            this.fizickaLica.Items.Clear();

            List<FizickoLicePregled> osobe = DTOManager.vratiSvaFizickaLica();

            foreach (FizickoLicePregled o in osobe)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    o.Id.ToString(),
                    o.Jmbg.ToString(),
                    o.Ime,
                    o.Prezime,
                    o.Struka
                });

                this.fizickaLica.Items.Add(item);
            }

            this.fizickaLica.Refresh();
        }
        public void popuniPravnaLica()
        {
            this.pravnaLica.Items.Clear();

            List<PravnaLicaPregled> osobe = DTOManager.vratiSvaPravnaLica();

            foreach (PravnaLicaPregled o in osobe)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    o.Id.ToString(),
                    o.Jmbg.ToString(),
                    o.Ime,
                    o.Prezime,
                    o.Struka
                });

                this.pravnaLica.Items.Add(item);
            }

            this.pravnaLica.Refresh();
        }

        public void popuniZaposlene()
        {
            String pom;
            this.zaposleni.Items.Clear();
            List<OsobaPregled> osobe = DTOManager.vratiSveOsobe();

            foreach (OsobaPregled o in osobe)
            {
                ListViewItem item = new ListViewItem(new string[] { o.Id.ToString(), o.Jmbg.ToString(), o.Ime, o.Prezime, o.DatumRodjenja.ToShortDateString(), o.Struka });
                this.zaposleni.Items.Add(item);

            }

            this.zaposleni.Refresh();
        }

        private void ZaposleniForma_Load(object sender, EventArgs e)
        {
            popuniZaposlene();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                popuniZaposlene();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                popuniFizickaLica();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                popuniPravnaLica();
            }
        }

        private void btDetaljiOosbe_Click(object sender, EventArgs e)
        {
            ListView tabela = null;

            if (tabControl1.SelectedIndex == 0)
                tabela = zaposleni;
            else if (tabControl1.SelectedIndex == 1)
                tabela = fizickaLica;
            else if (tabControl1.SelectedIndex == 2)
                tabela = pravnaLica;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati osobu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            DetaljiOsobeForma forma = new DetaljiOsobeForma(id);
            forma.ShowDialog();
        }

        private void bt_dodaj_Click(object sender, EventArgs e)
        {

            DodajOsobu forma = new DodajOsobu();
            forma.ShowDialog();
        }
    }
}
