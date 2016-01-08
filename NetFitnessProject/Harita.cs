using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetFitnessProject
{
    public partial class Harita : Screen
    {
        List<uyeler> uyeListesi = null;
        int seciliIndex = 0;
        string dbAdres = null;
        StringBuilder sbAdres = null;
        public Harita()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
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
                    MessageBox.Show("Veritabanında Hiçbir Üye Kaydı Bulunmamaktadır!");
                }
            }
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
        private void lstUyeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uyeListesi != null)
            {
                if (!string.IsNullOrEmpty(uyeListesi[lstUyeler.SelectedIndex].adres))
                    HaritaBul(uyeListesi[lstUyeler.SelectedIndex].adres);
                else
                    txtadres.Text = ("Adres Bilgileri Girilmemiş!");
            }
        }
        private void HaritaBul(string deger)
        {
            dbAdres = deger;
            sbAdres = new StringBuilder();
            sbAdres.Append("http://maps.google.com/maps?q=");
            sbAdres.Append(dbAdres + "," + "+");
            try
            {
                webBrowser1.Navigate(sbAdres.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                txtadres.Text = dbAdres;
            }
        }
        private void btnHaritadaGoster_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtadres.Text.Trim()))
                HaritaBul(txtadres.Text);
        }
        private void btnAdresGuncelle_Click(object sender, EventArgs e)
        {
            if (uyeListesi != null)
            {
                if (!string.IsNullOrEmpty(txtadres.Text.Trim()))
                {
                    DialogResult dialogResult = MessageBox.Show("Güncellemek İstediğinizden Emin Misiniz?", "Üye Adresi Güncelleme", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        seciliIndex = lstUyeler.SelectedIndex;
                        int id = uyeListesi[seciliIndex].uyeID;
                        using (sporEntities entity = new sporEntities())
                        {
                            uyeler uye = (from c in entity.uyelers
                                          where c.uyeID == id
                                          select c).FirstOrDefault();
                            if (uye != null)
                            {
                                uye.adres = txtadres.Text;
                                entity.SaveChanges();
                                MessageBox.Show(string.Format("{0} {1} İsimli Üyenin Adresi Başarıyla Güncellenmiştir!", uyeListesi[seciliIndex].adi, uyeListesi[seciliIndex].soyadi), "Üye Adresi Güncelleme");
                                Listele();
                            }
                            else
                                MessageBox.Show("Güncelleme Yapılacak Üye Bulunamadı!");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Güncellenecek Bir Üye Yok!");
        }
    }
}
