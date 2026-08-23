namespace Gradjevinska_firma.Forme
{
    partial class IzmeniUgovornuStranuForma
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
            btIzmeni = new Button();
            tbUloga = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(tbUloga);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(322, 151);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni ugovornu stranu";
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(42, 102);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 4;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // tbUloga
            // 
            tbUloga.Location = new Point(100, 44);
            tbUloga.Name = "tbUloga";
            tbUloga.Size = new Size(172, 27);
            tbUloga.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 47);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "Uloga:";
            // 
            // IzmeniUgovornuStranuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 151);
            Controls.Add(groupBox1);
            Name = "IzmeniUgovornuStranuForma";
            Text = "IzmeniUgovornuStranuForma";
            Load += IzmeniUgovornuStranuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btIzmeni;
        private TextBox tbUloga;
        private Label label2;
    }
}