namespace Gradjevinska_firma.Forme
{
    partial class DodajRadniNalogForma
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
            label2 = new Label();
            label3 = new Label();
            dtpDatumIzdavanja = new DateTimePicker();
            cbStatus = new ComboBox();
            btDodaj = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 60);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Status:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 103);
            label3.Name = "label3";
            label3.Size = new Size(124, 20);
            label3.TabIndex = 2;
            label3.Text = "Datum izdavanja:";
            // 
            // dtpDatumIzdavanja
            // 
            dtpDatumIzdavanja.Location = new Point(161, 98);
            dtpDatumIzdavanja.Name = "dtpDatumIzdavanja";
            dtpDatumIzdavanja.Size = new Size(250, 27);
            dtpDatumIzdavanja.TabIndex = 3;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Izdat", "U radu", "Zavrsen", "Storniran" });
            cbStatus.Location = new Point(89, 57);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 28);
            cbStatus.TabIndex = 4;
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(266, 164);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 5;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpDatumIzdavanja);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(531, 220);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj radni nalog";
            // 
            // DodajRadniNalogForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 220);
            Controls.Add(groupBox1);
            Name = "DodajRadniNalogForma";
            Text = "DodajRadniNalogForma";
            Load += DodajRadniNalogForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private Label label3;
        private DateTimePicker dtpDatumIzdavanja;
        private ComboBox cbStatus;
        private Button btDodaj;
        private GroupBox groupBox1;
    }
}