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
    public partial class IzmeniFazuForma : Form
    {
        private int idProjekta;
        private int idFaze;
        public IzmeniFazuForma(int idFaze, int idProjekta)
        {
            InitializeComponent();
            this.idFaze = idFaze;
            this.idProjekta = idProjekta;
        }

        private void IzmeniFazuForma_Load(object sender, EventArgs e)
        {
            popuniNadFaze();
            popuniPravnaLica();

            FazaBasic faza = FazaDTOManager.vratiFazuProjekta(idFaze);

            cbNaziv.SelectedItem = faza.Naziv;
            cbStatus.SelectedItem = faza.Status;
            nudBudzet.Value = (int)faza.Budzet;

            if (faza.FizickoLice != null)
            {
                foreach (var item in cbFicickoLice.Items)
                {
                    if (item is FizickoLicePregled f && f.Id == faza.FizickoLice.Id)
                    {
                        cbFicickoLice.SelectedValue = item;
                        break;
                    }
                }
            }

            if (faza.NadFaza != null)
            {
                foreach (var item in cbNadFaza.Items)
                {
                    if (item is FazaPregled fp && fp.Id == faza.NadFaza.Id)
                    {
                        cbNadFaza.SelectedValue = item;
                        break;
                    }
                }
            }

            if (faza.DatumDo.HasValue)
            {
                dtpDatumDo.Value = faza.DatumDo.Value;
                dtpDatumDo.Checked = true;
            }
            dtpDatumOd.Value = faza.DatumOd;
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

        private void btDodaj_Click(object sender, EventArgs e)//izmenibutton greska
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
                idFaze,
                cbNaziv.SelectedItem.ToString(),
                dtpDatumOd.Value,
                DatumDo,
                cbStatus.SelectedItem.ToString(),
                (int)nudBudzet.Value,
                projekat,
                fizickoLice,
                nadFaza
           );

            FazaDTOManager.izmeniFazu(faza);

            MessageBox.Show("Faza je uspesno izmenjena.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
