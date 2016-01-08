using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.IO;

namespace NetFitnessProject
{
    public partial class SifreDegis : Screen
    {
        sporEntities sp = new sporEntities();
        
        public SifreDegis()
        {
            InitializeComponent();
        }
        int idd = 1;
        private void btnDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new sporEntities())
                {
                    adminGiri sp = context.adminGiris.Find(idd);
                    if (txtmail.Text == sp.mail)
                    {
                     if (MD5Olustur(txtEskiSifre.Text) == sp.sifre.ToString())
                     {
                         if (txtYeniSifre.Text == txtYeniSifre2.Text)
                         {
                             adminGiri dm = context.adminGiris.FirstOrDefault(sil => sil.adminID == idd);
                              if (dm != null)
                              {
                                  dm.sifre = MD5Olustur(txtYeniSifre.Text);
                                  context.SaveChanges();
                                  MessageBox.Show("Şifre Değiştirme Başarılı!");
                              }
                          }
                         else
                         {
                              MessageBox.Show("Yeni Şifreleriniz Uyuşmuyor!");
                              temizle();
                         }
                      }
                     else
                     {
                         MessageBox.Show("Eski Şifrenizi Yanlış Girdiniz!");
                         temizle();
                      }
                    }
                    else
                    {
                        MessageBox.Show("Mail Adresinizi Yanlış Girdiniz!");
                        temizle();
                    }
                 }
             }
                catch (Exception ex)
             {
                MessageBox.Show("Şifre Değiştirme Hatası" + ex);
                }
           }
        public String MD5Olustur(String input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
      
    }
}
