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
using Gradjevinska_firma.DTOManager;
using Gradjevinska_firma.Entiteti;

namespace Gradjevinska_firma.Forme
{
    public partial class DodajFazuForma : Form
    {
        private int idProjekta;
        public DodajFazuForma(int idProjekta)
        {
            InitializeComponent();
            this.idProjekta = idProjekta;
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (cbNadFaza.SelectedItem == null)
            {
                MessageBox.Show("Izaberite nadfazu faze.");
                return;
            }

            if (cbFicickoLice.SelectedItem == null)
            {
                MessageBox.Show("Izaberite fizicko lice koje ucestvuje u fazi.");
                return;
            }

            if (cbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite status faze.");
                return;
            }

            if (cbNaziv.SelectedItem == null) 
            {
                MessageBox.Show("Izaberite naziv faze.");
                return;
            }

            FizickoLicePregled IzabranofizickoLice = (FizickoLicePregled)cbFicickoLice.SelectedItem;

            FizickoLiceBasic fizickoLice = new FizickoLiceBasic();

            fizickoLice.Id = IzabranofizickoLice.Id;

            FazaPregled izabranaNadFaza = (FazaPregled)cbNadFaza.SelectedItem;

            FazaBasic nadFaza = new FazaBasic();

            nadFaza.Id = izabranaNadFaza.Id;

            ProjekatBasic projekat = ProjekatDTOManager.vratiProjekat(idProjekta);

            DateTime? DatumDo = null;

            if (dtpDatumDo.Checked)
                DatumDo = dtpDatumDo.Value;

            FazaBasic faza = new FazaBasic(
                0,
                cbNaziv.SelectedItem.ToString(),
                dtpDatumOd.Value,
                DatumDo,
                cbStatus.SelectedItem.ToString(),
                (int)nudBudzet.Value,
                projekat,
                fizickoLice,
                nadFaza
           );

            FazaDTOManager.dodajFazu(faza);

            MessageBox.Show("Faza je uspesno dodata.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DodajFazuForma_Load(object sender, EventArgs e)
        {
            popuniNadFaze();
            popuniPravnaLica();

            dtpDatumDo.ShowCheckBox = true;

            dtpDatumDo.Checked = false;
        }

        private void popuniNadFaze()
        {
            cbNadFaza.Items.Clear();

            List<FazaPregled> faze = FazaDTOManager.vratiSveFaze();

            foreach (FazaPregled f in faze)
            {
                cbNadFaza.Items.Add(f);
            }

            cbNadFaza.DisplayMember = "Naziv";

            cbNadFaza.SelectedIndex = 0;
        }

        private void popuniPravnaLica()
        {
            cbFicickoLice.Items.Clear();
            List<FizickoLicePregled> fizickaLica = OsobaDTOManager.vratiFizickaLicaNaProjektu(idProjekta);

            foreach (FizickoLicePregled osoba in fizickaLica)
            {
                cbFicickoLice.Items.Add(osoba);
            }

            if (cbFicickoLice.Items.Count > 0)
                cbFicickoLice.SelectedIndex = 0;
        }
    }
}
