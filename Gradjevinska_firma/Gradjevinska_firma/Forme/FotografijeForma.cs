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
    public partial class FotografijeForma : Form
    {
        private int idNapredak;
        public FotografijeForma(int id)
        {
            InitializeComponent();
            idNapredak = id;
        }

        private void FotografijeForma_Load(object sender, EventArgs e)
        {
            NapredakBasic napredak = DTOManager.vratiNapredak(idNapredak);
            popuniPodacima(napredak);

            pbFotografija.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void popuniPodacima(NapredakBasic napredak)
        {
            fotografije.Items.Clear();

            foreach (FotografijaBasic f in napredak.Fotografije)
            {
                ListViewItem item = new ListViewItem(
                    new string[]
                    {
                        f.Putanja

                    });
                item.Tag = f;
                fotografije.Items.Add(item);
            }
            fotografije.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.fotografije.Refresh();
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            using (DodajFotografijuForma forma = new DodajFotografijuForma(idNapredak))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    NapredakBasic napredak = DTOManager.vratiNapredak(idNapredak);
                    popuniPodacima(napredak);
                }
            }
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
        }

        private void fotografije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fotografije.SelectedItems.Count == 0)
                return;

            string nazivFotografije =fotografije.SelectedItems[0].SubItems[0].Text;

            string putanja = Path.Combine(Application.StartupPath,"Fotografije",nazivFotografije);

            if (!File.Exists(putanja))
            {
                MessageBox.Show(
                    "Fotografija nije pronadjena:\n" + putanja
                );

                if (pbFotografija.Image != null)
                {
                    pbFotografija.Image.Dispose();
                    pbFotografija.Image = null;
                }

                return;
            }

            if (pbFotografija.Image != null)
            {
                pbFotografija.Image.Dispose();
                pbFotografija.Image = null;
            }

            pbFotografija.Image = Image.FromFile(putanja);
            pbFotografija.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btObrisi_Click(object sender, EventArgs e)
        {
            ListView tabela = fotografije;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati fotografiju iz tabele.");
                return;
            }

            FotografijaBasic f =(FotografijaBasic)fotografije.SelectedItems[0].Tag;

            string poruka = "Da li zelite da obrisete izabranu fotografiju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiFotografiju(f.IdNapredak, f.Putanja);
                MessageBox.Show("Brisanje fotografije je uspesno obavljeno!");
                pbFotografija.Image = null;
                NapredakBasic napredak = DTOManager.vratiNapredak(idNapredak);
                popuniPodacima(napredak);

            }

        }
    }
}
