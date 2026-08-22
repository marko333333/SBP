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
    public partial class OpremaForma : Form
    {
        public OpremaForma()
        {
            InitializeComponent();
        }

        private void OpremaForma_Load(object sender, EventArgs e)
        {
            popuniOpremu();
        }

        public void popuniOpremu()
        {
            this.oprema.Items.Clear();
            List<OpremaPregled> oprema = DTOManager.vratiSvuOpremu();

            foreach (OpremaPregled o in oprema)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   o.Id.ToString(),
                   o.Naziv,
                   o.Tip,
                   o.DatumUvoza.ToShortDateString(),
                   o.Proizvodjac,
                   o.RasponOdrzavanja,
                   o.Lokacija,
                   o.Status});
                this.oprema.Items.Add(item);

            }
            this.oprema.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.oprema.Refresh();
        }

        private void btDodajOpremu_Click(object sender, EventArgs e)
        {
            using (DodajOpremuForma forma = new DodajOpremuForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniOpremu();
                }
            }
        }

        private void btIzmeniOpremu_Click(object sender, EventArgs e)
        {
            ListView tabela = oprema;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati opremu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniOpremuForma forma = new IzmeniOpremuForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniOpremu();
                }
            }
        }

        private void btNabavka_Click(object sender, EventArgs e)
        {
            using (MehanizacijaForma forma = new MehanizacijaForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniOpremu();
                }
            }
        }

        private void btObrisiOpremu_Click(object sender, EventArgs e)
        {
            ListView tabela = oprema;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati opremu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabranu opremu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiOpremu(id);
                MessageBox.Show("Brisanje opreme je uspesno obavljeno!");
                popuniOpremu();

            }
        }
    }
}
