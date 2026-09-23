namespace Gradjevinska_firma.Forme
{
    partial class DodajNabavkuProjektaForma
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
            btnDodajNabavkuProjekta = new Button();
            dtpDatum = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            cbDobavljac = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbDobavljac);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnDodajNabavkuProjekta);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(289, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj nabavku projekta";
            // 
            // btnDodajNabavkuProjekta
            // 
            btnDodajNabavkuProjekta.Location = new Point(6, 130);
            btnDodajNabavkuProjekta.Name = "btnDodajNabavkuProjekta";
            btnDodajNabavkuProjekta.Size = new Size(258, 40);
            btnDodajNabavkuProjekta.TabIndex = 2;
            btnDodajNabavkuProjekta.Text = "Dodaj";
            btnDodajNabavkuProjekta.UseVisualStyleBackColor = true;
            btnDodajNabavkuProjekta.Click += btnDodajNabavkuProjekta_Click;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(61, 34);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(222, 23);
            dtpDatum.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 40);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 1;
            label1.Text = "Datum :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 86);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Dobavljac:";
            // 
            // cbDobavljac
            // 
            cbDobavljac.FormattingEnabled = true;
            cbDobavljac.Location = new Point(74, 83);
            cbDobavljac.Name = "cbDobavljac";
            cbDobavljac.Size = new Size(209, 23);
            cbDobavljac.TabIndex = 4;
            // 
            // DodajNabavkuProjektaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 194);
            Controls.Add(groupBox1);
            Name = "DodajNabavkuProjektaForma";
            Text = "DodajNabavkuProjektaForma";
            Load += DodajNabavkuProjektaForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private DateTimePicker dtpDatum;
        private Button btnDodajNabavkuProjekta;
        private ComboBox cbDobavljac;
        private Label label2;
    }
}