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
    public partial class DodajOsobu : Form
    {
        public DodajOsobu()
        {
            InitializeComponent();
        }

        private void gbPravnoLice_Enter(object sender, EventArgs e)
        {

        }

        private void DodajOsobu_Load(object sender, EventArgs e)
        {
            gbFizickoLice.Visible = false;
            gbPravnoLice.Visible = false;
        }

        private void rbFizickoLice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFizickoLice.Checked)
            {
                gbFizickoLice.Visible = true;
                gbPravnoLice.Visible = false;
            }
        }

        private void rbPravnoLice_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPravnoLice.Checked)
            {
                gbFizickoLice.Visible = false;
                gbPravnoLice.Visible = true;
            }
        }

        private void cbRadnik_CheckedChanged(object sender, EventArgs e)
        {
            lbK.Visible = cbRadnik.Checked;
            tbKvalifikacija.Visible = cbRadnik.Checked;
        }

        private void cbInzenjer_CheckedChanged(object sender, EventArgs e)
        {
            lbOR.Visible = cbInzenjer.Checked;
            tbOblastRada.Visible = cbInzenjer.Checked;

            lbO.Visible = cbInzenjer.Checked;
            tbOdgovornosti.Visible = cbInzenjer.Checked;
        }

        private void btDodajOsobu_Click(object sender, EventArgs e)
        {
            if (rbFizickoLice.Checked)
            {
                FizickoLiceBasic fizicko = new FizickoLiceBasic(
                    0,
                   long.Parse(tbJmbg.Text),
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

                DTOManager.dodajFizickoLice(fizicko);
                MessageBox.Show("Uspesno dodavanje.");
            }
            else if (rbPravnoLice.Checked)
            {
                PravnaLicaBasic pravno = new PravnaLicaBasic(
                    0,
                   long.Parse(tbJmbg.Text),
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

                DTOManager.dodajPravnoLice(pravno);

                MessageBox.Show("Uspesno dodavanje.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Izaberite da li dodajete fizicko ili pravno lice.");
            }
        }
    }
}
