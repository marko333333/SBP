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

namespace Gradjevinska_firma.Forme
{
    public partial class DodajPoslovniForma : Form
    {
        public DodajPoslovniForma()
        {
            InitializeComponent();
        }

        private void DodajPoslovniForma_Load(object sender, EventArgs e)
        {
            dtpStvarniZavrsetak.ShowCheckBox = true;

            dtpStvarniZavrsetak.Checked = false;
        }

        private void Dodaj_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNaziv.Text))
            {
                MessageBox.Show("Morate uneti naziv projekta.");
                return;
            }


            PoslovniBasic poslovni = new PoslovniBasic(
               0,
               tbNaziv.Text,
               tbOpis.Text,
               tbLokacija.Text,
               dtpDatumPocetka.Value,
               (int)nudBudzet.Value,
               cbStatus.SelectedItem.ToString(),
               dtpPlaniraniZavrsetak.Value,
               dtpStvarniZavrsetak.Value
           );

            ProjekatDTOManager.dodajPoslovni(poslovni);

            MessageBox.Show("Poslovni projekat je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
