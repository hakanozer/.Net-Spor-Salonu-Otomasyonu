using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace NetFitnessProject
{
    public partial class demirbaslarKontrol : Screen
    {
        sporEntities sp = new sporEntities();

        public demirbaslarKontrol()
        {
            InitializeComponent();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seçilen)
            {
                if (String.IsNullOrEmpty(txtAdi.Text) || String.IsNullOrEmpty(txtMarkasi.Text))
                {
                    if (String.IsNullOrEmpty(txtAdi.Text))
                    {
                        MessageBox.Show("Lütfen Demirbaş Adını Doldurunuz!");
                        txtAdi.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Demirbaş Markasını Doldurunuz!");
                        txtMarkasi.Focus();
                    }
                }
                else
                {
                    Güncelleme();
                    temizle();
                    Form1_Load(null, null);
                }
            }
        }

        private void btnDemirbasBul_Click(object sender, EventArgs e)
        {
            temizle();
            Form1_Load(null, null);
        }
        public int ekle(demirbaslar dm)
        {
            int sonuc = -1;
            try
            {
                using (var context = new sporEntities())
                {
                    context.demirbaslars.Add(dm);
                    sonuc = context.SaveChanges();
                    Form1_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme Hatası" + ex);
            }
            return sonuc;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                demirbaslar dm = new demirbaslar();
                if (!string.IsNullOrEmpty(txtAdi.Text))
                {
                    dm.adi = txtAdi.Text;
                    if (!string.IsNullOrEmpty(txtSeriNo.Text))
                    {
                        dm.serino = txtSeriNo.Text;
                        if (!string.IsNullOrEmpty(txtMarkasi.Text))
                        {
                            dm.markasi = txtMarkasi.Text;
                            if (!string.IsNullOrEmpty(txtFiyati.Text))
                            {
                                dm.fiyati = txtFiyati.Text;
                                if (!string.IsNullOrEmpty(dtpAlinmaTarihi.Value.ToString()))
                                {
                                    dm.alinmaTarihi = dtpAlinmaTarihi.Value;

                                    if (!string.IsNullOrEmpty(txtBakimAraligi.Text))
                                    {
                                        if (Convert.ToInt32(txtBakimAraligi.Text) > 0 && Convert.ToInt32(txtBakimAraligi.Text) < 255)
                                        {
                                            dm.bakimAraligi = Convert.ToByte(txtBakimAraligi.Text);

                                            if (!string.IsNullOrEmpty(dtpTarih.Value.ToString()))
                                            {
                                                dm.tarih = dtpTarih.Value;
                                                ekle(dm);
                                                MessageBox.Show("Kayıt Başarılı!");
                                                temizle();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Demirbaş Tarihini giriniz");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Lütfen 0 ile 255 arasında bir değer giriniz.");
                                            txtBakimAraligi.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Demirbaş bakımaralığı giriniz");
                                        txtBakimAraligi.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Demirbaş Alınma Tarihini giriniz");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Demirbaş Fiyatını giriniz");
                                txtFiyati.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Demirbaş markasını giriniz");
                            txtMarkasi.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Demirbaş serino giriniz");
                        txtSeriNo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Demirbaş adını giriniz");
                    txtAdi.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme Hatası" + ex);
            }
        }

        int id = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            try
            {
                using (var context = new sporEntities())
                {
                    demirbaslar ct = context.demirbaslars.FirstOrDefault(sil => sil.demirbasID == id);
                    txtAdi.Text = ct.adi;
                    txtSeriNo.Text = ct.serino;
                    txtMarkasi.Text = ct.markasi;
                    txtFiyati.Text = ct.fiyati;
                    dtpAlinmaTarihi.Value = ct.alinmaTarihi.Value;
                    txtBakimAraligi.Text = ct.bakimAraligi.ToString();
                    dtpTarih.Value = ct.tarih.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme Hatası : " + ex);
            }
        }
        public void temizle()
        {
            txtAdi.Clear();
            txtSeriNo.Clear();
            txtMarkasi.Clear();
            txtFiyati.Clear();
            txtBakimAraligi.Clear();
            txtAdi.Focus();
        }
        public void Güncelleme()
        {
            try
            {
                using (var context = new sporEntities())
                {
                    demirbaslar dm = context.demirbaslars.FirstOrDefault(sil => sil.demirbasID == id);
                    if (dm != null)
                    {
                        dm.adi = txtAdi.Text;
                        dm.markasi = txtMarkasi.Text;
                        dm.fiyati = txtFiyati.Text;
                        dm.alinmaTarihi = dtpAlinmaTarihi.Value;
                        dm.bakimAraligi = Convert.ToByte(txtBakimAraligi.Text);
                        dm.tarih = dtpTarih.Value;

                        context.SaveChanges();
                        Form1_Load(null, null);
                        MessageBox.Show("Güncelleme işlemi başarılı!");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Seçim Yapınız!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme Hatası : " + ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new sporEntities())
                {
                    dataGridView1.DataSource = context.demirbasGetir();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Getirme Hatası : " + ex);
            }
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            seçilen = true;
        }
    }
}
