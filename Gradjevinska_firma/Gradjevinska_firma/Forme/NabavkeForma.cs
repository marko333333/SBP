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
    public partial class NabavkeForma : Form
    {
        public NabavkeForma()
        {
            InitializeComponent();
        }

        private void btDodajNabavku_Click(object sender, EventArgs e)
        {
            using (DodajNabavkuForma forma = new DodajNabavkuForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniNabavke();
                }
            }
        }
        public void popuniNabavke()
        {
            this.nabavke.Items.Clear();
            List<NabavkePregled> nabavke = NabavkeDTOManager.vratiSveNabavke();

            foreach (NabavkePregled n in nabavke)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   n.Br_nabavke.ToString(),
                   n.Datum.ToShortDateString(),
                   n.Projekat.Naziv

                   });
                this.nabavke.Items.Add(item);

            }
            this.nabavke.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.nabavke.Refresh();
        }
        private void NabavkeForma_Load(object sender, EventArgs e)
        {
            popuniNabavke();
        }

        private void btIzmeniNabavku_Click(object sender, EventArgs e)
        {
            ListView tabela = nabavke;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniNabavkuForma forma = new IzmeniNabavkuForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniNabavke();
                }
            }
        }

        private void btObrisiNabavku_Click(object sender, EventArgs e)
        {
            ListView tabela = nabavke;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu nabavku?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                NabavkeDTOManager.obrisiNabavku(id);
                MessageBox.Show("Brisanje nabavke je uspesno obavljeno!");
                popuniNabavke();
            }
        }

        private void btDetalji_Click(object sender, EventArgs e)
        {
            ListView tabela = nabavke;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati nabavku iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (DetaljiNabavkeForma forma = new DetaljiNabavkeForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniNabavke();
                }
            }
        }
    }
}
