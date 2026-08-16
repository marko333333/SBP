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
    public partial class IzmeniIndustrijskiForma : Form
    {
        private int IdIndustrijski;
        public IzmeniIndustrijskiForma(int id)
        {
            InitializeComponent();
            IdIndustrijski = id;
        }

        private void IzmeniIndustrijskiForma_Load(object sender, EventArgs e)
        {
            dtpStvarniZavrsetak.ShowCheckBox = true;

            dtpStvarniZavrsetak.Checked = false;
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {

            //DateTime stvarniZavrsetak = null;

            //if (dtpStvarniZavrsetak.Checked)
            //    stvarniZavrsetak = dtpStvarniZavrsetak.Value;

            IndustrijskiBasic industrijski = new IndustrijskiBasic(
               IdIndustrijski,
               tbNaziv.Text,
               tbOpis.Text,
               tbLokacija.Text,
               dtpDatumPocetka.Value,
               (int)nudBudzet.Value,
               cbStatus.SelectedItem.ToString(),
               dtpPlaniraniZavrsetak.Value,
               dtpStvarniZavrsetak.Value
               //stvarniZavrsetak
           );

            DTOManager.izmeniIndustrijski(industrijski);

            MessageBox.Show("Industrijski projekat je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
