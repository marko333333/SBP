namespace Gradjevinska_firma.Forme
{
    partial class UgovoriForma
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
            ugovori = new ListView();
            btDetaljiUgovora = new Button();
            bt_obrisi = new Button();
            bt_izmeni = new Button();
            bt_dodaj = new Button();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ugovori);
            groupBox1.Location = new Point(2, -1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(601, 452);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ugovori";
            // 
            // ugovori
            // 
            ugovori.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            ugovori.Dock = DockStyle.Fill;
            ugovori.Location = new Point(3, 23);
            ugovori.Name = "ugovori";
            ugovori.Size = new Size(595, 426);
            ugovori.TabIndex = 0;
            ugovori.UseCompatibleStateImageBehavior = false;
            ugovori.View = View.Details;
            // 
            // btDetaljiUgovora
            // 
            btDetaljiUgovora.Location = new Point(645, 284);
            btDetaljiUgovora.Name = "btDetaljiUgovora";
            btDetaljiUgovora.Size = new Size(118, 52);
            btDetaljiUgovora.TabIndex = 12;
            btDetaljiUgovora.Text = "Detalji ugovora";
            btDetaljiUgovora.UseVisualStyleBackColor = true;
            // 
            // bt_obrisi
            // 
            bt_obrisi.Location = new Point(645, 205);
            bt_obrisi.Name = "bt_obrisi";
            bt_obrisi.Size = new Size(118, 52);
            bt_obrisi.TabIndex = 11;
            bt_obrisi.Text = "Obrisi ugovor";
            bt_obrisi.UseVisualStyleBackColor = true;
            // 
            // bt_izmeni
            // 
            bt_izmeni.Location = new Point(645, 125);
            bt_izmeni.Name = "bt_izmeni";
            bt_izmeni.Size = new Size(118, 52);
            bt_izmeni.TabIndex = 10;
            bt_izmeni.Text = "Izmeni ugovor";
            bt_izmeni.UseVisualStyleBackColor = true;
            // 
            // bt_dodaj
            // 
            bt_dodaj.Location = new Point(645, 48);
            bt_dodaj.Name = "bt_dodaj";
            bt_dodaj.Size = new Size(118, 52);
            bt_dodaj.TabIndex = 9;
            bt_dodaj.Text = "Dodaj ugovor";
            bt_dodaj.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Datum potpisivanja";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Vrednost";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Predmet ugovora";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Valuta";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Rok";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            // 
            // UgovoriForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btDetaljiUgovora);
            Controls.Add(bt_obrisi);
            Controls.Add(bt_izmeni);
            Controls.Add(bt_dodaj);
            Controls.Add(groupBox1);
            Name = "UgovoriForma";
            Text = "UgovoriForma";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView ugovori;
        private Button btDetaljiUgovora;
        private Button bt_obrisi;
        private Button bt_izmeni;
        private Button bt_dodaj;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}