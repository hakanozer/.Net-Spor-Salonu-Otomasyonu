using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetFitnessProject;

namespace NetFitnessProject
{
    public partial class hocaGiris : Form
    {
        public hocaGiris()
        {
            InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;
        }
   public  static int ID = 0;
        private void btnGiris_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtKullaniciAdi.Text)&&!string.IsNullOrEmpty(txtSifre.Text))
            {
                  try
            {
                 string id =txtKullaniciAdi.Text;
                 sporEntities db = new sporEntities();
                 string query = (from c in db.hocalars
                        where c.mail == id && c.sifre == txtSifre.Text
                        select c.mail).FirstOrDefault();
                 if (query != null)
                {
                    int query1 = (from c in db.hocalars
                    where c.mail == id && c.sifre == txtSifre.Text
                    select c.hocaID).FirstOrDefault();
                ID = query1;  
               MessageBox.Show("Giriş Başarılı");
               hocasayfasi hc = new hocasayfasi();  //*****---- Hatalar Çıktııııı!!!!!!! YARDIM LÜTFEEENNN!!
               hc.Show();
               this.Hide();
                }
                 else
                 {
                  
                     MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                 }
         
  
 
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show("Giriş Başarısız"+ex);
            }
            }
            else
            {
                MessageBox.Show("Alanlar Boş Bırakılamaz","Hata",  MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

}
        //md5 şifreleme not:hoca kaydını ben yapmadığım için şifrelemeyi yapmak zorunda değilim.

        public static string MD5Sifrele(string metin)
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGiris_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        }
        

    }
