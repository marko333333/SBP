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
    public partial class DodajNabavkuMaterijalForma : Form
    {
        private int idNabavka;
        public DodajNabavkuMaterijalForma(int id)
        {
            InitializeComponent();
            idNabavka = id;
        }

        private void DodajNabavkuMaterijalForma_Load(object sender, EventArgs e)
        {
            popuniMaterijale();
            cbStatus.Checked = false;
        }

        private void popuniMaterijale()
        {
            cbMaterijal.Items.Clear();

            NabavkeBasic nabavke = NabavkeDTOManager.vratiNabavku(idNabavka);

            List<MaterijalPregled> materijal = MaterijalDTOManager.vratiSavMaterijal();

            foreach (MaterijalPregled m in materijal)
            {
                bool vecNabavljen = false;

                foreach (NabavkaMaterijalBasic nm in nabavke.NabavkaMaterijal)
                {
                    if (nm.Materijal != null && nm.Materijal.ID == m.ID)
                    {
                        vecNabavljen = true;
                        break;
                    }
                }

                if (!vecNabavljen)
                {
                    cbMaterijal.Items.Add(m);
                }

            }

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbKolicina.Text) || !tbKolicina.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite kolicinu i ona mora da bude broj!");
                tbKolicina.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbCena.Text) || !tbCena.Text.All(char.IsDigit))
            {
                MessageBox.Show("Unesite cenu i ona mora da bude broj!");
                tbKolicina.Focus();
                return;
            }
            if (cbMaterijal.SelectedItem == null)
            {
                MessageBox.Show("Izaberite materijal");
                return;
            }

            MaterijalBasic materijal = new MaterijalBasic(); ;

            MaterijalPregled p = (MaterijalPregled)cbMaterijal.SelectedItem;

            materijal.ID = p.ID;
            materijal.Naziv = p.Naziv;

            NabavkeBasic nabavka = NabavkeDTOManager.vratiNabavku(idNabavka);

            NabavkaMaterijalBasic nabavkaOprema = new NabavkaMaterijalBasic(
                0, int.Parse(tbKolicina.Text), int.Parse(tbCena.Text), cbStatus.Checked, materijal, nabavka);

            NabavkeDTOManager.dodajNabavkaMaterijal(nabavkaOprema);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
