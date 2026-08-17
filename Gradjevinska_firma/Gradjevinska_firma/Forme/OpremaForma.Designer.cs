namespace Gradjevinska_firma.Forme
{
    partial class OpremaForma
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
            oprema = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            btObrisiOpremu = new Button();
            btIzmeniOpremu = new Button();
            btDodajOpremu = new Button();
            btNabavka = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(oprema);
            groupBox1.Location = new Point(0, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(616, 448);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Oprema";
            // 
            // oprema
            // 
            oprema.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9 });
            oprema.Dock = DockStyle.Fill;
            oprema.FullRowSelect = true;
            oprema.GridLines = true;
            oprema.Location = new Point(3, 23);
            oprema.Name = "oprema";
            oprema.Size = new Size(610, 422);
            oprema.TabIndex = 0;
            oprema.UseCompatibleStateImageBehavior = false;
            oprema.View = View.Details;
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
            // columnHeader6
            // 
            columnHeader6.Text = "Datum nabavke";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
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
            // btObrisiOpremu
            // 
            btObrisiOpremu.Location = new Point(639, 205);
            btObrisiOpremu.Name = "btObrisiOpremu";
            btObrisiOpremu.Size = new Size(139, 72);
            btObrisiOpremu.TabIndex = 12;
            btObrisiOpremu.Text = "Obrisi opremu";
            btObrisiOpremu.UseVisualStyleBackColor = true;
            // 
            // btIzmeniOpremu
            // 
            btIzmeniOpremu.Location = new Point(639, 125);
            btIzmeniOpremu.Name = "btIzmeniOpremu";
            btIzmeniOpremu.Size = new Size(139, 61);
            btIzmeniOpremu.TabIndex = 11;
            btIzmeniOpremu.Text = "Izmeni opremu";
            btIzmeniOpremu.UseVisualStyleBackColor = true;
            btIzmeniOpremu.Click += btIzmeniOpremu_Click;
            // 
            // btDodajOpremu
            // 
            btDodajOpremu.Location = new Point(639, 47);
            btDodajOpremu.Name = "btDodajOpremu";
            btDodajOpremu.Size = new Size(139, 57);
            btDodajOpremu.TabIndex = 10;
            btDodajOpremu.Text = "Dodaj opremu";
            btDodajOpremu.UseVisualStyleBackColor = true;
            btDodajOpremu.Click += btDodajOpremu_Click;
            // 
            // btNabavka
            // 
            btNabavka.Location = new Point(639, 302);
            btNabavka.Name = "btNabavka";
            btNabavka.Size = new Size(139, 72);
            btNabavka.TabIndex = 13;
            btNabavka.Text = "Nabavke opreme";
            btNabavka.UseVisualStyleBackColor = true;
            btNabavka.Click += btNabavka_Click;
            // 
            // OpremaForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btNabavka);
            Controls.Add(btObrisiOpremu);
            Controls.Add(groupBox1);
            Controls.Add(btIzmeniOpremu);
            Controls.Add(btDodajOpremu);
            Name = "OpremaForma";
            Text = "OpremaForma";
            Load += OpremaForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btObrisiOpremu;
        private Button btIzmeniOpremu;
        private Button btDodajOpremu;
        private Button btNabavka;
        private ListView oprema;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
    }
}