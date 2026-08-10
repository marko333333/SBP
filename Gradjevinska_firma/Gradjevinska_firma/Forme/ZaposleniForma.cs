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
    public partial class ZaposleniForma : Form
    {
        public ZaposleniForma()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void popuniPodacima()
        {
            String pom;
            this.zaposleni.Items.Clear();
            List<OsobaPregled> osobe = DTOManager.vratiSveOsobe();

            foreach (OsobaPregled o in osobe)
            {
                ListViewItem item = new ListViewItem(new string[] { o.Id.ToString(),o.Jmbg.ToString(),o.Ime,o.Prezime,o.DatumRodjenja.ToShortDateString(),o.Struka });
                this.zaposleni.Items.Add(item);

            }

            this.zaposleni.Refresh();
        }

        private void ZaposleniForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
