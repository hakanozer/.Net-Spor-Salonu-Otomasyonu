using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections;

namespace NetFitnessProject
{
    public partial class UyeForm1 : Screen
    {
        public int id;
        public UyeForm1()
        {
            InitializeComponent();
        }
        public ArrayList ls = new ArrayList();
        sporEntities sprEn = new sporEntities();
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTc;
            dataGridView1.DataSource = null;
            dataGetir();
        }
        public void dataGetir()
        {
            IEnumerable<uyeler> liste = sprEn.uyelers;
            foreach (var item in liste)
            {
                uyeler uye = new uyeler();
                uye.adi = item.adi;
                uye.soyadi = item.soyadi;
                uye.tcNo = item.tcNo;
                uye.telefon = item.telefon;
                uye.uyeID = item.uyeID;
                uye.mail = item.mail;
                uye.tarih = item.tarih;
                uye.dogumTarihi = item.dogumTarihi;
                uye.cinsiyet = item.cinsiyet;
                uye.kulAdi = item.kulAdi;
                uye.sifre = item.sifre;
                uye.adres = item.adres;
                uye.resim = item.resim;
                ls.Add(uye);
                
            }
            dataGridView1.DataSource = ls;

            dataGridView1.Columns[0].HeaderCell.Value = "";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[13].Visible = false;

        }
        
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            int sonuc = -1;

            if (txtAd.Text!=null && txtSoyad.Text!=null && txtAdres.Text!=null && txtMail.Text!=null && txtTc.Text!=null && txtTel.Text!=null && (rdbErkek.Checked!=true || rdbKadin.Checked!=true) && pictureBox1.Image!=null)
            {
                try
                {
                    using (var context = new sporEntities())
                    {

                        uyeler uye = new uyeler { adi = txtAd.Text, soyadi = txtSoyad.Text, telefon = txtTel.Text, mail = txtMail.Text, adres = txtAdres.Text, resim = openFileDialog1.FileName, dogumTarihi = dtpDogum.Value, dosya = null, cinsiyet = Convert.ToByte(rdbErkek.Checked ? 0 : 1), tcNo = txtTc.Text, tarih = dtpKayit.Value, uyelikDurumu = true };
                        context.uyelers.Add(uye);
                        sonuc = context.SaveChanges();

                        //context.proUyeEkle(null, null, txtAd.Text, txtSoyad.Text, txtTel.Text, txtMail.Text, txtAdres.Text, openFileDialog1.FileName, null, dtpDogum.Value, Convert.ToByte(rdbErkek.Checked ? 0 : 1), txtTc.Text, dtpKayit.Value,true);

                        //sonuc = context.SaveChanges();

                    }
                    MessageBox.Show("Üye kaydedildi.");

                    txtAd.Text = "";
                    txtAdres.Text = "";
                    txtMail.Text = "";
                    txtSoyad.Text = "";
                    txtTc.Text = "";
                    txtTel.Text = "";
                    dtpDogum.Value = DateTime.Now;
                    dtpKayit.Value = DateTime.Now;
                    rdbErkek.Checked = false;
                    rdbKadin.Checked = false;
                    pictureBox1.Image = null;
                    pictureBox1.Invalidate();
                    this.ActiveControl = txtTc;
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt gerçekleştirilemedi.  " + ex);
                }
                finally
                {
                    dataGetir();
                }
            }
            else
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            
        }

        DataGridViewRow row = null;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@row.Cells["resim"].Value.ToString());
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
                sil((int)row.Cells["uyeID"].Value);
            else
                MessageBox.Show("Silinecek üye seçiniz.");
           
        }
        public int sil(int id)
        {
            int sonuc = -1;
            try
            {
                using (var context = new sporEntities())
                {

                    uyeler uye = context.uyelers.FirstOrDefault(sil => sil.uyeID == id);
                    context.uyelers.Remove(uye);
                    sonuc = context.SaveChanges();
                    MessageBox.Show("Silme işlemi gerçekleşti.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("silme hatası: " + ex);
            }
            finally
            {
                dataGetir();
            }
            return sonuc;
            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                Form2 frm2 = new Form2(id);

                frm2.txtTc.Text = row.Cells["tcNo"].Value.ToString();
                frm2.txtAd.Text = row.Cells["adi"].Value.ToString();
                frm2.txtSoyad.Text = row.Cells["soyadi"].Value.ToString();
                frm2.txtTel.Text = row.Cells["telefon"].Value.ToString();
                frm2.txtMail.Text = row.Cells["mail"].Value.ToString();
                frm2.txtAdres.Text = row.Cells["adres"].Value.ToString();
                frm2.dtpDogum.Value = (DateTime)row.Cells["dogumTarihi"].Value;
                frm2.dtpKayit.Value = (DateTime)row.Cells["tarih"].Value;

                if ((byte)row.Cells["cinsiyet"].Value == 0)
                {
                    frm2.rdbErkek.Checked = true;
                }
                else
                {
                    frm2.rdbKadin.Checked = true;
                }
                frm2.Show();
            }
            else
            {
                MessageBox.Show("Kişi seçiniz.");
            }
                
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Open Image";
            fd.Filter = "bmp files (*.bmp)|*.bmp";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                
            }
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                row = this.dataGridView1.Rows[e.RowIndex];
                id = (int)row.Cells["uyeID"].Value;
                Form2 frm2 = new Form2(id);
            }
            
        }

        private void btnKaldir_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
