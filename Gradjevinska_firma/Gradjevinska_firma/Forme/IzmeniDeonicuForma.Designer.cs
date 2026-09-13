namespace Gradjevinska_firma.Forme
{
    partial class IzmeniDeonicuForma
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
            nudBrojDeonice = new NumericUpDown();
            Izmeni_button = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBrojDeonice).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nudBrojDeonice);
            groupBox1.Controls.Add(Izmeni_button);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(263, 172);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni deonicu";
            // 
            // nudBrojDeonice
            // 
            nudBrojDeonice.Location = new Point(91, 57);
            nudBrojDeonice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudBrojDeonice.Name = "nudBrojDeonice";
            nudBrojDeonice.Size = new Size(120, 23);
            nudBrojDeonice.TabIndex = 3;
            // 
            // Izmeni_button
            // 
            Izmeni_button.Location = new Point(73, 107);
            Izmeni_button.Name = "Izmeni_button";
            Izmeni_button.Size = new Size(138, 44);
            Izmeni_button.TabIndex = 17;
            Izmeni_button.Text = "Izmeni";
            Izmeni_button.UseVisualStyleBackColor = true;
            Izmeni_button.Click += Izmeni_button_Click;
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
            // IzmeniDeonicuForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 192);
            Controls.Add(groupBox1);
            Name = "IzmeniDeonicuForma";
            Text = "IzmeniDeonicuForma";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBrojDeonice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown nudBrojDeonice;
        private Button Izmeni_button;
        private Label label1;
    }
}