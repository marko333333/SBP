using Gradjevinska_firma.DTO;
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
    public partial class DodajFotografijuForma : Form
    {
        private int idNapredak;
        public DodajFotografijuForma(int id)
        {
            InitializeComponent();
            idNapredak = id;
        }

        private void DodajFotografijuForma_Load(object sender, EventArgs e)
        {

        }

        private string putanja;
        private void btIzaberi_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Izaberite fotografiju";

                dialog.Filter = "Slike (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    putanja = dialog.FileName;

                    tbFotografija.Text = putanja;

                    pcFotografija.Image = Image.FromFile(putanja);
                    pcFotografija.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(putanja))
            {
                MessageBox.Show("Morate izabrati fotografiju");
                return;
            }

            FotografijaBasic fotografija =new FotografijaBasic(idNapredak,putanja);

            DTOManager.dodajFotografiju(fotografija);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
