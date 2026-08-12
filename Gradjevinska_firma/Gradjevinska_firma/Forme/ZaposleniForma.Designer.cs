namespace Gradjevinska_firma.Forme
{
    partial class ZaposleniForma
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
            bt_dodaj = new Button();
            bt_izmeni = new Button();
            bt_obrisi = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            zaposleni = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            tabPage2 = new TabPage();
            fizickaLica = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            tabPage7 = new TabPage();
            pravnaLica = new ListView();
            columnHeader23 = new ColumnHeader();
            columnHeader24 = new ColumnHeader();
            columnHeader25 = new ColumnHeader();
            columnHeader26 = new ColumnHeader();
            columnHeader28 = new ColumnHeader();
            btDetaljiOosbe = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage7.SuspendLayout();
            SuspendLayout();
            // 
            // bt_dodaj
            // 
            bt_dodaj.Location = new Point(659, 26);
            bt_dodaj.Name = "bt_dodaj";
            bt_dodaj.Size = new Size(118, 52);
            bt_dodaj.TabIndex = 1;
            bt_dodaj.Text = "Dodaj osobu";
            bt_dodaj.UseVisualStyleBackColor = true;
            bt_dodaj.Click += bt_dodaj_Click_1;
            // 
            // bt_izmeni
            // 
            bt_izmeni.Location = new Point(659, 103);
            bt_izmeni.Name = "bt_izmeni";
            bt_izmeni.Size = new Size(118, 52);
            bt_izmeni.TabIndex = 2;
            bt_izmeni.Text = "Izmeni osobu";
            bt_izmeni.UseVisualStyleBackColor = true;
            bt_izmeni.Click += bt_izmeni_Click;
            // 
            // bt_obrisi
            // 
            bt_obrisi.Location = new Point(659, 183);
            bt_obrisi.Name = "bt_obrisi";
            bt_obrisi.Size = new Size(118, 52);
            bt_obrisi.TabIndex = 3;
            bt_obrisi.Text = "Obrisi osobu";
            bt_obrisi.UseVisualStyleBackColor = true;
            bt_obrisi.Click += bt_obrisi_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage7);
            tabControl1.Location = new Point(2, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(626, 455);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(zaposleni);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(618, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Svi zaposleni";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // zaposleni
            // 
            zaposleni.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            zaposleni.Dock = DockStyle.Fill;
            zaposleni.FullRowSelect = true;
            zaposleni.GridLines = true;
            zaposleni.Location = new Point(3, 3);
            zaposleni.Name = "zaposleni";
            zaposleni.Size = new Size(612, 416);
            zaposleni.TabIndex = 0;
            zaposleni.UseCompatibleStateImageBehavior = false;
            zaposleni.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Jmbg";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Ime";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Prezime";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Datum Rodjenja";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Struka";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 100;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(fizickaLica);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(618, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Fizicka lica";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // fizickaLica
            // 
            fizickaLica.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader12 });
            fizickaLica.Dock = DockStyle.Fill;
            fizickaLica.FullRowSelect = true;
            fizickaLica.GridLines = true;
            fizickaLica.Location = new Point(3, 3);
            fizickaLica.Name = "fizickaLica";
            fizickaLica.Size = new Size(612, 416);
            fizickaLica.TabIndex = 0;
            fizickaLica.UseCompatibleStateImageBehavior = false;
            fizickaLica.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Id";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Jmbg";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Ime";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Prezime";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            columnHeader10.Width = 150;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Struka";
            columnHeader12.TextAlign = HorizontalAlignment.Center;
            columnHeader12.Width = 150;
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(pravnaLica);
            tabPage7.Location = new Point(4, 29);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(618, 422);
            tabPage7.TabIndex = 2;
            tabPage7.Text = "Pravna Lica";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // pravnaLica
            // 
            pravnaLica.Columns.AddRange(new ColumnHeader[] { columnHeader23, columnHeader24, columnHeader25, columnHeader26, columnHeader28 });
            pravnaLica.Dock = DockStyle.Fill;
            pravnaLica.FullRowSelect = true;
            pravnaLica.GridLines = true;
            pravnaLica.Location = new Point(3, 3);
            pravnaLica.Name = "pravnaLica";
            pravnaLica.Size = new Size(612, 416);
            pravnaLica.TabIndex = 0;
            pravnaLica.UseCompatibleStateImageBehavior = false;
            pravnaLica.View = View.Details;
            // 
            // columnHeader23
            // 
            columnHeader23.Text = "Id";
            // 
            // columnHeader24
            // 
            columnHeader24.Text = "Jmbg";
            columnHeader24.TextAlign = HorizontalAlignment.Center;
            columnHeader24.Width = 150;
            // 
            // columnHeader25
            // 
            columnHeader25.Text = "Ime";
            columnHeader25.TextAlign = HorizontalAlignment.Center;
            columnHeader25.Width = 150;
            // 
            // columnHeader26
            // 
            columnHeader26.Text = "Prezime";
            columnHeader26.TextAlign = HorizontalAlignment.Center;
            columnHeader26.Width = 150;
            // 
            // columnHeader28
            // 
            columnHeader28.Text = "Struka";
            columnHeader28.TextAlign = HorizontalAlignment.Center;
            columnHeader28.Width = 100;
            // 
            // btDetaljiOosbe
            // 
            btDetaljiOosbe.Location = new Point(659, 261);
            btDetaljiOosbe.Name = "btDetaljiOosbe";
            btDetaljiOosbe.Size = new Size(118, 52);
            btDetaljiOosbe.TabIndex = 4;
            btDetaljiOosbe.Text = "Detalji osobe";
            btDetaljiOosbe.UseVisualStyleBackColor = true;
            btDetaljiOosbe.Click += btDetaljiOosbe_Click;
            // 
            // ZaposleniForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btDetaljiOosbe);
            Controls.Add(tabControl1);
            Controls.Add(bt_obrisi);
            Controls.Add(bt_izmeni);
            Controls.Add(bt_dodaj);
            Name = "ZaposleniForma";
            Text = "ZaposleniForma";
            Load += ZaposleniForma_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button bt_dodaj;
        private Button bt_izmeni;
        private Button bt_obrisi;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage7;
        private ListView pravnaLica;
        private ListView zaposleni;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ListView fizickaLica;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader12;
        private Button btDetaljiOosbe;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader28;
    }
}