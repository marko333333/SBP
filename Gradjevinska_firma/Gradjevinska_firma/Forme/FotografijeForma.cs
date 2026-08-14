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

        }
    }
}
