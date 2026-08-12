namespace Gradjevinska_firma.Forme
{
    partial class IzmeniOsobuForma
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
            dtpDatumRodjenja = new DateTimePicker();
            gbFizickoLice = new GroupBox();
            tbOdgovornosti = new TextBox();
            tbKvalifikacija = new TextBox();
            tbOblastRada = new TextBox();
            cbAO = new CheckBox();
            cbNO = new CheckBox();
            cbPoslovodja = new CheckBox();
            cbArhitekta = new CheckBox();
            cbInzenjer = new CheckBox();
            cbRadnik = new CheckBox();
            lbO = new Label();
            lbK = new Label();
            lbOR = new Label();
            cbBK = new CheckBox();
            gbPravnoLice = new GroupBox();
            cbNadzorniOrgan = new CheckBox();
            cbDobavljaci = new CheckBox();
            cbPodizvodjac = new CheckBox();
            cbIzvodjac = new CheckBox();
            cbInvenstitor = new CheckBox();
            cbPB = new CheckBox();
            tbStruka = new TextBox();
            tbPrezime = new TextBox();
            tbIme = new TextBox();
            tbJmbg = new TextBox();
            btIzmeni = new Button();
            rbPravnoLice = new RadioButton();
            rbFizickoLice = new RadioButton();
            lb5 = new Label();
            lb1 = new Label();
            lb2 = new Label();
            lb4 = new Label();
            lb3 = new Label();
            groupBox1.SuspendLayout();
            gbFizickoLice.SuspendLayout();
            gbPravnoLice.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpDatumRodjenja);
            groupBox1.Controls.Add(gbFizickoLice);
            groupBox1.Controls.Add(gbPravnoLice);
            groupBox1.Controls.Add(tbStruka);
            groupBox1.Controls.Add(tbPrezime);
            groupBox1.Controls.Add(tbIme);
            groupBox1.Controls.Add(tbJmbg);
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(rbPravnoLice);
            groupBox1.Controls.Add(rbFizickoLice);
            groupBox1.Controls.Add(lb5);
            groupBox1.Controls.Add(lb1);
            groupBox1.Controls.Add(lb2);
            groupBox1.Controls.Add(lb4);
            groupBox1.Controls.Add(lb3);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 450);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Osoba";
            // 
            // dtpDatumRodjenja
            // 
            dtpDatumRodjenja.Location = new Point(150, 169);
            dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            dtpDatumRodjenja.Size = new Size(200, 27);
            dtpDatumRodjenja.TabIndex = 30;
            // 
            // gbFizickoLice
            // 
            gbFizickoLice.Controls.Add(tbOdgovornosti);
            gbFizickoLice.Controls.Add(tbKvalifikacija);
            gbFizickoLice.Controls.Add(tbOblastRada);
            gbFizickoLice.Controls.Add(cbAO);
            gbFizickoLice.Controls.Add(cbNO);
            gbFizickoLice.Controls.Add(cbPoslovodja);
            gbFizickoLice.Controls.Add(cbArhitekta);
            gbFizickoLice.Controls.Add(cbInzenjer);
            gbFizickoLice.Controls.Add(cbRadnik);
            gbFizickoLice.Controls.Add(lbO);
            gbFizickoLice.Controls.Add(lbK);
            gbFizickoLice.Controls.Add(lbOR);
            gbFizickoLice.Controls.Add(cbBK);
            gbFizickoLice.Location = new Point(356, 9);
            gbFizickoLice.Name = "gbFizickoLice";
            gbFizickoLice.Size = new Size(438, 362);
            gbFizickoLice.TabIndex = 29;
            gbFizickoLice.TabStop = false;
            gbFizickoLice.Text = "Fizicko lice";
            // 
            // tbOdgovornosti
            // 
            tbOdgovornosti.Location = new Point(159, 174);
            tbOdgovornosti.Name = "tbOdgovornosti";
            tbOdgovornosti.Size = new Size(165, 27);
            tbOdgovornosti.TabIndex = 31;
            // 
            // tbKvalifikacija
            // 
            tbKvalifikacija.Location = new Point(150, 91);
            tbKvalifikacija.Name = "tbKvalifikacija";
            tbKvalifikacija.Size = new Size(165, 27);
            tbKvalifikacija.TabIndex = 29;
            // 
            // tbOblastRada
            // 
            tbOblastRada.Location = new Point(150, 141);
            tbOblastRada.Name = "tbOblastRada";
            tbOblastRada.Size = new Size(165, 27);
            tbOblastRada.TabIndex = 30;
            // 
            // cbAO
            // 
            cbAO.AutoSize = true;
            cbAO.Location = new Point(22, 295);
            cbAO.Name = "cbAO";
            cbAO.Size = new Size(189, 24);
            cbAO.TabIndex = 9;
            cbAO.Text = "Administrativno osoblje";
            cbAO.UseVisualStyleBackColor = true;
            // 
            // cbNO
            // 
            cbNO.AutoSize = true;
            cbNO.Location = new Point(22, 265);
            cbNO.Name = "cbNO";
            cbNO.Size = new Size(137, 24);
            cbNO.TabIndex = 8;
            cbNO.Text = "Nadzorni Organ";
            cbNO.UseVisualStyleBackColor = true;
            // 
            // cbPoslovodja
            // 
            cbPoslovodja.AutoSize = true;
            cbPoslovodja.Location = new Point(22, 235);
            cbPoslovodja.Name = "cbPoslovodja";
            cbPoslovodja.Size = new Size(103, 24);
            cbPoslovodja.TabIndex = 7;
            cbPoslovodja.Text = "Poslovodja";
            cbPoslovodja.UseVisualStyleBackColor = true;
            // 
            // cbArhitekta
            // 
            cbArhitekta.AutoSize = true;
            cbArhitekta.Location = new Point(22, 205);
            cbArhitekta.Name = "cbArhitekta";
            cbArhitekta.Size = new Size(91, 24);
            cbArhitekta.TabIndex = 6;
            cbArhitekta.Text = "Arhitekta";
            cbArhitekta.UseVisualStyleBackColor = true;
            // 
            // cbInzenjer
            // 
            cbInzenjer.AutoSize = true;
            cbInzenjer.Location = new Point(22, 117);
            cbInzenjer.Name = "cbInzenjer";
            cbInzenjer.Size = new Size(83, 24);
            cbInzenjer.TabIndex = 5;
            cbInzenjer.Text = "Inzenjer";
            cbInzenjer.UseVisualStyleBackColor = true;
            cbInzenjer.CheckedChanged += cbInzenjer_CheckedChanged;
            // 
            // cbRadnik
            // 
            cbRadnik.AutoSize = true;
            cbRadnik.Location = new Point(22, 67);
            cbRadnik.Name = "cbRadnik";
            cbRadnik.Size = new Size(76, 24);
            cbRadnik.TabIndex = 4;
            cbRadnik.Text = "Radnik";
            cbRadnik.UseVisualStyleBackColor = true;
            cbRadnik.CheckedChanged += cbRadnik_CheckedChanged;
            // 
            // lbO
            // 
            lbO.AutoSize = true;
            lbO.Location = new Point(55, 173);
            lbO.Name = "lbO";
            lbO.Size = new Size(103, 20);
            lbO.TabIndex = 3;
            lbO.Text = "Odgovornosti:";
            // 
            // lbK
            // 
            lbK.AutoSize = true;
            lbK.Location = new Point(54, 94);
            lbK.Name = "lbK";
            lbK.Size = new Size(90, 20);
            lbK.TabIndex = 2;
            lbK.Text = "Kvalifikacija:";
            // 
            // lbOR
            // 
            lbOR.AutoSize = true;
            lbOR.Location = new Point(55, 144);
            lbOR.Name = "lbOR";
            lbOR.Size = new Size(89, 20);
            lbOR.TabIndex = 1;
            lbOR.Text = "Oblast rada:";
            // 
            // cbBK
            // 
            cbBK.AutoSize = true;
            cbBK.Location = new Point(22, 37);
            cbBK.Name = "cbBK";
            cbBK.Size = new Size(198, 24);
            cbBK.TabIndex = 0;
            cbBK.Text = "Bezbednosni koordinator";
            cbBK.UseVisualStyleBackColor = true;
            // 
            // gbPravnoLice
            // 
            gbPravnoLice.Controls.Add(cbNadzorniOrgan);
            gbPravnoLice.Controls.Add(cbDobavljaci);
            gbPravnoLice.Controls.Add(cbPodizvodjac);
            gbPravnoLice.Controls.Add(cbIzvodjac);
            gbPravnoLice.Controls.Add(cbInvenstitor);
            gbPravnoLice.Controls.Add(cbPB);
            gbPravnoLice.Location = new Point(356, 12);
            gbPravnoLice.Name = "gbPravnoLice";
            gbPravnoLice.Size = new Size(432, 359);
            gbPravnoLice.TabIndex = 28;
            gbPravnoLice.TabStop = false;
            gbPravnoLice.Text = "Pravno lice";
            // 
            // cbNadzorniOrgan
            // 
            cbNadzorniOrgan.AutoSize = true;
            cbNadzorniOrgan.Location = new Point(22, 187);
            cbNadzorniOrgan.Name = "cbNadzorniOrgan";
            cbNadzorniOrgan.Size = new Size(137, 24);
            cbNadzorniOrgan.TabIndex = 8;
            cbNadzorniOrgan.Text = "Nadzorni Organ";
            cbNadzorniOrgan.UseVisualStyleBackColor = true;
            // 
            // cbDobavljaci
            // 
            cbDobavljaci.AutoSize = true;
            cbDobavljaci.Location = new Point(22, 157);
            cbDobavljaci.Name = "cbDobavljaci";
            cbDobavljaci.Size = new Size(98, 24);
            cbDobavljaci.TabIndex = 7;
            cbDobavljaci.Text = "Dobavljac";
            cbDobavljaci.UseVisualStyleBackColor = true;
            // 
            // cbPodizvodjac
            // 
            cbPodizvodjac.AutoSize = true;
            cbPodizvodjac.Location = new Point(22, 127);
            cbPodizvodjac.Name = "cbPodizvodjac";
            cbPodizvodjac.Size = new Size(111, 24);
            cbPodizvodjac.TabIndex = 6;
            cbPodizvodjac.Text = "Podizvodjac";
            cbPodizvodjac.UseVisualStyleBackColor = true;
            // 
            // cbIzvodjac
            // 
            cbIzvodjac.AutoSize = true;
            cbIzvodjac.Location = new Point(22, 97);
            cbIzvodjac.Name = "cbIzvodjac";
            cbIzvodjac.Size = new Size(86, 24);
            cbIzvodjac.TabIndex = 5;
            cbIzvodjac.Text = "Izvodjac";
            cbIzvodjac.UseVisualStyleBackColor = true;
            // 
            // cbInvenstitor
            // 
            cbInvenstitor.AutoSize = true;
            cbInvenstitor.Location = new Point(22, 67);
            cbInvenstitor.Name = "cbInvenstitor";
            cbInvenstitor.Size = new Size(92, 24);
            cbInvenstitor.TabIndex = 4;
            cbInvenstitor.Text = "Investitor";
            cbInvenstitor.UseVisualStyleBackColor = true;
            // 
            // cbPB
            // 
            cbPB.AutoSize = true;
            cbPB.Location = new Point(22, 37);
            cbPB.Name = "cbPB";
            cbPB.Size = new Size(146, 24);
            cbPB.TabIndex = 0;
            cbPB.Text = "Projektantski biro";
            cbPB.UseVisualStyleBackColor = true;
            // 
            // tbStruka
            // 
            tbStruka.Location = new Point(84, 221);
            tbStruka.Name = "tbStruka";
            tbStruka.Size = new Size(165, 27);
            tbStruka.TabIndex = 27;
            // 
            // tbPrezime
            // 
            tbPrezime.Location = new Point(96, 121);
            tbPrezime.Name = "tbPrezime";
            tbPrezime.Size = new Size(165, 27);
            tbPrezime.TabIndex = 25;
            // 
            // tbIme
            // 
            tbIme.Location = new Point(68, 75);
            tbIme.Name = "tbIme";
            tbIme.Size = new Size(165, 27);
            tbIme.TabIndex = 24;
            // 
            // tbJmbg
            // 
            tbJmbg.Location = new Point(79, 32);
            tbJmbg.Name = "tbJmbg";
            tbJmbg.Size = new Size(165, 27);
            tbJmbg.TabIndex = 23;
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(213, 378);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(124, 43);
            btIzmeni.TabIndex = 22;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // rbPravnoLice
            // 
            rbPravnoLice.AutoSize = true;
            rbPravnoLice.Location = new Point(27, 317);
            rbPravnoLice.Name = "rbPravnoLice";
            rbPravnoLice.Size = new Size(102, 24);
            rbPravnoLice.TabIndex = 21;
            rbPravnoLice.TabStop = true;
            rbPravnoLice.Text = "Pravno lice";
            rbPravnoLice.UseVisualStyleBackColor = true;
            rbPravnoLice.CheckedChanged += rbPravnoLice_CheckedChanged;
            // 
            // rbFizickoLice
            // 
            rbFizickoLice.AutoSize = true;
            rbFizickoLice.Location = new Point(27, 270);
            rbFizickoLice.Name = "rbFizickoLice";
            rbFizickoLice.Size = new Size(102, 24);
            rbFizickoLice.TabIndex = 20;
            rbFizickoLice.TabStop = true;
            rbFizickoLice.Text = "Fizicko lice";
            rbFizickoLice.UseVisualStyleBackColor = true;
            rbFizickoLice.CheckedChanged += rbFizickoLice_CheckedChanged;
            // 
            // lb5
            // 
            lb5.AutoSize = true;
            lb5.Location = new Point(25, 224);
            lb5.Name = "lb5";
            lb5.Size = new Size(53, 20);
            lb5.TabIndex = 14;
            lb5.Text = "Struka:";
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(25, 35);
            lb1.Name = "lb1";
            lb1.Size = new Size(48, 20);
            lb1.TabIndex = 10;
            lb1.Text = "Jmbg:";
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Location = new Point(25, 78);
            lb2.Name = "lb2";
            lb2.Size = new Size(37, 20);
            lb2.TabIndex = 11;
            lb2.Text = "Ime:";
            // 
            // lb4
            // 
            lb4.AutoSize = true;
            lb4.Location = new Point(25, 173);
            lb4.Name = "lb4";
            lb4.Size = new Size(120, 20);
            lb4.TabIndex = 13;
            lb4.Text = "Datum Rodjenja:";
            // 
            // lb3
            // 
            lb3.AutoSize = true;
            lb3.Location = new Point(25, 124);
            lb3.Name = "lb3";
            lb3.Size = new Size(65, 20);
            lb3.TabIndex = 12;
            lb3.Text = "Prezime:";
            // 
            // IzmeniOsobuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "IzmeniOsobuForma";
            Text = "IzmeniOsobuForma";
            Load += IzmeniOsobuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbFizickoLice.ResumeLayout(false);
            gbFizickoLice.PerformLayout();
            gbPravnoLice.ResumeLayout(false);
            gbPravnoLice.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpDatumRodjenja;
        private GroupBox gbFizickoLice;
        private TextBox tbOdgovornosti;
        private TextBox tbKvalifikacija;
        private TextBox tbOblastRada;
        private CheckBox cbAO;
        private CheckBox cbNO;
        private CheckBox cbPoslovodja;
        private CheckBox cbArhitekta;
        private CheckBox cbInzenjer;
        private CheckBox cbRadnik;
        private Label lbO;
        private Label lbK;
        private Label lbOR;
        private CheckBox cbBK;
        private GroupBox gbPravnoLice;
        private CheckBox cbNadzorniOrgan;
        private CheckBox cbDobavljaci;
        private CheckBox cbPodizvodjac;
        private CheckBox cbIzvodjac;
        private CheckBox cbInvenstitor;
        private CheckBox cbPB;
        private TextBox tbStruka;
        private TextBox tbPrezime;
        private TextBox tbIme;
        private TextBox tbJmbg;
        private Button btIzmeni;
        private RadioButton rbPravnoLice;
        private RadioButton rbFizickoLice;
        private Label lb5;
        private Label lb1;
        private Label lb2;
        private Label lb4;
        private Label lb3;
    }
}