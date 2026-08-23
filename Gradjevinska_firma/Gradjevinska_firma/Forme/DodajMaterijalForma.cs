using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
    public partial class DodajMaterijalForma : Form
    {
        public DodajMaterijalForma()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void DodajMaterijalForma_Load(object sender, EventArgs e)
        {

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

            GradjevinskiBasic materijal=new GradjevinskiBasic
                (0,tbNaziv.Text,int.Parse(tbcena.Text),tbProizvodjac.Text,tbJedinicaMere.Text,tbSertifikat.Text,"Gradjevinski");

            MaterijalDTOManager.dodajGradjevinskiMaterijal(materijal);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
