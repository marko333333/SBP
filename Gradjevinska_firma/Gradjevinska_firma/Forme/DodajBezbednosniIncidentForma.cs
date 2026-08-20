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
    public partial class DodajBezbednosniIncidentForma : Form
    {
        private int IdProjekta;
        public DodajBezbednosniIncidentForma(int id)
        {
            InitializeComponent();
            IdProjekta = id;
        }

        private void Dodaj_button_Click(object sender, EventArgs e)
        {

            if (cbTipIncidenta.SelectedItem == null)
            {
                MessageBox.Show("Izaberite tip incidenta");
                return;
            }

            if (cbOsoba.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati osobu.");
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
                "Nepoštovanje procedura" => "NepostovanjeProcedura",
                "Opasna situacija" => "OpasnaSituacija",
                "Ekološki incident" => "EkoloskiIncident",
                _ => throw new ArgumentException("Nepoznat tip incidenta.")
            };

            BezbednosniIncidentBasic incident = new BezbednosniIncidentBasic(
                0,
                tbOpis.Text,
                dtpDatum.Value,
                tbLokacija.Text,
                tbPreduzeteMere.Text,
                tbPosledice.Text,
                prikazaniTip,
                projekat,
                osoba
           );

            DTOManager.dodajBezbednosniIncident(incident, tipZaKlasu);//proveri

            MessageBox.Show("Bezbednosni incident je uspesno dodat.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DodajBezbednosniIncidentForma_Load(object sender, EventArgs e)//ne radi klik na item
        {
            popuniOsobama();
        }

        private void popuniOsobama()
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
    }
}
