namespace Gradjevinska_firma.Forme
{
    partial class IzmeniFakturuForma
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
            cbStatusPlacanja = new CheckBox();
            cbPrimalac = new ComboBox();
            lblPrimalac = new Label();
            nudIznos = new NumericUpDown();
            cbIzdavalac = new ComboBox();
            lblIzdavalac = new Label();
            IzmeniFakturu_button = new Button();
            tbValuta = new TextBox();
            dtpDatum = new DateTimePicker();
            label8 = new Label();
            lblStatusPlacanja = new Label();
            lblValuta = new Label();
            lblIznos = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudIznos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbStatusPlacanja);
            groupBox1.Controls.Add(cbPrimalac);
            groupBox1.Controls.Add(lblPrimalac);
            groupBox1.Controls.Add(nudIznos);
            groupBox1.Controls.Add(cbIzdavalac);
            groupBox1.Controls.Add(lblIzdavalac);
            groupBox1.Controls.Add(IzmeniFakturu_button);
            groupBox1.Controls.Add(tbValuta);
            groupBox1.Controls.Add(dtpDatum);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(lblStatusPlacanja);
            groupBox1.Controls.Add(lblValuta);
            groupBox1.Controls.Add(lblIznos);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(364, 326);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni fakturu";
            // 
            // cbStatusPlacanja
            // 
            cbStatusPlacanja.AutoSize = true;
            cbStatusPlacanja.Location = new Point(107, 80);
            cbStatusPlacanja.Name = "cbStatusPlacanja";
            cbStatusPlacanja.Size = new Size(68, 19);
            cbStatusPlacanja.TabIndex = 25;
            cbStatusPlacanja.Text = "Placeno";
            cbStatusPlacanja.UseVisualStyleBackColor = true;
            // 
            // cbPrimalac
            // 
            cbPrimalac.FormattingEnabled = true;
            cbPrimalac.Location = new Point(107, 150);
            cbPrimalac.Name = "cbPrimalac";
            cbPrimalac.Size = new Size(121, 23);
            cbPrimalac.TabIndex = 24;
            // 
            // lblPrimalac
            // 
            lblPrimalac.AutoSize = true;
            lblPrimalac.Location = new Point(10, 153);
            lblPrimalac.Name = "lblPrimalac";
            lblPrimalac.Size = new Size(59, 15);
            lblPrimalac.TabIndex = 3;
            lblPrimalac.Text = "Primalac :";
            // 
            // nudIznos
            // 
            nudIznos.Location = new Point(107, 22);
            nudIznos.Name = "nudIznos";
            nudIznos.Size = new Size(120, 23);
            nudIznos.TabIndex = 3;
            // 
            // cbIzdavalac
            // 
            cbIzdavalac.FormattingEnabled = true;
            cbIzdavalac.Location = new Point(107, 115);
            cbIzdavalac.Name = "cbIzdavalac";
            cbIzdavalac.Size = new Size(121, 23);
            cbIzdavalac.TabIndex = 23;
            // 
            // lblIzdavalac
            // 
            lblIzdavalac.AutoSize = true;
            lblIzdavalac.Location = new Point(8, 118);
            lblIzdavalac.Name = "lblIzdavalac";
            lblIzdavalac.Size = new Size(61, 15);
            lblIzdavalac.TabIndex = 21;
            lblIzdavalac.Text = "Izdavalac :";
            // 
            // IzmeniFakturu_button
            // 
            IzmeniFakturu_button.Location = new Point(107, 254);
            IzmeniFakturu_button.Name = "IzmeniFakturu_button";
            IzmeniFakturu_button.Size = new Size(138, 44);
            IzmeniFakturu_button.TabIndex = 17;
            IzmeniFakturu_button.Text = "Izmeni";
            IzmeniFakturu_button.UseVisualStyleBackColor = true;
            IzmeniFakturu_button.Click += IzmeniFakturu_button_Click;
            // 
            // tbValuta
            // 
            tbValuta.Location = new Point(107, 51);
            tbValuta.Name = "tbValuta";
            tbValuta.Size = new Size(120, 23);
            tbValuta.TabIndex = 15;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(84, 188);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(193, 23);
            dtpDatum.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 194);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 7;
            label8.Text = "Datum :";
            // 
            // lblStatusPlacanja
            // 
            lblStatusPlacanja.AutoSize = true;
            lblStatusPlacanja.Location = new Point(6, 85);
            lblStatusPlacanja.Name = "lblStatusPlacanja";
            lblStatusPlacanja.Size = new Size(92, 15);
            lblStatusPlacanja.TabIndex = 2;
            lblStatusPlacanja.Text = "Status placanja :";
            // 
            // lblValuta
            // 
            lblValuta.AutoSize = true;
            lblValuta.Location = new Point(6, 59);
            lblValuta.Name = "lblValuta";
            lblValuta.Size = new Size(45, 15);
            lblValuta.TabIndex = 1;
            lblValuta.Text = "Valuta :";
            // 
            // lblIznos
            // 
            lblIznos.AutoSize = true;
            lblIznos.Location = new Point(6, 30);
            lblIznos.Name = "lblIznos";
            lblIznos.Size = new Size(40, 15);
            lblIznos.TabIndex = 0;
            lblIznos.Text = "Iznos :";
            // 
            // IzmeniFakturuForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 341);
            Controls.Add(groupBox1);
            Name = "IzmeniFakturuForma";
            Text = "IzmeniFakturuForma";
            Load += IzmeniFakturuForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudIznos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox cbStatusPlacanja;
        private ComboBox cbPrimalac;
        private Label lblPrimalac;
        private NumericUpDown nudIznos;
        private ComboBox cbIzdavalac;
        private Label lblIzdavalac;
        private Button IzmeniFakturu_button;
        private TextBox tbValuta;
        private DateTimePicker dtpDatum;
        private Label label8;
        private Label lblStatusPlacanja;
        private Label lblValuta;
        private Label lblIznos;
    }
}