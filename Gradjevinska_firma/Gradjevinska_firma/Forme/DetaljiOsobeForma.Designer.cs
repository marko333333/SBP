namespace Gradjevinska_firma.Forme
{
    partial class DetaljiOsobeForma
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            lbJmbg = new Label();
            lbIme = new Label();
            lbPrezime = new Label();
            lbDatumRodj = new Label();
            lbStruka = new Label();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(9, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(695, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(687, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Osnovni podaci";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(687, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Flagovi";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(687, 417);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Kontakti";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(687, 417);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Licence";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbJmbg
            // 
            lbJmbg.AutoSize = true;
            lbJmbg.Location = new Point(732, 29);
            lbJmbg.Name = "lbJmbg";
            lbJmbg.Size = new Size(45, 20);
            lbJmbg.TabIndex = 0;
            lbJmbg.Text = "Jmbg";
            // 
            // lbIme
            // 
            lbIme.AutoSize = true;
            lbIme.Location = new Point(743, 80);
            lbIme.Name = "lbIme";
            lbIme.Size = new Size(34, 20);
            lbIme.TabIndex = 1;
            lbIme.Text = "Ime";
            // 
            // lbPrezime
            // 
            lbPrezime.AutoSize = true;
            lbPrezime.Location = new Point(732, 127);
            lbPrezime.Name = "lbPrezime";
            lbPrezime.Size = new Size(62, 20);
            lbPrezime.TabIndex = 2;
            lbPrezime.Text = "Prezime";
            // 
            // lbDatumRodj
            // 
            lbDatumRodj.AutoSize = true;
            lbDatumRodj.Location = new Point(710, 168);
            lbDatumRodj.Name = "lbDatumRodj";
            lbDatumRodj.Size = new Size(117, 20);
            lbDatumRodj.TabIndex = 3;
            lbDatumRodj.Text = "Datum Rodjenja";
            // 
            // lbStruka
            // 
            lbStruka.AutoSize = true;
            lbStruka.Location = new Point(732, 222);
            lbStruka.Name = "lbStruka";
            lbStruka.Size = new Size(50, 20);
            lbStruka.TabIndex = 4;
            lbStruka.Text = "Struka";
            // 
            // DetaljiOsobeForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbStruka);
            Controls.Add(tabControl1);
            Controls.Add(lbDatumRodj);
            Controls.Add(lbJmbg);
            Controls.Add(lbPrezime);
            Controls.Add(lbIme);
            Name = "DetaljiOsobeForma";
            Text = "DetaljiOsobeForma";
            Load += DetaljiOsobeForma_Load;
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label lbJmbg;
        private Label lbIme;
        private Label lbPrezime;
        private Label lbDatumRodj;
        private Label lbStruka;
    }
}