using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
using Gradjevinska_firma.Entiteti;
using NHibernate.Action;
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
    public partial class IzmeniAngazujForma : Form
    {
        private int idOprema;
        private int idZadatka;
        public IzmeniAngazujForma(int idoprema, int idzadatak)
        {
            InitializeComponent();
            idOprema = idoprema;
            idZadatka = idzadatak;
        }

        private void IzmeniAngazujForma_Load(object sender, EventArgs e)
        {
            AngazujeBasic a = AngazujOpremuDTOManager.vratiAngazuje(idZadatka, idOprema);
            dtpDatumDo.ShowCheckBox = true;
            dtpDatumDo.Checked = false;

            dtpDatumOd.Value = a.DatumOd;

            if (a.DatumDo.HasValue)
            {
                dtpDatumDo.Value = a.DatumDo.Value;
                dtpDatumDo.Checked = true;
            }

            tbBrojSati.Text = a.BrojSati.ToString();
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbBrojSati.Text) || !tbBrojSati.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite broj sati i broj sati mora da bude broj!!!");
                tbBrojSati.Focus();
                return;
            }

            DateTime? datumDo = null;

            if (dtpDatumDo.Checked)
            {
                datumDo = dtpDatumDo.Value;
            }

            ZadatakBasic zadatak = new ZadatakBasic();
            zadatak.Id = idZadatka;

            OpremaBasic oprema = new OpremaBasic();
            oprema.Id = idOprema;

            AngazujeBasic angazuje = new AngazujeBasic(
                zadatak, oprema, dtpDatumOd.Value, datumDo, int.Parse(tbBrojSati.Text));

            AngazujOpremuDTOManager.izmeniAngazuje(angazuje);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
