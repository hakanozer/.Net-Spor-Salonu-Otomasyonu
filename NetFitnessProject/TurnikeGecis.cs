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

namespace NetFitnessProject
{
    public partial class TurnikeGecis : Screen
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
                        if (deger == false)
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
                                MessageBox.Show("Üyelik Süreniz Dolmuştur.\n Lütfen Yenileyiniz\n Son Giriş Tarihiniz:\n " + uyeBitisTarihi);
                                textBox1.Clear();
                                textBox1.Focus();
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show(" Lütfen ID Giriniz,", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex);
                }
            }

        }





        private void TurnikeGecis_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.Text = null;
            textBox1.Clear();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
