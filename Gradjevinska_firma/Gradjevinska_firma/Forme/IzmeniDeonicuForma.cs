using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;

namespace Gradjevinska_firma.Forme
{
    public partial class IzmeniDeonicuForma : Form
    {
        private int idDeonice;
        private int idInfrastrukture;
        public IzmeniDeonicuForma(int idDeonice, int idInfrastrukture)
        {
            InitializeComponent();
            this.idDeonice = idDeonice;
            this.idInfrastrukture = idInfrastrukture;
        }

        private void Izmeni_button_Click(object sender, EventArgs e)
        {
            InfrastrukturaBasic infra = ProjekatDTOManager.vratiInfrastrukturu(idInfrastrukture);
            DeonicaBasic deonica = new DeonicaBasic(
                idDeonice,
                int.Parse(nudBrojDeonice.Text),
                infra
           );

            DeonicaDTOManager.izmeniDeonicu(deonica);

            MessageBox.Show("Deonica je uspesno izmenjena.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
