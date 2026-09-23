namespace Gradjevinska_firma.Forme
{
    partial class DodajNabavkuForma
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
            cbProjekat = new ComboBox();
            label2 = new Label();
            btDodaj = new Button();
            dtpDatum = new DateTimePicker();
            label1 = new Label();
            lblDobavljac = new Label();
            cbDobavljac = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbDobavljac);
            groupBox1.Controls.Add(lblDobavljac);
            groupBox1.Controls.Add(cbProjekat);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(339, 228);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj nabavku";
            // 
            // cbProjekat
            // 
            cbProjekat.FormattingEnabled = true;
            cbProjekat.Location = new Point(97, 75);
            cbProjekat.Name = "cbProjekat";
            cbProjekat.Size = new Size(203, 23);
            cbProjekat.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 75);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 5;
            label2.Text = "Naziv projekta:";
            label2.Click += label2_Click;
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(116, 184);
            btDodaj.Margin = new Padding(3, 2, 3, 2);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(82, 22);
            btDodaj.TabIndex = 4;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(81, 38);
            dtpDatum.Margin = new Padding(3, 2, 3, 2);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(219, 23);
            dtpDatum.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Datum:";
            // 
            // lblDobavljac
            // 
            lblDobavljac.AutoSize = true;
            lblDobavljac.Location = new Point(12, 120);
            lblDobavljac.Name = "lblDobavljac";
            lblDobavljac.Size = new Size(62, 15);
            lblDobavljac.TabIndex = 7;
            lblDobavljac.Text = "Dobavljac:";
            // 
            // cbDobavljac
            // 
            cbDobavljac.FormattingEnabled = true;
            cbDobavljac.Location = new Point(97, 117);
            cbDobavljac.Name = "cbDobavljac";
            cbDobavljac.Size = new Size(203, 23);
            cbDobavljac.TabIndex = 8;
            // 
            // DodajNabavkuForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 228);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DodajNabavkuForma";
            Text = "DodajNabavkuForma";
            Load += DodajNabavkuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btDodaj;
        private DateTimePicker dtpDatum;
        private Label label1;
        private Label label2;
        private ComboBox cbProjekat;
        private ComboBox cbDobavljac;
        private Label lblDobavljac;
    }
}