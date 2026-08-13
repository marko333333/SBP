namespace Gradjevinska_firma.Forme
{
    partial class ZadaciForma
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
            zadaci = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            btDetaljiOosbe = new Button();
            bt_obrisi = new Button();
            bt_izmeni = new Button();
            bt_dodaj = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(zadaci);
            groupBox1.Location = new Point(3, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(530, 387);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Zadaci";
            // 
            // zadaci
            // 
            zadaci.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader9, columnHeader10, columnHeader4, columnHeader5, columnHeader11, columnHeader6, columnHeader12, columnHeader7, columnHeader8 });
            zadaci.Dock = DockStyle.Fill;
            zadaci.FullRowSelect = true;
            zadaci.GridLines = true;
            zadaci.Location = new Point(3, 23);
            zadaci.Name = "zadaci";
            zadaci.Size = new Size(524, 361);
            zadaci.TabIndex = 0;
            zadaci.UseCompatibleStateImageBehavior = false;
            zadaci.View = View.Details;
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
            columnHeader3.Text = "Opis";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Faza";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "NadZadatak";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Procenjeni trosak";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Planirani pocetak";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Stvarni pocetak";
            columnHeader11.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Planirani zavrsetak";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Stvarni zavrsetak";
            columnHeader12.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Prioritet";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Status";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            // 
            // btDetaljiOosbe
            // 
            btDetaljiOosbe.Location = new Point(584, 258);
            btDetaljiOosbe.Name = "btDetaljiOosbe";
            btDetaljiOosbe.Size = new Size(118, 52);
            btDetaljiOosbe.TabIndex = 8;
            btDetaljiOosbe.Text = "Detalji zadatka";
            btDetaljiOosbe.UseVisualStyleBackColor = true;
            btDetaljiOosbe.Click += btDetaljiOosbe_Click;
            // 
            // bt_obrisi
            // 
            bt_obrisi.Location = new Point(584, 180);
            bt_obrisi.Name = "bt_obrisi";
            bt_obrisi.Size = new Size(118, 52);
            bt_obrisi.TabIndex = 7;
            bt_obrisi.Text = "Obrisi zadatak";
            bt_obrisi.UseVisualStyleBackColor = true;
            // 
            // bt_izmeni
            // 
            bt_izmeni.Location = new Point(584, 100);
            bt_izmeni.Name = "bt_izmeni";
            bt_izmeni.Size = new Size(118, 52);
            bt_izmeni.TabIndex = 6;
            bt_izmeni.Text = "Izmeni zadatak";
            bt_izmeni.UseVisualStyleBackColor = true;
            bt_izmeni.Click += bt_izmeni_Click;
            // 
            // bt_dodaj
            // 
            bt_dodaj.Location = new Point(584, 23);
            bt_dodaj.Name = "bt_dodaj";
            bt_dodaj.Size = new Size(118, 52);
            bt_dodaj.TabIndex = 5;
            bt_dodaj.Text = "Dodaj zadatak";
            bt_dodaj.UseVisualStyleBackColor = true;
            bt_dodaj.Click += bt_dodaj_Click;
            // 
            // ZadaciForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(755, 382);
            Controls.Add(btDetaljiOosbe);
            Controls.Add(bt_obrisi);
            Controls.Add(bt_izmeni);
            Controls.Add(bt_dodaj);
            Controls.Add(groupBox1);
            Name = "ZadaciForma";
            Text = "ZadaciForma";
            Load += ZadaciForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView zadaci;
        private Button btDetaljiOosbe;
        private Button bt_obrisi;
        private Button bt_izmeni;
        private Button bt_dodaj;
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
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
    }
}