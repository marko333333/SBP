namespace Gradjevinska_firma.Forme
{
    partial class InfrastrukturaForma
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
            projekti = new ListView();
            ID = new ColumnHeader();
            Naziv = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(projekti);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 284);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Projekti";
            // 
            // projekti
            // 
            projekti.Columns.AddRange(new ColumnHeader[] { ID, Naziv, columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            projekti.FullRowSelect = true;
            projekti.GridLines = true;
            projekti.Location = new Point(6, 22);
            projekti.Name = "projekti";
            projekti.Size = new Size(741, 245);
            projekti.TabIndex = 1;
            projekti.UseCompatibleStateImageBehavior = false;
            projekti.View = View.Details;
            // 
            // ID
            // 
            ID.Text = "ID";
            ID.Width = 30;
            // 
            // Naziv
            // 
            Naziv.Text = "Naziv";
            Naziv.Width = 100;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Opis";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Lokacija";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Datum_pocetka";
            columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Budzet";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Status";
            columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Planirani_zavrsetak";
            columnHeader6.Width = 111;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Stvarni_zavrsetak";
            columnHeader7.Width = 111;
            // 
            // button4
            // 
            button4.Location = new Point(830, 175);
            button4.Name = "button4";
            button4.Size = new Size(126, 39);
            button4.TabIndex = 9;
            button4.Text = "Detalji";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(830, 130);
            button3.Name = "button3";
            button3.Size = new Size(126, 39);
            button3.TabIndex = 8;
            button3.Text = "Obrisi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(830, 85);
            button2.Name = "button2";
            button2.Size = new Size(126, 39);
            button2.TabIndex = 7;
            button2.Text = "Izmeni";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(830, 40);
            button1.Name = "button1";
            button1.Size = new Size(126, 39);
            button1.TabIndex = 6;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // InfrastrukturaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 340);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Name = "InfrastrukturaForma";
            Text = "InfrastrukturaForma";
            Load += InfrastrukturaForma_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListView projekti;
        private ColumnHeader ID;
        private ColumnHeader Naziv;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}