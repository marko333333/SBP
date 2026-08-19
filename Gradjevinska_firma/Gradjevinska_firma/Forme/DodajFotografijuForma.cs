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
        private string nazivFotografije;
        public DodajFotografijuForma(int id)
        {
            InitializeComponent();
            idNapredak = id;
        }

        private void DodajFotografijuForma_Load(object sender, EventArgs e)
        {

        }
        private void btIzaberi_Click(object sender, EventArgs e)
        {
            string folder = Path.Combine(Application.StartupPath,"Fotografije");

            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Folder Fotografije ne postoji.");
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Izaberite fotografiju";

                dialog.InitialDirectory = folder;

                dialog.Filter ="Slike (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                string izabranaPutanja =Path.GetFullPath(dialog.FileName);

                string folderPutanja =Path.GetFullPath(folder);

                if (!izabranaPutanja.StartsWith(folderPutanja + Path.DirectorySeparatorChar,StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Morate izabrati samo fotografiju iz foldera Fotografije.");
                    return;
                }

                nazivFotografije =Path.GetFileName(dialog.FileName);

                tbFotografija.Text = nazivFotografije;

                if (pcFotografija.Image != null)
                {
                    pcFotografija.Image.Dispose();
                    pcFotografija.Image = null;
                }

                pcFotografija.Image =Image.FromFile(izabranaPutanja);

                pcFotografija.SizeMode =PictureBoxSizeMode.Zoom;
            }

        }

        private void btDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nazivFotografije))
            {
                MessageBox.Show("Morate izabrati fotografiju");
                return;
            }

            FotografijaBasic fotografija =new FotografijaBasic(idNapredak,nazivFotografije);

            DTOManager.dodajFotografiju(fotografija);

            MessageBox.Show("Uspesno dodavanje.");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
