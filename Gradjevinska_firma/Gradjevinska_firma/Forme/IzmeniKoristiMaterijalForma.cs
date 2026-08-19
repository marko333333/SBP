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
    public partial class IzmeniKoristiMaterijalForma : Form
    {
        private int idKoristi;
        public IzmeniKoristiMaterijalForma(int id)
        {
            InitializeComponent();
            idKoristi = id;
        }

        private void IzmeniKoristiMaterijalForma_Load(object sender, EventArgs e)
        {
            KoristiBasic koristi=DTOManager.vratiKoristZadatka(idKoristi);

            tbKolicina.Text = koristi.Kolicina.ToString();
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbKolicina.Text) || !tbKolicina.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite kolicinu i ona mora da bude broj!!!");
                tbKolicina.Focus();
                return;
            }

            KoristiBasic koristi = new KoristiBasic();
            koristi.ID = idKoristi;
            koristi.Kolicina = int.Parse(tbKolicina.Text);

            DTOManager.izmeniKoristi(koristi);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
