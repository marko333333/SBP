namespace Gradjevinska_firma.Forme
{
    partial class DodajPosebnuKlauzuluForma
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
            label1 = new Label();
            tbPosebnaKlauzula = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbPosebnaKlauzula);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(402, 185);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj posebnu klauzulu";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(60, 110);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 2;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 57);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 1;
            label1.Text = "Posebna klauzula:";
            // 
            // tbPosebnaKlauzula
            // 
            tbPosebnaKlauzula.Location = new Point(157, 54);
            tbPosebnaKlauzula.Name = "tbPosebnaKlauzula";
            tbPosebnaKlauzula.Size = new Size(209, 27);
            tbPosebnaKlauzula.TabIndex = 0;
            // 
            // DodajPosebnuKlauzuluForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 185);
            Controls.Add(groupBox1);
            Name = "DodajPosebnuKlauzuluForma";
            Text = "DodajPosebnuKlauzuluForma";
            Load += DodajPosebnuKlauzuluForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbPosebnaKlauzula;
        private Label label1;
        private Button btDodaj;
    }
}