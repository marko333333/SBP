namespace Gradjevinska_firma.Forme
{
    partial class DodajLicencuForma
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
            btDodajLicencu = new Button();
            tbLicenca = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodajLicencu);
            groupBox1.Controls.Add(tbLicenca);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(474, 207);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Licenca";
            // 
            // btDodajLicencu
            // 
            btDodajLicencu.Location = new Point(136, 105);
            btDodajLicencu.Name = "btDodajLicencu";
            btDodajLicencu.Size = new Size(94, 29);
            btDodajLicencu.TabIndex = 2;
            btDodajLicencu.Text = "Dodaj";
            btDodajLicencu.UseVisualStyleBackColor = true;
            btDodajLicencu.Click += btDodajLicencu_Click;
            // 
            // tbLicenca
            // 
            tbLicenca.Location = new Point(89, 34);
            tbLicenca.Name = "tbLicenca";
            tbLicenca.Size = new Size(179, 27);
            tbLicenca.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 37);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 0;
            label1.Text = "Licenca:";
            // 
            // DodajLicencuForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 207);
            Controls.Add(groupBox1);
            Name = "DodajLicencuForma";
            Text = "DodajLicencuForma";
            Load += DodajLicencuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btDodajLicencu;
        private TextBox tbLicenca;
        private Label label1;
    }
}