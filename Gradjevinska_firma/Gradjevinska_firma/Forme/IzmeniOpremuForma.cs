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
    public partial class IzmeniOpremuForma : Form
    {
        private int idOprema;
        public IzmeniOpremuForma(int id)
        {
            InitializeComponent();
            idOprema = id;
        }

        private void IzmeniOpremuForma_Load(object sender, EventArgs e)
        {

        }

        private void btizmeni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTip.Text))
            {
                MessageBox.Show("Unesite tip opreme!");
                tbTip.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbNaziv.Text))
            {
                MessageBox.Show("Unesite naziv opreme!");
                tbNaziv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbProizvodjac.Text))
            {
                MessageBox.Show("Unesite proizvodjaca!");
                tbProizvodjac.Focus();
                return;
            }


            OpremaBasic oprema = new OpremaBasic(
                idOprema, tbNaziv.Text, tbTip.Text, dtpdatumUvoza.Value, tbProizvodjac.Text, tbRasponOdrzavanja.Text, tbLokacija.Text, cbStatus.SelectedItem.ToString());

            DTOManager.izmeniOpremu(oprema);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
