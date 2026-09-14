namespace Gradjevinska_firma.Forme
{
    partial class DodajPoslovniObjekatForma
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
            numBrJedinica = new NumericUpDown();
            numSpratnost = new NumericUpDown();
            numBrObjekta = new NumericUpDown();
            Dodaj_button = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBrJedinica).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSpratnost).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBrObjekta).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numBrJedinica);
            groupBox1.Controls.Add(numSpratnost);
            groupBox1.Controls.Add(numBrObjekta);
            groupBox1.Controls.Add(Dodaj_button);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(229, 196);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj poslovin objekat";
            // 
            // numBrJedinica
            // 
            numBrJedinica.Location = new Point(82, 86);
            numBrJedinica.Name = "numBrJedinica";
            numBrJedinica.Size = new Size(120, 23);
            numBrJedinica.TabIndex = 20;
            // 
            // numSpratnost
            // 
            numSpratnost.Location = new Point(82, 57);
            numSpratnost.Name = "numSpratnost";
            numSpratnost.Size = new Size(120, 23);
            numSpratnost.TabIndex = 19;
            // 
            // numBrObjekta
            // 
            numBrObjekta.Location = new Point(82, 28);
            numBrObjekta.Name = "numBrObjekta";
            numBrObjekta.Size = new Size(120, 23);
            numBrObjekta.TabIndex = 18;
            // 
            // Dodaj_button
            // 
            Dodaj_button.Location = new Point(32, 127);
            Dodaj_button.Name = "Dodaj_button";
            Dodaj_button.Size = new Size(170, 48);
            Dodaj_button.TabIndex = 17;
            Dodaj_button.Text = "Dodaj";
            Dodaj_button.UseVisualStyleBackColor = true;
            Dodaj_button.Click += Dodaj_button_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Br_jedinica :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 59);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Spratnost: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Br_objekta :";
            // 
            // DodajPoslovniObjekatForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(252, 208);
            Controls.Add(groupBox1);
            Name = "DodajPoslovniObjekatForma";
            Text = "DodajPoslovniObjekatForma";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBrJedinica).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSpratnost).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBrObjekta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown numBrJedinica;
        private NumericUpDown numSpratnost;
        private NumericUpDown numBrObjekta;
        private Button Dodaj_button;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}