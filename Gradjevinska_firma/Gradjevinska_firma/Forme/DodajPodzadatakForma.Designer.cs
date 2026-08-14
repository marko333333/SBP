namespace Gradjevinska_firma.Forme
{
    partial class DodajPodzadatakForma
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            btDodaj = new Button();
            cbNaziv = new ComboBox();
            label1 = new Label();
            zadatakBasicBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)zadatakBasicBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btDodaj);
            groupBox1.Controls.Add(cbNaziv);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(498, 206);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj podzadatak";
            // 
            // btDodaj
            // 
            btDodaj.Location = new Point(124, 134);
            btDodaj.Name = "btDodaj";
            btDodaj.Size = new Size(94, 29);
            btDodaj.TabIndex = 2;
            btDodaj.Text = "Dodaj";
            btDodaj.UseVisualStyleBackColor = true;
            btDodaj.Click += btDodaj_Click;
            // 
            // cbNaziv
            // 
            cbNaziv.FormattingEnabled = true;
            cbNaziv.Location = new Point(83, 59);
            cbNaziv.Name = "cbNaziv";
            cbNaziv.Size = new Size(213, 28);
            cbNaziv.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 62);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // zadatakBasicBindingSource
            // 
            zadatakBasicBindingSource.DataSource = typeof(DTO.ZadatakBasic);
            // 
            // DodajPodzadatakForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 206);
            Controls.Add(groupBox1);
            Name = "DodajPodzadatakForma";
            Text = "DodajPodzadatakForma";
            Load += DodajPodzadatakForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)zadatakBasicBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cbNaziv;
        private Label label1;
        private Button btDodaj;
        private BindingSource zadatakBasicBindingSource;
    }
}