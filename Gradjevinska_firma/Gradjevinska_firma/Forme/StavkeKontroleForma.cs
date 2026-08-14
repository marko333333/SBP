using Gradjevinska_firma.DTO;
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
    public partial class StavkeKontroleForma : Form
    {
        private int idStavke;
        private int idKontrole;
        public StavkeKontroleForma(int id, int idkontrole)
        {
            InitializeComponent();
            idStavke = id;
            idKontrole = idkontrole;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void StavkeKontroleForma_Load(object sender, EventArgs e)
        {

        }

        private void bt_dodaj_Click(object sender, EventArgs e)
        {
            using (DodajStavkuForma forma = new DodajStavkuForma(idKontrole))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    ZadatakBasic zadatak = DTOManager.vratiZadatak(idKontrole);
                    //popuniKontroluKvaliteta(zadatak);
                }
            }
        }
    }
}
