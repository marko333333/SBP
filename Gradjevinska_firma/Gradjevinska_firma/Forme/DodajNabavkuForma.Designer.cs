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
            btDodaj = new Button();
            cbProjekat = new ComboBox();
            dtpDatum = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(cbProjekat);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 224);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj nabavku";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(30, 168);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 4;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // cbProjekat
            // 
            cbProjekat.FormattingEnabled = true;
            cbProjekat.Location = new Point(144, 94);
            cbProjekat.Name = "cbProjekat";
            cbProjekat.Size = new Size(199, 28);
            cbProjekat.TabIndex = 3;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(93, 50);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(250, 27);
            dtpDatum.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 97);
            label2.Name = "label2";
            label2.Size = new Size(108, 20);
            label2.TabIndex = 1;
            label2.Text = "Naziv projekta:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 55);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Datum:";
            // 
            // DodajNabavkuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 224);
            Controls.Add(groupBox1);
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
        private ComboBox cbProjekat;
        private DateTimePicker dtpDatum;
        private Label label2;
        private Label label1;
    }
}