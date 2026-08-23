namespace Gradjevinska_firma.Forme
{
    partial class IzmeniFazuForma
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
            cbNaziv = new ComboBox();
            dtpDatumDo = new DateTimePicker();
            btDodaj = new Button();
            nudBudzet = new NumericUpDown();
            cbNadFaza = new ComboBox();
            cbFicickoLice = new ComboBox();
            cbStatus = new ComboBox();
            dtpDatumOd = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            lb1 = new Label();
            lb4 = new Label();
            lb5 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBudzet).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbNaziv);
            groupBox1.Controls.Add(dtpDatumDo);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(nudBudzet);
            groupBox1.Controls.Add(cbNadFaza);
            groupBox1.Controls.Add(cbFicickoLice);
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(dtpDatumOd);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lb1);
            groupBox1.Controls.Add(lb4);
            groupBox1.Controls.Add(lb5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(566, 211);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni fazu";
            // 
            // cbNaziv
            // 
            cbNaziv.FormattingEnabled = true;
            cbNaziv.Items.AddRange(new object[] { "Pripremni radovi", "Grubi gradjevinski radovi", "Instalacije", "Zavrsni radovi", "Tehnicki prijem", "Ostalo" });
            cbNaziv.Location = new Point(71, 25);
            cbNaziv.Name = "cbNaziv";
            cbNaziv.Size = new Size(140, 23);
            cbNaziv.TabIndex = 58;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(313, 53);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(216, 23);
            dtpDatumDo.TabIndex = 57;
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(355, 142);
            btDodaj.Margin = new Padding(3, 2, 3, 2);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(103, 40);
            btDodaj.TabIndex = 56;
            btDodaj.Text = "Izmeni";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // nudBudzet
            // 
            nudBudzet.Location = new Point(71, 85);
            nudBudzet.Margin = new Padding(3, 2, 3, 2);
            nudBudzet.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudBudzet.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudBudzet.Name = "nudBudzet";
            nudBudzet.Size = new Size(140, 23);
            nudBudzet.TabIndex = 55;
            nudBudzet.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // cbNadFaza
            // 
            cbNadFaza.FormattingEnabled = true;
            cbNadFaza.Location = new Point(71, 159);
            cbNadFaza.Margin = new Padding(3, 2, 3, 2);
            cbNadFaza.Name = "cbNadFaza";
            cbNadFaza.Size = new Size(140, 23);
            cbNadFaza.TabIndex = 54;
            // 
            // cbFicickoLice
            // 
            cbFicickoLice.FormattingEnabled = true;
            cbFicickoLice.Location = new Point(71, 121);
            cbFicickoLice.Margin = new Padding(3, 2, 3, 2);
            cbFicickoLice.Name = "cbFicickoLice";
            cbFicickoLice.Size = new Size(140, 23);
            cbFicickoLice.TabIndex = 53;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Planiran", "U toku", "Zavrsen", "Otkazan" });
            cbStatus.Location = new Point(71, 55);
            cbStatus.Margin = new Padding(3, 2, 3, 2);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(140, 23);
            cbStatus.TabIndex = 52;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(313, 25);
            dtpDatumOd.Margin = new Padding(3, 2, 3, 2);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(219, 23);
            dtpDatumOd.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 158);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 41;
            label6.Text = "NadFaza:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 123);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 40;
            label5.Text = "Fizicko lice:";
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Location = new Point(23, 28);
            lb1.Name = "lb1";
            lb1.Size = new Size(39, 15);
            lb1.TabIndex = 22;
            lb1.Text = "Naziv:";
            // 
            // lb4
            // 
            lb4.AutoSize = true;
            lb4.Location = new Point(13, 86);
            lb4.Name = "lb4";
            lb4.Size = new Size(49, 15);
            lb4.TabIndex = 25;
            lb4.Text = "Budzet :";
            // 
            // lb5
            // 
            lb5.AutoSize = true;
            lb5.Location = new Point(20, 57);
            lb5.Name = "lb5";
            lb5.Size = new Size(42, 15);
            lb5.TabIndex = 26;
            lb5.Text = "Status:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(244, 54);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 33;
            label2.Text = "Datum do:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 27);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 32;
            label1.Text = "Datum od:";
            // 
            // IzmeniFazuForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 211);
            Controls.Add(groupBox1);
            Name = "IzmeniFazuForma";
            Text = "IzmeniFazuForma";
            Load += IzmeniFazuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBudzet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbNaziv;
        private DateTimePicker dtpDatumDo;
        private Button btDodaj;
        private NumericUpDown nudBudzet;
        private ComboBox cbNadFaza;
        private ComboBox cbFicickoLice;
        private ComboBox cbStatus;
        private DateTimePicker dtpDatumOd;
        private Label label6;
        private Label label5;
        private Label lb1;
        private Label lb4;
        private Label lb5;
        private Label label2;
        private Label label1;
    }
}