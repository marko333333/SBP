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
    public partial class IzmeniPodzadatakForma : Form
    {
        private int idZadatka;
        private int idPodZadatka;
        public IzmeniPodzadatakForma(int id,int idzadatak)
        {
            InitializeComponent();
            idPodZadatka = id;
            idZadatka = idzadatak;
        }

        private void IzmeniPodzadatakForma_Load(object sender, EventArgs e)
        {
            popuniPodzadatke();
            popuniPodacima();

        }

        private void popuniPodacima()
        {
            ZadatakBasic podzadatak =DTOManager.vratiZadatak(idPodZadatka);

            if (podzadatak.Roditelj == null)
            {
                cbNaziv.SelectedIndex = -1;
                return;
            }

            for (int i = 0; i < cbNaziv.Items.Count; i++)
            {
                ZadatakPregled z =(ZadatakPregled)cbNaziv.Items[i];

                if (z.Id == podzadatak.Roditelj.Id)
                {
                    cbNaziv.SelectedIndex = i;
                    break;
                }
            }
        }

        private void popuniPodzadatke()
        {
            cbNaziv.Items.Clear();

            List<ZadatakPregled> zadaci = DTOManager.vratiSveZadatke();

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
    }
}
