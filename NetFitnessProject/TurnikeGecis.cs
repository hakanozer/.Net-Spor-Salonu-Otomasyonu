using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SporSalonuOtomasyonu
{
    public partial class TurnikeGecis : Form
    {
        DateTime uyeBitisTarihi;
        bool deger = false;
        public TurnikeGecis()
        {
            InitializeComponent();
        }
        sporEntities se = new sporEntities();
        public int ID = 0;

        private void btnTurnike_Click(object sender, EventArgs e)
        {
          
       
        }
       

        
        

        private void TurnikeGecis_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            deger = false;
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    string path = "";
                    lblAdSoyad.Text = "";
                    using (var ct = new sporEntities())
                    {
                        int sayi = Convert.ToInt32(textBox1.Text);

                        foreach (proUyeIDAra_Result item in ct.proUyeIDAra(sayi))
                        {
                            deger = true;
                            uyeBitisTarihi = (DateTime)item.bitisTarihi;
                            path = item.resim;
                            lblAdSoyad.Text = item.adi.ToUpper().Trim() + " " + item.soyadi.ToUpper().Trim();

                        }
                    }
                    try
                    {
                        pictureBox1.Load(path);
                    }
                    catch (Exception)
                    {
                        pictureBox1.Load("resimler\\photo.jpg");
                    }

                    int sonuc = DateTime.Compare(uyeBitisTarihi, DateTime.Now);
                    if (sonuc == 1 && !string.IsNullOrEmpty(lblAdSoyad.Text.Trim()))
                    {
                        TimeSpan kalanGun = uyeBitisTarihi.Subtract(DateTime.Now);
                        MessageBox.Show("Üye Giriş Başarılı.  " + lblAdSoyad.Text.ToUpper().Trim() + ": " + kalanGun.Days + " Gününüz Kaldı.");
                    }
                    if (deger==false)
                    {
                      if (!deger)
                    {
                        MessageBox.Show("Üye Bulunamadı");
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    }
                    else
                    {
if (sonuc == -1)
                    {
                        MessageBox.Show("Üyelik Süreniz Dolmuştur. Lütfen Yenileyiniz! Son Giriş Tarihiniz: " + uyeBitisTarihi);
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    }
                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex);
            }
        }
    }
}
