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
    public partial class DodajLekPregledForma : Form
    {
        private int idOsobe;
        public DodajLekPregledForma(int id)
        {
            InitializeComponent();
            idOsobe = id;
        }

        private void DodajLekPregledForma_Load(object sender, EventArgs e)
        {

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            LekarskiPregledBasic lekPregled = new LekarskiPregledBasic(
                0,idOsobe,tbLekPregled.Text,dtpDatum.Value);

            DTOManager.dodajLekPregled(lekPregled);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
