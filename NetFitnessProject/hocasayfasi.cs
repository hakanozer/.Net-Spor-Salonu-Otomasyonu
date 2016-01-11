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

using System.Data.SqlClient;
namespace NetFitnessProject
{
    public partial class hocasayfasi : Form
    {
        public hocasayfasi()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            timer1.Enabled = true;
        }

        private void hocasayfasi_Load(object sender, EventArgs e)
        {

        }

        private void btnPrgramOlustur_Click(object sender, EventArgs e)
        {
            programsayfasi prsf = new programsayfasi();
            prsf.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            hocaGiris frm = new hocaGiris();
            frm.Show();
            this.Hide();
           

        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            
            sporEntities db = new sporEntities();
            try
            {
                using (var ct = new sporEntities())
                {
                    
                    
                IList<satislar> courseList = ct.hocayaAitUyeGetirme(hocaGiris.ID).ToList<satislar>();
                        
                ArrayList ls = new ArrayList();
                foreach (var item in courseList)
                {
                    satislar uye = new satislar();
                    uye.uyeID = item.uyeID;
                    uye.satisID = item.satisID;
                    uye.paketID = item.paketID;
                    uye.odemeTuru = item.odemeTuru;
                    uye.tarih = item.tarih;
                    uye.baslamaTarih = item.baslamaTarih;
                    uye.bitisTarihi = item.bitisTarihi;
                    uye.tarih = item.tarih;
                    uye.hocaID = item.hocaID;
                    ls.Add(uye);
                }
                dataGridView1.DataSource = ls;
                dataGridView1.Visible = true;
               
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex);
            }
        }
        
        private void btnAyarlar_Click(object sender, EventArgs e)
        {
           
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
           // Raporlama rapor = new Raporlama();
        //    rapor.Show();
           
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
        }

        private void btnTurnike_Click(object sender, EventArgs e)
        {
            TurnikeGecis trg = new TurnikeGecis();
            trg.Show();
        }

        private void btnHocaAyar_Click(object sender, EventArgs e)
        {
            HocaAyarlari ayar = new HocaAyarlari();
            ayar.Show();
            this.Hide();
        }
    }
}
