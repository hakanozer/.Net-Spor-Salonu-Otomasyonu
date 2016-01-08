using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NetFitnessProject
{
    public partial class sirketBilgileriDuzenle : Screen
    {
        public sirketBilgileriDuzenle()
        {
            InitializeComponent();
        }

        public void Güncelleme()
        {
            try
            {
                using (var context = new sporEntities())
                {
                    sirketBilgileri dm = context.sirketBilgileris.FirstOrDefault(sil => sil.sirketID == id);
                    if (dm != null)
                    {
                        if (String.IsNullOrEmpty(textBox1.Text))
                        {
                            MessageBox.Show("Lütfen Unvan Alanını Doldurunuz!");
                            textBox1.Focus();
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(textBox2.Text))
                            {
                                MessageBox.Show("Lütfen Telefon Alanını Doldurunuz!");
                                textBox2.Focus();
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(textBox3.Text))
                                {
                                    MessageBox.Show("Lütfen Adres Alanını Doldurunuz!");
                                    textBox3.Focus();
                                }
                                else
                                {
                                    if (String.IsNullOrEmpty(textBox4.Text))
                                    {
                                        MessageBox.Show("Lütfen Mail Alanını Doldurunuz!");
                                        textBox4.Focus();
                                    }
                                    else
                                    {
                                        if (String.IsNullOrEmpty(textBox5.Text))
                                        {
                                            MessageBox.Show("Lütfen Web Alanını Doldurunuz!");
                                            textBox5.Focus();
                                        }
                                        else
                                        {
                                            if (String.IsNullOrEmpty(textBox6.Text))
                                            {
                                                MessageBox.Show("Lütfen Çalışma Başlangıç Alanını Doldurunuz!");
                                                textBox6.Focus();
                                            }
                                            else
                                            {
                                                if (String.IsNullOrEmpty(textBox7.Text))
                                                {
                                                    MessageBox.Show("Lütfen Çalışma Bitiş Alanını Doldurunuz!");
                                                    textBox7.Focus();
                                                }
                                                else
                                                {
                                                    if (String.IsNullOrEmpty(textBox8.Text))
                                                    {
                                                        MessageBox.Show("Lütfen Logo Alanını Doldurunuz!");
                                                        textBox8.Focus();
                                                    }
                                                    else
                                                    {
                                                        if (String.IsNullOrEmpty(dateTimePicker1.Value.ToString()))
                                                        {
                                                            MessageBox.Show("Lütfen Tarih Alanını Doldurunuz!");
                                                        }
                                                        else
                                                        {
                                                            dm.unvan = textBox1.Text;
                                                            dm.telefon = textBox2.Text;
                                                            dm.adres = textBox3.Text;
                                                            dm.mail = textBox4.Text;
                                                            dm.web = textBox5.Text;
                                                            dm.calismaBaslangic = textBox6.Text;
                                                            dm.calismaBitis = textBox7.Text;
                                                            dm.logo = textBox8.Text;
                                                            dm.tarih = dateTimePicker1.Value;

                                                            context.SaveChanges();
                                                            Form1_Load(null, null);
                                                            MessageBox.Show("Güncelleme işlemi başarılı!");
                                                            textBox1.Clear();
                                                            textBox2.Clear();
                                                            textBox3.Clear();
                                                            textBox4.Clear();
                                                            textBox5.Clear();
                                                            textBox6.Clear();
                                                            textBox7.Clear();
                                                            textBox8.Clear();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }            
                            }
                        }
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
        
    }
}
