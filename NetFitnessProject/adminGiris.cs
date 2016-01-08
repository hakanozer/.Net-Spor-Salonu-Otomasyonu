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
using System.Data.Common;
using NetFitnessProject;

namespace NetFitnessProject
{
    public partial class adminGiris : Form
    {
        public static int id = -1;
        public adminGiris()
        {
            InitializeComponent();
        }

        sporEntities se = new sporEntities();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            String adi = txtKullaniciAdi.Text.Trim();
            String sifre = txtSifre.Text.Trim();

            if (adi.Equals("") || sifre.Equals(""))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
                txtKullaniciAdi.Focus();
            }
            else
            {

                if (kullaniciDogrula(adi, MD5Olustur(sifre)))
                {
                    index f2 = new index();
                    f2.Show();
                    this.Hide();
                    //MessageBox.Show("Kullanıcı id = " + id);
                }
                else
                {
                    //MessageBox.Show("Kullanıcı Adı yada Şifre Hatalı");
                    txtKullaniciAdi.Text = "";
                    txtSifre.Text = "";
                    txtKullaniciAdi.Focus();
                }

            }
            if (rdbHocaGirisi.Checked)
            {
                hocaGiris frmForm1 = new hocaGiris();
                frmForm1.Show();
               
            }
        }
        
        private bool kullaniciDogrula(string kAdi, string kParola)
        {

            bool durum = false;
            using (sporEntities db = new sporEntities())
            {

                List<adminGiri> data = db.Database.SqlQuery<adminGiri>("select *from adminGiris where kulAdi = '" + kAdi + "' and sifre = '" + kParola + "' ").ToList();

                // admin girişi
                Boolean durumi = false;
                if (radioButton1.CanSelect) {
                    foreach (adminGiri item in data)
                    {
                        durumi = true;
                    }

                    if (data != null && durumi)
                    {
                        adminGiris.id = data[0].adminID;
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Admin kullanıcı adı yada şifre hatalı");
                        durum = false;
                    }
                    
                }

                /*
                // hoca girişi
                if (radioButton2.CanSelect)
                {
                    hocalar hc = (from c in db.hocalars where c.mail == kAdi && c.sifre == kParola select c).FirstOrDefault();
                    if (hc != null)
                    {
                        adminGiris.id = hc.hocaID;
                        durum = true;
                    }
                    else {
                        MessageBox.Show("Hoca kullanıcı adı yada şifre hatalı");
                        durum = false;
                    }
                }
                 * 
                 */


            }
            return durum;
        }

        public string MD5Olustur(string input)
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

        private void txtKullaniciAdi_Validated(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text.Trim() == "")
                errorProvider1.SetError(txtKullaniciAdi, "Kullanıcı Adı Girmelisiniz");

            else
                errorProvider1.SetError(txtKullaniciAdi, "");

        }

        private void txtSifre_Validated(object sender, EventArgs e)
        {
            if (txtSifre.Text.Trim() == "")
                errorProvider1.SetError(txtSifre, "Şifreyi Girmelisiniz");

            else
                errorProvider1.SetError(txtSifre, "");
        }

        private void adminGiris_Load(object sender, EventArgs e)
        {
           
        }

        private void rdbHocaGirisi_CheckedChanged(object sender, EventArgs e)
        {
           
        }

    }
}
