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
    public partial class PaketKontrol : Screen
    {
        public PaketKontrol()
        {
            InitializeComponent();
        }
        sporEntities spr = new sporEntities();
        private void button1_Click(object sender, EventArgs e)
        {
          
            if ( !String.IsNullOrEmpty(textBox2.Text.Trim()) && !String.IsNullOrEmpty(textBox3.Text.Trim()) && !String.IsNullOrEmpty(textBox3.Text.Trim()) &&  !String.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                try
                {
                    paketler pkt = new paketler();
                    pkt.kategoriID = (int)ls[comboBox1.SelectedIndex];
                    pkt.paketAdi = textBox2.Text;
                    pkt.gun = byte.Parse(textBox3.Text);
                    pkt.ucret = decimal.Parse(textBox4.Text);
                    pkt.tarih = DateTime.Now;
                    spr.paketlers.Add(pkt);


                    spr.SaveChanges();
                    datagetir();
                    MessageBox.Show("Başarıyla eklendi");

                    comboBox1.Text = "";
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }
                catch (Exception )
                {
                    MessageBox.Show("Kategori seçiniz ve gün,ücret bölümüne sayısal veri giriniz    ");
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurunuz ve kategori seçiniz.");
            }

           
        }
        bool secim=false;
        int categori_id = -1;
        ArrayList ls = new ArrayList();
        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<kategoriler> liste = spr.kategorilers;

            foreach (var item in liste)
            {
                kategoriler kt = new kategoriler();

                kt.adi = item.adi;
                categori_id = item.kategoriID;
                ls.Add(item.kategoriID);
                
                comboBox1.Items.Add(kt.adi);
                comboBox2.Items.Add(kt.adi);

            }
            datagetir();

        }
        int pid = -1;
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count!=0)
            {
                if (!String.IsNullOrEmpty(textBox1.Text.Trim()) && !String.IsNullOrEmpty(textBox5.Text.Trim()) && !String.IsNullOrEmpty(textBox6.Text.Trim()))
                {
                    try
                    {
                        String id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                        pid = Convert.ToInt32(id);

                        paketler pk = spr.paketlers.FirstOrDefault(gncl => gncl.paketID == pid);
                        if (pk != null)
                        {

                            pk.kategoriID = (int)ls[comboBox2.SelectedIndex];

                            pk.paketAdi = textBox1.Text;
                            pk.gun = byte.Parse(textBox5.Text);
                            pk.ucret = decimal.Parse(textBox6.Text);
                            pk.tarih = DateTime.Now;
                            spr.SaveChanges();



                            comboBox2.Text = "";
                            textBox1.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                        }
                        datagetir();
                        MessageBox.Show("Başarıyla güncellendi");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kategori seçiniz ve gün, ücret bölümüne sayısal veri giriniz");
                    }
                }
                else
                {
                    MessageBox.Show(" Güncellenecek paketi seçiniz ve tüm alanları doldurunuz ");
                }
            }
            else
            {
                MessageBox.Show("Güncellenecek paket yoktur");
            }
           
          
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        public void datagetir()
        {
            ArrayList paket = new ArrayList();
            IEnumerable<paketler> liste = spr.paketlers;

            foreach (var item in liste)
            {
                paketler pkt = new paketler();

                pkt.paketAdi = item.paketAdi;
                pkt.paketID = item.paketID;
                pkt.kategoriID = item.kategoriID;
                pkt.ucret = item.ucret;
                pkt.tarih = item.tarih;
                pkt.gun = item.gun;


                paket.Add(pkt);


            }
            dataGridView1.DataSource = paket;
            dataGridView2.DataSource = paket;
        }
      int  pid2=-1;
        private void button2_Click(object sender, EventArgs e)
        {

            if (secim==true)
            {
                 String id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            pid2  = Convert.ToInt32(id);
            spr.paketlers .Remove(spr.paketlers .Find(pid2));
            try
            {
                spr.SaveChanges();
                comboBox2.Text = "";
               
                textBox1.Clear();
                textBox5.Clear();
                textBox6.Clear();
                secim = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex);
            }
            datagetir();
            }
            else
            {
                MessageBox.Show("Silmek için seçim yapınız");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {    
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

      

        private void dataGridView2_CellMouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                
          int   id22 = int .Parse (dataGridView2.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString());
          

            secim = true;
            textBox1.Text = dataGridView2.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView2.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView2.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();

            IEnumerable<kategoriler> liste = spr.kategorilers.Where(k=> k.kategoriID==id22);

            foreach (var item in liste)
            {
                comboBox2.Text = item.adi;
               

            }
            }
            catch (Exception)
            {
                MessageBox.Show("Paket bilgisi yoktur.Lütfen ekleme yapınız");
               
            }
            button3.Enabled = true;
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
