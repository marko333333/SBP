namespace Gradjevinska_firma.Forme
{
    partial class DodajZastitnuOpremuForma
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
            tbZastitnaOprema = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(tbZastitnaOprema);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(460, 166);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Zastitna oprema";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(136, 105);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 2;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // tbZastitnaOprema
            // 
            tbZastitnaOprema.Location = new Point(147, 34);
            tbZastitnaOprema.Name = "tbZastitnaOprema";
            tbZastitnaOprema.Size = new Size(179, 27);
            tbZastitnaOprema.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 37);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 0;
            label1.Text = "Zastitna oprema:";
            // 
            // DodajZastitnuOpremuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 166);
            Controls.Add(groupBox1);
            Name = "DodajZastitnuOpremuForma";
            Text = "DodajZastitnuOpremuForma";
            Load += DodajZastitnuOpremuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btDodaj;
        private TextBox tbZastitnaOprema;
        private Label label1;
    }
}