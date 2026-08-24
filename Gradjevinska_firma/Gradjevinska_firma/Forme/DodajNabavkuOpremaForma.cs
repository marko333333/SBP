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
    public partial class DodajNabavkuOpremaForma : Form
    {
        private int idNabavke;
        public DodajNabavkuOpremaForma(int id)
        {
            InitializeComponent();
            idNabavke = id;
        }

        private void DodajNabavkuOpremaForma_Load(object sender, EventArgs e)
        {
            popuniOpremu();
            cbStatus.Checked = false;
        }

        private void popuniOpremu()
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

                if (!vecNabavljen)
                {
                    cbOprema.Items.Add(o);
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
            if (cbOprema.SelectedItem==null)
            {
                MessageBox.Show("Izaberite opremu");
                return;
            }

            OpremaBasic oprema = new OpremaBasic(); ;

            OpremaPregled p = (OpremaPregled)cbOprema.SelectedItem;

            oprema.Id = p.Id;
            oprema.Naziv=p.Naziv;

            NabavkeBasic nabavka = NabavkeDTOManager.vratiNabavku(idNabavke);

            NabavkaOpremaBasic nabavkaOprema=new NabavkaOpremaBasic(
                0,int.Parse(tbKolicina.Text),int.Parse(tbCena.Text),cbStatus.Checked,oprema,nabavka);
           
             NabavkeDTOManager.dodajNabavkaOprema(nabavkaOprema);

             MessageBox.Show("Uspesno dodavanje.");

             this.DialogResult = DialogResult.OK;
             this.Close();
            }
    }
}
