using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
        public IzmeniRadniNalogForma(int id)
        {
            InitializeComponent();
            idRadniNalog = id;
        }

        private void IzmeniRadniNalogForma_Load(object sender, EventArgs e)
        {
            RadniNalogBasic radniNalog=RadniNaloziDTOManager.vratiRadniNalog(idRadniNalog);
            cbStatus.SelectedItem= radniNalog.Status;
            dtpDatumIzdavanja.Value = radniNalog.DatumIzdavanja;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {

            RadniNalogBasic radniNalog = new RadniNalogBasic();
            radniNalog.BrNaloga = idRadniNalog;
            radniNalog.Status = cbStatus.SelectedItem.ToString();
            radniNalog.DatumIzdavanja = dtpDatumIzdavanja.Value;

            RadniNaloziDTOManager.izmeniRadniNalog(radniNalog);
            MessageBox.Show("Uspesna izmena.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
