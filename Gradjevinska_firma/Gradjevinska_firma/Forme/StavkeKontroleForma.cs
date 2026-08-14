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
            KontrolaKvalitetaBasic kontrola=DTOManager.vratiKontroluKvaliteta(idKontrole);
            popuniPodacima(kontrola);
        }

        private void popuniPodacima(KontrolaKvalitetaBasic kontrola)
        {
            stavke.Items.Clear();

            foreach (StavkaKontroleBasic k in kontrola.StavkeKontrole)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        k.Id.ToString(),
                        k.RedniBrojStavke.ToString(),
                        k.Uzorci,
                        k.LabNalazi,
                        k.RezultatiIspitivanja,
                        k.KorektivneMere,
                        k.RokZaOtklanjanje.HasValue ? k.RokZaOtklanjanje.Value.ToShortDateString(): "",
                    });

                stavke.Items.Add(item);
            }
            stavke.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.stavke.Refresh();

        }

        private void bt_dodaj_Click(object sender, EventArgs e)
        {
            using (DodajStavkuForma forma = new DodajStavkuForma(idKontrole))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    KontrolaKvalitetaBasic kontrola = DTOManager.vratiKontroluKvaliteta(idKontrole);
                    popuniPodacima(kontrola);
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
                    popuniPodacima(kontrola);
                }
            }
        }

        private void bt_obrisi_Click(object sender, EventArgs e)
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
            string poruka = "Da li zelite da obrisete izabranu stavku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiStavku(id);
                MessageBox.Show("Brisanje stavke je uspesno obavljeno!");
                KontrolaKvalitetaBasic kontrola = DTOManager.vratiKontroluKvaliteta(idKontrole);
                popuniPodacima(kontrola);

            }
            else
            {

            }
        }
    }
}
