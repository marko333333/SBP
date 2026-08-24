namespace Gradjevinska_firma.Forme
{
    partial class DodajNabavkuMaterijalForma
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
            tbCena = new TextBox();
            tbKolicina = new TextBox();
            cbMaterijal = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbStatus = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(tbCena);
            groupBox1.Controls.Add(tbKolicina);
            groupBox1.Controls.Add(cbMaterijal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(332, 291);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj nabavku materijala";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(43, 250);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 8;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // tbCena
            // 
            tbCena.Location = new Point(91, 134);
            tbCena.Name = "tbCena";
            tbCena.Size = new Size(125, 27);
            tbCena.TabIndex = 6;
            // 
            // tbKolicina
            // 
            tbKolicina.Location = new Point(112, 87);
            tbKolicina.Name = "tbKolicina";
            tbKolicina.Size = new Size(125, 27);
            tbKolicina.TabIndex = 5;
            // 
            // cbMaterijal
            // 
            cbMaterijal.FormattingEnabled = true;
            cbMaterijal.Location = new Point(112, 44);
            cbMaterijal.Name = "cbMaterijal";
            cbMaterijal.Size = new Size(178, 28);
            cbMaterijal.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 180);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 137);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Cena:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 90);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 1;
            label2.Text = "Kolicina:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 47);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 0;
            label1.Text = "Materijal:";
            // 
            // cbStatus
            // 
            cbStatus.AutoSize = true;
            cbStatus.Location = new Point(46, 185);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(95, 24);
            cbStatus.TabIndex = 9;
            cbStatus.Text = "Isporucen";
            cbStatus.UseVisualStyleBackColor = true;
            // 
            // DodajNabavkuMaterijalForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 291);
            Controls.Add(groupBox1);
            Name = "DodajNabavkuMaterijalForma";
            Text = "DodajNabavkuMaterijalForma";
            Load += DodajNabavkuMaterijalForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btDodaj;
        private TextBox tbCena;
        private TextBox tbKolicina;
        private ComboBox cbMaterijal;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox cbStatus;
    }
}