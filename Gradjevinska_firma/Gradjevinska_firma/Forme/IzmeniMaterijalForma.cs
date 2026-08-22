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
    public partial class IzmeniMaterijalForma : Form
    {
        private int idMaterijal;
        public IzmeniMaterijalForma(int id)
        {
            InitializeComponent();
            idMaterijal = id;
        }

        private void IzmeniMaterijalForma_Load(object sender, EventArgs e)
        {
            GradjevinskiBasic materijal = DTOManager.vratiGradjevinskiMaterijal(idMaterijal);

            tbNaziv.Text = materijal.Naziv;
            tbcena.Text = materijal.Cena.ToString();
            tbProizvodjac.Text = materijal.Proizvodjac;
            tbJedinicaMere.Text = materijal.JedinicaMere;
            tbSertifikat.Text = materijal.Sertifikat;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
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

            GradjevinskiBasic materijal = new GradjevinskiBasic
                (idMaterijal, tbNaziv.Text, int.Parse(tbcena.Text), tbProizvodjac.Text, tbJedinicaMere.Text, tbSertifikat.Text, "Gradjevinski");

            DTOManager.izmeniGradjevinskiMaterijal(materijal);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
