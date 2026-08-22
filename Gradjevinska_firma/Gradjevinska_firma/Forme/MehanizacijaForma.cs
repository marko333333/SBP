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
    public partial class MehanizacijaForma : Form
    {
        public MehanizacijaForma()
        {
            InitializeComponent();
        }

        private void MehanizacijaForma_Load(object sender, EventArgs e)
        {
            popuniMehanizacije();
        }

        private void popuniMehanizacije()
        {
            mehanizacija.Items.Clear();

            List<MehanizacijaPregled> lista = DTOManager.vratiSveMehanizacije();

            foreach (MehanizacijaPregled m in lista)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        m.Id.ToString(),
                        m.Naziv,
                        m.Tip,
                        m.DatumUvoza.ToShortDateString(),
                        m.Proizvodjac,
                        m.RasponOdrzavanja,
                        m.Lokacija,
                        m.Status,
                        m.TipMehanizacije
                    });

                mehanizacija.Items.Add(item);
            }

            mehanizacija.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btDodajOpremu_Click(object sender, EventArgs e)
        {
            using (DodajMehanizacijuForma forma = new DodajMehanizacijuForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniMehanizacije();
                }
            }
        }

        private void btIzmeniOpremu_Click(object sender, EventArgs e)
        {
            ListView tabela = mehanizacija;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati mehanizaciju iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniMehanizacijuForma forma = new IzmeniMehanizacijuForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniMehanizacije();
                }
            }
        }

        private void btObrisiMehanizaciju_Click(object sender, EventArgs e)
        {
            ListView tabela = mehanizacija;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati mehanizaciju iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu mehanizaciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiOpremu(id);
                MessageBox.Show("Brisanje mehanizacije je uspesno obavljeno!");
                popuniMehanizacije();

            }
        }
    }
}
