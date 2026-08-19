namespace Gradjevinska_firma.Forme
{
    partial class DodajMaterijalForma
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
            btDodaj = new Button();
            tbSertifikat = new TextBox();
            tbJedinicaMere = new TextBox();
            tbProizvodjac = new TextBox();
            tbcena = new TextBox();
            tbNaziv = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(tbSertifikat);
            groupBox1.Controls.Add(tbJedinicaMere);
            groupBox1.Controls.Add(tbProizvodjac);
            groupBox1.Controls.Add(tbcena);
            groupBox1.Controls.Add(tbNaziv);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(420, 326);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj gradjevinski materijal";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(33, 266);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 12;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // tbSertifikat
            // 
            tbSertifikat.Location = new Point(110, 215);
            tbSertifikat.Name = "tbSertifikat";
            tbSertifikat.Size = new Size(125, 27);
            tbSertifikat.TabIndex = 10;
            // 
            // tbJedinicaMere
            // 
            tbJedinicaMere.Location = new Point(142, 174);
            tbJedinicaMere.Name = "tbJedinicaMere";
            tbJedinicaMere.Size = new Size(79, 27);
            tbJedinicaMere.TabIndex = 9;
            // 
            // tbProizvodjac
            // 
            tbProizvodjac.Location = new Point(128, 133);
            tbProizvodjac.Name = "tbProizvodjac";
            tbProizvodjac.Size = new Size(180, 27);
            tbProizvodjac.TabIndex = 8;
            // 
            // tbcena
            // 
            tbcena.Location = new Point(84, 92);
            tbcena.Name = "tbcena";
            tbcena.Size = new Size(125, 27);
            tbcena.TabIndex = 7;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(88, 50);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(149, 27);
            tbNaziv.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 218);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 4;
            label5.Text = "Sertifikat:";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 177);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 3;
            label4.Text = "Jedinica mere:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 136);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 2;
            label3.Text = "Proizvodjac:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 95);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 1;
            label2.Text = "Cena:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 53);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // DodajMaterijalForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 326);
            Controls.Add(groupBox1);
            Name = "DodajMaterijalForma";
            Text = "DodajMaterijalForma";
            Load += DodajMaterijalForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label4;
        private Button btDodaj;
        private TextBox tbSertifikat;
        private TextBox tbJedinicaMere;
        private TextBox tbProizvodjac;
        private TextBox tbcena;
        private TextBox tbNaziv;
    }
}