namespace Gradjevinska_firma.Forme
{
    partial class DodajNapredakForma
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
            label5 = new Label();
            dtpDatum = new DateTimePicker();
            tbDnevniIzvestaj = new TextBox();
            tbProcenatRealizacije = new TextBox();
            tbPrimedbaNadzora = new TextBox();
            tbKorektivnaMera = new TextBox();
            btDodaj = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 51);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Datum:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 95);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 1;
            label2.Text = "Dnevni izvestaj";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 140);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 2;
            label3.Text = "Procenat realizacije";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 186);
            label4.Name = "label4";
            label4.Size = new Size(134, 20);
            label4.TabIndex = 3;
            label4.Text = "Primedba nadzora:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 235);
            label5.Name = "label5";
            label5.Size = new Size(120, 20);
            label5.TabIndex = 4;
            label5.Text = "Korektivna mera:";
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(90, 46);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(250, 27);
            dtpDatum.TabIndex = 5;
            // 
            // tbDnevniIzvestaj
            // 
            tbDnevniIzvestaj.Location = new Point(141, 92);
            tbDnevniIzvestaj.Name = "tbDnevniIzvestaj";
            tbDnevniIzvestaj.Size = new Size(288, 27);
            tbDnevniIzvestaj.TabIndex = 6;
            // 
            // tbProcenatRealizacije
            // 
            tbProcenatRealizacije.Location = new Point(171, 137);
            tbProcenatRealizacije.Name = "tbProcenatRealizacije";
            tbProcenatRealizacije.Size = new Size(116, 27);
            tbProcenatRealizacije.TabIndex = 7;
            // 
            // tbPrimedbaNadzora
            // 
            tbPrimedbaNadzora.Location = new Point(167, 183);
            tbPrimedbaNadzora.Name = "tbPrimedbaNadzora";
            tbPrimedbaNadzora.Size = new Size(286, 27);
            tbPrimedbaNadzora.TabIndex = 8;
            // 
            // tbKorektivnaMera
            // 
            tbKorektivnaMera.Location = new Point(162, 232);
            tbKorektivnaMera.Name = "tbKorektivnaMera";
            tbKorektivnaMera.Size = new Size(241, 27);
            tbKorektivnaMera.TabIndex = 9;
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(319, 297);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 10;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbKorektivnaMera);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbPrimedbaNadzora);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbProcenatRealizacije);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbDnevniIzvestaj);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(575, 376);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj napredak";
            // 
            // DodajNapredakForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 376);
            Controls.Add(groupBox1);
            Name = "DodajNapredakForma";
            Text = "DodajNapredakForma";
            Load += DodajNapredakForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpDatum;
        private TextBox tbDnevniIzvestaj;
        private TextBox tbProcenatRealizacije;
        private TextBox tbPrimedbaNadzora;
        private TextBox tbKorektivnaMera;
        private Button btDodaj;
        private GroupBox groupBox1;
    }
}