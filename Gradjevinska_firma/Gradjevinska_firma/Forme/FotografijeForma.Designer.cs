namespace Gradjevinska_firma.Forme
{
    partial class FotografijeForma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            fotografije = new ListView();
            columnHeader1 = new ColumnHeader();
            pbFotografija = new PictureBox();
            btDodaj = new Button();
            btObrisi = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFotografija).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fotografije);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(514, 417);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fotografije";
            // 
            // fotografije
            // 
            fotografije.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            fotografije.Dock = DockStyle.Fill;
            fotografije.FullRowSelect = true;
            fotografije.GridLines = true;
            fotografije.Location = new Point(3, 23);
            fotografije.Name = "fotografije";
            fotografije.Size = new Size(508, 391);
            fotografije.TabIndex = 0;
            fotografije.UseCompatibleStateImageBehavior = false;
            fotografije.View = View.Details;
            fotografije.SelectedIndexChanged += fotografije_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Fotografija";
            // 
            // pbFotografija
            // 
            pbFotografija.Location = new Point(541, 23);
            pbFotografija.Name = "pbFotografija";
            pbFotografija.Size = new Size(388, 291);
            pbFotografija.TabIndex = 1;
            pbFotografija.TabStop = false;
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(605, 338);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(114, 64);
            btDodaj.TabIndex = 2;
            btDodaj.Text = "Dodaj fotografiju";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // btObrisi
            // 
            btObrisi.Location = new Point(791, 338);
            btObrisi.Name = "btObrisi";
            btObrisi.Size = new Size(114, 64);
            btObrisi.TabIndex = 4;
            btObrisi.Text = "Obrisi fotografiju";
            btObrisi.UseVisualStyleBackColor = true;
            btObrisi.Click += btObrisi_Click;
            // 
            // FotografijeForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 528);
            Controls.Add(btObrisi);
            Controls.Add(btDodaj);
            Controls.Add(pbFotografija);
            Controls.Add(groupBox1);
            Name = "FotografijeForma";
            Text = "FotografijeForma";
            Load += FotografijeForma_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFotografija).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView fotografije;
        private PictureBox pbFotografija;
        private Button btDodaj;
        private Button btObrisi;
        private ColumnHeader columnHeader1;
    }
}