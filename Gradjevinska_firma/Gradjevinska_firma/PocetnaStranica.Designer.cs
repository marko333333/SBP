namespace Gradjevinska_firma
{
    partial class PocetnaStranica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocetnaStranica));
            lb1 = new Label();
            bt1 = new Button();
            pictureBox1 = new PictureBox();
            bt2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lb1
            // 
            lb1.AutoSize = true;
            lb1.Font = new Font("Elephant", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb1.Location = new Point(385, 28);
            lb1.Name = "lb1";
            lb1.Size = new Size(364, 43);
            lb1.TabIndex = 0;
            lb1.Text = "Gradjevinska firma";
            lb1.Click += label1_Click;
            // 
            // bt1
            // 
            bt1.Font = new Font("Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt1.Location = new Point(477, 179);
            bt1.Name = "bt1";
            bt1.Size = new Size(209, 56);
            bt1.TabIndex = 1;
            bt1.Text = "Projekat";
            bt1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(366, 579);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // bt2
            // 
            bt2.Font = new Font("Lucida Bright", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt2.Location = new Point(477, 280);
            bt2.Name = "bt2";
            bt2.Size = new Size(209, 56);
            bt2.TabIndex = 3;
            bt2.Text = "Zaposleni";
            bt2.UseVisualStyleBackColor = true;
            bt2.Click += bt2_Click;
            // 
            // PocetnaStranica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 576);
            Controls.Add(bt2);
            Controls.Add(pictureBox1);
            Controls.Add(bt1);
            Controls.Add(lb1);
            Name = "PocetnaStranica";
            Text = "PocetnaStranica";
            Load += PocetnaStranica_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb1;
        private Button bt1;
        private PictureBox pictureBox1;
        private Button bt2;
    }
}