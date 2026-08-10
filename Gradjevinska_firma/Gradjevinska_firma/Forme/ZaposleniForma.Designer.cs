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
            groupBox1 = new GroupBox();
            zaposleni = new ListView();
            bt_dodaj = new Button();
            bt_izmeni = new Button();
            bt_obrisi = new Button();
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
            groupBox1.Controls.Add(zaposleni);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(630, 428);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Osobe";
            // 
            // zaposleni
            // 
            zaposleni.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            zaposleni.Dock = DockStyle.Fill;
            zaposleni.FullRowSelect = true;
            zaposleni.GridLines = true;
            zaposleni.Location = new Point(3, 23);
            zaposleni.Name = "zaposleni";
            zaposleni.Size = new Size(624, 402);
            zaposleni.TabIndex = 0;
            zaposleni.UseCompatibleStateImageBehavior = false;
            zaposleni.View = View.Details;
            // 
            // bt_dodaj
            // 
            bt_dodaj.Location = new Point(659, 26);
            bt_dodaj.Name = "bt_dodaj";
            bt_dodaj.Size = new Size(118, 52);
            bt_dodaj.TabIndex = 1;
            bt_dodaj.Text = "Dodaj osobu";
            bt_dodaj.UseVisualStyleBackColor = true;
            // 
            // bt_izmeni
            // 
            bt_izmeni.Location = new Point(659, 103);
            bt_izmeni.Name = "bt_izmeni";
            bt_izmeni.Size = new Size(118, 52);
            bt_izmeni.TabIndex = 2;
            bt_izmeni.Text = "Izmeni osobu";
            bt_izmeni.UseVisualStyleBackColor = true;
            // 
            // bt_obrisi
            // 
            bt_obrisi.Location = new Point(659, 183);
            bt_obrisi.Name = "bt_obrisi";
            bt_obrisi.Size = new Size(118, 52);
            bt_obrisi.TabIndex = 3;
            bt_obrisi.Text = "Obrisi osobu";
            bt_obrisi.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Jmbg";
            columnHeader2.Width = 80;
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
            columnHeader6.Width = 150;
            // 
            // ZaposleniForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bt_obrisi);
            Controls.Add(bt_izmeni);
            Controls.Add(bt_dodaj);
            Controls.Add(groupBox1);
            Name = "ZaposleniForma";
            Text = "ZaposleniForma";
            Load += ZaposleniForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView zaposleni;
        private Button bt_dodaj;
        private Button bt_izmeni;
        private Button bt_obrisi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}