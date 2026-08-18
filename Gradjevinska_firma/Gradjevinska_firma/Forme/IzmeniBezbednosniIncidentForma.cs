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
    public partial class IzmeniBezbednosniIncidentForma : Form
    {
        private int IdIncidenta;
        public IzmeniBezbednosniIncidentForma(int id)
        {
            InitializeComponent();
            IdIncidenta = id;
        }
    }
}
