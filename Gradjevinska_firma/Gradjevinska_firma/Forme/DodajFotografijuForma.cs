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
    public partial class DodajFotografijuForma : Form
    {
        private int idNapredak;
        public DodajFotografijuForma(int id)
        {
            InitializeComponent();
            idNapredak = id;
        }

        private void DodajFotografijuForma_Load(object sender, EventArgs e)
        {

        }
    }
}
