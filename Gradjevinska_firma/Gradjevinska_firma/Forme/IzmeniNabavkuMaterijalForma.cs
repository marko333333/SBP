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
    public partial class IzmeniNabavkuMaterijalForma : Form
    {
        private int idNabavkaMaterijal;
        private int idNabavka;
        public IzmeniNabavkuMaterijalForma(int id, int idNabavka)
        {
            InitializeComponent();
            idNabavkaMaterijal = id;
            this.idNabavka = idNabavka;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
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
                MessageBox.Show("Izaberite opremu");
                return;
            }

            MaterijalBasic materijal = new MaterijalBasic(); ;

            MaterijalPregled p = (MaterijalPregled)cbMaterijal.SelectedItem;

            materijal.ID = p.ID;
            materijal.Naziv = p.Naziv;

            NabavkaMaterijalBasic nabavkaMaterijal = new NabavkaMaterijalBasic();

            nabavkaMaterijal.ID = idNabavkaMaterijal;
            nabavkaMaterijal.Kolicina = int.Parse(tbKolicina.Text);
            nabavkaMaterijal.Cena = int.Parse(tbCena.Text);
            nabavkaMaterijal.Status_isporuke = cbStatus.Checked;
            nabavkaMaterijal.Materijal = materijal;

            NabavkeDTOManager.izmeniNabavkaMaterijal(nabavkaMaterijal);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void popuniMaterijale(int idTrenutnogMaterijala)
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

                if (!vecNabavljen || m.ID == idTrenutnogMaterijala)
                {
                    cbMaterijal.Items.Add(m);
                }

            }

        }
        private void IzmeniNabavkuMaterijalForma_Load(object sender, EventArgs e)
        {
            

            NabavkaMaterijalBasic nabavkaMaterijal = NabavkeDTOManager.vratiNabavkuMaterijala(idNabavkaMaterijal);

            tbKolicina.Text = nabavkaMaterijal.Kolicina.ToString();
            tbCena.Text = nabavkaMaterijal.Cena.ToString();
            cbStatus.Checked = nabavkaMaterijal.Status_isporuke;

            popuniMaterijale(nabavkaMaterijal.Materijal.ID);

            for (int i = 0; i < cbMaterijal.Items.Count; i++)
            {
                MaterijalPregled m = (MaterijalPregled)cbMaterijal.Items[i];

                if (m.ID == nabavkaMaterijal.Materijal.ID)
                {
                    cbMaterijal.SelectedIndex = i;
                    break;
                }
            }

        }
    }
}
