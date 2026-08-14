namespace Gradjevinska_firma.Forme
{
    partial class StavkeKontroleForma
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
            stavke = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            bt_obrisi = new Button();
            bt_izmeni = new Button();
            bt_dodaj = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(stavke);
            groupBox1.Location = new Point(0, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(605, 449);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stavke kontrole";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // stavke
            // 
            stavke.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            stavke.Dock = DockStyle.Fill;
            stavke.FullRowSelect = true;
            stavke.GridLines = true;
            stavke.Location = new Point(3, 23);
            stavke.Name = "stavke";
            stavke.Size = new Size(599, 423);
            stavke.TabIndex = 0;
            stavke.UseCompatibleStateImageBehavior = false;
            stavke.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Redni broj stavke";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Uzorci";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Lab nalazi";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Rezultati ispitivanja";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Korektivne mere";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Rok za otklananje nepravilnosti";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // bt_obrisi
            // 
            bt_obrisi.Location = new Point(643, 196);
            bt_obrisi.Name = "bt_obrisi";
            bt_obrisi.Size = new Size(118, 52);
            bt_obrisi.TabIndex = 11;
            bt_obrisi.Text = "Obrisi stavku";
            bt_obrisi.UseVisualStyleBackColor = true;
            bt_obrisi.Click += bt_obrisi_Click;
            // 
            // bt_izmeni
            // 
            bt_izmeni.Location = new Point(643, 116);
            bt_izmeni.Name = "bt_izmeni";
            bt_izmeni.Size = new Size(118, 52);
            bt_izmeni.TabIndex = 10;
            bt_izmeni.Text = "Izmeni stavku";
            bt_izmeni.UseVisualStyleBackColor = true;
            bt_izmeni.Click += bt_izmeni_Click;
            // 
            // bt_dodaj
            // 
            bt_dodaj.Location = new Point(643, 39);
            bt_dodaj.Name = "bt_dodaj";
            bt_dodaj.Size = new Size(118, 52);
            bt_dodaj.TabIndex = 9;
            bt_dodaj.Text = "Dodaj stavku";
            bt_dodaj.UseVisualStyleBackColor = true;
            bt_dodaj.Click += bt_dodaj_Click;
            // 
            // StavkeKontroleForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bt_obrisi);
            Controls.Add(bt_izmeni);
            Controls.Add(bt_dodaj);
            Controls.Add(groupBox1);
            Name = "StavkeKontroleForma";
            Text = "StavkeKontroleForma";
            Load += StavkeKontroleForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView stavke;
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
    }
}