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
    public partial class DodajDeonicuForma : Form
    {
        private int idInfrastrukture;
        public DodajDeonicuForma(int idInfrastrukture)
        {
            InitializeComponent();
            this.idInfrastrukture = idInfrastrukture;
        }

        private void Dodaj_button_Click(object sender, EventArgs e)
        {
            InfrastrukturaBasic infra = ProjekatDTOManager.vratiInfrastrukturu(idInfrastrukture);
            DeonicaBasic deonica = new DeonicaBasic(
                0,
                int.Parse(nudBrojDeonice.Text),
                infra
           );

            DeonicaDTOManager.dodajDeonicu(deonica);

            MessageBox.Show("Deonica je uspesno dodata.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
