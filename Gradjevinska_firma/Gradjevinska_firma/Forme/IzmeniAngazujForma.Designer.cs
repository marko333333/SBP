namespace Gradjevinska_firma.Forme
{
    partial class IzmeniAngazujForma
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
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            tbBrojSati = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(dtpDatumOd);
            groupBox1.Controls.Add(dtpDatumDo);
            groupBox1.Controls.Add(tbBrojSati);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(446, 333);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Angazuj opremu";
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(35, 273);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 8;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(120, 87);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(250, 27);
            dtpDatumOd.TabIndex = 6;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(120, 140);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(250, 27);
            dtpDatumDo.TabIndex = 5;
            // 
            // tbBrojSati
            // 
            tbBrojSati.Location = new Point(107, 191);
            tbBrojSati.Name = "tbBrojSati";
            tbBrojSati.Size = new Size(129, 27);
            tbBrojSati.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 194);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 3;
            label4.Text = "Broj sati:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 145);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Datum do:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 92);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Datum od:";
            // 
            // IzmeniAngazujForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 333);
            Controls.Add(groupBox1);
            Name = "IzmeniAngazujForma";
            Text = "IzmeniAngazujForma";
            Load += IzmeniAngazujForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btIzmeni;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
        private TextBox tbBrojSati;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}