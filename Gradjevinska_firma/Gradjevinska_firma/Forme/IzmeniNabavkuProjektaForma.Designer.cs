namespace Gradjevinska_firma.Forme
{
    partial class IzmeniNabavkuProjektaForma
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
            btnIzmeniNabavkuProjekta = new Button();
            dtpDatum = new DateTimePicker();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnIzmeniNabavkuProjekta);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(289, 124);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni nabavku projekta";
            // 
            // btnIzmeniNabavkuProjekta
            // 
            btnIzmeniNabavkuProjekta.Location = new Point(15, 78);
            btnIzmeniNabavkuProjekta.Name = "btnIzmeniNabavkuProjekta";
            btnIzmeniNabavkuProjekta.Size = new Size(258, 40);
            btnIzmeniNabavkuProjekta.TabIndex = 2;
            btnIzmeniNabavkuProjekta.Text = "Izmeni";
            btnIzmeniNabavkuProjekta.UseVisualStyleBackColor = true;
            btnIzmeniNabavkuProjekta.Click += btnIzmeniNabavkuProjekta_Click;
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
            // IzmeniNabavkuProjektaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 136);
            Controls.Add(groupBox1);
            Name = "IzmeniNabavkuProjektaForma";
            Text = "IzmeniNabavkuProjektaForma";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnIzmeniNabavkuProjekta;
        private DateTimePicker dtpDatum;
        private Label label1;
    }
}