namespace Gradjevinska_firma.Forme
{
    partial class IzmeniBezbednosniIncidentForma
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
            cbOsoba = new ComboBox();
            label6 = new Label();
            tbPosledice = new TextBox();
            cbTipIncidenta = new ComboBox();
            btnIzmeni = new Button();
            tbOpis = new TextBox();
            tbLokacija = new TextBox();
            tbPreduzeteMere = new TextBox();
            dtpDatum = new DateTimePicker();
            label8 = new Label();
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
            groupBox1.Controls.Add(cbOsoba);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(tbPosledice);
            groupBox1.Controls.Add(cbTipIncidenta);
            groupBox1.Controls.Add(btnIzmeni);
            groupBox1.Controls.Add(tbOpis);
            groupBox1.Controls.Add(tbLokacija);
            groupBox1.Controls.Add(tbPreduzeteMere);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(364, 423);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj bezbednosni incidient";
            // 
            // cbOsoba
            // 
            cbOsoba.FormattingEnabled = true;
            cbOsoba.Location = new Point(107, 211);
            cbOsoba.Name = "cbOsoba";
            cbOsoba.Size = new Size(121, 23);
            cbOsoba.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 214);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 21;
            label6.Text = "Osoba :";
            // 
            // tbPosledice
            // 
            tbPosledice.Location = new Point(107, 109);
            tbPosledice.Name = "tbPosledice";
            tbPosledice.Size = new Size(120, 23);
            tbPosledice.TabIndex = 20;
            // 
            // cbTipIncidenta
            // 
            cbTipIncidenta.FormattingEnabled = true;
            cbTipIncidenta.Items.AddRange(new object[] { "Povreda na radu", "Kvar opreme", "Nepostovanje procedura", "Opasna situacija", "Ekoloski incident" });
            cbTipIncidenta.Location = new Point(107, 138);
            cbTipIncidenta.Name = "cbTipIncidenta";
            cbTipIncidenta.Size = new Size(121, 23);
            cbTipIncidenta.TabIndex = 19;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(107, 361);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(138, 44);
            btnIzmeni.TabIndex = 17;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // tbOpis
            // 
            tbOpis.Location = new Point(107, 22);
            tbOpis.Name = "tbOpis";
            tbOpis.Size = new Size(120, 23);
            tbOpis.TabIndex = 16;
            // 
            // tbLokacija
            // 
            tbLokacija.Location = new Point(107, 51);
            tbLokacija.Name = "tbLokacija";
            tbLokacija.Size = new Size(120, 23);
            tbLokacija.TabIndex = 15;
            // 
            // tbPreduzeteMere
            // 
            tbPreduzeteMere.Location = new Point(107, 80);
            tbPreduzeteMere.Name = "tbPreduzeteMere";
            tbPreduzeteMere.Size = new Size(120, 23);
            tbPreduzeteMere.TabIndex = 14;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(84, 174);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(193, 23);
            dtpDatum.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 180);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 7;
            label8.Text = "Datum :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 113);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 4;
            label5.Text = "Posledice :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 143);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 3;
            label4.Text = "Tip incidenta :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 2;
            label3.Text = "Preduzete mere :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 59);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Lokacija :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Opis :";
            // 
            // IzmeniBezbednosniIncidentForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 450);
            Controls.Add(groupBox1);
            Name = "IzmeniBezbednosniIncidentForma";
            Text = "IzmeniBezbednosniIncidentForma";
            Load += IzmeniBezbednosniIncidentForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbOsoba;
        private Label label6;
        private TextBox tbPosledice;
        private ComboBox cbTipIncidenta;
        private Button btnIzmeni;
        private TextBox tbOpis;
        private TextBox tbLokacija;
        private TextBox tbPreduzeteMere;
        private DateTimePicker dtpDatum;
        private Label label8;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}