namespace Gradjevinska_firma.Forme
{
    partial class DodajAngazovanForma
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
            cbStatus = new ComboBox();
            dtpDatumDo = new DateTimePicker();
            dtpDatumOd = new DateTimePicker();
            cbOsoba = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(dtpDatumDo);
            groupBox1.Controls.Add(dtpDatumOd);
            groupBox1.Controls.Add(cbOsoba);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(444, 264);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj angazovanje";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(28, 217);
            btDodaj.Margin = new Padding(3, 2, 3, 2);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(82, 22);
            btDodaj.TabIndex = 8;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Dodeljen", "Odsutan", "Razduzen" });
            cbStatus.Location = new Point(156, 150);
            cbStatus.Margin = new Padding(3, 2, 3, 2);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(133, 23);
            cbStatus.TabIndex = 7;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(102, 111);
            dtpDatumDo.Margin = new Padding(3, 2, 3, 2);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(219, 23);
            dtpDatumDo.TabIndex = 6;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(102, 72);
            dtpDatumOd.Margin = new Padding(3, 2, 3, 2);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(219, 23);
            dtpDatumOd.TabIndex = 5;
            // 
            // cbOsoba
            // 
            cbOsoba.FormattingEnabled = true;
            cbOsoba.Location = new Point(81, 39);
            cbOsoba.Margin = new Padding(3, 2, 3, 2);
            cbOsoba.Name = "cbOsoba";
            cbOsoba.Size = new Size(189, 23);
            cbOsoba.TabIndex = 4;
            cbOsoba.SelectedIndexChanged += cbOsoba_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 152);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 3;
            label4.Text = "Status angazovanja:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 115);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Datum do:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 76);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Datum od:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 41);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "Osoba:";
            // 
            // DodajAngazovanForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 264);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DodajAngazovanForma";
            Text = "DodajAngazovanForma";
            Load += DodajAngazovanForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btDodaj;
        private ComboBox cbStatus;
        private DateTimePicker dtpDatumDo;
        private DateTimePicker dtpDatumOd;
        private ComboBox cbOsoba;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}