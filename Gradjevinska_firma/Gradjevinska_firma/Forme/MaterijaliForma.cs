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
    public partial class MaterijaliForma : Form
    {
        public MaterijaliForma()
        {
            InitializeComponent();
        }

        private void MaterijaliForma_Load(object sender, EventArgs e)
        {
            popuniMaterijale();
        }

        public void popuniMaterijale()
        {
            this.materijali.Items.Clear();
            List<MaterijalPregled> materijali = DTOManager.vratiSavMaterijal();

            foreach (MaterijalPregled m in materijali)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   m.ID.ToString(),
                   m.Naziv,
                   m.Cena.ToString(),
                   m.Proizvodjac,
                   m.JedinicaMere.ToString(),
                   m.Sertifikat,
                   m.Tip});//ne prikazuje se tip materijala
                this.materijali.Items.Add(item);

            }
            this.materijali.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.materijali.Refresh();
        }

        private void btDodajMaterijal_Click(object sender, EventArgs e)
        {
            using (DodajMaterijalForma forma = new DodajMaterijalForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniMaterijale();
                }
            }
        }

        private void btIzmeniMaterijal_Click(object sender, EventArgs e)
        {
            ListView tabela = materijali;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniMaterijalForma forma = new IzmeniMaterijalForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniMaterijale();
                }
            }
        }
    }
}
