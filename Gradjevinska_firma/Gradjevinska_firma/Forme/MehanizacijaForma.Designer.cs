namespace Gradjevinska_firma.Forme
{
    partial class MehanizacijaForma
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
            mehanizacija = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            btObrisiMehanizaciju = new Button();
            btIzmeniOpremu = new Button();
            btDodajMehanizaciju = new Button();
            columnHeader6 = new ColumnHeader();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mehanizacija);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(592, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mehanizacija";
            // 
            // mehanizacija
            // 
            mehanizacija.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader7, columnHeader8, columnHeader9, columnHeader6 });
            mehanizacija.Dock = DockStyle.Fill;
            mehanizacija.FullRowSelect = true;
            mehanizacija.GridLines = true;
            mehanizacija.Location = new Point(3, 23);
            mehanizacija.Name = "mehanizacija";
            mehanizacija.Size = new Size(586, 400);
            mehanizacija.TabIndex = 1;
            mehanizacija.UseCompatibleStateImageBehavior = false;
            mehanizacija.View = View.Details;
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
            columnHeader3.Text = "Tip";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Datum uvoza";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Proizvodjac";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Raspon odrzavanja";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Lokacija";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Status";
            columnHeader9.TextAlign = HorizontalAlignment.Center;
            // 
            // btObrisiMehanizaciju
            // 
            btObrisiMehanizaciju.Location = new Point(632, 193);
            btObrisiMehanizaciju.Name = "btObrisiMehanizaciju";
            btObrisiMehanizaciju.Size = new Size(139, 72);
            btObrisiMehanizaciju.TabIndex = 16;
            btObrisiMehanizaciju.Text = "Obrisi mehanizaciju";
            btObrisiMehanizaciju.UseVisualStyleBackColor = true;
            btObrisiMehanizaciju.Click += btObrisiMehanizaciju_Click;
            // 
            // btIzmeniOpremu
            // 
            btIzmeniOpremu.Location = new Point(632, 113);
            btIzmeniOpremu.Name = "btIzmeniOpremu";
            btIzmeniOpremu.Size = new Size(139, 61);
            btIzmeniOpremu.TabIndex = 15;
            btIzmeniOpremu.Text = "Izmeni mehanizaciju";
            btIzmeniOpremu.UseVisualStyleBackColor = true;
            btIzmeniOpremu.Click += btIzmeniOpremu_Click;
            // 
            // btDodajMehanizaciju
            // 
            btDodajMehanizaciju.Location = new Point(632, 35);
            btDodajMehanizaciju.Name = "btDodajMehanizaciju";
            btDodajMehanizaciju.Size = new Size(139, 57);
            btDodajMehanizaciju.TabIndex = 14;
            btDodajMehanizaciju.Text = "Dodaj mehanizaciju";
            btDodajMehanizaciju.UseVisualStyleBackColor = true;
            btDodajMehanizaciju.Click += btDodajOpremu_Click;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Tip mehanizacije";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            // 
            // MehanizacijaForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btObrisiMehanizaciju);
            Controls.Add(btIzmeniOpremu);
            Controls.Add(btDodajMehanizaciju);
            Controls.Add(groupBox1);
            Name = "MehanizacijaForma";
            Text = "MehanizacijaForma";
            Load += MehanizacijaForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btObrisiMehanizaciju;
        private Button btIzmeniOpremu;
        private Button btDodajMehanizaciju;
        private ListView mehanizacija;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader6;
    }
}