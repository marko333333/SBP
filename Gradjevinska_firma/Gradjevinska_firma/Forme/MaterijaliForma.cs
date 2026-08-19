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
            popuniGradjevinskeMaterijale();
        }

        public void popuniGradjevinskeMaterijale()
        {
            this.gradjevinski.Items.Clear();
            List<GradjevinskiPregled> materijali = DTOManager.vratiSavGradjevinskiMaterijal();

            foreach (GradjevinskiPregled m in materijali)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   m.ID.ToString(),
                   m.Naziv,
                   m.Cena.ToString(),
                   m.Proizvodjac,
                   m.JedinicaMere.ToString(),
                   m.Sertifikat,
                   });
                this.gradjevinski.Items.Add(item);

            }
            this.gradjevinski.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.gradjevinski.Refresh();
        }

        public void popuniZavrsniMaterijale()
        {
            this.zavrsni.Items.Clear();
            List<ZavrsniPregled> materijali = DTOManager.vratiSavZavrsniMaterijal();

            foreach (ZavrsniPregled m in materijali)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   m.ID.ToString(),
                   m.Naziv,
                   m.Cena.ToString(),
                   m.Proizvodjac,
                   m.JedinicaMere.ToString(),
                   m.Sertifikat,
                   });
                this.zavrsni.Items.Add(item);

            }
            this.zavrsni.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.zavrsni.Refresh();
        }

        public void popuniZastitniMaterijale()
        {
            this.zastitni.Items.Clear();
            List<ZastitniPregled> materijali = DTOManager.vratiSavZastitniMaterijal();

            foreach (ZastitniPregled m in materijali)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   m.ID.ToString(),
                   m.Naziv,
                   m.Cena.ToString(),
                   m.Proizvodjac,
                   m.JedinicaMere.ToString(),
                   m.Sertifikat,
                   });
                this.zastitni.Items.Add(item);

            }
            this.zastitni.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.zastitni.Refresh();
        }

        public void popuniElektroMaterijale()
        {
            this.elektro.Items.Clear();
            List<ElektroPregled> materijali = DTOManager.vratiSavElektroMaterijal();

            foreach (ElektroPregled m in materijali)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   m.ID.ToString(),
                   m.Naziv,
                   m.Cena.ToString(),
                   m.Proizvodjac,
                   m.JedinicaMere.ToString(),
                   m.Sertifikat,
                   });
                this.elektro.Items.Add(item);

            }
            this.elektro.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.elektro.Refresh();
        }

        public void popuniMasinskiMaterijale()
        {
            this.masinski.Items.Clear();
            List<MasinskiPregled> materijali = DTOManager.vratiSavMasinskiMaterijal();

            foreach (MasinskiPregled m in materijali)
            {
                ListViewItem item = new ListViewItem(new string[] {
                   m.ID.ToString(),
                   m.Naziv,
                   m.Cena.ToString(),
                   m.Proizvodjac,
                   m.JedinicaMere.ToString(),
                   m.Sertifikat,
                   });
                this.masinski.Items.Add(item);

            }
            this.masinski.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.masinski.Refresh();
        }

        private void btDodajMaterijal_Click(object sender, EventArgs e)
        {
            using (DodajMaterijalForma forma = new DodajMaterijalForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniGradjevinskeMaterijale();
                }
            }
        }

        private void btIzmeniMaterijal_Click(object sender, EventArgs e)
        {
            ListView tabela = gradjevinski;

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
                    popuniGradjevinskeMaterijale();
                }
            }
        }

        private void btDodajZavrsni_Click(object sender, EventArgs e)
        {
            using (DodajZavrsniForma forma = new DodajZavrsniForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniZavrsniMaterijale();
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                popuniGradjevinskeMaterijale();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                popuniZavrsniMaterijale();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                popuniZastitniMaterijale();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                popuniElektroMaterijale();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                popuniMasinskiMaterijale();
            }
        }

        private void btDodajZastitni_Click(object sender, EventArgs e)
        {
            using (DodajZastitniForma forma = new DodajZastitniForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniZastitniMaterijale();
                }
            }
        }

        private void btDodajElektro_Click(object sender, EventArgs e)
        {
            using (DodajElektroForma forma = new DodajElektroForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniElektroMaterijale();
                }
            }
        }

        private void btDodajMasinski_Click(object sender, EventArgs e)
        {
            using (DodajMasinskiForma forma = new DodajMasinskiForma())
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniMasinskiMaterijale();
                }
            }
        }

        private void btIzmeniMasinski_Click(object sender, EventArgs e)
        {
            ListView tabela = masinski;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniMasinskiForma forma = new IzmeniMasinskiForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniMasinskiMaterijale();
                }
            }
        }

        private void btIzmeniZavrsni_Click(object sender, EventArgs e)
        {
            ListView tabela = zavrsni;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniZavrsniForma forma = new IzmeniZavrsniForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniZavrsniMaterijale();
                }
            }
        }

        private void btIzmeniZastitni_Click(object sender, EventArgs e)
        {
            ListView tabela = zastitni;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniZastitniForma forma = new IzmeniZastitniForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniZastitniMaterijale();
                }
            }
        }

        private void btIzmeniElektro_Click(object sender, EventArgs e)
        {
            ListView tabela = elektro;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            using (IzmeniElektroForma forma = new IzmeniElektroForma(id))
            {
                if (forma.ShowDialog() == DialogResult.OK)
                {
                    popuniElektroMaterijale();
                }
            }
        }

        private void btObrisiMasinski_Click(object sender, EventArgs e)
        {
            ListView tabela = masinski;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani materijal?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiMaterijal(id);
                MessageBox.Show("Brisanje materijala je uspesno obavljeno!");
                popuniMasinskiMaterijale();

            }
        }

        private void btObrisiElektro_Click(object sender, EventArgs e)
        {
            ListView tabela = elektro;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani materijal?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiMaterijal(id);
                MessageBox.Show("Brisanje materijala je uspesno obavljeno!");
                popuniElektroMaterijale();

            }
        }

        private void btobrisiZastitni_Click(object sender, EventArgs e)
        {
            ListView tabela = zastitni;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani materijal?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiMaterijal(id);
                MessageBox.Show("Brisanje materijala je uspesno obavljeno!");
                popuniZastitniMaterijale();

            }
        }

        private void btObrisiZavrsni_Click(object sender, EventArgs e)
        {
            ListView tabela = zavrsni;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani materijal?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiMaterijal(id);
                MessageBox.Show("Brisanje materijala je uspesno obavljeno!");
                popuniZavrsniMaterijale();

            }
        }

        private void btObrisiGradj_Click(object sender, EventArgs e)
        {
            ListView tabela = gradjevinski;

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati materijal iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );
            string poruka = "Da li zelite da obrisete izabrani materijal?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiMaterijal(id);
                MessageBox.Show("Brisanje materijala je uspesno obavljeno!");
                popuniGradjevinskeMaterijale();

            }
        }
    }
}
