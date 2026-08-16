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
    public partial class DetaljiIndustrijskiForma : Form
    {
        private int IdIndustrijski;
        public DetaljiIndustrijskiForma(int id)
        {
            InitializeComponent();
            IdIndustrijski = id;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
