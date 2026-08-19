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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox2 = new GroupBox();
            gradjevinski = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            btDodajGradj = new Button();
            btObrisiGradj = new Button();
            btIzmeniGradj = new Button();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            zavrsni = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            btDodajZavrsni = new Button();
            btObrisiZavrsni = new Button();
            btIzmeniZavrsni = new Button();
            tabPage3 = new TabPage();
            groupBox4 = new GroupBox();
            zastitni = new ListView();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            columnHeader19 = new ColumnHeader();
            columnHeader20 = new ColumnHeader();
            columnHeader21 = new ColumnHeader();
            btDodajZastitni = new Button();
            btobrisiZastitni = new Button();
            btIzmeniZastitni = new Button();
            tabPage4 = new TabPage();
            groupBox5 = new GroupBox();
            elektro = new ListView();
            columnHeader22 = new ColumnHeader();
            columnHeader23 = new ColumnHeader();
            columnHeader24 = new ColumnHeader();
            columnHeader25 = new ColumnHeader();
            columnHeader26 = new ColumnHeader();
            columnHeader27 = new ColumnHeader();
            columnHeader28 = new ColumnHeader();
            btDodajElektro = new Button();
            btObrisiElektro = new Button();
            btIzmeniElektro = new Button();
            tabPage5 = new TabPage();
            groupBox6 = new GroupBox();
            masinski = new ListView();
            columnHeader29 = new ColumnHeader();
            columnHeader30 = new ColumnHeader();
            columnHeader31 = new ColumnHeader();
            columnHeader32 = new ColumnHeader();
            columnHeader33 = new ColumnHeader();
            columnHeader34 = new ColumnHeader();
            columnHeader35 = new ColumnHeader();
            btDodajMasinski = new Button();
            btObrisiMasinski = new Button();
            btIzmeniMasinski = new Button();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox4.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox5.SuspendLayout();
            tabPage5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tabControl1);
            groupBox1.Location = new Point(6, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(782, 452);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Materijali";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 23);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 393);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Gradjevinski";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gradjevinski);
            groupBox2.Controls.Add(btDodajGradj);
            groupBox2.Controls.Add(btObrisiGradj);
            groupBox2.Controls.Add(btIzmeniGradj);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(762, 387);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Gradjevinski";
            // 
            // gradjevinski
            // 
            gradjevinski.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            gradjevinski.FullRowSelect = true;
            gradjevinski.GridLines = true;
            gradjevinski.Location = new Point(18, 26);
            gradjevinski.Name = "gradjevinski";
            gradjevinski.Size = new Size(554, 361);
            gradjevinski.TabIndex = 0;
            gradjevinski.UseCompatibleStateImageBehavior = false;
            gradjevinski.View = View.Details;
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
            // btDodajGradj
            // 
            btDodajGradj.Location = new Point(594, 26);
            btDodajGradj.Name = "btDodajGradj";
            btDodajGradj.Size = new Size(139, 59);
            btDodajGradj.TabIndex = 14;
            btDodajGradj.Text = "Dodaj materijal";
            btDodajGradj.UseVisualStyleBackColor = true;
            btDodajGradj.Click += btDodajMaterijal_Click;
            // 
            // btObrisiGradj
            // 
            btObrisiGradj.Location = new Point(594, 196);
            btObrisiGradj.Name = "btObrisiGradj";
            btObrisiGradj.Size = new Size(139, 72);
            btObrisiGradj.TabIndex = 16;
            btObrisiGradj.Text = "Obrisi materijal";
            btObrisiGradj.UseVisualStyleBackColor = true;
            btObrisiGradj.Click += btObrisiGradj_Click;
            // 
            // btIzmeniGradj
            // 
            btIzmeniGradj.Location = new Point(594, 109);
            btIzmeniGradj.Name = "btIzmeniGradj";
            btIzmeniGradj.Size = new Size(139, 61);
            btIzmeniGradj.TabIndex = 15;
            btIzmeniGradj.Text = "Izmeni materijal";
            btIzmeniGradj.UseVisualStyleBackColor = true;
            btIzmeniGradj.Click += btIzmeniMaterijal_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 393);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Zavrsni";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(zavrsni);
            groupBox3.Controls.Add(btDodajZavrsni);
            groupBox3.Controls.Add(btObrisiZavrsni);
            groupBox3.Controls.Add(btIzmeniZavrsni);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(762, 387);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Zavrsni";
            // 
            // zavrsni
            // 
            zavrsni.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12, columnHeader13, columnHeader14 });
            zavrsni.FullRowSelect = true;
            zavrsni.GridLines = true;
            zavrsni.Location = new Point(18, 26);
            zavrsni.Name = "zavrsni";
            zavrsni.Size = new Size(554, 361);
            zavrsni.TabIndex = 0;
            zavrsni.UseCompatibleStateImageBehavior = false;
            zavrsni.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Id";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Naziv";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Cena";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Proizvodjac";
            columnHeader11.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Jedinica mere";
            columnHeader12.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Sertifikat";
            columnHeader13.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Tip";
            columnHeader14.TextAlign = HorizontalAlignment.Center;
            // 
            // btDodajZavrsni
            // 
            btDodajZavrsni.Location = new Point(594, 26);
            btDodajZavrsni.Name = "btDodajZavrsni";
            btDodajZavrsni.Size = new Size(139, 59);
            btDodajZavrsni.TabIndex = 14;
            btDodajZavrsni.Text = "Dodaj materijal";
            btDodajZavrsni.UseVisualStyleBackColor = true;
            btDodajZavrsni.Click += btDodajZavrsni_Click;
            // 
            // btObrisiZavrsni
            // 
            btObrisiZavrsni.Location = new Point(594, 196);
            btObrisiZavrsni.Name = "btObrisiZavrsni";
            btObrisiZavrsni.Size = new Size(139, 72);
            btObrisiZavrsni.TabIndex = 16;
            btObrisiZavrsni.Text = "Obrisi materijal";
            btObrisiZavrsni.UseVisualStyleBackColor = true;
            btObrisiZavrsni.Click += btObrisiZavrsni_Click;
            // 
            // btIzmeniZavrsni
            // 
            btIzmeniZavrsni.Location = new Point(594, 109);
            btIzmeniZavrsni.Name = "btIzmeniZavrsni";
            btIzmeniZavrsni.Size = new Size(139, 61);
            btIzmeniZavrsni.TabIndex = 15;
            btIzmeniZavrsni.Text = "Izmeni materijal";
            btIzmeniZavrsni.UseVisualStyleBackColor = true;
            btIzmeniZavrsni.Click += btIzmeniZavrsni_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox4);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(768, 393);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Zastitni";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(zastitni);
            groupBox4.Controls.Add(btDodajZastitni);
            groupBox4.Controls.Add(btobrisiZastitni);
            groupBox4.Controls.Add(btIzmeniZastitni);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(762, 387);
            groupBox4.TabIndex = 20;
            groupBox4.TabStop = false;
            groupBox4.Text = "Zastitni";
            // 
            // zastitni
            // 
            zastitni.Columns.AddRange(new ColumnHeader[] { columnHeader15, columnHeader16, columnHeader17, columnHeader18, columnHeader19, columnHeader20, columnHeader21 });
            zastitni.FullRowSelect = true;
            zastitni.GridLines = true;
            zastitni.Location = new Point(18, 26);
            zastitni.Name = "zastitni";
            zastitni.Size = new Size(554, 361);
            zastitni.TabIndex = 0;
            zastitni.UseCompatibleStateImageBehavior = false;
            zastitni.View = View.Details;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Id";
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Naziv";
            columnHeader16.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Cena";
            columnHeader17.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Proizvodjac";
            columnHeader18.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "Jedinica mere";
            columnHeader19.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader20
            // 
            columnHeader20.Text = "Sertifikat";
            columnHeader20.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader21
            // 
            columnHeader21.Text = "Tip";
            columnHeader21.TextAlign = HorizontalAlignment.Center;
            // 
            // btDodajZastitni
            // 
            btDodajZastitni.Location = new Point(594, 26);
            btDodajZastitni.Name = "btDodajZastitni";
            btDodajZastitni.Size = new Size(139, 59);
            btDodajZastitni.TabIndex = 14;
            btDodajZastitni.Text = "Dodaj materijal";
            btDodajZastitni.UseVisualStyleBackColor = true;
            btDodajZastitni.Click += btDodajZastitni_Click;
            // 
            // btobrisiZastitni
            // 
            btobrisiZastitni.Location = new Point(594, 196);
            btobrisiZastitni.Name = "btobrisiZastitni";
            btobrisiZastitni.Size = new Size(139, 72);
            btobrisiZastitni.TabIndex = 16;
            btobrisiZastitni.Text = "Obrisi materijal";
            btobrisiZastitni.UseVisualStyleBackColor = true;
            btobrisiZastitni.Click += btobrisiZastitni_Click;
            // 
            // btIzmeniZastitni
            // 
            btIzmeniZastitni.Location = new Point(594, 109);
            btIzmeniZastitni.Name = "btIzmeniZastitni";
            btIzmeniZastitni.Size = new Size(139, 61);
            btIzmeniZastitni.TabIndex = 15;
            btIzmeniZastitni.Text = "Izmeni materijal";
            btIzmeniZastitni.UseVisualStyleBackColor = true;
            btIzmeniZastitni.Click += btIzmeniZastitni_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(groupBox5);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(768, 393);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Elektro";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(elektro);
            groupBox5.Controls.Add(btDodajElektro);
            groupBox5.Controls.Add(btObrisiElektro);
            groupBox5.Controls.Add(btIzmeniElektro);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(0, 0);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(768, 393);
            groupBox5.TabIndex = 21;
            groupBox5.TabStop = false;
            groupBox5.Text = "Elektro";
            // 
            // elektro
            // 
            elektro.Columns.AddRange(new ColumnHeader[] { columnHeader22, columnHeader23, columnHeader24, columnHeader25, columnHeader26, columnHeader27, columnHeader28 });
            elektro.FullRowSelect = true;
            elektro.GridLines = true;
            elektro.Location = new Point(18, 26);
            elektro.Name = "elektro";
            elektro.Size = new Size(554, 361);
            elektro.TabIndex = 0;
            elektro.UseCompatibleStateImageBehavior = false;
            elektro.View = View.Details;
            // 
            // columnHeader22
            // 
            columnHeader22.Text = "Id";
            // 
            // columnHeader23
            // 
            columnHeader23.Text = "Naziv";
            columnHeader23.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader24
            // 
            columnHeader24.Text = "Cena";
            columnHeader24.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader25
            // 
            columnHeader25.Text = "Proizvodjac";
            columnHeader25.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader26
            // 
            columnHeader26.Text = "Jedinica mere";
            columnHeader26.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader27
            // 
            columnHeader27.Text = "Sertifikat";
            columnHeader27.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader28
            // 
            columnHeader28.Text = "Tip";
            columnHeader28.TextAlign = HorizontalAlignment.Center;
            // 
            // btDodajElektro
            // 
            btDodajElektro.Location = new Point(594, 26);
            btDodajElektro.Name = "btDodajElektro";
            btDodajElektro.Size = new Size(139, 59);
            btDodajElektro.TabIndex = 14;
            btDodajElektro.Text = "Dodaj materijal";
            btDodajElektro.UseVisualStyleBackColor = true;
            btDodajElektro.Click += btDodajElektro_Click;
            // 
            // btObrisiElektro
            // 
            btObrisiElektro.Location = new Point(594, 196);
            btObrisiElektro.Name = "btObrisiElektro";
            btObrisiElektro.Size = new Size(139, 72);
            btObrisiElektro.TabIndex = 16;
            btObrisiElektro.Text = "Obrisi materijal";
            btObrisiElektro.UseVisualStyleBackColor = true;
            btObrisiElektro.Click += btObrisiElektro_Click;
            // 
            // btIzmeniElektro
            // 
            btIzmeniElektro.Location = new Point(594, 109);
            btIzmeniElektro.Name = "btIzmeniElektro";
            btIzmeniElektro.Size = new Size(139, 61);
            btIzmeniElektro.TabIndex = 15;
            btIzmeniElektro.Text = "Izmeni materijal";
            btIzmeniElektro.UseVisualStyleBackColor = true;
            btIzmeniElektro.Click += btIzmeniElektro_Click;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(groupBox6);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(768, 393);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Masinski";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(masinski);
            groupBox6.Controls.Add(btDodajMasinski);
            groupBox6.Controls.Add(btObrisiMasinski);
            groupBox6.Controls.Add(btIzmeniMasinski);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(0, 0);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(768, 393);
            groupBox6.TabIndex = 22;
            groupBox6.TabStop = false;
            groupBox6.Text = "Masinski";
            // 
            // masinski
            // 
            masinski.Columns.AddRange(new ColumnHeader[] { columnHeader29, columnHeader30, columnHeader31, columnHeader32, columnHeader33, columnHeader34, columnHeader35 });
            masinski.FullRowSelect = true;
            masinski.GridLines = true;
            masinski.Location = new Point(18, 26);
            masinski.Name = "masinski";
            masinski.Size = new Size(554, 361);
            masinski.TabIndex = 0;
            masinski.UseCompatibleStateImageBehavior = false;
            masinski.View = View.Details;
            // 
            // columnHeader29
            // 
            columnHeader29.Text = "Id";
            // 
            // columnHeader30
            // 
            columnHeader30.Text = "Naziv";
            columnHeader30.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader31
            // 
            columnHeader31.Text = "Cena";
            columnHeader31.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader32
            // 
            columnHeader32.Text = "Proizvodjac";
            columnHeader32.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader33
            // 
            columnHeader33.Text = "Jedinica mere";
            columnHeader33.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader34
            // 
            columnHeader34.Text = "Sertifikat";
            columnHeader34.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader35
            // 
            columnHeader35.Text = "Tip";
            columnHeader35.TextAlign = HorizontalAlignment.Center;
            // 
            // btDodajMasinski
            // 
            btDodajMasinski.Location = new Point(594, 26);
            btDodajMasinski.Name = "btDodajMasinski";
            btDodajMasinski.Size = new Size(139, 59);
            btDodajMasinski.TabIndex = 14;
            btDodajMasinski.Text = "Dodaj materijal";
            btDodajMasinski.UseVisualStyleBackColor = true;
            btDodajMasinski.Click += btDodajMasinski_Click;
            // 
            // btObrisiMasinski
            // 
            btObrisiMasinski.Location = new Point(594, 196);
            btObrisiMasinski.Name = "btObrisiMasinski";
            btObrisiMasinski.Size = new Size(139, 72);
            btObrisiMasinski.TabIndex = 16;
            btObrisiMasinski.Text = "Obrisi materijal";
            btObrisiMasinski.UseVisualStyleBackColor = true;
            btObrisiMasinski.Click += btObrisiMasinski_Click;
            // 
            // btIzmeniMasinski
            // 
            btIzmeniMasinski.Location = new Point(594, 109);
            btIzmeniMasinski.Name = "btIzmeniMasinski";
            btIzmeniMasinski.Size = new Size(139, 61);
            btIzmeniMasinski.TabIndex = 15;
            btIzmeniMasinski.Text = "Izmeni materijal";
            btIzmeniMasinski.UseVisualStyleBackColor = true;
            btIzmeniMasinski.Click += btIzmeniMasinski_Click;
            // 
            // MaterijaliForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "MaterijaliForma";
            Text = "MaterijaliForma";
            Load += MaterijaliForma_Load;
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView gradjevinski;
        private Button btObrisiGradj;
        private Button btIzmeniGradj;
        private Button btDodajGradj;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private ListView zavrsni;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private Button btDodajZavrsni;
        private Button btObrisiZavrsni;
        private Button btIzmeniZavrsni;
        private GroupBox groupBox4;
        private ListView zastitni;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private Button btDodajZastitni;
        private Button btobrisiZastitni;
        private Button btIzmeniZastitni;
        private GroupBox groupBox5;
        private ListView elektro;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader27;
        private ColumnHeader columnHeader28;
        private Button btDodajElektro;
        private Button btObrisiElektro;
        private Button btIzmeniElektro;
        private GroupBox groupBox6;
        private ListView masinski;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private ColumnHeader columnHeader33;
        private ColumnHeader columnHeader34;
        private ColumnHeader columnHeader35;
        private Button btDodajMasinski;
        private Button btObrisiMasinski;
        private Button btIzmeniMasinski;
    }
}