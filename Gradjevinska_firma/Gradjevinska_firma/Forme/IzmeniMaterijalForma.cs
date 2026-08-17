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
    public partial class IzmeniMaterijalForma : Form
    {
        private int idMaterijal;
        public IzmeniMaterijalForma(int id)
        {
            InitializeComponent();
            idMaterijal = id;
        }

        private void IzmeniMaterijalForma_Load(object sender, EventArgs e)
        {

        }
    }
}
