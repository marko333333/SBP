namespace Gradjevinska_firma.Forme
{
    partial class IzmeniAngazovanjeForma
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
            cbStatus = new ComboBox();
            dtpDatumDo = new DateTimePicker();
            dtpDatumOd = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btIzmeni);
            groupBox1.Controls.Add(cbStatus);
            groupBox1.Controls.Add(dtpDatumDo);
            groupBox1.Controls.Add(dtpDatumOd);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(482, 345);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izmeni angazovanje";
            // 
            // btIzmeni
            // 
            btIzmeni.Location = new Point(32, 289);
            btIzmeni.Name = "btIzmeni";
            btIzmeni.Size = new Size(94, 29);
            btIzmeni.TabIndex = 8;
            btIzmeni.Text = "Izmeni";
            btIzmeni.UseVisualStyleBackColor = true;
            btIzmeni.Click += btIzmeni_Click;
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Dodeljen", "Odsutan", "Razduzen" });
            cbStatus.Location = new Point(178, 200);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 28);
            cbStatus.TabIndex = 7;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(117, 148);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(250, 27);
            dtpDatumDo.TabIndex = 6;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(117, 96);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(250, 27);
            dtpDatumOd.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 203);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 3;
            label4.Text = "Status angazovanja:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 153);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Datum do:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 101);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Datum od:";
            // 
            // IzmeniAngazovanjeForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 345);
            Controls.Add(groupBox1);
            Name = "IzmeniAngazovanjeForma";
            Text = "IzmeniAngazovanjeForma";
            Load += IzmeniAngazovanjeForma_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btIzmeni;
        private ComboBox cbStatus;
        private DateTimePicker dtpDatumDo;
        private DateTimePicker dtpDatumOd;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}