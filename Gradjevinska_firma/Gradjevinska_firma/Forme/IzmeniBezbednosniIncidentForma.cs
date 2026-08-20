using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradjevinska_firma.DTO;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Forme
{
    public partial class IzmeniBezbednosniIncidentForma : Form
    {
        private int IdProjekta;
        private int IdIncidenta;
        public IzmeniBezbednosniIncidentForma(int idIncidenta, int id)
        {
            InitializeComponent();
            IdIncidenta = idIncidenta;
            IdProjekta = id;
        }
        private void IzmeniBezbednosniIncidentForma_Load(object sender, EventArgs e)
        {
            PopuniOsobama();
        }

        private void PopuniOsobama()
        {
            cbOsoba.Items.Clear();
            List<OsobaPregled> osobe = DTOManager.vratiOsobeNaProjektu(IdProjekta);

            foreach (OsobaPregled osoba in osobe)
            {
                cbOsoba.Items.Add(osoba);
            }

            if (cbOsoba.Items.Count > 0)
                cbOsoba.SelectedIndex = 0;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (cbOsoba.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati osobu.");
                return;
            }

            if (cbTipIncidenta.SelectedItem == null)
            {
                MessageBox.Show("Izaberite tip incidenta");
                return;
            }

            OsobaPregled izabranaOsoba = (OsobaPregled)cbOsoba.SelectedItem;

            OsobaBasic osoba = new OsobaBasic();
            osoba.Id = izabranaOsoba.Id;

            ProjekatBasic projekat = DTOManager.vratiProjekat(IdProjekta);

            string prikazaniTip = cbTipIncidenta.SelectedItem.ToString();

            string tipZaKlasu = prikazaniTip switch
            {
                "Povreda na radu" => "PovredaNaRadu",
                "Kvar opreme" => "KvarOpreme",
                "Nepostovanje procedura" => "NepostovanjeProcedura",
                "Opasna situacija" => "OpasnaSituacija",
                "Ekoloski incident" => "EkoloskiIncident",
                _ => throw new ArgumentException("Nepoznat tip incidenta.")
            };

            BezbednosniIncidentBasic incident = new BezbednosniIncidentBasic(
                IdIncidenta,
                tbOpis.Text,
                dtpDatum.Value,
                tbLokacija.Text,
                tbPreduzeteMere.Text,
                tbPosledice.Text,
                prikazaniTip,
                projekat,
                osoba
            );

            DTOManager.izmeniBezbednosniIncident(incident);

            MessageBox.Show("Bezbednosni incident je uspesno izmenjen.");

            this.DialogResult = DialogResult.OK;
            this.Close();    
        }
    }
}
