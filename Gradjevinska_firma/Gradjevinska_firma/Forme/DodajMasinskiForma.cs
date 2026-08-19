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
    public partial class DodajMasinskiForma : Form
    {
        public DodajMasinskiForma()
        {
            InitializeComponent();
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbcena.Text) || !tbcena.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite cenu i cena mora da bude broj!");
                tbcena.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbNaziv.Text))
            {
                MessageBox.Show("Unesite naziv materijala!");
                tbNaziv.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbProizvodjac.Text))
            {
                MessageBox.Show("Unesite proizvodjaca!");
                tbProizvodjac.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbJedinicaMere.Text))
            {
                MessageBox.Show("Unesite jedinicu mere!");
                tbJedinicaMere.Focus();
                return;
            }

            MasinskiBasic materijal = new MasinskiBasic
                (0, tbNaziv.Text, int.Parse(tbcena.Text), tbProizvodjac.Text, tbJedinicaMere.Text, tbSertifikat.Text, "Masinski");

            DTOManager.dodajMasinskiMaterijal(materijal);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
