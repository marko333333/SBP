namespace Gradjevinska_firma.Forme
{
    partial class DetaljiIndustrijskiForma
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
            label2 = new Label();
            lbStvarniZavrsetak = new Label();
            label6 = new Label();
            lbPlaniraniZavrsetak = new Label();
            label8 = new Label();
            label9 = new Label();
            lbDatumPocetka = new Label();
            label11 = new Label();
            label12 = new Label();
            lbNaziv = new Label();
            label14 = new Label();
            lbLokacija = new Label();
            lbOpis = new Label();
            label17 = new Label();
            lbBudzet = new Label();
            lbStatus = new Label();
            tabPage2 = new TabPage();
            Ugovori = new ListView();
            Datum_potpisivanja = new ColumnHeader();
            ID = new ColumnHeader();
            Vrednost = new ColumnHeader();
            Predmet_ugovora = new ColumnHeader();
            Valuta = new ColumnHeader();
            Rok = new ColumnHeader();
            tabPage3 = new TabPage();
            Incidenti = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            tabPage4 = new TabPage();
            Fakture = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            tabPage5 = new TabPage();
            Faze = new ListView();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(12, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(841, 256);
            tabControl1.TabIndex = 20;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(lbStvarniZavrsetak);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(lbPlaniraniZavrsetak);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(lbDatumPocetka);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(lbNaziv);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(lbLokacija);
            tabPage1.Controls.Add(lbOpis);
            tabPage1.Controls.Add(label17);
            tabPage1.Controls.Add(lbBudzet);
            tabPage1.Controls.Add(lbStatus);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(833, 228);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Osnovni podaci";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 15);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 18;
            label2.Text = "Naziv:";
            // 
            // lbStvarniZavrsetak
            // 
            lbStvarniZavrsetak.AutoSize = true;
            lbStvarniZavrsetak.Location = new Point(558, 74);
            lbStvarniZavrsetak.Name = "lbStvarniZavrsetak";
            lbStvarniZavrsetak.Size = new Size(38, 15);
            lbStvarniZavrsetak.TabIndex = 33;
            lbStvarniZavrsetak.Text = "label1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 65);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 20;
            label6.Text = "Lokacija:";
            // 
            // lbPlaniraniZavrsetak
            // 
            lbPlaniraniZavrsetak.AutoSize = true;
            lbPlaniraniZavrsetak.Location = new Point(558, 41);
            lbPlaniraniZavrsetak.Name = "lbPlaniraniZavrsetak";
            lbPlaniraniZavrsetak.Size = new Size(38, 15);
            lbPlaniraniZavrsetak.TabIndex = 32;
            lbPlaniraniZavrsetak.Text = "label1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 91);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 21;
            label8.Text = "Budzet:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 41);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 19;
            label9.Text = "Opis:";
            // 
            // lbDatumPocetka
            // 
            lbDatumPocetka.AutoSize = true;
            lbDatumPocetka.Location = new Point(558, 6);
            lbDatumPocetka.Name = "lbDatumPocetka";
            lbDatumPocetka.Size = new Size(38, 15);
            lbDatumPocetka.TabIndex = 31;
            lbDatumPocetka.Text = "label1";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 120);
            label11.Name = "label11";
            label11.Size = new Size(42, 15);
            label11.TabIndex = 22;
            label11.Text = "Status:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(435, 74);
            label12.Name = "label12";
            label12.Size = new Size(97, 15);
            label12.TabIndex = 30;
            label12.Text = "Stvarni zavrsetak:";
            // 
            // lbNaziv
            // 
            lbNaziv.AutoSize = true;
            lbNaziv.Location = new Point(75, 15);
            lbNaziv.Name = "lbNaziv";
            lbNaziv.Size = new Size(38, 15);
            lbNaziv.TabIndex = 23;
            lbNaziv.Text = "label1";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(435, 41);
            label14.Name = "label14";
            label14.Size = new Size(107, 15);
            label14.TabIndex = 29;
            label14.Text = "Planirani zavrsetak:";
            // 
            // lbLokacija
            // 
            lbLokacija.AutoSize = true;
            lbLokacija.Location = new Point(75, 65);
            lbLokacija.Name = "lbLokacija";
            lbLokacija.Size = new Size(38, 15);
            lbLokacija.TabIndex = 24;
            lbLokacija.Text = "label1";
            // 
            // lbOpis
            // 
            lbOpis.AutoSize = true;
            lbOpis.Location = new Point(75, 41);
            lbOpis.Name = "lbOpis";
            lbOpis.Size = new Size(38, 15);
            lbOpis.TabIndex = 25;
            lbOpis.Text = "label1";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(435, 6);
            label17.Name = "label17";
            label17.Size = new Size(91, 15);
            label17.TabIndex = 28;
            label17.Text = "Datum pocetka:";
            // 
            // lbBudzet
            // 
            lbBudzet.AutoSize = true;
            lbBudzet.Location = new Point(75, 91);
            lbBudzet.Name = "lbBudzet";
            lbBudzet.Size = new Size(38, 15);
            lbBudzet.TabIndex = 26;
            lbBudzet.Text = "label1";
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(75, 120);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(38, 15);
            lbStatus.TabIndex = 27;
            lbStatus.Text = "label1";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(Ugovori);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(833, 228);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ugovori";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Ugovori
            // 
            Ugovori.Columns.AddRange(new ColumnHeader[] { Datum_potpisivanja, ID, Vrednost, Predmet_ugovora, Valuta, Rok });
            Ugovori.GridLines = true;
            Ugovori.Location = new Point(3, 19);
            Ugovori.Name = "Ugovori";
            Ugovori.Size = new Size(528, 203);
            Ugovori.TabIndex = 0;
            Ugovori.UseCompatibleStateImageBehavior = false;
            Ugovori.View = View.Details;
            // 
            // Datum_potpisivanja
            // 
            Datum_potpisivanja.DisplayIndex = 1;
            Datum_potpisivanja.Text = "Datum_potpisivanja";
            Datum_potpisivanja.Width = 130;
            // 
            // ID
            // 
            ID.DisplayIndex = 0;
            ID.Text = "ID";
            ID.Width = 30;
            // 
            // Vrednost
            // 
            Vrednost.Text = "Vrednost";
            // 
            // Predmet_ugovora
            // 
            Predmet_ugovora.Text = "Predmet_ugovora";
            Predmet_ugovora.Width = 120;
            // 
            // Valuta
            // 
            Valuta.Text = "Valuta";
            // 
            // Rok
            // 
            Rok.Text = "Rok";
            Rok.Width = 120;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(Incidenti);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(833, 228);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Bezbednosni Incidenti";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Incidenti
            // 
            Incidenti.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            Incidenti.Location = new Point(3, 12);
            Incidenti.Name = "Incidenti";
            Incidenti.Size = new Size(507, 216);
            Incidenti.TabIndex = 0;
            Incidenti.UseCompatibleStateImageBehavior = false;
            Incidenti.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Opis";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Datum";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Lokacija";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Preduzete_mere";
            columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Posledice";
            columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Tip_incidenta";
            columnHeader7.Width = 90;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(Fakture);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(833, 228);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Faktura";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // Fakture
            // 
            Fakture.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            Fakture.Location = new Point(3, 13);
            Fakture.Name = "Fakture";
            Fakture.Size = new Size(377, 212);
            Fakture.TabIndex = 0;
            Fakture.UseCompatibleStateImageBehavior = false;
            Fakture.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Br_fakture";
            columnHeader8.Width = 65;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Iznos";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Valuta";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Status_placanja";
            columnHeader11.Width = 105;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Datum";
            columnHeader12.Width = 80;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(Faze);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(833, 228);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Faza";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // Faze
            // 
            Faze.Columns.AddRange(new ColumnHeader[] { columnHeader13, columnHeader14, columnHeader15, columnHeader16, columnHeader17, columnHeader18 });
            Faze.Location = new Point(3, 17);
            Faze.Name = "Faze";
            Faze.Size = new Size(406, 208);
            Faze.TabIndex = 0;
            Faze.UseCompatibleStateImageBehavior = false;
            Faze.View = View.Details;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "ID";
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Naziv";
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Datum_od";
            columnHeader15.Width = 80;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Datum_do";
            columnHeader16.Width = 80;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Status";
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Budzet";
            // 
            // DetaljiIndustrijskiForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 352);
            Controls.Add(tabControl1);
            Name = "DetaljiIndustrijskiForma";
            Text = "DetaljiIndustrijskiForma";
            Load += DetaljiIndustrijskiForma_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Label label2;
        private Label lbStvarniZavrsetak;
        private Label label6;
        private Label lbPlaniraniZavrsetak;
        private Label label8;
        private Label label9;
        private Label lbDatumPocetka;
        private Label label11;
        private Label label12;
        private Label lbNaziv;
        private Label label14;
        private Label lbLokacija;
        private Label lbOpis;
        private Label label17;
        private Label lbBudzet;
        private Label lbStatus;
        private ListView Ugovori;
        private ColumnHeader Datum_potpisivanja;
        private ColumnHeader ID;
        private ColumnHeader Vrednost;
        private ColumnHeader Predmet_ugovora;
        private ColumnHeader Valuta;
        private ColumnHeader Rok;
        private ListView Incidenti;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ListView Fakture;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ListView Faze;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
    }
}