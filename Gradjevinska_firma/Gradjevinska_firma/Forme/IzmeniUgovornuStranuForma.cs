using Gradjevinska_firma.DTO;
using Gradjevinska_firma.DTOManager;
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
    public partial class IzmeniUgovornuStranuForma : Form
    {
        private int idUgovorneStrane;
        public IzmeniUgovornuStranuForma(int id)
        {
            InitializeComponent();
            idUgovorneStrane = id;
        }

        private void IzmeniUgovornuStranuForma_Load(object sender, EventArgs e)
        {
            ImaUgovornuStranuBasic imaUgovornuStranu = ImaUgovorneStraneDTOManager.vratiImaUgovornuStranu(idUgovorneStrane);

            tbUloga.Text = imaUgovornuStranu.Uloga;
        }

        private void btIzmeni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUloga.Text))
            {
                MessageBox.Show("Unesite ulogu osobe!");
                tbUloga.Focus();
                return;
            }

            ImaUgovornuStranuBasic ugovornaStrana = new ImaUgovornuStranuBasic();
            ugovornaStrana.Id=idUgovorneStrane;
            ugovornaStrana.Uloga=tbUloga.Text;

            ImaUgovorneStraneDTOManager.izmeniUgovornuStranu(ugovornaStrana);

            MessageBox.Show("Uspesna izmena");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
