namespace NetFitnessProject
{
    partial class demirbaslarKontrol
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDemirbasBul = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtBakimAraligi = new System.Windows.Forms.TextBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.dtpAlinmaTarihi = new System.Windows.Forms.DateTimePicker();
            this.txtFiyati = new System.Windows.Forms.TextBox();
            this.txtMarkasi = new System.Windows.Forms.TextBox();
            this.txtSeriNo = new System.Windows.Forms.TextBox();
            this.txtAdi = new System.Windows.Forms.TextBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.lblBakimAraligi = new System.Windows.Forms.Label();
            this.lblalinmaTarih = new System.Windows.Forms.Label();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.lblMarkası = new System.Windows.Forms.Label();
            this.lblSeriNo = new System.Windows.Forms.Label();
            this.lblAdi = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnDemirbasBul);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.btnKaydet);
            this.groupBox1.Controls.Add(this.txtBakimAraligi);
            this.groupBox1.Controls.Add(this.dtpTarih);
            this.groupBox1.Controls.Add(this.dtpAlinmaTarihi);
            this.groupBox1.Controls.Add(this.txtFiyati);
            this.groupBox1.Controls.Add(this.txtMarkasi);
            this.groupBox1.Controls.Add(this.txtSeriNo);
            this.groupBox1.Controls.Add(this.txtAdi);
            this.groupBox1.Controls.Add(this.lblTarih);
            this.groupBox1.Controls.Add(this.lblBakimAraligi);
            this.groupBox1.Controls.Add(this.lblalinmaTarih);
            this.groupBox1.Controls.Add(this.lblFiyat);
            this.groupBox1.Controls.Add(this.lblMarkası);
            this.groupBox1.Controls.Add(this.lblSeriNo);
            this.groupBox1.Controls.Add(this.lblAdi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(65, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 490);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Demirbaş Kontrolü";
            // 
            // btnDemirbasBul
            // 
            this.btnDemirbasBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDemirbasBul.Location = new System.Drawing.Point(484, 84);
            this.btnDemirbasBul.Name = "btnDemirbasBul";
            this.btnDemirbasBul.Size = new System.Drawing.Size(93, 30);
            this.btnDemirbasBul.TabIndex = 36;
            this.btnDemirbasBul.Text = "YENİ EKLE";
            this.btnDemirbasBul.UseVisualStyleBackColor = true;
            this.btnDemirbasBul.Click += new System.EventHandler(this.btnDemirbasBul_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(645, 230);
            this.dataGridView1.TabIndex = 35;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(484, 168);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(93, 30);
            this.btnGuncelle.TabIndex = 33;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Location = new System.Drawing.Point(484, 210);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(93, 30);
            this.btnSil.TabIndex = 32;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(484, 126);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(93, 30);
            this.btnKaydet.TabIndex = 31;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtBakimAraligi
            // 
            this.txtBakimAraligi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBakimAraligi.Location = new System.Drawing.Point(145, 186);
            this.txtBakimAraligi.Name = "txtBakimAraligi";
            this.txtBakimAraligi.Size = new System.Drawing.Size(190, 22);
            this.txtBakimAraligi.TabIndex = 30;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTarih.Location = new System.Drawing.Point(145, 218);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(190, 22);
            this.dtpTarih.TabIndex = 29;
            // 
            // dtpAlinmaTarihi
            // 
            this.dtpAlinmaTarihi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpAlinmaTarihi.Location = new System.Drawing.Point(145, 154);
            this.dtpAlinmaTarihi.Name = "dtpAlinmaTarihi";
            this.dtpAlinmaTarihi.Size = new System.Drawing.Size(190, 22);
            this.dtpAlinmaTarihi.TabIndex = 28;
            // 
            // txtFiyati
            // 
            this.txtFiyati.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFiyati.Location = new System.Drawing.Point(145, 122);
            this.txtFiyati.Name = "txtFiyati";
            this.txtFiyati.Size = new System.Drawing.Size(190, 22);
            this.txtFiyati.TabIndex = 27;
            // 
            // txtMarkasi
            // 
            this.txtMarkasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMarkasi.Location = new System.Drawing.Point(145, 90);
            this.txtMarkasi.Name = "txtMarkasi";
            this.txtMarkasi.Size = new System.Drawing.Size(190, 22);
            this.txtMarkasi.TabIndex = 26;
            // 
            // txtSeriNo
            // 
            this.txtSeriNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSeriNo.Location = new System.Drawing.Point(145, 58);
            this.txtSeriNo.Name = "txtSeriNo";
            this.txtSeriNo.Size = new System.Drawing.Size(190, 22);
            this.txtSeriNo.TabIndex = 25;
            // 
            // txtAdi
            // 
            this.txtAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAdi.Location = new System.Drawing.Point(145, 26);
            this.txtAdi.Name = "txtAdi";
            this.txtAdi.Size = new System.Drawing.Size(190, 22);
            this.txtAdi.TabIndex = 24;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.Location = new System.Drawing.Point(49, 219);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(39, 16);
            this.lblTarih.TabIndex = 23;
            this.lblTarih.Text = "Tarih";
            // 
            // lblBakimAraligi
            // 
            this.lblBakimAraligi.AutoSize = true;
            this.lblBakimAraligi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBakimAraligi.Location = new System.Drawing.Point(49, 187);
            this.lblBakimAraligi.Name = "lblBakimAraligi";
            this.lblBakimAraligi.Size = new System.Drawing.Size(87, 16);
            this.lblBakimAraligi.TabIndex = 22;
            this.lblBakimAraligi.Text = "Bakım Aralığı";
            // 
            // lblalinmaTarih
            // 
            this.lblalinmaTarih.AutoSize = true;
            this.lblalinmaTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblalinmaTarih.Location = new System.Drawing.Point(49, 155);
            this.lblalinmaTarih.Name = "lblalinmaTarih";
            this.lblalinmaTarih.Size = new System.Drawing.Size(86, 16);
            this.lblalinmaTarih.TabIndex = 21;
            this.lblalinmaTarih.Text = "Alınma Tarihi";
            // 
            // lblFiyat
            // 
            this.lblFiyat.AutoSize = true;
            this.lblFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiyat.Location = new System.Drawing.Point(49, 123);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Size = new System.Drawing.Size(40, 16);
            this.lblFiyat.TabIndex = 20;
            this.lblFiyat.Text = "Fiyatı";
            // 
            // lblMarkası
            // 
            this.lblMarkası.AutoSize = true;
            this.lblMarkası.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMarkası.Location = new System.Drawing.Point(49, 91);
            this.lblMarkası.Name = "lblMarkası";
            this.lblMarkası.Size = new System.Drawing.Size(56, 16);
            this.lblMarkası.TabIndex = 19;
            this.lblMarkası.Text = "Markası";
            // 
            // lblSeriNo
            // 
            this.lblSeriNo.AutoSize = true;
            this.lblSeriNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSeriNo.Location = new System.Drawing.Point(49, 59);
            this.lblSeriNo.Name = "lblSeriNo";
            this.lblSeriNo.Size = new System.Drawing.Size(53, 16);
            this.lblSeriNo.TabIndex = 18;
            this.lblSeriNo.Text = "Seri No";
            // 
            // lblAdi
            // 
            this.lblAdi.AutoSize = true;
            this.lblAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdi.Location = new System.Drawing.Point(49, 27);
            this.lblAdi.Name = "lblAdi";
            this.lblAdi.Size = new System.Drawing.Size(28, 16);
            this.lblAdi.TabIndex = 17;
            this.lblAdi.Text = "Adı";
            // 
            // demirbaslarKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox1);
            this.Name = "demirbaslarKontrol";
            this.Text = "Demirbaş Kontrolü";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtBakimAraligi;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.DateTimePicker dtpAlinmaTarihi;
        private System.Windows.Forms.TextBox txtFiyati;
        private System.Windows.Forms.TextBox txtMarkasi;
        private System.Windows.Forms.TextBox txtSeriNo;
        private System.Windows.Forms.TextBox txtAdi;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label lblBakimAraligi;
        private System.Windows.Forms.Label lblalinmaTarih;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label lblMarkası;
        private System.Windows.Forms.Label lblSeriNo;
        private System.Windows.Forms.Label lblAdi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDemirbasBul;

    }
}

