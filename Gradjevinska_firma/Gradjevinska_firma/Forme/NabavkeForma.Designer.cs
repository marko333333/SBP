namespace Gradjevinska_firma.Forme
{
    partial class NabavkeForma
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
            nabavke = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            btDetalji = new Button();
            btObrisiNabavku = new Button();
            btIzmeniNabavku = new Button();
            btDodajNabavku = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nabavke);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(588, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nabavke";
            // 
            // nabavke
            // 
            nabavke.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            nabavke.Dock = DockStyle.Fill;
            nabavke.FullRowSelect = true;
            nabavke.GridLines = true;
            nabavke.Location = new Point(3, 23);
            nabavke.Name = "nabavke";
            nabavke.Size = new Size(582, 424);
            nabavke.TabIndex = 0;
            nabavke.UseCompatibleStateImageBehavior = false;
            nabavke.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Br nabavke";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Datum";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Projekat";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // btDetalji
            // 
            btDetalji.Location = new Point(619, 278);
            btDetalji.Name = "btDetalji";
            btDetalji.Size = new Size(139, 72);
            btDetalji.TabIndex = 17;
            btDetalji.Text = "Detalji nabavke";
            btDetalji.UseVisualStyleBackColor = true;
            btDetalji.Click += btDetalji_Click;
            // 
            // btObrisiNabavku
            // 
            btObrisiNabavku.Location = new Point(619, 181);
            btObrisiNabavku.Name = "btObrisiNabavku";
            btObrisiNabavku.Size = new Size(139, 72);
            btObrisiNabavku.TabIndex = 16;
            btObrisiNabavku.Text = "Obrisi nabavku";
            btObrisiNabavku.UseVisualStyleBackColor = true;
            btObrisiNabavku.Click += btObrisiNabavku_Click;
            // 
            // btIzmeniNabavku
            // 
            btIzmeniNabavku.Location = new Point(619, 101);
            btIzmeniNabavku.Name = "btIzmeniNabavku";
            btIzmeniNabavku.Size = new Size(139, 61);
            btIzmeniNabavku.TabIndex = 15;
            btIzmeniNabavku.Text = "Izmeni nabavku";
            btIzmeniNabavku.UseVisualStyleBackColor = true;
            btIzmeniNabavku.Click += btIzmeniNabavku_Click;
            // 
            // btDodajNabavku
            // 
            btDodajNabavku.Location = new Point(619, 23);
            btDodajNabavku.Name = "btDodajNabavku";
            btDodajNabavku.Size = new Size(139, 57);
            btDodajNabavku.TabIndex = 14;
            btDodajNabavku.Text = "Dodaj nabavku";
            btDodajNabavku.UseVisualStyleBackColor = true;
            btDodajNabavku.Click += btDodajNabavku_Click;
            // 
            // NabavkeForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btDetalji);
            Controls.Add(btObrisiNabavku);
            Controls.Add(btIzmeniNabavku);
            Controls.Add(btDodajNabavku);
            Controls.Add(groupBox1);
            Name = "NabavkeForma";
            Text = "NabavkeForma";
            Load += NabavkeForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView nabavke;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button btDetalji;
        private Button btObrisiNabavku;
        private Button btIzmeniNabavku;
        private Button btDodajNabavku;
    }
}