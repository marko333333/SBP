namespace Gradjevinska_firma.Forme
{
    partial class IzmeniZadatakForma
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
            lbProjekat = new Label();
            btIzmeni = new Button();
            label7 = new Label();
            prioritet = new NumericUpDown();
            cbNadzadatak = new ComboBox();
            cbFaza = new ComboBox();
            cbStatus = new ComboBox();
            dtpStvarniZ = new DateTimePicker();
            dtpPlaniraniZ = new DateTimePicker();
            dtpStvarniP = new DateTimePicker();
            dtpPlaniraniP = new DateTimePicker();
            tbTrosak = new TextBox();
            tbOpis = new TextBox();
            tbNaziv = new TextBox();
            label6 = new Label();
            label5 = new Label();
            lb1 = new Label();
            lb3 = new Label();
            lb4 = new Label();
            lb2 = new Label();
            lb5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)prioritet).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbProjekat);
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(prioritet);
            groupBox1.Controls.Add(cbNadzadatak);
            groupBox1.Controls.Add(cbFaza);
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(dtpStvarniZ);
            groupBox1.Controls.Add(dtpPlaniraniZ);
            groupBox1.Controls.Add(dtpStvarniP);
            groupBox1.Controls.Add(dtpPlaniraniP);
            groupBox1.Controls.Add(tbTrosak);
            groupBox1.Controls.Add(tbOpis);
            groupBox1.Controls.Add(tbNaziv);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lb1);
            groupBox1.Controls.Add(lb3);
            groupBox1.Controls.Add(lb4);
            groupBox1.Controls.Add(lb2);
            groupBox1.Controls.Add(lb5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 356);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni zadatak";
            // 
            // lbProjekat
            // 
            lbProjekat.AutoSize = true;
            lbProjekat.Location = new Point(316, 215);
            lbProjekat.Name = "lbProjekat";
            lbProjekat.Size = new Size(50, 20);
            lbProjekat.TabIndex = 60;
            lbProjekat.Text = "label8";
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(615, 304);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 56;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(244, 215);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 59;
            label7.Text = "Projekat:";
            // 
            // prioritet
            // 
            prioritet.Location = new Point(97, 139);
            prioritet.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            prioritet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            prioritet.Name = "prioritet";
            prioritet.Size = new Size(150, 27);
            prioritet.TabIndex = 55;
            prioritet.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cbNadzadatak
            // 
            cbNadzadatak.FormattingEnabled = true;
            cbNadzadatak.Location = new Point(124, 249);
            cbNadzadatak.Name = "cbNadzadatak";
            cbNadzadatak.Size = new Size(151, 28);
            cbNadzadatak.TabIndex = 54;
            // 
            // cbFaza
            // 
            cbFaza.FormattingEnabled = true;
            cbFaza.Location = new Point(74, 212);
            cbFaza.Name = "cbFaza";
            cbFaza.Size = new Size(151, 28);
            cbFaza.TabIndex = 53;
            cbFaza.SelectedIndexChanged += cbFaza_SelectedIndexChanged;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Planiran", "U toku", "Zavrsen", "Otkazan" });
            cbStatus.Location = new Point(86, 176);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 28);
            cbStatus.TabIndex = 52;
            // 
            // dtpStvarniZ
            // 
            dtpStvarniZ.Location = new Point(523, 141);
            dtpStvarniZ.Name = "dtpStvarniZ";
            dtpStvarniZ.Size = new Size(250, 27);
            dtpStvarniZ.TabIndex = 51;
            // 
            // dtpPlaniraniZ
            // 
            dtpPlaniraniZ.Location = new Point(531, 103);
            dtpPlaniraniZ.Name = "dtpPlaniraniZ";
            dtpPlaniraniZ.Size = new Size(250, 27);
            dtpPlaniraniZ.TabIndex = 50;
            // 
            // dtpStvarniP
            // 
            dtpStvarniP.Location = new Point(523, 66);
            dtpStvarniP.Name = "dtpStvarniP";
            dtpStvarniP.Size = new Size(250, 27);
            dtpStvarniP.TabIndex = 49;
            // 
            // dtpPlaniraniP
            // 
            dtpPlaniraniP.Location = new Point(523, 30);
            dtpPlaniraniP.Name = "dtpPlaniraniP";
            dtpPlaniraniP.Size = new Size(250, 27);
            dtpPlaniraniP.TabIndex = 48;
            // 
            // tbTrosak
            // 
            tbTrosak.Location = new Point(86, 103);
            tbTrosak.Name = "tbTrosak";
            tbTrosak.Size = new Size(131, 27);
            tbTrosak.TabIndex = 46;
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(74, 71);
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(205, 27);
            tbOpis.TabIndex = 45;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(81, 37);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(159, 27);
            tbNaziv.TabIndex = 44;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 252);
            label6.Name = "label6";
            label6.Size = new Size(92, 20);
            label6.TabIndex = 41;
            label6.Text = "Nadzadatak:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 215);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 40;
            label5.Text = "Faza:";
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(26, 40);
            lb1.Name = "lb1";
            lb1.Size = new Size(49, 20);
            lb1.TabIndex = 22;
            lb1.Text = "Naziv:";
            // 
            // lb3
            // 
            lb3.AutoSize = true;
            lb3.Location = new Point(26, 106);
            lb3.Name = "lb3";
            lb3.Size = new Size(54, 20);
            lb3.TabIndex = 24;
            lb3.Text = "Trosak:";
            // 
            // lb4
            // 
            lb4.AutoSize = true;
            lb4.Location = new Point(26, 141);
            lb4.Name = "lb4";
            lb4.Size = new Size(65, 20);
            lb4.TabIndex = 25;
            lb4.Text = "Prioritet:";
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Location = new Point(26, 74);
            lb2.Name = "lb2";
            lb2.Size = new Size(42, 20);
            lb2.TabIndex = 23;
            lb2.Text = "Opis:";
            // 
            // lb5
            // 
            lb5.AutoSize = true;
            lb5.Location = new Point(26, 179);
            lb5.Name = "lb5";
            lb5.Size = new Size(52, 20);
            lb5.TabIndex = 26;
            lb5.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(391, 141);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 35;
            label4.Text = "Stvarni zavrsetak:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(391, 106);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 34;
            label3.Text = "Planirani zavrsetak:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(391, 71);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 33;
            label2.Text = "Stvarni pocetak:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(391, 37);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 32;
            label1.Text = "Planirani pocetak:";
            // 
            // IzmeniZadatakForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 356);
            Controls.Add(groupBox1);
            Name = "IzmeniZadatakForma";
            Text = "IzmeniZadatakForma";
            Load += IzmeniZadatakForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)prioritet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btIzmeni;
        private NumericUpDown prioritet;
        private ComboBox cbNadzadatak;
        private ComboBox cbFaza;
        private ComboBox cbStatus;
        private DateTimePicker dtpStvarniZ;
        private DateTimePicker dtpPlaniraniZ;
        private DateTimePicker dtpStvarniP;
        private DateTimePicker dtpPlaniraniP;
        private TextBox tbTrosak;
        private TextBox tbOpis;
        private TextBox tbNaziv;
        private Label label6;
        private Label label5;
        private Label lb1;
        private Label lb3;
        private Label lb4;
        private Label lb2;
        private Label lb5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lbProjekat;
        private Label label7;
    }
}