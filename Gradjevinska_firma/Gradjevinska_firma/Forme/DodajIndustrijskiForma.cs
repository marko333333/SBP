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
    public partial class DodajIndustrijskiForma : Form
    {
        public DodajIndustrijskiForma()
        {
            InitializeComponent();
        }

        private void DodajIndustrijskiForma_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbNaziv.Text))
            {
                MessageBox.Show("Morate uneti naziv projekta.");
                return;
            }

            //DateTime? stvarniZavrsetak = null;


            //if (dtpStvarniZavrsetak.Checked)
            //    stvarniZavrsetak = dtpStvarniZavrsetak.Value;


            IndustrijskiBasic industrijski = new IndustrijskiBasic(
               0,
               tbNaziv.Text,
               tbOpis.Text,
               tbLokacija.Text,
               dtpDatumPocetka.Value,
               (int)nudBudzet.Value,
               cbStatus.SelectedItem.ToString(),//ako pravi problem dodaj required string
               dtpPlaniraniZavrsetak.Value,
               dtpStvarniZavrsetak.Value
           );

            DTOManager.dodajIndustrijski(industrijski);

            MessageBox.Show("Projekat infrastruktura je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DodajIndustrijskiForma_Load_1(object sender, EventArgs e)
        {
            dtpStvarniZavrsetak.ShowCheckBox = true;

            dtpStvarniZavrsetak.Checked = false;
        }
    }
}
