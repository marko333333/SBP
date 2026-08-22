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
    public partial class UgovoriForma : Form
    {
        public UgovoriForma()
        {
            InitializeComponent();
        }

        private void bt_dodaj_Click(object sender, EventArgs e)
        {
        }
        public void popuniUgovore()
        {
            this.ugovori.Items.Clear();
            List<UgovorPregled> ugovor = DTOManager.vratiSveUgovore();

            foreach (UgovorPregled u in ugovor)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   u.Id.ToString(),
                   u.DatumPotpisivanja.ToShortDateString(),
                   u.Vrednost.ToString(),
                   u.PredmetUgovora,
                   u.Valuta,
                   u.Rok.ToShortDateString()

                   });
                this.ugovori.Items.Add(item);

            }
            this.ugovori.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.ugovori.Refresh();
        }
        private void UgovoriForma_Load(object sender, EventArgs e)
        {

        }

        private void bt_obrisi_Click(object sender, EventArgs e)
        {
        }

        private void bt_izmeni_Click(object sender, EventArgs e)
        {

        }

        private void btDetaljiUgovora_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListView tabela = ugovori;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati ugovor iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniUgovorForma forma = new IzmeniUgovorForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniUgovore();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (DodajUgovorForma forma = new DodajUgovorForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniUgovore();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListView tabela = ugovori;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati ugovor iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani ugovor?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiUgovor(id);
                MessageBox.Show("Brisanje ugovora je uspesno obavljeno!");
                popuniUgovore();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListView tabela = ugovori;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati ugovor iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (DetaljiUgovoraForma forma = new DetaljiUgovoraForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniUgovore();
                }
            }
        }
    }
}
