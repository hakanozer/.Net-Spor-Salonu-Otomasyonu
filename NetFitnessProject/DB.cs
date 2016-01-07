using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// kütüphaneler
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace NetFitnessProject
{
    class DB
    {

        string dbName = "spor";
        string userName = "sa";
        string userPass = "12345";
        string dataSource = @"SC-105-01\MSSQL2012";

        //sqlconnection nesnesi
        public SqlConnection conn = null;

        public DB()
        {

            try
            {
                //sql bağlantısı yapılıyor
                conn = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog =" + dbName + ";User Id=" + userName + ";Password=" + userPass);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Baglanti Hatasi : " + ex);
            }

        }
        //kapatma fnc
        public void kapat()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("DB kapatma sorunu" + ex);
            }

        }

        //DB baglantı acma fnc
        public void ac()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("DB acma sorunu" + ex);
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

        // data getirme fonksiyonu
        public SqlDataReader query(String query)
        {
            SqlDataReader rd = null;
            try
            {
                SqlCommand cm = new SqlCommand(query, conn);
                rd = cm.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Okuma Hatası " + ex);
            }
            return rd;
        }


       



       


    }
}
