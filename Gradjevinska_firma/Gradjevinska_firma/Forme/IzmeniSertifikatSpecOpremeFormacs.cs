using FluentNHibernate.Conventions;
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
    public partial class IzmeniSertifikatSpecOpremeFormacs : Form
    {
        private int idSertifikat;
        private int idOsobe;
        public IzmeniSertifikatSpecOpremeFormacs(int id, int idosoba)
        {
            InitializeComponent();
            idSertifikat = id;
            idOsobe = idosoba;

        }

        private void IzmeniSertifikatSpecOpremeFormacs_Load(object sender, EventArgs e)
        {
            SertifikatSpecOpremeBasic sertifikatSpec=DTOManager.vratiSertifikat(idSertifikat);
            tbSertifikatSpec.Text = sertifikatSpec.Sertifikat;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
                SertifikatSpecOpremeBasic sertifikatSpec = new SertifikatSpecOpremeBasic(idSertifikat, idOsobe, tbSertifikatSpec.Text);

                DTOManager.izmeniSertifikatSpecOpreme(sertifikatSpec);
                MessageBox.Show("Uspesna izmena.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            
            
        }
    }
}
