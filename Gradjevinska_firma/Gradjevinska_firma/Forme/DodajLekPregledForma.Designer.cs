namespace Gradjevinska_firma.Forme
{
    partial class DodajLekPregledForma
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
            dtpDatum = new DateTimePicker();
            label2 = new Label();
            btDodaj = new Button();
            tbLekPregled = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(tbLekPregled);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(515, 199);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lekarski pregled";
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(89, 83);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(250, 27);
            dtpDatum.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 83);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 3;
            label2.Text = "Datum:";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(188, 136);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 2;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // tbLekPregled
            // 
            tbLekPregled.Location = new Point(146, 34);
            tbLekPregled.Name = "tbLekPregled";
            tbLekPregled.Size = new Size(220, 27);
            tbLekPregled.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 37);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 0;
            label1.Text = "Lekarski pregled:";
            // 
            // DodajLekPregledForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 199);
            Controls.Add(groupBox1);
            Name = "DodajLekPregledForma";
            Text = "DodajLekPregledForma";
            Load += DodajLekPregledForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpDatum;
        private Label label2;
        private Button btDodaj;
        private TextBox tbLekPregled;
        private Label label1;
    }
}