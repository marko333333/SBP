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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Gradjevinska_firma.Forme
{
    public partial class IzmeniOsobuForma : Form
    {
        private int idOsobe;
        public IzmeniOsobuForma(int id)
        {
            InitializeComponent();
            idOsobe = id;
   
        }

        public void popuniPodacima()
        {
            FizickoLiceBasic fizicko = DTOManager.vratiFizickoLice(idOsobe);

            if (fizicko != null)
            {
                gbFizickoLice.Visible = true;

                tbJmbg.Text = fizicko.Jmbg.ToString();
                tbIme.Text = fizicko.Ime;
                tbPrezime.Text = fizicko.Prezime;
                dtpDatumRodjenja.Value = fizicko.DatumRodjenja;
                tbStruka.Text = fizicko.Struka;

                rbFizickoLice.Checked = true;

                cbBK.Checked = fizicko.FlagBK;
                cbRadnik.Checked = fizicko.FlagR;

                if (cbRadnik.Checked)
                {
                    lbK.Visible = true;
                    tbKvalifikacija.Visible = true;
                    tbKvalifikacija.Text = fizicko.Kvalifikacija;
                }
                cbInzenjer.Checked = fizicko.FlagI;
                if (cbInzenjer.Checked)
                {
                    lbOR.Visible = true;
                    tbOblastRada.Visible = true;
                    lbO.Visible = true;
                    tbOdgovornosti.Visible = true;
                    tbOblastRada.Text = fizicko.OblastRada;
                    tbOdgovornosti.Text = fizicko.Odgovornosti;
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

                    tbJmbg.Text = pravno.Jmbg.ToString();
                    tbIme.Text = pravno.Ime;
                    tbPrezime.Text = pravno.Prezime;
                    dtpDatumRodjenja.Value = pravno.DatumRodjenja;
                    tbStruka.Text = pravno.Struka;

                    rbPravnoLice.Checked = true;

                    cbPB.Checked = pravno.FlagPB;
                    cbInvenstitor.Checked = pravno.FlagInve;
                    cbIzvodjac.Checked = pravno.FlagIzv;
                    cbPodizvodjac.Checked = pravno.FlagP;
                    cbDobavljaci.Checked = pravno.FlagD;
                    cbNO.Checked = pravno.FlagN;
                }
            }
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {

            if (rbFizickoLice.Checked)
            {
                FizickoLiceBasic fizicko = new FizickoLiceBasic(
                   idOsobe,
                  tbJmbg.Text,
                  tbIme.Text,
                  tbPrezime.Text,
                  dtpDatumRodjenja.Value,
                  tbStruka.Text,
                  cbBK.Checked,
                  cbRadnik.Checked,
                  tbKvalifikacija.Text,
                  cbInzenjer.Checked,
                  tbOblastRada.Text,
                  tbOdgovornosti.Text,
                  cbArhitekta.Checked,
                  cbPoslovodja.Checked,
                  cbNadzorniOrgan.Checked,
                  cbAO.Checked);

                DTOManager.izmeniFizickoLice(fizicko);
                MessageBox.Show("Uspesna izmena.");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else if (rbPravnoLice.Checked)
            {
                PravnaLicaBasic pravno = new PravnaLicaBasic(
                    idOsobe,
                   tbJmbg.Text,
                   tbIme.Text,
                   tbPrezime.Text,
                   dtpDatumRodjenja.Value,
                   tbStruka.Text,
                   cbPB.Checked,
                   cbInvenstitor.Checked,
                   cbIzvodjac.Checked,
                   cbPodizvodjac.Checked,
                   cbDobavljaci.Checked,
                   cbNO.Checked);

                DTOManager.izmeniPravnoLice(pravno);

                MessageBox.Show("Uspesna izmena.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }



        }

        private void cbInzenjer_CheckedChanged(object sender, EventArgs e)
        {
            lbOR.Visible = cbInzenjer.Checked;
            tbOblastRada.Visible = cbInzenjer.Checked;

            lbO.Visible = cbInzenjer.Checked;
            tbOdgovornosti.Visible = cbInzenjer.Checked;
        }

        private void cbRadnik_CheckedChanged(object sender, EventArgs e)
        {
            lbK.Visible = cbRadnik.Checked;
            tbKvalifikacija.Visible = cbRadnik.Checked;
        }

        private void rbPravnoLice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPravnoLice.Checked)
            {
                gbFizickoLice.Visible = false;
                gbPravnoLice.Visible = true;
            }
        }

        private void rbFizickoLice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFizickoLice.Checked)
            {
                gbFizickoLice.Visible = true;
                gbPravnoLice.Visible = false;
            }
        }

        private void IzmeniOsobuForma_Load(object sender, EventArgs e)
        {
            gbFizickoLice.Visible = false;
            gbPravnoLice.Visible = false;
            popuniPodacima();
        }
    }
}
