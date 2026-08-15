namespace Gradjevinska_firma.Forme
{
    partial class DodajZadatakForma
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
            label7 = new Label();
            btDodaj = new Button();
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
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btDodaj);
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
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(700, 282);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj zadatak";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lbProjekat
            // 
            lbProjekat.AutoSize = true;
            lbProjekat.Location = new Point(275, 161);
            lbProjekat.Name = "lbProjekat";
            lbProjekat.Size = new Size(38, 15);
            lbProjekat.TabIndex = 58;
            lbProjekat.Text = "label8";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(212, 161);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 57;
            label7.Text = "Projekat:";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(538, 228);
            btDodaj.Margin = new Padding(3, 2, 3, 2);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(82, 22);
            btDodaj.TabIndex = 56;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // prioritet
            // 
            prioritet.Location = new Point(85, 104);
            prioritet.Margin = new Padding(3, 2, 3, 2);
            prioritet.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            prioritet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            prioritet.Name = "prioritet";
            prioritet.Size = new Size(131, 23);
            prioritet.TabIndex = 55;
            prioritet.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // cbNadzadatak
            // 
            cbNadzadatak.FormattingEnabled = true;
            cbNadzadatak.Location = new Point(108, 187);
            cbNadzadatak.Margin = new Padding(3, 2, 3, 2);
            cbNadzadatak.Name = "cbNadzadatak";
            cbNadzadatak.Size = new Size(133, 23);
            cbNadzadatak.TabIndex = 54;
            // 
            // cbFaza
            // 
            cbFaza.FormattingEnabled = true;
            cbFaza.Location = new Point(65, 159);
            cbFaza.Margin = new Padding(3, 2, 3, 2);
            cbFaza.Name = "cbFaza";
            cbFaza.Size = new Size(133, 23);
            cbFaza.TabIndex = 53;
            cbFaza.SelectedIndexChanged += cbFaza_SelectedIndexChanged;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Planiran", "U toku", "Zavrsen", "Otkazan" });
            cbStatus.Location = new Point(75, 132);
            cbStatus.Margin = new Padding(3, 2, 3, 2);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(133, 23);
            cbStatus.TabIndex = 52;
            // 
            // dtpStvarniZ
            // 
            dtpStvarniZ.Location = new Point(458, 106);
            dtpStvarniZ.Margin = new Padding(3, 2, 3, 2);
            dtpStvarniZ.Name = "dtpStvarniZ";
            dtpStvarniZ.Size = new Size(219, 23);
            dtpStvarniZ.TabIndex = 51;
            // 
            // dtpPlaniraniZ
            // 
            dtpPlaniraniZ.Location = new Point(465, 77);
            dtpPlaniraniZ.Margin = new Padding(3, 2, 3, 2);
            dtpPlaniraniZ.Name = "dtpPlaniraniZ";
            dtpPlaniraniZ.Size = new Size(219, 23);
            dtpPlaniraniZ.TabIndex = 50;
            // 
            // dtpStvarniP
            // 
            dtpStvarniP.Location = new Point(458, 50);
            dtpStvarniP.Margin = new Padding(3, 2, 3, 2);
            dtpStvarniP.Name = "dtpStvarniP";
            dtpStvarniP.Size = new Size(219, 23);
            dtpStvarniP.TabIndex = 49;
            // 
            // dtpPlaniraniP
            // 
            dtpPlaniraniP.Location = new Point(458, 22);
            dtpPlaniraniP.Margin = new Padding(3, 2, 3, 2);
            dtpPlaniraniP.Name = "dtpPlaniraniP";
            dtpPlaniraniP.Size = new Size(219, 23);
            dtpPlaniraniP.TabIndex = 48;
            // 
            // tbTrosak
            // 
            tbTrosak.Location = new Point(75, 77);
            tbTrosak.Margin = new Padding(3, 2, 3, 2);
            tbTrosak.Name = "tbTrosak";
            tbTrosak.Size = new Size(115, 23);
            tbTrosak.TabIndex = 46;
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(65, 53);
            tbOpis.Margin = new Padding(3, 2, 3, 2);
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(180, 23);
            tbOpis.TabIndex = 45;
            // 
            // tbNaziv
            // 
            tbNaziv.Location = new Point(71, 28);
            tbNaziv.Margin = new Padding(3, 2, 3, 2);
            tbNaziv.Name = "tbNaziv";
            tbNaziv.Size = new Size(140, 23);
            tbNaziv.TabIndex = 44;
            tbNaziv.TextChanged += tbNaziv_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 189);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 41;
            label6.Text = "Nadzadatak:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 161);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 40;
            label5.Text = "Faza:";
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(23, 30);
            lb1.Name = "lb1";
            lb1.Size = new Size(39, 15);
            lb1.TabIndex = 22;
            lb1.Text = "Naziv:";
            // 
            // lb3
            // 
            lb3.AutoSize = true;
            lb3.Location = new Point(23, 80);
            lb3.Name = "lb3";
            lb3.Size = new Size(44, 15);
            lb3.TabIndex = 24;
            lb3.Text = "Trosak:";
            // 
            // lb4
            // 
            lb4.AutoSize = true;
            lb4.Location = new Point(23, 106);
            lb4.Name = "lb4";
            lb4.Size = new Size(52, 15);
            lb4.TabIndex = 25;
            lb4.Text = "Prioritet:";
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Location = new Point(23, 56);
            lb2.Name = "lb2";
            lb2.Size = new Size(34, 15);
            lb2.TabIndex = 23;
            lb2.Text = "Opis:";
            // 
            // lb5
            // 
            lb5.AutoSize = true;
            lb5.Location = new Point(23, 134);
            lb5.Name = "lb5";
            lb5.Size = new Size(42, 15);
            lb5.TabIndex = 26;
            lb5.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(342, 106);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 35;
            label4.Text = "Stvarni zavrsetak:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(342, 80);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 34;
            label3.Text = "Planirani zavrsetak:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(342, 53);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 33;
            label2.Text = "Stvarni pocetak:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(342, 28);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 32;
            label1.Text = "Planirani pocetak:";
            // 
            // DodajZadatakForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 282);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DodajZadatakForma";
            Text = "DodajZadatakForma";
            Load += DodajZadatakForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)prioritet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
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
        private NumericUpDown prioritet;
        private ComboBox cbNadzadatak;
        private ComboBox cbFaza;
        private Button btDodaj;
        private Label lbProjekat;
        private Label label7;
    }
}