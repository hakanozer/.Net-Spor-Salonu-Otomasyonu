using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace NetFitnessProject
{
    public partial class mailto : Screen
    {
        MailMessage mail = new MailMessage();

        public mailto()
        {
            InitializeComponent();
        }
        private void Mail_Load(object sender, EventArgs e)
        {
           
            timer1.Enabled = true;
            dataGetir();

        }
        private void btGonder_Click(object sender, EventArgs e)
        {
            bool kontrol = EmailKontrol(textBox1.Text);

            if (kontrol == false)
            {
                errorProvider1.SetError(textBox1, "Geçersiz email format");
                MessageBox.Show("Geçersiz email formatı girdiniz");
                textBox1.Text = null;

            }
            else
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;

                string kime = textBox1.Text;
                string konu = textBox2.Text;
                string icerik = textBox3.Text;
                try
                {
                    sc.Credentials = new NetworkCredential("hakanilefitness@gmail.com", "fitnessilehakan");

                    mail.From = new MailAddress("hakanilefitness@gmail.com", "Hakan Fitness");
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.IsBodyHtml = true;
                    mail.Body = icerik;

                    sc.Send(mail);
                    MessageBox.Show("Mail Gönderildi:\n\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Mail Gönderilemedi:\n\n" + ex);
                }
            }

            

        }

        int kontrol = 0;
        private void btEkle_Click(object sender, EventArgs e)
        {
            string DosyaYolu = null;
            kontrol++;

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.ShowDialog();
            DosyaYolu = dosya.FileName;
            textBox4.Text += dosya.SafeFileName + "\r\n";

            try
            {
                mail.Attachments.Add(new Attachment(DosyaYolu));
                label4.Text = kontrol + " Dosya Eklendi.";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Dosya Eklenemedi Hatası:\n" + ex);
            }
        }
        static bool EmailKontrol(string inputEmail)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            return (new Regex(strRegex)).IsMatch(inputEmail);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            temizle(this);
        }
        private void temizle(Control ctl)
        {
            mail = new MailMessage();
            label4.Text = "Dosya Eklenmedi...";
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                if (c.Controls.Count > 0)
                {
                    temizle(c);
                }
            }
            textBox1.Focus();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString();
        }

        List<string> list = new List<string>();
        private void dataGetir()
        {
            try
            {
                var context = new sporEntities();

                foreach (var item in context.proMail())
                {
                   // checkedListBox1.Items.Add(item.adi.ToUpperInvariant() + " " + item.soyadi.ToUpper());
                    list.Add(item.mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uye Yükleme Hatası" + ex);
            }
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
           
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
//textBox1.Text = list[checkedListBox1.SelectedIndex];
        }
    }
}
