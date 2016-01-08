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

     
      
        public void temizle()
        {
            txtAdi.Clear();
            txtSeriNo.Clear();
            txtMarkasi.Clear();
            txtFiyati.Clear();
            txtBakimAraligi.Clear();
            txtAdi.Focus();
        }
        
                     
        }

    }
}
