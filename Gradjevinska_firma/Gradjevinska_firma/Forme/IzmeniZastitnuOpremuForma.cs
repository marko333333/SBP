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
    public partial class IzmeniZastitnuOpremuForma : Form
    {
        private int idZastitnaOprema;
        private int idOsobe;
        public IzmeniZastitnuOpremuForma(int id, int idosoba)
        {
            InitializeComponent();
            idZastitnaOprema = id;
            idOsobe = idosoba;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {

                ZastitnaOpremaBasic zastitnaOprema = new ZastitnaOpremaBasic(idZastitnaOprema, idOsobe, tbZastitnaOprema.Text);

                DTOManager.izmeniZastitnuOpremu(zastitnaOprema);
                MessageBox.Show("Uspesna izmena.");
                this.DialogResult = DialogResult.OK;
                this.Close();

            

        }

        private void IzmeniZastitnuOpremuForma_Load(object sender, EventArgs e)
        {
            ZastitnaOpremaBasic zastitnaOprema = DTOManager.vratiZastitnuOpremu(idZastitnaOprema);
            tbZastitnaOprema.Text=zastitnaOprema.NazivOpreme;
            
        }
    }
}
