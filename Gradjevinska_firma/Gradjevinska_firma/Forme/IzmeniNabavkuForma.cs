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
    public partial class IzmeniNabavkuForma : Form
    {
        private int idNabavke;
        public IzmeniNabavkuForma(int id)
        {
            InitializeComponent();
            idNabavke = id;
        }

        private void IzmeniNabavkuForma_Load(object sender, EventArgs e)
        {
            NabavkeBasic nabavka=NabavkeDTOManager.vratiNabavku(idNabavke);

            dtpDatum.Value = nabavka.Datum;

            cbProjekat.Items.Clear();

            List<ProjekatPregled> projekti = ProjekatDTOManager.vratiSveProjekte();

            foreach (ProjekatPregled p in projekti)
            {
                cbProjekat.Items.Add(p);
            }

            if (nabavka.Projekat != null)
            {
                for (int i = 0; i < cbProjekat.Items.Count; i++)
                {
                    ProjekatPregled p = (ProjekatPregled)cbProjekat.Items[i];

                    if (p.ID == nabavka.Projekat.ID)
                    {
                        cbProjekat.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            if (cbProjekat.SelectedItem == null)
            {
                MessageBox.Show("Izaberite projekat.");
                return;
            }

            ProjekatPregled projekat = (ProjekatPregled)cbProjekat.SelectedItem;

            NabavkeBasic nabavka = new NabavkeBasic();

            nabavka.Br_nabavke = idNabavke;
            nabavka.Datum = dtpDatum.Value;

            ProjekatBasic p = new ProjekatBasic();
            p.ID = projekat.ID;
            p.Naziv = projekat.Naziv;

            nabavka.Projekat = p;

            NabavkeDTOManager.izmeniNabavku(nabavka);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
