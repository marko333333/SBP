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
    public partial class DodajNabavkuForma : Form
    {
        public DodajNabavkuForma()
        {
            InitializeComponent();
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (cbProjekat.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati projekat");
                return;
            }

            ProjekatBasic projekat = new ProjekatBasic();

            ProjekatPregled p = (ProjekatPregled)cbProjekat.SelectedItem;

            projekat.ID = p.ID;
            projekat.Naziv = p.Naziv;

            NabavkeBasic nabavka = new NabavkeBasic(
                0, dtpDatum.Value, projekat);

            NabavkeDTOManager.dodajNabavku(nabavka);

            MessageBox.Show("Uspesno dodavanje");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void popuniProjekte()
        {
            cbProjekat.Items.Clear();

            List<ProjekatPregled> projekti = ProjekatDTOManager.vratiSveProjekte();

            foreach (ProjekatPregled p in projekti)
            {
                cbProjekat.Items.Add(p);
            }

            cbProjekat.DisplayMember = "Naziv";

            if (cbProjekat.Items.Count > 0)
                cbProjekat.SelectedIndex = 0;
        }

        private void DodajNabavkuForma_Load(object sender, EventArgs e)
        {
            popuniProjekte();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
