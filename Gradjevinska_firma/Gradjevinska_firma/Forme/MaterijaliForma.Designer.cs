namespace Gradjevinska_firma.Forme
{
    partial class MaterijaliForma
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
            materijali = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            btNabavka = new Button();
            btObrisiMaterijal = new Button();
            btIzmeniMaterijal = new Button();
            btDodajMaterijal = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(materijali);
            groupBox1.Location = new Point(6, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(596, 452);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Materijali";
            // 
            // materijali
            // 
            materijali.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            materijali.Dock = DockStyle.Fill;
            materijali.FullRowSelect = true;
            materijali.GridLines = true;
            materijali.Location = new Point(3, 23);
            materijali.Name = "materijali";
            materijali.Size = new Size(590, 426);
            materijali.TabIndex = 0;
            materijali.UseCompatibleStateImageBehavior = false;
            materijali.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Naziv";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Cena";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Proizvodjac";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Jedinica mere";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Sertifikat";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Tip";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // btNabavka
            // 
            btNabavka.Location = new Point(628, 284);
            btNabavka.Name = "btNabavka";
            btNabavka.Size = new Size(139, 72);
            btNabavka.TabIndex = 17;
            btNabavka.Text = "Nabavke materijal";
            btNabavka.UseVisualStyleBackColor = true;
            // 
            // btObrisiMaterijal
            // 
            btObrisiMaterijal.Location = new Point(628, 187);
            btObrisiMaterijal.Name = "btObrisiMaterijal";
            btObrisiMaterijal.Size = new Size(139, 72);
            btObrisiMaterijal.TabIndex = 16;
            btObrisiMaterijal.Text = "Obrisi materijal";
            btObrisiMaterijal.UseVisualStyleBackColor = true;
            // 
            // btIzmeniMaterijal
            // 
            btIzmeniMaterijal.Location = new Point(628, 107);
            btIzmeniMaterijal.Name = "btIzmeniMaterijal";
            btIzmeniMaterijal.Size = new Size(139, 61);
            btIzmeniMaterijal.TabIndex = 15;
            btIzmeniMaterijal.Text = "Izmeni materijal";
            btIzmeniMaterijal.UseVisualStyleBackColor = true;
            btIzmeniMaterijal.Click += btIzmeniMaterijal_Click;
            // 
            // btDodajMaterijal
            // 
            btDodajMaterijal.Location = new Point(628, 29);
            btDodajMaterijal.Name = "btDodajMaterijal";
            btDodajMaterijal.Size = new Size(139, 57);
            btDodajMaterijal.TabIndex = 14;
            btDodajMaterijal.Text = "Dodaj materijal";
            btDodajMaterijal.UseVisualStyleBackColor = true;
            btDodajMaterijal.Click += btDodajMaterijal_Click;
            // 
            // MaterijaliForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btNabavka);
            Controls.Add(btObrisiMaterijal);
            Controls.Add(btIzmeniMaterijal);
            Controls.Add(btDodajMaterijal);
            Controls.Add(groupBox1);
            Name = "MaterijaliForma";
            Text = "MaterijaliForma";
            Load += MaterijaliForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView materijali;
        private Button btNabavka;
        private Button btObrisiMaterijal;
        private Button btIzmeniMaterijal;
        private Button btDodajMaterijal;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
    }
}