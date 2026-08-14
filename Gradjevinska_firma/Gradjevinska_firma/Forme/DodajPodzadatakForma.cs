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
    public partial class DodajPodzadatakForma : Form
    {
        private int idZadatka;
        public DodajPodzadatakForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void DodajPodzadatakForma_Load(object sender, EventArgs e)
        {
            popuniPodzadatke();
        }

        private void popuniPodzadatke()
        {
            cbNaziv.Items.Clear();

            List<ZadatakPregled> zadaci =DTOManager.vratiSveZadatke();

            foreach (ZadatakPregled z in zadaci)
            {
                if (z.Id == idZadatka)
                    continue;

                if (z.NadZadatak != null)
                    continue;

                cbNaziv.Items.Add(z);
            }

            cbNaziv.DisplayMember = "Naziv";

            if (cbNaziv.Items.Count > 0)
                cbNaziv.SelectedIndex = 0;
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (cbNaziv.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati podzadatak.");
                return;
            }

            ZadatakPregled izabrani =(ZadatakPregled)cbNaziv.SelectedItem;

            int idPodzadatka = izabrani.Id;

            DTOManager.dodajPodzadatak(idZadatka,idPodzadatka);

            MessageBox.Show("Podzadatak je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
