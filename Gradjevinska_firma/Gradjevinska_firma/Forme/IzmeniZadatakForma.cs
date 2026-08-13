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
    public partial class IzmeniZadatakForma : Form
    {
        private int idZadatka;
        public IzmeniZadatakForma(int id)
        {
            InitializeComponent();
            idZadatka = id;
        }

        private void IzmeniZadatakForma_Load(object sender, EventArgs e)
        {
            ZadatakBasic zadatak = DTOManager.vratiZadatak(idZadatka);
            tbNaziv.Text = zadatak.Naziv;
            tbOpis.Text=zadatak.Opis;
            tbTrosak.Text = zadatak.ProcenjeniTrosak.ToString();
            prioritet.Value = zadatak.Prioritet;
            cbStatus.Text = zadatak.Status;
            cbFaza.Text = zadatak.Faza.Naziv;
            cbNadzadatak.Text = zadatak.Roditelj.Naziv;
            dtpPlaniraniP.Text = zadatak.PlaniraniPocetak.Value.ToShortDateString();
            dtpPlaniraniZ.Text = zadatak.PlaniraniZavrsetak.Value.ToShortDateString();
            //dodaj za ostalo ali razmisli o null vrednostima i da li dtp moze da ima null vrednosti
        }
    }
}
