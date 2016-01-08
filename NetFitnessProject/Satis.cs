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
    public partial class Satis : Screen
    {
        //entity
        sporEntities context = new sporEntities();
        //paketlerin id'lerinin tutulduğu liste
        ArrayList listOfPaket = new ArrayList();
        // hocaların id'lerinin tutulduğu liste
        ArrayList listOfHoca  = new ArrayList();
        //uzatılıcak paket'in satış id'si
        int satisID =-1;
        //uzatılıcak tarihin başlangıcı
        DateTime endDate;
        // önceki üyeliğin ücreti
        decimal oldPrice = -1;
        public Satis()
        {
            InitializeComponent();
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
                try
                {
                    //paket satışı yapılacak üyenin bilgileri tc no'suna göre getiriliyor.
                    var rs = context.getUye(txtUyeTc.Text);
                    getUye_Result uyeResult = rs.First();
                    txtAdSoyad.Text = uyeResult.adi + " " + uyeResult.soyadi;
                    txtMail.Text = uyeResult.mail;
                    txtTel.Text = uyeResult.telefon;
                    txtID.Text = uyeResult.uyeID.ToString();
                    int userID = Convert.ToInt32(txtID.Text);

                //aktif üyelik kontorlü
                //ArrayList list = new ArrayList()
                //list.Add((DateTime)context.satislar.Where(f => f.uyeID == userID).Select(c => c.bitisTarihi).Last());
                DateTime dt = (DateTime)context.satislars.Where(f => f.uyeID == userID).OrderByDescending(f => f.bitisTarihi).Select(c => c.bitisTarihi).First();
                   if (dt != null)
                { 
                     MessageBox.Show("Bu üyenin zaten aktif paketi "+dt.Date+" tarihine kadar bulunmaktadır.Süre uzatmak için süre uzatma sekmesine geçiniz veya üyelik bitişinden sonraki bir tarih seçiniz.");
                    dateTimePicker1.MinDate = dt;
                        }
                    else
                    {
                    dateTimePicker1.MinDate = DateTime.Now;
                    }


                uyeResult = null;
                    rs = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Böyle bir üye bulunamadı" );
                    txtUyeTc.Focus();
                }
         
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                //paket süre uzatımı yapılacak üyenin bilgileri tc no'suna göre getiriliyor.
                var rs = context.getSatis(txtSureUyeTc.Text);
                getSatis_Result uyeResult = rs.First();
                txtSureID.Text = uyeResult.uyeID.ToString();
                txtSureTel.Text = uyeResult.telefon;
                txtSureUyeAdi.Text = uyeResult.adi + " " + uyeResult.soyadi;
                txtSureUyeMail.Text = uyeResult.mail;
                txtUyeBas.Text = uyeResult.baslamaTarih.ToString();
                txtUyeBit.Text = uyeResult.bitisTarihi.ToString();
                satisID = uyeResult.satisID;
                endDate = (DateTime)uyeResult.bitisTarihi;
                oldPrice = (decimal)uyeResult.ucret;
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aktif paketi bulunan böyle bir üye bulunamadı");
                txtSureUyeTc.Focus();
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) 
            {
                //tab geçişlerinde önceki tab temizleniyor.
                txtAdSoyad.Text = null;
                txtMail.Text = null;
                txtTel.Text = null;
                txtID.Text = null;
                txtUyeTc.Text = null;   
            }
            else
            {
                getPaket();
                getHoca();
                txtSureID.Text = null;
                txtSureTel.Text = null;
                txtSureUyeAdi.Text = null;
                txtSureUyeMail.Text = null;
                txtUyeBas.Text = null;
                txtUyeBit.Text = null;
                txtSureUyeTc.Text = null;
                satisID = -1;
                oldPrice = -1;

            }
        }
        private void getPaket()
        {
            //veri tabanındaki paketler combobox'a getiriliyor
            listOfPaket.Clear() ;
            cmbPaket.Items.Clear();
            foreach(var paket in context.paketlers)
            {
                listOfPaket.Add(paket.paketID);
                cmbPaket.Items.Add(paket.paketAdi);
            }

        }
        private void getHoca()
        {
            //veri tabanındaki hocalar combobox'a getiriliyor
            listOfHoca.Clear();
            cmbHoca.Items.Clear();
            foreach (var hoca in context.hocalars)
            {
                listOfHoca.Add(hoca.hocaID);
                cmbHoca.Items.Add(hoca.adi+" "+hoca.soyadi);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getPaket();
            getHoca();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //yeni satış yapılıyor.
            try
            {
                if (cmbHoca.SelectedIndex >= 0 && cmbPaket.SelectedIndex >= 0 && cmbOdeme.SelectedIndex >= 0 && txtID != null)
                {       
                int paketID = (int)listOfPaket[cmbPaket.SelectedIndex];
                int paketDays = (int)context.paketlers.Where(f => f.paketID == paketID).Select(c => c.gun).FirstOrDefault();
                satislar satis = new satislar();
                satis.hocaID = (int)listOfHoca[cmbHoca.SelectedIndex];
                satis.paketID = (int)listOfPaket[cmbPaket.SelectedIndex];
                satis.odemeTuru = (byte)(cmbOdeme.SelectedIndex + 1);
                satis.tarih = DateTime.Now;
                satis.ucret = context.paketlers.Where(f => f.paketID == paketID).Select(c => c.ucret).FirstOrDefault();
                satis.uyeID = Convert.ToInt32(txtID.Text);
                satis.baslamaTarih = dateTimePicker1.Value;
                satis.bitisTarihi = dateTimePicker1.Value.AddDays(paketDays);
                context.satislars.Add(satis);
                 context.SaveChanges();
                    MessageBox.Show("satış başarılı");
                }
                else
                {
                    MessageBox.Show("lütfen bütün alanları doldurun");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ekleme hatası \n"+ex);
            }
        }
        private void btnSureEkle_Click(object sender, EventArgs e)
        {
            if (txtUcret != null && endDate != null && txtGunEkle!= null)
            {
                try
                {
                    endDate = endDate.AddDays(Convert.ToInt32(txtGunEkle.Text));
                    decimal price = Convert.ToDecimal(txtUcret.Text);
                    price = price + oldPrice;
                    if (oldPrice > 0 && endDate != null && txtGunEkle.Text != null)
                        try
                        {
                            context.updUyelik(satisID, price, endDate);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("geçerli bir gün sayısı giriniz.");                       
                        }
                   
                    MessageBox.Show("üyelik tarih'i " + endDate + " tarihine ertelendi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("güncelleme başarısız." );
                }           
            }
        }
    }
}
