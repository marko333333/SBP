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
    public partial class IzmeniPosebnuKlauzuluForma : Form
    {
        private int idPosebnaKlauzula;
        public IzmeniPosebnuKlauzuluForma(int id)
        {
            InitializeComponent();
            idPosebnaKlauzula = id;
        }

        private void IzmeniPosebnuKlauzuluForma_Load(object sender, EventArgs e)
        {
            PosebnaKlauzulaBasic posebnaKlauzula = PosebnaKlauzulaDTOManager.vratiPosebnuKlauzulu(idPosebnaKlauzula);

            tbPosebnaKlauzula.Text = posebnaKlauzula.TekstKlauzule;
        }

        private void btiIzmeni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPosebnaKlauzula.Text))
            {
                MessageBox.Show("Unesite ulogu osobe!");
                tbPosebnaKlauzula.Focus();
                return;
            }


            PosebnaKlauzulaBasic posebnaKlauzula = new PosebnaKlauzulaBasic();
            posebnaKlauzula.Id = idPosebnaKlauzula;
            posebnaKlauzula.TekstKlauzule= tbPosebnaKlauzula.Text;

            PosebnaKlauzulaDTOManager.izmeniPosebnuKlauzulu(posebnaKlauzula);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
