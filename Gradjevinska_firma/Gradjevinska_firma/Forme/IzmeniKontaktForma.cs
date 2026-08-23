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
    public partial class IzmeniKontaktForma : Form
    {
        private int idKontakt;
        private int idOsoba;
        public IzmeniKontaktForma(int id,int idosoba)
        {
            InitializeComponent();
            idKontakt = id;
            idOsoba = idosoba;
        }

        private void IzmeniKontaktForma_Load(object sender, EventArgs e)
        {
            KontaktBasic kontakt = KontaktDTOManager.vratiKontakt(idKontakt);
            tbKontakt.Text = kontakt.Broj;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            KontaktBasic kontakt = new KontaktBasic(idKontakt, idOsoba, tbKontakt.Text);

            KontaktDTOManager.izmeniKontakt(kontakt);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
