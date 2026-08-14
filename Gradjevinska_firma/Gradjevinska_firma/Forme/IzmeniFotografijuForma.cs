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
    public partial class IzmeniFotografijuForma : Form
    {
        private int idFotografija;
        private int idNapredak;
        public IzmeniFotografijuForma(int id,int idnapredak)
        {
            InitializeComponent();
            idFotografija = id;
            idNapredak = idnapredak;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {

        }
    }
}
