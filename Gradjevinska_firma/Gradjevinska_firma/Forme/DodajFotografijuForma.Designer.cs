namespace Gradjevinska_firma.Forme
{
    partial class DodajFotografijuForma
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
            btIzaberi = new Button();
            pcFotografija = new PictureBox();
            btDodaj = new Button();
            tbFotografija = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcFotografija).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btIzaberi);
            groupBox1.Controls.Add(pcFotografija);
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(tbFotografija);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(738, 389);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj fotografiju";
            // 
            // btIzaberi
            // 
            btIzaberi.Location = new Point(213, 299);
            btIzaberi.Name = "btIzaberi";
            btIzaberi.Size = new Size(94, 51);
            btIzaberi.TabIndex = 4;
            btIzaberi.Text = "Izaberi fotografiju";
            btIzaberi.UseVisualStyleBackColor = true;
            btIzaberi.Click += btIzaberi_Click;
            // 
            // pcFotografija
            // 
            pcFotografija.Location = new Point(333, 28);
            pcFotografija.Name = "pcFotografija";
            pcFotografija.Size = new Size(380, 322);
            pcFotografija.TabIndex = 3;
            pcFotografija.TabStop = false;
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(213, 100);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 2;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // tbFotografija
            // 
            tbFotografija.Location = new Point(96, 52);
            tbFotografija.Name = "tbFotografija";
            tbFotografija.Size = new Size(191, 27);
            tbFotografija.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 55);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Putanja:";
            // 
            // DodajFotografijuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 389);
            Controls.Add(groupBox1);
            Name = "DodajFotografijuForma";
            Text = "DodajFotografijuForma";
            Load += DodajFotografijuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcFotografija).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btDodaj;
        private TextBox tbFotografija;
        private Label label1;
        private PictureBox pcFotografija;
        private Button btIzaberi;
    }
}