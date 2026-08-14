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
    public partial class DodajRadniNalogForma : Form
    {
        private int idZadatka;
        public DodajRadniNalogForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void DodajRadniNalogForma_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {

            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
            RadniNalogBasic radniNalog = new RadniNalogBasic(
                0, zadatak, cbStatus.SelectedItem.ToString(), dtpDatumIzdavanja.Value);

            DTOManager.dodajRadniNalog(radniNalog);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
