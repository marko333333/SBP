namespace Gradjevinska_firma.Forme
{
    partial class IzmeniNapredakForma
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
            label1 = new Label();
            btIzmeni = new Button();
            label2 = new Label();
            tbKorektivnaMera = new TextBox();
            label3 = new Label();
            tbPrimedbaNadzora = new TextBox();
            label4 = new Label();
            tbProcenatRealizacije = new TextBox();
            label5 = new Label();
            tbDnevniIzvestaj = new TextBox();
            dtpDatum = new DateTimePicker();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btIzmeni);
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
            groupBox1.Size = new Size(537, 355);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni napredak";
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
            // btIzmeni
            // 
            btIzmeni.Location = new Point(319, 297);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 10;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
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
            // tbKorektivnaMera
            // 
            tbKorektivnaMera.Location = new Point(162, 232);
            tbKorektivnaMera.Name = "tbKorektivnaMera";
            tbKorektivnaMera.Size = new Size(241, 27);
            tbKorektivnaMera.TabIndex = 9;
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
            // tbPrimedbaNadzora
            // 
            tbPrimedbaNadzora.Location = new Point(167, 183);
            tbPrimedbaNadzora.Name = "tbPrimedbaNadzora";
            tbPrimedbaNadzora.Size = new Size(286, 27);
            tbPrimedbaNadzora.TabIndex = 8;
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
            // tbProcenatRealizacije
            // 
            tbProcenatRealizacije.Location = new Point(171, 137);
            tbProcenatRealizacije.Name = "tbProcenatRealizacije";
            tbProcenatRealizacije.Size = new Size(116, 27);
            tbProcenatRealizacije.TabIndex = 7;
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
            // tbDnevniIzvestaj
            // 
            tbDnevniIzvestaj.Location = new Point(141, 92);
            tbDnevniIzvestaj.Name = "tbDnevniIzvestaj";
            tbDnevniIzvestaj.Size = new Size(288, 27);
            tbDnevniIzvestaj.TabIndex = 6;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(90, 46);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(250, 27);
            dtpDatum.TabIndex = 5;
            // 
            // IzmeniNapredakForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 355);
            Controls.Add(groupBox1);
            Name = "IzmeniNapredakForma";
            Text = "IzmeniNapredakForma";
            Load += IzmeniNapredakForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btIzmeni;
        private Label label2;
        private TextBox tbKorektivnaMera;
        private Label label3;
        private TextBox tbPrimedbaNadzora;
        private Label label4;
        private TextBox tbProcenatRealizacije;
        private Label label5;
        private TextBox tbDnevniIzvestaj;
        private DateTimePicker dtpDatum;
    }
}