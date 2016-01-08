namespace NetFitnessProject
{
    partial class Harita
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lstUyeler = new System.Windows.Forms.ListBox();
            this.txtadres = new System.Windows.Forms.TextBox();
            this.btnAdresGuncelle = new System.Windows.Forms.Button();
            this.btnHaritadaGoster = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(331, 73);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(441, 457);
            this.webBrowser1.TabIndex = 0;
            // 
            // lstUyeler
            // 
            this.lstUyeler.BackColor = System.Drawing.SystemColors.Control;
            this.lstUyeler.ColumnWidth = 50;
            this.lstUyeler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstUyeler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstUyeler.FormattingEnabled = true;
            this.lstUyeler.ItemHeight = 15;
            this.lstUyeler.Location = new System.Drawing.Point(11, 50);
            this.lstUyeler.Name = "lstUyeler";
            this.lstUyeler.Size = new System.Drawing.Size(280, 195);
            this.lstUyeler.TabIndex = 10;
            this.lstUyeler.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstUyeler_DrawItem);
            this.lstUyeler.SelectedIndexChanged += new System.EventHandler(this.lstUyeler_SelectedIndexChanged);
            // 
            // txtadres
            // 
            this.txtadres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtadres.Location = new System.Drawing.Point(6, 17);
            this.txtadres.Multiline = true;
            this.txtadres.Name = "txtadres";
            this.txtadres.Size = new System.Drawing.Size(290, 121);
            this.txtadres.TabIndex = 11;
            // 
            // btnAdresGuncelle
            // 
            this.btnAdresGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdresGuncelle.Location = new System.Drawing.Point(156, 150);
            this.btnAdresGuncelle.Name = "btnAdresGuncelle";
            this.btnAdresGuncelle.Size = new System.Drawing.Size(134, 42);
            this.btnAdresGuncelle.TabIndex = 12;
            this.btnAdresGuncelle.Text = "Adres Güncelle";
            this.btnAdresGuncelle.UseVisualStyleBackColor = true;
            this.btnAdresGuncelle.Click += new System.EventHandler(this.btnAdresGuncelle_Click);
            // 
            // btnHaritadaGoster
            // 
            this.btnHaritadaGoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHaritadaGoster.Location = new System.Drawing.Point(9, 150);
            this.btnHaritadaGoster.Name = "btnHaritadaGoster";
            this.btnHaritadaGoster.Size = new System.Drawing.Size(113, 42);
            this.btnHaritadaGoster.TabIndex = 13;
            this.btnHaritadaGoster.Text = "Haritada Göster";
            this.btnHaritadaGoster.UseVisualStyleBackColor = true;
            this.btnHaritadaGoster.Click += new System.EventHandler(this.btnHaritadaGoster_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtadres);
            this.groupBox1.Controls.Add(this.btnHaritadaGoster);
            this.groupBox1.Controls.Add(this.btnAdresGuncelle);
            this.groupBox1.Location = new System.Drawing.Point(12, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 201);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adres Güncelle";
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.BackColor = System.Drawing.Color.Transparent;
            this.lblBaslik.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBaslik.Location = new System.Drawing.Point(11, 19);
            this.lblBaslik.MinimumSize = new System.Drawing.Size(280, 30);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(280, 30);
            this.lblBaslik.TabIndex = 13;
            this.lblBaslik.Text = "ID          TC NO                AD                  SOYAD";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblBaslik);
            this.groupBox2.Controls.Add(this.lstUyeler);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 250);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Üye Bilgileri";
            // 
            // Harita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Harita";
            this.Text = "Haritalar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.webBrowser1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ListBox lstUyeler;
        private System.Windows.Forms.TextBox txtadres;
        private System.Windows.Forms.Button btnAdresGuncelle;
        private System.Windows.Forms.Button btnHaritadaGoster;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

