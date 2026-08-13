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
    public partial class ZadaciForma : Form
    {
        public ZadaciForma()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            zadaci.Items.Clear();

            List<ZadatakPregled> lista = DTOManager.vratiSveZadatke();

            foreach (ZadatakPregled z in lista)
            {
                string roditelj = "";

                if (z.NadZadatak != null)
                    roditelj = z.NadZadatak.Naziv;

                ListViewItem item = new ListViewItem(new string[]
                {
                    z.Id.ToString(),z.Naziv,z.Opis,
                    z.Faza != null ? z.Faza.Naziv : "",
                    roditelj,z.ProcenjeniTrosak.ToString(),
                    z.PlaniraniPocetak.HasValue? z.PlaniraniPocetak.Value.ToShortDateString(): "",
                    z.StvarniPocetak.HasValue? z.StvarniPocetak.Value.ToShortDateString(): "",
                    z.PlaniraniZavrsetak.HasValue? z.PlaniraniZavrsetak.Value.ToShortDateString(): "",
                    z.StvarniZavrsetak.HasValue? z.StvarniZavrsetak.Value.ToShortDateString(): "",
                    z.Prioritet.ToString(),z.Status
                });

                zadaci.Items.Add(item);
            }

            zadaci.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            zadaci.Refresh();
        }
        private void ZadaciForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void btDetaljiOosbe_Click(object sender, EventArgs e)
        {
            ListView tabela = zadaci;
            

            if (tabela.SelectedItems.Count == 0)
            {
                MessageBox.Show("Potrebno je odabrati osobu iz tabele.");
                return;
            }

            int id = int.Parse(
                tabela.SelectedItems[0].SubItems[0].Text
            );

            DetaljiZadaciForma forma = new DetaljiZadaciForma(id);
            forma.ShowDialog();
        }
    }
}
