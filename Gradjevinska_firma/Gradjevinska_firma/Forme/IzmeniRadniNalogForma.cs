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
    public partial class IzmeniRadniNalogForma : Form
    {
        private int idRadniNalog;
        private int idZadatka;
        public IzmeniRadniNalogForma(int id, int idzadatak)
        {
            InitializeComponent();
            idRadniNalog = id;
            idZadatka = idzadatak;
        }

        private void IzmeniRadniNalogForma_Load(object sender, EventArgs e)
        {
            RadniNalogBasic radniNalog=DTOManager.vratiRadniNalog(idRadniNalog);
            cbStatus.SelectedItem= radniNalog.Status;
            dtpDatumIzdavanja.Value = radniNalog.DatumIzdavanja;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {   
            ZadatakBasic zadatak=DTOManager.vratiZadatak(idZadatka);

            RadniNalogBasic radniNalog = new RadniNalogBasic(
                idRadniNalog,zadatak,cbStatus.SelectedItem.ToString(),dtpDatumIzdavanja.Value);

            DTOManager.izmeniRadniNalog(radniNalog);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
