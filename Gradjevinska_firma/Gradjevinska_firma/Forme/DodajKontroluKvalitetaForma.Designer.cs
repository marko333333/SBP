namespace Gradjevinska_firma.Forme
{
    partial class DodajKontroluKvalitetaForma
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbZabrana = new CheckBox();
            label5 = new Label();
            label6 = new Label();
            dtpDatumInspekcije = new DateTimePicker();
            dtpDatumOtklananja = new DateTimePicker();
            tbPrimedba = new TextBox();
            tbZapisnik = new TextBox();
            tbRazlogZabrane = new TextBox();
            btDodaj = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 62);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 0;
            label1.Text = "Datum inspekcije:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 105);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 1;
            label2.Text = "Primedba nadzora:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 154);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 2;
            label3.Text = "Zapisnik:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 196);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 3;
            // 
            // cbZabrana
            // 
            cbZabrana.AutoSize = true;
            cbZabrana.Location = new Point(37, 192);
            cbZabrana.Name = "cbZabrana";
            cbZabrana.Size = new Size(197, 24);
            cbZabrana.TabIndex = 4;
            cbZabrana.Text = "Zabrana nastavka radova";
            cbZabrana.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 242);
            label5.Name = "label5";
            label5.Size = new Size(115, 20);
            label5.TabIndex = 5;
            label5.Text = "Razlog zabrane:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 280);
            label6.Name = "label6";
            label6.Size = new Size(187, 20);
            label6.TabIndex = 6;
            label6.Text = "Datum otklananja zabrane:";
            // 
            // dtpDatumInspekcije
            // 
            dtpDatumInspekcije.Location = new Point(159, 55);
            dtpDatumInspekcije.Name = "dtpDatumInspekcije";
            dtpDatumInspekcije.Size = new Size(250, 27);
            dtpDatumInspekcije.TabIndex = 7;
            // 
            // dtpDatumOtklananja
            // 
            dtpDatumOtklananja.Location = new Point(217, 275);
            dtpDatumOtklananja.Name = "dtpDatumOtklananja";
            dtpDatumOtklananja.Size = new Size(250, 27);
            dtpDatumOtklananja.TabIndex = 8;
            // 
            // tbPrimedba
            // 
            tbPrimedba.Location = new Point(167, 102);
            tbPrimedba.Name = "tbPrimedba";
            tbPrimedba.Size = new Size(277, 27);
            tbPrimedba.TabIndex = 9;
            // 
            // tbZapisnik
            // 
            tbZapisnik.Location = new Point(102, 151);
            tbZapisnik.Name = "tbZapisnik";
            tbZapisnik.Size = new Size(277, 27);
            tbZapisnik.TabIndex = 10;
            // 
            // tbRazlogZabrane
            // 
            tbRazlogZabrane.Location = new Point(152, 239);
            tbRazlogZabrane.Name = "tbRazlogZabrane";
            tbRazlogZabrane.Size = new Size(277, 27);
            tbRazlogZabrane.TabIndex = 11;
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(404, 360);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 12;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbRazlogZabrane);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbZapisnik);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbPrimedba);
            groupBox1.Controls.Add(cbZabrana);
            groupBox1.Controls.Add(dtpDatumOtklananja);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtpDatumInspekcije);
            groupBox1.Controls.Add(label6);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(605, 408);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj kontrolu kvaliteta";
            // 
            // DodajKontroluKvalitetaForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 408);
            Controls.Add(groupBox1);
            Name = "DodajKontroluKvalitetaForma";
            Text = "DodajKontroluKvalitetaForma";
            Load += DodajKontroluKvalitetaForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox cbZabrana;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpDatumInspekcije;
        private DateTimePicker dtpDatumOtklananja;
        private TextBox tbPrimedba;
        private TextBox tbZapisnik;
        private TextBox tbRazlogZabrane;
        private Button btDodaj;
        private GroupBox groupBox1;
    }
}