using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradjevinska_firma.DTO;

namespace Gradjevinska_firma.Forme
{
    public partial class IndustrijskiForma : Form
    {
        public IndustrijskiForma()
        {
            InitializeComponent();
        }

        public void popuniPodacima()
        {
            projekti.Items.Clear();

            List<IndustrijskiPregled> lista = DTOManager.vratiSveIndustrijske();

            foreach (IndustrijskiPregled i in lista)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    i.ID.ToString(),
                    i.Naziv,
                    i.Opis,
                    i.Lokacija,

                    i.Datum_pocetka.ToShortDateString(),
                    i.Budzet.ToString(),
                    i.Status,
                    i.Planirani_zavrsetak.ToShortDateString(),
                    i.Stvarni_zavrsetak.HasValue ? i.Stvarni_zavrsetak.Value.ToShortDateString(): "",
                });

                projekti.Items.Add(item);
            }

            projekti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            projekti.Refresh();
        }

        private void IndustrijskiForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListView tabela = projekti;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati projekat iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani projekat?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiProjekat(id);
                MessageBox.Show("Brisanje projekta je uspesno obavljeno!");
                popuniPodacima();

            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListView tabela = projekti;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati projekat iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniIndustrijskiForma forma = new IzmeniIndustrijskiForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniPodacima();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DodajIndustrijskiForma forma = new DodajIndustrijskiForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniPodacima();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListView tabela = projekti;


            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati zadatak iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            DetaljiIndustrijskiForma forma = new DetaljiIndustrijskiForma(id);
            forma.ShowDialog();
        }
    }
}
