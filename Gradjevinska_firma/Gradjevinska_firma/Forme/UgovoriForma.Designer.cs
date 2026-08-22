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
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            listView1 = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            listView2 = new ListView();
            columnHeader13 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            listView3 = new ListView();
            columnHeader19 = new ColumnHeader();
            columnHeader20 = new ColumnHeader();
            columnHeader21 = new ColumnHeader();
            columnHeader22 = new ColumnHeader();
            columnHeader23 = new ColumnHeader();
            columnHeader24 = new ColumnHeader();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ugovori);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(601, 405);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ugovori";
            // 
            // ugovori
            // 
            ugovori.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            ugovori.Dock = DockStyle.Fill;
            ugovori.FullRowSelect = true;
            ugovori.GridLines = true;
            ugovori.Location = new Point(3, 23);
            ugovori.Name = "ugovori";
            ugovori.Size = new Size(595, 379);
            ugovori.TabIndex = 0;
            ugovori.UseCompatibleStateImageBehavior = false;
            ugovori.View = View.Details;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(2, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(626, 446);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(618, 413);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Svi ugovori";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listView1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(618, 413);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ugovori projekata";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(listView2);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(618, 413);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Ugovori materijala";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(listView3);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(618, 413);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Ugovori opreme";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(650, 301);
            button1.Name = "button1";
            button1.Size = new Size(118, 52);
            button1.TabIndex = 17;
            button1.Text = "Detalji ugovora";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(650, 65);
            button2.Name = "button2";
            button2.Size = new Size(118, 52);
            button2.TabIndex = 14;
            button2.Text = "Dodaj ugovor";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(650, 222);
            button3.Name = "button3";
            button3.Size = new Size(118, 52);
            button3.TabIndex = 16;
            button3.Text = "Obrisi ugovor";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(650, 142);
            button4.Name = "button4";
            button4.Size = new Size(118, 52);
            button4.TabIndex = 15;
            button4.Text = "Izmeni ugovor";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(3, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(612, 407);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Id";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Datum potpisivanja";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Vrednost";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Predmet ugovora";
            columnHeader10.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Valuta";
            columnHeader11.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Rok";
            columnHeader12.TextAlign = HorizontalAlignment.Center;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader13, columnHeader14, columnHeader15, columnHeader16, columnHeader17, columnHeader18 });
            listView2.Dock = DockStyle.Fill;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Location = new Point(3, 3);
            listView2.Name = "listView2";
            listView2.Size = new Size(612, 407);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Id";
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "Datum potpisivanja";
            columnHeader14.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Vrednost";
            columnHeader15.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Predmet ugovora";
            columnHeader16.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Valuta";
            columnHeader17.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Rok";
            columnHeader18.TextAlign = HorizontalAlignment.Center;
            // 
            // listView3
            // 
            listView3.Columns.AddRange(new ColumnHeader[] { columnHeader19, columnHeader20, columnHeader21, columnHeader22, columnHeader23, columnHeader24 });
            listView3.Dock = DockStyle.Fill;
            listView3.FullRowSelect = true;
            listView3.GridLines = true;
            listView3.Location = new Point(3, 3);
            listView3.Name = "listView3";
            listView3.Size = new Size(612, 407);
            listView3.TabIndex = 1;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.Details;
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "Id";
            // 
            // columnHeader20
            // 
            columnHeader20.Text = "Datum potpisivanja";
            columnHeader20.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader21
            // 
            columnHeader21.Text = "Vrednost";
            columnHeader21.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader22
            // 
            columnHeader22.Text = "Predmet ugovora";
            columnHeader22.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader23
            // 
            columnHeader23.Text = "Valuta";
            columnHeader23.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader24
            // 
            columnHeader24.Text = "Rok";
            columnHeader24.TextAlign = HorizontalAlignment.Center;
            // 
            // UgovoriForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(tabControl1);
            Name = "UgovoriForma";
            Text = "UgovoriForma";
            Load += UgovoriForma_Load;
            groupBox1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView ugovori;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListView listView1;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ListView listView2;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ListView listView3;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
    }
}