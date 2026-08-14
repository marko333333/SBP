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
    public partial class IzmeniIndustrijskiForma : Form
    {
        private int IdIndustrijski;
        public IzmeniIndustrijskiForma(int id)
        {
            InitializeComponent();
            IdIndustrijski = id;
        }

    }
}
