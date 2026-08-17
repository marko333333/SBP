namespace Gradjevinska_firma.Forme
{
    partial class AngazujOpremu
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
            cbOprema = new ComboBox();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            tbBrojSati = new TextBox();
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
            groupBox1.Controls.Add(cbOprema);
            groupBox1.Controls.Add(dtpDatumOd);
            groupBox1.Controls.Add(dtpDatumDo);
            groupBox1.Controls.Add(tbBrojSati);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(506, 334);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Angazuj opremu";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(35, 273);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 8;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // cbOprema
            // 
            cbOprema.FormattingEnabled = true;
            cbOprema.Location = new Point(107, 44);
            cbOprema.Name = "cbOprema";
            cbOprema.Size = new Size(183, 28);
            cbOprema.TabIndex = 7;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(120, 87);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(250, 27);
            dtpDatumOd.TabIndex = 6;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(120, 140);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(250, 27);
            dtpDatumDo.TabIndex = 5;
            // 
            // tbBrojSati
            // 
            tbBrojSati.Location = new Point(107, 191);
            tbBrojSati.Name = "tbBrojSati";
            tbBrojSati.Size = new Size(129, 27);
            tbBrojSati.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 194);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 3;
            label4.Text = "Broj sati:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 145);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Datum do:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 92);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Datum od:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 47);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 0;
            label1.Text = "Oprema:";
            // 
            // AngazujOpremu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 334);
            Controls.Add(groupBox1);
            Name = "AngazujOpremu";
            Text = "AngazujOpremu";
            Load += AngazujOpremu_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btDodaj;
        private ComboBox cbOprema;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
        private TextBox tbBrojSati;
    }
}