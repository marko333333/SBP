namespace Gradjevinska_firma.Forme
{
    partial class IzmeniUgovorForma
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
            tbVrednost = new TextBox();
            label5 = new Label();
            btIzmeni = new Button();
            cbTipUgovora = new ComboBox();
            tbValuta = new TextBox();
            tbPredmetUgovora = new TextBox();
            dtpRok = new DateTimePicker();
            dtpDatumPotpisivanja = new DateTimePicker();
            rbOprema = new RadioButton();
            rbMaterijal = new RadioButton();
            rbProjekat = new RadioButton();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbVrednost);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(cbTipUgovora);
            groupBox1.Controls.Add(tbValuta);
            groupBox1.Controls.Add(tbPredmetUgovora);
            groupBox1.Controls.Add(dtpRok);
            groupBox1.Controls.Add(dtpDatumPotpisivanja);
            groupBox1.Controls.Add(rbOprema);
            groupBox1.Controls.Add(rbMaterijal);
            groupBox1.Controls.Add(rbProjekat);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(468, 413);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni ugovor";
            // 
            // tbVrednost
            // 
            tbVrednost.Location = new Point(104, 81);
            tbVrednost.Name = "tbVrednost";
            tbVrednost.Size = new Size(172, 27);
            tbVrednost.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 84);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 15;
            label5.Text = "Vrednost:";
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(26, 365);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 14;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // cbTipUgovora
            // 
            cbTipUgovora.FormattingEnabled = true;
            cbTipUgovora.Location = new Point(26, 305);
            cbTipUgovora.Name = "cbTipUgovora";
            cbTipUgovora.Size = new Size(188, 28);
            cbTipUgovora.TabIndex = 11;
            // 
            // tbValuta
            // 
            tbValuta.Location = new Point(85, 150);
            tbValuta.Name = "tbValuta";
            tbValuta.Size = new Size(125, 27);
            tbValuta.TabIndex = 10;
            // 
            // tbPredmetUgovora
            // 
            tbPredmetUgovora.Location = new Point(159, 114);
            tbPredmetUgovora.Name = "tbPredmetUgovora";
            tbPredmetUgovora.Size = new Size(208, 27);
            tbPredmetUgovora.TabIndex = 9;
            // 
            // dtpRok
            // 
            dtpRok.Location = new Point(69, 193);
            dtpRok.Name = "dtpRok";
            dtpRok.Size = new Size(250, 27);
            dtpRok.TabIndex = 8;
            // 
            // dtpDatumPotpisivanja
            // 
            dtpDatumPotpisivanja.Location = new Point(174, 51);
            dtpDatumPotpisivanja.Name = "dtpDatumPotpisivanja";
            dtpDatumPotpisivanja.Size = new Size(250, 27);
            dtpDatumPotpisivanja.TabIndex = 7;
            // 
            // rbOprema
            // 
            rbOprema.AutoSize = true;
            rbOprema.Location = new Point(28, 249);
            rbOprema.Name = "rbOprema";
            rbOprema.Size = new Size(84, 24);
            rbOprema.TabIndex = 6;
            rbOprema.TabStop = true;
            rbOprema.Text = "Oprema";
            rbOprema.UseVisualStyleBackColor = true;
            rbOprema.CheckedChanged += rbOprema_CheckedChanged;
            // 
            // rbMaterijal
            // 
            rbMaterijal.AutoSize = true;
            rbMaterijal.Location = new Point(142, 249);
            rbMaterijal.Name = "rbMaterijal";
            rbMaterijal.Size = new Size(89, 24);
            rbMaterijal.TabIndex = 5;
            rbMaterijal.TabStop = true;
            rbMaterijal.Text = "Materijal";
            rbMaterijal.UseVisualStyleBackColor = true;
            rbMaterijal.CheckedChanged += rbMaterijal_CheckedChanged;
            // 
            // rbProjekat
            // 
            rbProjekat.AutoSize = true;
            rbProjekat.Location = new Point(260, 249);
            rbProjekat.Name = "rbProjekat";
            rbProjekat.Size = new Size(84, 24);
            rbProjekat.TabIndex = 4;
            rbProjekat.TabStop = true;
            rbProjekat.Text = "Projekat";
            rbProjekat.UseVisualStyleBackColor = true;
            rbProjekat.CheckedChanged += rbProjekat_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 198);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 3;
            label4.Text = "Rok:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 153);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 2;
            label3.Text = "Valuta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 117);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Predmet ugovora:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 51);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 0;
            label1.Text = "Datum potpisivanja:";
            // 
            // IzmeniUgovorForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 413);
            Controls.Add(groupBox1);
            Name = "IzmeniUgovorForma";
            Text = "IzmeniUgovorForma";
            Load += IzmeniUgovorForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbVrednost;
        private Label label5;
        private Button btIzmeni;
        private ComboBox cbTipUgovora;
        private TextBox tbValuta;
        private TextBox tbPredmetUgovora;
        private DateTimePicker dtpRok;
        private DateTimePicker dtpDatumPotpisivanja;
        private RadioButton rbOprema;
        private RadioButton rbMaterijal;
        private RadioButton rbProjekat;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}