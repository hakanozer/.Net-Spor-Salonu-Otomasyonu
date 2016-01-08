using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;

namespace NetFitnessProject
{
    public partial class ResimCek : Screen
    {
        private FilterInfoCollection webcam = null;             //webcam isminde tanımladığımız değişken bilgisayara kaç kamera bağlıysa onları tutan bir dizi. 
        private VideoCaptureDevice cam;                         //cam ise bizim kullanacağımız aygıt.
        string varsayilanPath = "resimler\\photo.jpg";
        bool deger = true;
        bool guncellensinmi = false;
        bool uyeFotoSilinsinmi = false;
        bool varsayilanPathmi = false;
        int seciliIndex = 0;
        List<uyeler> uyeListesi = null;
        public ResimCek()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);//webcam dizisine mevcut kameraları dolduruyoruz.
            if (webcam != null)
            {
                foreach (FilterInfo videocapturedevice in webcam)
                    comboBox1.Items.Add(videocapturedevice.Name);//kameraları combobox a dolduruyoruz.

                comboBox1.SelectedIndex = 0;
                btnBaslat_Click(null, null);
            }
            else
                MessageBox.Show("Kamera Aygıtı Bulunamadı!");
            Listele();
            lstUyeler_SelectedIndexChanged(null, null);
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (deger && webcam != null)
            {
                try
                {
                    cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString); //başlaya basıldığıdnda yukarda tanımladığımız cam değişkenine                                                                                           cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);                      //comboboxta seçilmş olan kamerayı atıyoruz.
                    cam.Start();                                    //kamerayı başlatıyoruz.
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("resim çekme hatası"+ex);
                }

