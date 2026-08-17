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
    public partial class IzmeniAngazovanjeForma : Form
    {
        private int idOsobe;
        private int idZadatka;
        public IzmeniAngazovanjeForma(int idosobe, int idzadatak)
        {
            InitializeComponent();
            idOsobe = idosobe;
            idZadatka = idzadatak;
        }

        private void IzmeniAngazovanjeForma_Load(object sender, EventArgs e)
        {
            AngazovanBasic a = DTOManager.vratiAngazovanje(idZadatka, idOsobe);
            dtpDatumDo.Checked = false;

            dtpDatumOd.Value = a.DatumOd;

            if (a.DatumDo.HasValue)
            {
                dtpDatumDo.Value = a.DatumDo.Value;
                dtpDatumDo.Checked = true;
            }

            cbStatus.SelectedItem = a.StatusAngazovanja;
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

            OsobaBasic osoba = new OsobaBasic();
            osoba.Id = idOsobe;

            AngazovanBasic angazovanje = new AngazovanBasic(
                zadatak,osoba,dtpDatumOd.Value,datumDo,cbStatus.SelectedItem.ToString()
            );

            DTOManager.izmeniAngazovanje(angazovanje);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
