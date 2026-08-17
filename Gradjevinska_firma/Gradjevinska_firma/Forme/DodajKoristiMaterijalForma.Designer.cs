namespace Gradjevinska_firma.Forme
{
    partial class DodajKoristiMaterijalForma
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
            cbMaterijal = new ComboBox();
            tbKolicina = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(cbMaterijal);
            groupBox1.Controls.Add(tbKolicina);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(410, 226);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj koriscenje";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(29, 149);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 4;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // cbMaterijal
            // 
            cbMaterijal.FormattingEnabled = true;
            cbMaterijal.Location = new Point(94, 40);
            cbMaterijal.Name = "cbMaterijal";
            cbMaterijal.Size = new Size(151, 28);
            cbMaterijal.TabIndex = 3;
            // 
            // tbKolicina
            // 
            tbKolicina.Location = new Point(94, 78);
            tbKolicina.Name = "tbKolicina";
            tbKolicina.Size = new Size(147, 27);
            tbKolicina.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 81);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Kolicina:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 43);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 0;
            label1.Text = "Materijal:";
            // 
            // DodajKoristiMaterijalForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 226);
            Controls.Add(groupBox1);
            Name = "DodajKoristiMaterijalForma";
            Text = "DodajKoristiMaterijalForma";
            Load += DodajKoristiMaterijalForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btDodaj;
        private ComboBox cbMaterijal;
        private TextBox tbKolicina;
        private Label label2;
        private Label label1;
    }
}