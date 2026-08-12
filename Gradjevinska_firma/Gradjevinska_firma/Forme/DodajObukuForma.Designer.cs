namespace Gradjevinska_firma.Forme
{
    partial class DodajObukuForma
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
            tbObuka = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(tbObuka);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(585, 208);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Obuka";
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
            // tbObuka
            // 
            tbObuka.Location = new Point(89, 34);
            tbObuka.Name = "tbObuka";
            tbObuka.Size = new Size(220, 27);
            tbObuka.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 37);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Obuka:";
            // 
            // DodajObukuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 208);
            Controls.Add(groupBox1);
            Name = "DodajObukuForma";
            Text = "DodajObukuForma";
            Load += DodajObukuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpDatum;
        private Label label2;
        private Button btDodaj;
        private TextBox tbObuka;
        private Label label1;
    }
}