                deger = false;  
            }
        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bit = (Bitmap)eventArgs.Frame.Clone();//kısaca bu eventta kameradan alınan görüntüyü picturebox a atıyoruz.
                pictureBox1.Image = bit;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kameradan görüntü okuma hatası: " + ex);
            }
        }
        private void btnDurdur_Click(object sender, EventArgs e)
        {
            if (!deger && webcam != null)
            {
                cam.Stop();
                deger = true;
            }
        }
        private void btnCek_Click(object sender, EventArgs e)
        {
            if (webcam != null)
            {
                guncellensinmi = true;
                pictureBox2.Image = pictureBox1.Image;//foto çek denildiği zaman picturebox1 taki o an ki görüntüyü picturebox2 ye atıyoruz.
            }
        }
        private void btnTmizleKamera_Click(object sender, EventArgs e)
        {
            guncellensinmi = false;
            pictureBox2.Load(varsayilanPath);
        }
        private void btnSilUye_Click(object sender, EventArgs e)
        {
            if (!varsayilanPathmi && uyeListesi != null)
            {
                DialogResult dialogResult = MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Üye Fotoğrafı Silme ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    uyeFotoSilinsinmi = true;
                    seciliIndex = lstUyeler.SelectedIndex;
                    if (ResimGuncelle(Convert.ToInt32(uyeListesi[lstUyeler.SelectedIndex].uyeID.ToString())))
                        MessageBox.Show("Silme İşlemi Başarılı!");
                    else
                        MessageBox.Show("Silme İşlemi Başarısız!");
                }
            }
            else
                MessageBox.Show("Silinecek Bir Fotoğraf Yok!");
        }
        private void btnGuncelleFoto_Click(object sender, EventArgs e)
        {
            if (uyeListesi != null)
            {
                if (guncellensinmi)
                {
                    DialogResult dialogResult = MessageBox.Show("Güncellemek İstediğinizden Emin Misiniz?", "Üye Fotoğrafı Güncelleme", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        seciliIndex = lstUyeler.SelectedIndex;
                        if (ResimGuncelle(Convert.ToInt32(uyeListesi[lstUyeler.SelectedIndex].uyeID.ToString())))
                            MessageBox.Show("Üye Fotoğrafı Güncellendi!");
                        else
                            MessageBox.Show("Güncelleme İşlemi Başarısız!");
                    }
                }
                else
                    MessageBox.Show("Lütfen Bir Fotoğraf Çekiniz!");
            }

            else
                MessageBox.Show("Güncellenecek Bir Fotoğraf Yok!");
        }
        private void lstUyeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uyeListesi != null)
            {
                txtResimYolu.Text = uyeListesi[lstUyeler.SelectedIndex].resim.ToString();
                if (varsayilanPath == txtResimYolu.Text || string.IsNullOrEmpty(txtResimYolu.Text))
                {
                    varsayilanPathmi = true;
                    pictureBox3.Load(varsayilanPath);
                }
                else
                {
                    try
                    {
                        varsayilanPathmi = false;
                        pictureBox3.Load(uyeListesi[lstUyeler.SelectedIndex].resim.ToString());
                    }
                    catch (Exception ex)
                    {
                        pictureBox3.Load(varsayilanPath);
                        varsayilanPathmi = true;
                        if (ex is FileNotFoundException)
                            MessageBox.Show(txtResimYolu.Text + " İsimli Dosya Bulunamıyor. Silinmiş veya Başka Bir Yere Taşınmış Olabilir! Lütfen Yeni Bir Fotoğraj Çekiniz!");
                    }
                }
            }
        }
        private void Listele()
        {
            using (sporEntities entity = new sporEntities())
            {
                uyeListesi = entity.uyelers.ToList();
                if (uyeListesi != null)
                {
                    lstUyeler.DataSource = uyeListesi;
                    lstUyeler.SelectedIndex = seciliIndex;
                }
                else
                {
                    varsayilanPathmi = true;
                    MessageBox.Show("Veritabanında Hiçbir Üye Kaydı Bulunmamaktadır!");
                }
            }
        }
        private bool ResimGuncelle(int id)
        {
            bool deger = false;
            using (sporEntities entity = new sporEntities())
            {
                uyeler uye = (from nesne in entity.uyelers
                              where nesne.uyeID == id
                              select nesne).FirstOrDefault();
                if (uye != null)
                {
                    if (ResimSil(uye.resim))
                    {
                        if (uyeFotoSilinsinmi)
                        {
                            uye.resim = varsayilanPath;
                            uyeFotoSilinsinmi = false;
                        }
                        else
                        {
                            pictureBox2.Image.Save("resimler\\" + id + ".jpg"); // klasore kayıt yapılıyor.
                            uye.resim = "resimler\\" + id + ".jpg"; // ardından veritabanı güncelleniyor.
                        }
                        entity.SaveChanges();
                        deger = true;
                    }
                }
                else
                    MessageBox.Show(string.Format("{0} ID numaralı üye bulunamadı!", id), "HATA");
            }
            Listele();
            return deger;
        }
        private bool ResimSil(string path)
        {
            bool deger = false;
            try
            {
                if (path != varsayilanPath && !string.IsNullOrEmpty(path))
                {
                    pictureBox3.Load(varsayilanPath);
                    File.Delete(path);
                    deger = true;
                }
                else
                    deger = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return deger;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnDurdur_Click(null, null);
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void lstUyeler_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (uyeListesi != null)
            {
                e.DrawBackground();
                e.Graphics.DrawString(uyeListesi[e.Index].uyeID.ToString(), lstUyeler.Font, Brushes.Black, new PointF(e.Bounds.Left, e.Bounds.Top));
                e.Graphics.DrawString(uyeListesi[e.Index].tcNo, lstUyeler.Font, Brushes.Black, new PointF(e.Bounds.Left + (40), e.Bounds.Top));
                e.Graphics.DrawString(uyeListesi[e.Index].adi.ToUpper().Trim(), lstUyeler.Font, Brushes.Black, new PointF(e.Bounds.Left + (135), e.Bounds.Top));
                e.Graphics.DrawString(uyeListesi[e.Index].soyadi.ToUpper().Trim(), lstUyeler.Font, Brushes.Black, new PointF(e.Bounds.Left + (220), e.Bounds.Top));
            }
        }
    }
}
