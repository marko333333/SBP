using Gradjevinska_firma.DTO;
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
            AngazujeBasic a = DTOManager.vratiAngazuje(idZadatka, idOprema);
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
                zadatak,oprema,dtpDatumOd.Value,datumDo,int.Parse(tbBrojSati.Text));

            DTOManager.izmeniAngazuje(angazuje);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
