namespace Gradjevinska_firma.Forme
{
    partial class DodajDeonicuForma
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
            Dodaj_button = new Button();
            label1 = new Label();
            nudBrojDeonice = new NumericUpDown();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBrojDeonice).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nudBrojDeonice);
            groupBox1.Controls.Add(Dodaj_button);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(263, 172);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj deonicu";
            // 
            // Dodaj_button
            // 
            Dodaj_button.Location = new Point(89, 107);
            Dodaj_button.Name = "Dodaj_button";
            Dodaj_button.Size = new Size(138, 44);
            Dodaj_button.TabIndex = 17;
            Dodaj_button.Text = "Dodaj";
            Dodaj_button.UseVisualStyleBackColor = true;
            Dodaj_button.Click += Dodaj_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 59);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Broj deonice :";
            // 
            // nudBrojDeonice
            // 
            nudBrojDeonice.Location = new Point(91, 57);
            nudBrojDeonice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudBrojDeonice.Name = "nudBrojDeonice";
            nudBrojDeonice.Size = new Size(120, 23);
            nudBrojDeonice.TabIndex = 3;
            // 
            // DodajDeonicuForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 178);
            Controls.Add(groupBox1);
            Name = "DodajDeonicuForma";
            Text = "DodajDeonicuForma";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBrojDeonice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button Dodaj_button;
        private Label label1;
        private NumericUpDown nudBrojDeonice;
    }
}