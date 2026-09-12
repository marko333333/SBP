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
using Gradjevinska_firma.DTOManager;

namespace Gradjevinska_firma.Forme
{
    public partial class SanacijaForma : Form
    {
        public SanacijaForma()
        {
            InitializeComponent();
        }

        public void popuniPodacima()
        {
            projekti.Items.Clear();

            List<RekonstrukcijaPregled> lista = ProjekatDTOManager.vratiSveRekonstrukcije();

            foreach (RekonstrukcijaPregled i in lista)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    i.ID.ToString(),
                    i.Naziv,
                    i.Opis,
                    i.Lokacija,

                    i.Datum_pocetka.ToShortDateString(),
                    i.Budzet.HasValue ? i.Budzet.Value.ToString() : "",
                    i.Status,
                    i.Planirani_zavrsetak.ToShortDateString(),
                    i.Stvarni_zavrsetak.HasValue ? i.Stvarni_zavrsetak.Value.ToShortDateString() : "",
                    i.Trosak.ToString()
                });

                projekti.Items.Add(item);
            }

            projekti.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            projekti.Refresh();
        }

        private void SanacijaForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DodajSanacijaForma forma = new DodajSanacijaForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniPodacima();
                }
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

            using (IzmeniSanacijaForma forma = new IzmeniSanacijaForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniPodacima();
                }
            }
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
                ProjekatDTOManager.obrisiProjekat(id);
                MessageBox.Show("Brisanje projekta je uspesno obavljeno!");
                popuniPodacima();

            }
            else
            {

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

            DetaljiSanacijaForma forma = new DetaljiSanacijaForma(id);
            forma.ShowDialog();
        }
    }
}
