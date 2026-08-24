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
    public partial class IzmeniNabavkuOpremaForma : Form
    {
        private int idNabavkaOprema;
        private int idNabavke;
        public IzmeniNabavkuOpremaForma(int id, int idNabavke)
        {
            InitializeComponent();
            idNabavkaOprema = id;
            this.idNabavke = idNabavke;
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
            if (cbOprema.SelectedItem == null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }

            OpremaBasic oprema = new OpremaBasic(); ;

            OpremaPregled p = (OpremaPregled)cbOprema.SelectedItem;

            oprema.Id = p.Id;
            oprema.Naziv = p.Naziv;


            NabavkaOpremaBasic nabavkaOprema = new NabavkaOpremaBasic();

            nabavkaOprema.ID = idNabavkaOprema;
            nabavkaOprema.Kolicina = int.Parse(tbKolicina.Text);
            nabavkaOprema.Cena = int.Parse(tbCena.Text);
            nabavkaOprema.Status_isporuke = cbStatus.Checked;
            nabavkaOprema.Oprema = oprema;

            NabavkeDTOManager.izmeniNabavkaOprema(nabavkaOprema);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IzmeniNabavkuOpremaForma_Load(object sender, EventArgs e)
        {

            NabavkaOpremaBasic nabavkaOprema = NabavkeDTOManager.vratiNabavkuOpremu(idNabavkaOprema);

            tbKolicina.Text = nabavkaOprema.Kolicina.ToString();
            tbCena.Text = nabavkaOprema.Cena.ToString();
            cbStatus.Checked = nabavkaOprema.Status_isporuke;

            popuniOpremu(nabavkaOprema.Oprema.Id);

            for (int i = 0; i < cbOprema.Items.Count; i++)
            {
                OpremaPregled o = (OpremaPregled)cbOprema.Items[i];

                if (o.Id == nabavkaOprema.Oprema.Id)
                {
                    cbOprema.SelectedIndex = i;
                    break;
                }
            }
        }

        private void popuniOpremu(int idTrenutneOpreme)
        {
            cbOprema.Items.Clear();

            NabavkeBasic nabavke = NabavkeDTOManager.vratiNabavku(idNabavke);

            List<OpremaPregled> oprema = OpremaDTOManager.vratiSvuOpremu();

            foreach (OpremaPregled o in oprema)
            {
                bool vecNabavljen = false;

                foreach (NabavkaOpremaBasic no in nabavke.NabavkaOprema)
                {
                    if (no.Oprema != null && no.Oprema.Id == o.Id)
                    {
                        vecNabavljen = true;
                        break;
                    }
                }

                if (!vecNabavljen || o.Id == idTrenutneOpreme)
                {
                    cbOprema.Items.Add(o);
                }

            }

        }
    }
}
