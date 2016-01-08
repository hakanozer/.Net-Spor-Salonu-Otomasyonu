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
    public partial class programsayfasi :Screen
    {
        public programsayfasi()
        {
            InitializeComponent();
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                
            using (var context = new sporEntities())
            {
              
                
                if (!string.IsNullOrEmpty(txtBaslik.Text) && !string.IsNullOrEmpty(txtIcerik.Text)&&!string.IsNullOrEmpty(txtUyeID.Text) &&string.IsNullOrEmpty(txtUyeAdi.Text) &&string.IsNullOrEmpty(txtUyeSoyadi.Text))
                {
                    context.ekleme(Convert.ToInt32(txtUyeID.Text),txtBaslik.Text,txtIcerik.Text,hocaGiris.ID);

                    MessageBox.Show("Kayıt Başarılı");
                    txtBaslik.Clear();
                    txtIcerik.Clear();
                    txtUyeAdi.Clear();
                    txtUyeID.Clear();
                    txtUyeSoyadi.Clear();
                }
                 else
	{
        MessageBox.Show("Üyeyi Seçerek Başlık ve İçeriği Giriniz");

	}
               
            }
               

            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt  Başarısız."+ex);
                txtBaslik.Clear();
                txtIcerik.Clear();
                txtUyeAdi.Clear();
                txtUyeID.Clear();
                txtUyeSoyadi.Clear();
            }

           
               
            }

        private void programsayfasi_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            txtUyeAdi.Visible = false;
            txtUyeSoyadi.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            //sporEntities sp = new sporEntities();
            //IEnumerable<uyeler> uyeListe = sp.uyelers;
            //ArrayList ls = new ArrayList();
            //foreach (var item in uyeListe)
            //{
            //    uyeler uye = new uyeler();
            //    uye.uyeID = item.uyeID;
            //    uye.adi = item.adi;
            //    uye.soyadi = item.soyadi;
            //    uye.telefon = item.telefon;
            //    uye.mail = item.mail;
            //    uye.adres = item.adres;
            //    uye.resim = item.resim;
            //    uye.dogumTarihi = item.dogumTarihi;
            //    uye.cinsiyet = item.cinsiyet;
            //    uye.tcNo = item.tcNo;
            //    uye.tarih = item.tarih;
            //    ls.Add(uye);
            //}
            sporEntities db = new sporEntities();
            try
            {
                using (var ct = new sporEntities())
                {


                    IList<satislar> courseList = ct.hocayaAitUyeGetirme(hocaGiris.ID).ToList<satislar>();

                    ArrayList ls = new ArrayList();
                    foreach (var item in courseList)
                    {
                        satislar uye = new satislar();
                        uye.uyeID = item.uyeID;
                        uye.satisID = item.satisID;
                        uye.paketID = item.paketID;
                        uye.odemeTuru = item.odemeTuru;
                        uye.tarih = item.tarih;
                        uye.baslamaTarih = item.baslamaTarih;
                        uye.bitisTarihi = item.bitisTarihi;
                        uye.tarih = item.tarih;
                        uye.hocaID = item.hocaID;
                        ls.Add(uye);
                    }
                    dataGridView1.DataSource = ls;
                    dataGridView1.Visible = true;
                    lblUyeler.Visible = true;
                    btnUyeler.Visible = false;
                    txtUyeAdi.Visible = false;
                    txtUyeSoyadi.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex);
            }
            //dataGridView1.DataSource = ls;
            //dataGridView1.Visible = true;
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            txtUyeID.Text = "";
            txtUyeAdi.Text = "";
            txtUyeSoyadi.Text = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected!=true)
                {

                    txtUyeID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                   // txtUyeAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    //txtUyeSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                }
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA"+ex);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            hocaGiris frm = new hocaGiris();
            frm.Show();
            this.Hide();
           
        }
           

        }
    }

