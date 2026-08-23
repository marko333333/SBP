namespace Gradjevinska_firma.Forme
{
    partial class DodajUgovornuStranuForma
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
            tbUloga = new TextBox();
            cbOsoba = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(tbUloga);
            groupBox1.Controls.Add(cbOsoba);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(365, 224);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj ugovornu stranu";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(42, 156);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 4;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // tbUloga
            // 
            tbUloga.Location = new Point(93, 90);
            tbUloga.Name = "tbUloga";
            tbUloga.Size = new Size(172, 27);
            tbUloga.TabIndex = 3;
            // 
            // cbOsoba
            // 
            cbOsoba.FormattingEnabled = true;
            cbOsoba.Location = new Point(93, 50);
            cbOsoba.Name = "cbOsoba";
            cbOsoba.Size = new Size(202, 28);
            cbOsoba.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 93);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Uloga:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 53);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Osoba:";
            // 
            // DodajUgovornuStranuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 224);
            Controls.Add(groupBox1);
            Name = "DodajUgovornuStranuForma";
            Text = "DodajUgovornuStranuForma";
            Load += DodajUgovornuStranuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btDodaj;
        private TextBox tbUloga;
        private ComboBox cbOsoba;
        private Label label2;
        private Label label1;
    }
}