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
    public partial class DetaljiOsobeForma : Form
    {
        private int idOsobe;
        public DetaljiOsobeForma(int id)
        {
            InitializeComponent();
            
            idOsobe=id;
        }

        private void DetaljiOsobeForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }


    }
}
