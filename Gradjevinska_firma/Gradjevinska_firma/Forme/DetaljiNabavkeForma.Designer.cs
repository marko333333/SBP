namespace Gradjevinska_firma.Forme
{
    partial class DetaljiNabavkeForma
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lbProjekat = new Label();
            lbDatum = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            btObrisiNabavkuOprema = new Button();
            btIzmeniNabavkuOprema = new Button();
            btDodajNabavkuOprema = new Button();
            nabavkeOprema = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            tabPage3 = new TabPage();
            btObrisiNabavkuMaterijal = new Button();
            btIzmeniNabavkuMaterijal = new Button();
            btDodajNabavkuMaterijal = new Button();
            nabavkeMaterijal = new ListView();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lbProjekat);
            tabPage1.Controls.Add(lbDatum);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Osnovni podaci";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbProjekat
            // 
            lbProjekat.AutoSize = true;
            lbProjekat.Location = new Point(105, 78);
            lbProjekat.Name = "lbProjekat";
            lbProjekat.Size = new Size(50, 20);
            lbProjekat.TabIndex = 3;
            lbProjekat.Text = "label4";
            // 
            // lbDatum
            // 
            lbDatum.AutoSize = true;
            lbDatum.Location = new Point(96, 40);
            lbDatum.Name = "lbDatum";
            lbDatum.Size = new Size(50, 20);
            lbDatum.TabIndex = 2;
            lbDatum.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 78);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "Projekat:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 40);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Datum:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btObrisiNabavkuOprema);
            tabPage2.Controls.Add(btIzmeniNabavkuOprema);
            tabPage2.Controls.Add(btDodajNabavkuOprema);
            tabPage2.Controls.Add(nabavkeOprema);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Nabavke oprema";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btObrisiNabavkuOprema
            // 
            btObrisiNabavkuOprema.Location = new Point(615, 180);
            btObrisiNabavkuOprema.Name = "btObrisiNabavkuOprema";
            btObrisiNabavkuOprema.Size = new Size(139, 72);
            btObrisiNabavkuOprema.TabIndex = 19;
            btObrisiNabavkuOprema.Text = "Obrisi nabavku";
            btObrisiNabavkuOprema.UseVisualStyleBackColor = true;
            btObrisiNabavkuOprema.Click += btObrisiNabavkuOprema_Click;
            // 
            // btIzmeniNabavkuOprema
            // 
            btIzmeniNabavkuOprema.Location = new Point(615, 100);
            btIzmeniNabavkuOprema.Name = "btIzmeniNabavkuOprema";
            btIzmeniNabavkuOprema.Size = new Size(139, 61);
            btIzmeniNabavkuOprema.TabIndex = 18;
            btIzmeniNabavkuOprema.Text = "Izmeni nabavku";
            btIzmeniNabavkuOprema.UseVisualStyleBackColor = true;
            btIzmeniNabavkuOprema.Click += btIzmeniNabavkuOprema_Click;
            // 
            // btDodajNabavkuOprema
            // 
            btDodajNabavkuOprema.Location = new Point(615, 22);
            btDodajNabavkuOprema.Name = "btDodajNabavkuOprema";
            btDodajNabavkuOprema.Size = new Size(139, 57);
            btDodajNabavkuOprema.TabIndex = 17;
            btDodajNabavkuOprema.Text = "Dodaj nabavku";
            btDodajNabavkuOprema.UseVisualStyleBackColor = true;
            btDodajNabavkuOprema.Click += btDodajNabavkuOprema_Click;
            // 
            // nabavkeOprema
            // 
            nabavkeOprema.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader5, columnHeader2, columnHeader3, columnHeader4 });
            nabavkeOprema.Dock = DockStyle.Left;
            nabavkeOprema.FullRowSelect = true;
            nabavkeOprema.GridLines = true;
            nabavkeOprema.Location = new Point(3, 3);
            nabavkeOprema.Name = "nabavkeOprema";
            nabavkeOprema.Size = new Size(574, 411);
            nabavkeOprema.TabIndex = 0;
            nabavkeOprema.UseCompatibleStateImageBehavior = false;
            nabavkeOprema.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Oprema";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Kolicina";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Cena";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Status isporuke";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btObrisiNabavkuMaterijal);
            tabPage3.Controls.Add(btIzmeniNabavkuMaterijal);
            tabPage3.Controls.Add(btDodajNabavkuMaterijal);
            tabPage3.Controls.Add(nabavkeMaterijal);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 417);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Nabavke materijal";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btObrisiNabavkuMaterijal
            // 
            btObrisiNabavkuMaterijal.Location = new Point(614, 175);
            btObrisiNabavkuMaterijal.Name = "btObrisiNabavkuMaterijal";
            btObrisiNabavkuMaterijal.Size = new Size(139, 72);
            btObrisiNabavkuMaterijal.TabIndex = 19;
            btObrisiNabavkuMaterijal.Text = "Obrisi nabavku";
            btObrisiNabavkuMaterijal.UseVisualStyleBackColor = true;
            btObrisiNabavkuMaterijal.Click += btObrisiNabavkuMaterijal_Click;
            // 
            // btIzmeniNabavkuMaterijal
            // 
            btIzmeniNabavkuMaterijal.Location = new Point(614, 95);
            btIzmeniNabavkuMaterijal.Name = "btIzmeniNabavkuMaterijal";
            btIzmeniNabavkuMaterijal.Size = new Size(139, 61);
            btIzmeniNabavkuMaterijal.TabIndex = 18;
            btIzmeniNabavkuMaterijal.Text = "Izmeni nabavku";
            btIzmeniNabavkuMaterijal.UseVisualStyleBackColor = true;
            btIzmeniNabavkuMaterijal.Click += btIzmeniNabavkuMaterijal_Click;
            // 
            // btDodajNabavkuMaterijal
            // 
            btDodajNabavkuMaterijal.Location = new Point(614, 17);
            btDodajNabavkuMaterijal.Name = "btDodajNabavkuMaterijal";
            btDodajNabavkuMaterijal.Size = new Size(139, 57);
            btDodajNabavkuMaterijal.TabIndex = 17;
            btDodajNabavkuMaterijal.Text = "Dodaj nabavku";
            btDodajNabavkuMaterijal.UseVisualStyleBackColor = true;
            btDodajNabavkuMaterijal.Click += btDodajNabavkuMaterijal_Click;
            // 
            // nabavkeMaterijal
            // 
            nabavkeMaterijal.Columns.AddRange(new ColumnHeader[] { columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            nabavkeMaterijal.Dock = DockStyle.Left;
            nabavkeMaterijal.FullRowSelect = true;
            nabavkeMaterijal.GridLines = true;
            nabavkeMaterijal.Location = new Point(3, 3);
            nabavkeMaterijal.Name = "nabavkeMaterijal";
            nabavkeMaterijal.Size = new Size(574, 411);
            nabavkeMaterijal.TabIndex = 1;
            nabavkeMaterijal.UseCompatibleStateImageBehavior = false;
            nabavkeMaterijal.View = View.Details;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Id";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Materijal";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Kolicina";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Cena";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Status isporuke";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            // 
            // DetaljiNabavkeForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "DetaljiNabavkeForma";
            Text = "DetaljiNabavkeForma";
            Load += DetaljiNabavkeForma_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label1;
        private Label label2;
        private Label lbProjekat;
        private Label lbDatum;
        private ListView nabavkeOprema;
        private ListView nabavkeMaterijal;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Button btObrisiNabavkuOprema;
        private Button btIzmeniNabavkuOprema;
        private Button btDodajNabavkuOprema;
        private Button btObrisiNabavkuMaterijal;
        private Button btIzmeniNabavkuMaterijal;
        private Button btDodajNabavkuMaterijal;
    }
}