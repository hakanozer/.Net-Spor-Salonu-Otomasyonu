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
using System.Security.Cryptography;

namespace KullaniciGirisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        sporEntities1 spr = new sporEntities1();
        int brnsID = -1;

        ArrayList brid = new ArrayList();
        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<branslar> liste = spr.branslar;

            foreach (var item in liste)
            {
                branslar br = new branslar();
                br.bransAdi = item.bransAdi;
                brnsID = item.bransID;
                brid.Add(item.bransID);
                comboBox1.Items.Add(br.bransAdi);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = spr.hocaGetirPro(comboBox1.SelectedItem.ToString());
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            pictureBox1.ImageLocation = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text.Trim()) && !String.IsNullOrEmpty(textBox2.Text.Trim()) && !String.IsNullOrEmpty(textBox3.Text.Trim()) && !String.IsNullOrEmpty(textBox4.Text.Trim()) && !String.IsNullOrEmpty(textBox5.Text.Trim()) && !String.IsNullOrEmpty(textBox6.Text.Trim()) && !String.IsNullOrEmpty(textBox7.Text.Trim())
                )
            {
                try
                {
                    var veri1 = spr.hocalar.Where(f => f.mail == textBox6.Text.Trim()).FirstOrDefault();                  
                    if (veri1!=null)
                    {
                        MessageBox.Show("Bu mail mevcut");
                    }
                    else
                    {
                        hocalar hc = new hocalar();
                        hc.adminID = 1;
                        hc.bransID = (int)brid[comboBox1.SelectedIndex];
                        hc.adi = textBox1.Text;
                        hc.soyadi = textBox2.Text;
                        hc.telefon = textBox3.Text;
                        hc.cep = textBox4.Text;
                        hc.adres = textBox5.Text;
                        hc.mail = textBox6.Text;
                        hc.sifre = MD5Sifrele(textBox7.Text);
                        hc.tarih = DateTime.Now;
                        hc.resim = "Resimler\\" + resimYolu;
                        spr.hocalar.Add(hc);
                        spr.SaveChanges();
                        comboBox1_SelectedIndexChanged(null, null);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        pictureBox1.ImageLocation = "";
                    }                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Branşı seçiniz.");
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları Doldurunuz ve branşı seçiniz.");
            }

        }

        int did = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            did = Convert.ToInt32(id);
            try
            {
                spr.hocalar.Remove(spr.hocalar.Find(did));
                spr.SaveChanges();
                comboBox1_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex);
            }
        }

        int did2 = -1;
        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text.Trim()) && !String.IsNullOrEmpty(textBox2.Text.Trim()) && !String.IsNullOrEmpty(textBox3.Text.Trim()) && !String.IsNullOrEmpty(textBox4.Text.Trim()) && !String.IsNullOrEmpty(textBox5.Text.Trim()) && !String.IsNullOrEmpty(textBox6.Text.Trim()))
            {
                try
                {
                    String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    did2 = Convert.ToInt32(id);

                    hocalar hc = spr.hocalar.FirstOrDefault(sil => sil.hocaID == did2);
                    if (hc != null)
                    {
                        hc.adminID = 1;
                        hc.bransID = (int)brid[comboBox1.SelectedIndex];
                        hc.adi = textBox1.Text;
                        hc.soyadi = textBox2.Text;
                        hc.telefon = textBox3.Text;
                        hc.cep = textBox4.Text;
                        hc.adres = textBox5.Text;
                        hc.mail = textBox6.Text;
                        hc.tarih = DateTime.Now;
                        if (!String.IsNullOrEmpty(textBox7.Text.Trim()))
                        {
                            hc.sifre = MD5Sifrele(textBox7.Text);
                        }                        
                        hc.resim = "Resimler\\" + resimYolu;
                        spr.SaveChanges();
                        comboBox1_SelectedIndexChanged(null, null);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        pictureBox1.ImageLocation = "";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Branşı seçiniz.");
                }
            }
            else
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
        }
        
        string resimYolu;
        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.

            openFileDialog1.Title = "Resim Ekranı";//diğaloğumuzun başlığını belirliyoruz.

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                resimYolu = openFileDialog1.SafeFileName;
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        public string MD5Sifrele(string metin)
        {
            // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

            //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
            StringBuilder sb = new StringBuilder();


            //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürelim.
            return sb.ToString();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                pictureBox1.Load("Resimler\\default.jpg");
                textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                String resim = spr.resimPro(id).First().ToString();
                pictureBox1.Load(resim);

                //string asd = Convert.ToString(spr.Database.ExecuteSqlCommand("select resim from hocalar where hocaID ='" + id + "'"));
                //pictureBox1.Load(asd);

                //pictureBox1.Load(spr.resimPro(id).ToString());
            }
            catch (Exception)
            {
            }
        }
    }
}

