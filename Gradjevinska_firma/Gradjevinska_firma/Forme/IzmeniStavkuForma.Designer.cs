namespace Gradjevinska_firma.Forme
{
    partial class IzmeniStavkuForma
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
            dtpRok = new DateTimePicker();
            tbKorektivneMere = new TextBox();
            tbRezultatIspit = new TextBox();
            tbLabNalaz = new TextBox();
            tbUzorci = new TextBox();
            tbRbStavke = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btIzmeni = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(dtpRok);
            groupBox1.Controls.Add(tbKorektivneMere);
            groupBox1.Controls.Add(tbRezultatIspit);
            groupBox1.Controls.Add(tbLabNalaz);
            groupBox1.Controls.Add(tbUzorci);
            groupBox1.Controls.Add(tbRbStavke);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 450);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni stavku";
            // 
            // dtpRok
            // 
            dtpRok.Location = new Point(242, 258);
            dtpRok.Name = "dtpRok";
            dtpRok.Size = new Size(250, 27);
            dtpRok.TabIndex = 11;
            // 
            // tbKorektivneMere
            // 
            tbKorektivneMere.Location = new Point(148, 217);
            tbKorektivneMere.Name = "tbKorektivneMere";
            tbKorektivneMere.Size = new Size(262, 27);
            tbKorektivneMere.TabIndex = 10;
            // 
            // tbRezultatIspit
            // 
            tbRezultatIspit.Location = new Point(163, 171);
            tbRezultatIspit.Name = "tbRezultatIspit";
            tbRezultatIspit.Size = new Size(209, 27);
            tbRezultatIspit.TabIndex = 9;
            // 
            // tbLabNalaz
            // 
            tbLabNalaz.Location = new Point(101, 128);
            tbLabNalaz.Name = "tbLabNalaz";
            tbLabNalaz.Size = new Size(230, 27);
            tbLabNalaz.TabIndex = 8;
            // 
            // tbUzorci
            // 
            tbUzorci.Location = new Point(76, 86);
            tbUzorci.Name = "tbUzorci";
            tbUzorci.Size = new Size(278, 27);
            tbUzorci.TabIndex = 7;
            // 
            // tbRbStavke
            // 
            tbRbStavke.Location = new Point(144, 43);
            tbRbStavke.Name = "tbRbStavke";
            tbRbStavke.Size = new Size(187, 27);
            tbRbStavke.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 263);
            label6.Name = "label6";
            label6.Size = new Size(218, 20);
            label6.TabIndex = 5;
            label6.Text = "Rok za otklananje nepravilnosti:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 221);
            label5.Name = "label5";
            label5.Size = new Size(120, 20);
            label5.TabIndex = 4;
            label5.Text = "Korektivne mere:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 174);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 3;
            label4.Text = "Rezultati ispitivanja:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 131);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Lab nalazi:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 89);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "Uzorci:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 46);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 0;
            label1.Text = "Redni broj stavke:";
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(254, 340);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 12;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // IzmeniStavkuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "IzmeniStavkuForma";
            Text = "IzmeniStavkuForma";
            Load += IzmeniStavkuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpRok;
        private TextBox tbKorektivneMere;
        private TextBox tbRezultatIspit;
        private TextBox tbLabNalaz;
        private TextBox tbUzorci;
        private TextBox tbRbStavke;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btIzmeni;
    }
}