using Gradjevinska_firma.DTO;
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
    public partial class StavkeKontroleForma : Form
    {
        private int idKontrole;
        public StavkeKontroleForma(int id)
        {
            InitializeComponent();
            idKontrole = id;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void StavkeKontroleForma_Load(object sender, EventArgs e)
        {

        }

        private void popuniPodacima()
        {
           /* stavke.Items.Clear();

            List<StavkaKontrolePregled> lista = DTOManager.vratiSveStavke();

            foreach (ZadatakPregled z in lista)
            {
                string roditelj = "";

                if (z.NadZadatak != null)
                    roditelj = z.NadZadatak.Naziv;

                ListViewItem item = new ListViewItem(new string[]
                {
                    z.Id.ToString(),z.Naziv,z.Opis,
                    z.Faza != null ? z.Faza.Naziv : "",
                    roditelj,z.ProcenjeniTrosak.ToString(),
                    z.PlaniraniPocetak.ToShortDateString(),
                    z.StvarniPocetak.HasValue ? z.StvarniPocetak.Value.ToShortDateString(): "",
                    z.PlaniraniZavrsetak.ToShortDateString(),
                    z.StvarniZavrsetak.HasValue ? z.StvarniZavrsetak.Value.ToShortDateString(): "",
                    z.Prioritet.ToString(),z.Status
                });

                stavke.Items.Add(item);
            }

            stavke.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            stavke.Refresh();
           */
        }

        private void bt_dodaj_Click(object sender, EventArgs e)
        {
            using (DodajStavkuForma forma = new DodajStavkuForma(idStavke))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    KontrolaKvalitetaBasic kontrola = DTOManager.vratiKontroluKvaliteta(idKontrole);
                    //popuniKontroluKvaliteta(zadatak);
                }
            }
        }

        private void bt_izmeni_Click(object sender, EventArgs e)
        {
            ListView tabela = stavke;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati stavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniStavkuForma forma = new IzmeniStavkuForma(id, idKontrole))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    KontrolaKvalitetaBasic kontrola = DTOManager.vratiKontroluKvaliteta(idKontrole);
                    //popuniKontroluKvaliteta(zadatak);
                }
            }
        }
    }
}
