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
    public partial class DodajPosebnuKlauzuluForma : Form
    {
        private int idUgovora;
        public DodajPosebnuKlauzuluForma(int id)
        {
            InitializeComponent();
            idUgovora = id;
        }

        private void DodajPosebnuKlauzuluForma_Load(object sender, EventArgs e)
        {

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPosebnaKlauzula.Text))
            {
                MessageBox.Show("Unesite posebnu klauzula osobe!");
                tbPosebnaKlauzula.Focus();
                return;
            }

            PosebnaKlauzulaBasic posebnaKlauzula = new PosebnaKlauzulaBasic(
                0,idUgovora,tbPosebnaKlauzula.Text
            );

            PosebnaKlauzulaDTOManager.dodajPosebnuKlauzulu(posebnaKlauzula);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
