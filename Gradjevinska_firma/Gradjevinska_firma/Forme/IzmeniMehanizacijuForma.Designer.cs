namespace Gradjevinska_firma.Forme
{
    partial class IzmeniMehanizacijuForma
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
            label5 = new Label();
            btIzmeni = new Button();
            cbStatus = new ComboBox();
            tbLokacija = new TextBox();
            tbRasponOdrzavanja = new TextBox();
            tbProizvodjac = new TextBox();
            dtpdatumUvoza = new DateTimePicker();
            tbTip = new TextBox();
            tbNaziv = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cbTipMehanizacije = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbTipMehanizacije);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(tbLokacija);
            groupBox1.Controls.Add(tbRasponOdrzavanja);
            groupBox1.Controls.Add(tbProizvodjac);
            groupBox1.Controls.Add(dtpdatumUvoza);
            groupBox1.Controls.Add(tbTip);
            groupBox1.Controls.Add(tbNaziv);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(455, 450);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni mehanizaciju";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 311);
            label5.Name = "label5";
            label5.Size = new Size(124, 20);
            label5.TabIndex = 17;
            label5.Text = "Tip mehanizacije:";
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(36, 361);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 16;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Slobodna", "U upotrebi", "U odrzavanju", "Rashodovana", "Vracena" });
            cbStatus.Location = new Point(94, 263);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 28);
            cbStatus.TabIndex = 15;
            // 
            // tbLokacija
            // 
            tbLokacija.Location = new Point(102, 222);
            tbLokacija.Name = "tbLokacija";
            tbLokacija.Size = new Size(173, 27);
            tbLokacija.TabIndex = 14;
            // 
            // tbRasponOdrzavanja
            // 
            tbRasponOdrzavanja.Location = new Point(174, 187);
            tbRasponOdrzavanja.Name = "tbRasponOdrzavanja";
            tbRasponOdrzavanja.Size = new Size(139, 27);
            tbRasponOdrzavanja.TabIndex = 13;
            // 
            // tbProizvodjac
            // 
            tbProizvodjac.Location = new Point(125, 148);
            tbProizvodjac.Name = "tbProizvodjac";
            tbProizvodjac.Size = new Size(188, 27);
            tbProizvodjac.TabIndex = 11;
            // 
            // dtpdatumUvoza
            // 
            dtpdatumUvoza.Location = new Point(136, 116);
            dtpdatumUvoza.Name = "dtpdatumUvoza";
            dtpdatumUvoza.Size = new Size(250, 27);
            dtpdatumUvoza.TabIndex = 10;
            // 
            // tbTip
            // 
            tbTip.Location = new Point(69, 83);
            tbTip.Name = "tbTip";
            tbTip.Size = new Size(206, 27);
            tbTip.TabIndex = 9;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(85, 51);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(190, 27);
            tbNaziv.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 266);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 7;
            label8.Text = "Status:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 225);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 6;
            label7.Text = "Lokacija:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 190);
            label6.Name = "label6";
            label6.Size = new Size(138, 20);
            label6.TabIndex = 5;
            label6.Text = "Raspon odrzavanja:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 151);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Proizvodjac:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 119);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 2;
            label3.Text = "Datum uvoza:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 86);
            label2.Name = "label2";
            label2.Size = new Size(33, 20);
            label2.TabIndex = 1;
            label2.Text = "Tip:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 54);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // cbTipMehanizacije
            // 
            cbTipMehanizacije.FormattingEnabled = true;
            cbTipMehanizacije.Items.AddRange(new object[] { "Gradjevinska masina", "Alat", "Transportno sredstvo", "Specijalizovana oprema" });
            cbTipMehanizacije.Location = new Point(166, 308);
            cbTipMehanizacije.Name = "cbTipMehanizacije";
            cbTipMehanizacije.Size = new Size(191, 28);
            cbTipMehanizacije.TabIndex = 19;
            // 
            // IzmeniMehanizacijuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 450);
            Controls.Add(groupBox1);
            Name = "IzmeniMehanizacijuForma";
            Text = "IzmeniMehanizacijuForma";
            Load += IzmeniMehanizacijuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private Button btIzmeni;
        private ComboBox cbStatus;
        private TextBox tbLokacija;
        private TextBox tbRasponOdrzavanja;
        private TextBox tbProizvodjac;
        private DateTimePicker dtpdatumUvoza;
        private TextBox tbTip;
        private TextBox tbNaziv;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cbTipMehanizacije;
    }
}