namespace NetFitnessProject
{
    partial class programsayfasi
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
            this.txtBaslik = new System.Windows.Forms.TextBox();
            this.txtIcerik = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblUyeler = new System.Windows.Forms.Label();
            this.txtUyeID = new System.Windows.Forms.TextBox();
            this.txtUyeAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUyeSoyadi = new System.Windows.Forms.TextBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnUyeler = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBaslik
            // 
            this.txtBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaslik.Location = new System.Drawing.Point(81, 101);
            this.txtBaslik.Name = "txtBaslik";
            this.txtBaslik.Size = new System.Drawing.Size(97, 22);
            this.txtBaslik.TabIndex = 0;
            // 
            // txtIcerik
            // 
            this.txtIcerik.Location = new System.Drawing.Point(67, 178);
            this.txtIcerik.Multiline = true;
            this.txtIcerik.Name = "txtIcerik";
            this.txtIcerik.Size = new System.Drawing.Size(219, 322);
            this.txtIcerik.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Başlık";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(64, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "İÇERİK";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(292, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(435, 324);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // lblUyeler
            // 
            this.lblUyeler.AutoSize = true;
            this.lblUyeler.BackColor = System.Drawing.Color.Transparent;
            this.lblUyeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUyeler.Location = new System.Drawing.Point(301, 157);
            this.lblUyeler.Name = "lblUyeler";
            this.lblUyeler.Size = new System.Drawing.Size(62, 16);
            this.lblUyeler.TabIndex = 5;
            this.lblUyeler.Text = "ÜYELER";
            this.lblUyeler.Visible = false;
            // 
            // txtUyeID
            // 
            this.txtUyeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUyeID.Location = new System.Drawing.Point(81, 72);
            this.txtUyeID.Name = "txtUyeID";
            this.txtUyeID.Size = new System.Drawing.Size(97, 22);
            this.txtUyeID.TabIndex = 6;
            // 
            // txtUyeAdi
            // 
            this.txtUyeAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUyeAdi.Location = new System.Drawing.Point(292, 74);
            this.txtUyeAdi.Name = "txtUyeAdi";
            this.txtUyeAdi.Size = new System.Drawing.Size(129, 22);
            this.txtUyeAdi.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "ÜyeID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(204, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Üye Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(204, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Üye Soyadı";
            // 
            // txtUyeSoyadi
            // 
            this.txtUyeSoyadi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUyeSoyadi.Location = new System.Drawing.Point(292, 102);
            this.txtUyeSoyadi.Name = "txtUyeSoyadi";
            this.txtUyeSoyadi.Size = new System.Drawing.Size(129, 22);
            this.txtUyeSoyadi.TabIndex = 6;
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCikis.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCikis.Location = new System.Drawing.Point(618, 100);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(109, 30);
            this.btnCikis.TabIndex = 7;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnUyeler
            // 
            this.btnUyeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUyeler.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUyeler.Location = new System.Drawing.Point(177, 510);
            this.btnUyeler.Name = "btnUyeler";
            this.btnUyeler.Size = new System.Drawing.Size(109, 40);
            this.btnUyeler.TabIndex = 3;
            this.btnUyeler.Text = "  ÜYELER";
            this.btnUyeler.UseVisualStyleBackColor = true;
            this.btnUyeler.Click += new System.EventHandler(this.btnUyeler_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnKaydet.Location = new System.Drawing.Point(60, 510);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(111, 40);
            this.btnKaydet.TabIndex = 2;
            this.btnKaydet.Text = "    KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // programsayfasi
            // 
            this.AcceptButton = this.btnKaydet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.txtUyeSoyadi);
            this.Controls.Add(this.txtUyeAdi);
            this.Controls.Add(this.txtUyeID);
            this.Controls.Add(this.lblUyeler);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUyeler);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIcerik);
            this.Controls.Add(this.txtBaslik);
            this.Name = "programsayfasi";
            this.Text = "programsayfasi";
            this.Load += new System.EventHandler(this.programsayfasi_Load);
            this.Controls.SetChildIndex(this.txtBaslik, 0);
            this.Controls.SetChildIndex(this.txtIcerik, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnKaydet, 0);
            this.Controls.SetChildIndex(this.btnUyeler, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.lblUyeler, 0);
            this.Controls.SetChildIndex(this.txtUyeID, 0);
            this.Controls.SetChildIndex(this.txtUyeAdi, 0);
            this.Controls.SetChildIndex(this.txtUyeSoyadi, 0);
            this.Controls.SetChildIndex(this.btnCikis, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBaslik;
        private System.Windows.Forms.TextBox txtIcerik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnUyeler;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblUyeler;
        private System.Windows.Forms.TextBox txtUyeID;
        private System.Windows.Forms.TextBox txtUyeAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUyeSoyadi;
        private System.Windows.Forms.Button btnCikis;
    }
}