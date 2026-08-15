namespace Gradjevinska_firma.Forme
{
    partial class DodajIndustrijskiForma
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
            cbStatus = new ComboBox();
            nudBudzet = new NumericUpDown();
            Dodaj_button = new Button();
            tbNaziv = new TextBox();
            tbOpis = new TextBox();
            tbLokacija = new TextBox();
            dtpStvarniZavrsetak = new DateTimePicker();
            dtpPlaniraniZavrsetak = new DateTimePicker();
            dtpDatumPocetka = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBudzet).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(nudBudzet);
            groupBox1.Controls.Add(Dodaj_button);
            groupBox1.Controls.Add(tbNaziv);
            groupBox1.Controls.Add(tbOpis);
            groupBox1.Controls.Add(tbLokacija);
            groupBox1.Controls.Add(dtpStvarniZavrsetak);
            groupBox1.Controls.Add(dtpPlaniraniZavrsetak);
            groupBox1.Controls.Add(dtpDatumPocetka);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(16, 17);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(744, 268);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj industrijski projekat";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "U toku", "Zavrsen", "Planiran", "Otkazan" });
            cbStatus.Location = new Point(69, 140);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(121, 23);
            cbStatus.TabIndex = 19;
            // 
            // nudBudzet
            // 
            nudBudzet.Location = new Point(70, 109);
            nudBudzet.Name = "nudBudzet";
            nudBudzet.Size = new Size(120, 23);
            nudBudzet.TabIndex = 18;
            // 
            // Dodaj_button
            // 
            Dodaj_button.Location = new Point(669, 234);
            Dodaj_button.Name = "Dodaj_button";
            Dodaj_button.Size = new Size(75, 23);
            Dodaj_button.TabIndex = 17;
            Dodaj_button.Text = "Dodaj";
            Dodaj_button.UseVisualStyleBackColor = true;
            Dodaj_button.Click += button1_Click;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(70, 22);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(120, 23);
            tbNaziv.TabIndex = 16;
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(70, 51);
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(120, 23);
            tbOpis.TabIndex = 15;
            // 
            // tbLokacija
            // 
            tbLokacija.Location = new Point(70, 80);
            tbLokacija.Name = "tbLokacija";
            tbLokacija.Size = new Size(120, 23);
            tbLokacija.TabIndex = 14;
            // 
            // dtpStvarniZavrsetak
            // 
            dtpStvarniZavrsetak.Location = new Point(542, 118);
            dtpStvarniZavrsetak.Name = "dtpStvarniZavrsetak";
            dtpStvarniZavrsetak.Size = new Size(200, 23);
            dtpStvarniZavrsetak.TabIndex = 10;
            // 
            // dtpPlaniraniZavrsetak
            // 
            dtpPlaniraniZavrsetak.Location = new Point(542, 77);
            dtpPlaniraniZavrsetak.Name = "dtpPlaniraniZavrsetak";
            dtpPlaniraniZavrsetak.Size = new Size(200, 23);
            dtpPlaniraniZavrsetak.TabIndex = 9;
            // 
            // dtpDatumPocetka
            // 
            dtpDatumPocetka.Location = new Point(542, 35);
            dtpDatumPocetka.Name = "dtpDatumPocetka";
            dtpDatumPocetka.Size = new Size(200, 23);
            dtpDatumPocetka.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(432, 41);
            label8.Name = "label8";
            label8.Size = new Size(94, 15);
            label8.TabIndex = 7;
            label8.Text = "Datum pocetka :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(426, 83);
            label7.Name = "label7";
            label7.Size = new Size(110, 15);
            label7.TabIndex = 6;
            label7.Text = "Planirani zavrsetak :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(432, 124);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 5;
            label6.Text = "Stvarni zavrsetak :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 113);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 4;
            label5.Text = "Budzet :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 143);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 3;
            label4.Text = "Status :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 2;
            label3.Text = "Lokacija :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 59);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Opis :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Naziv :";
            // 
            // DodajIndustrijskiForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 286);
            Controls.Add(groupBox1);
            Name = "DodajIndustrijskiForma";
            Text = "DodajIndrustrijskiForma";
            Load += DodajIndustrijskiForma_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBudzet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpStvarniZavrsetak;
        private DateTimePicker dtpPlaniraniZavrsetak;
        private DateTimePicker dtpDatumPocetka;
        private TextBox tbNaziv;
        private TextBox tbOpis;
        private TextBox tbLokacija;
        private Button Dodaj_button;
        private NumericUpDown nudBudzet;
        private ComboBox cbStatus;
    }
}