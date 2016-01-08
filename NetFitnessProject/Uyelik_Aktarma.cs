using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetFitnessProject
{
    public partial class Uyelik_Aktarma : Screen
    {
        public Uyelik_Aktarma()
        {
            InitializeComponent();
        }
        int satisID = 0;
        int alanID = 0;
        DateTime bugun = DateTime.Now;
        DateTime bitisTarihi;
        int uylikDurumu = 0;
        public void Uye_Getir(DataGridView dgv1, DataGridView dgv2)
        {
            using (var context = new sporEntities())
            {
                dataGridView1.DataSource = context.Satislari_Getir();
                dataGridView2.DataSource = context.Satislari_Getir();
            }
        }
        public void UyeID_AL(DataGridView dvg, Label lbl)
        {
            try
            {
                var context = new sporEntities();
                int uyeID = Convert.ToInt32(dvg.CurrentRow.Cells[1].Value);
                IEnumerable<IDdenUyeGetir_Result> liste = context.IDdenUyeGetir(uyeID);
                String adi = "";
                String soyadi = "";
                foreach (IDdenUyeGetir_Result item in liste)
                {
                    adi = item.adi;
                    soyadi = item.soyadi;
                    uylikDurumu = Convert.ToInt32(item.uyelikDurumu);
                }
                lbl.Text = adi + " " + soyadi;
            }
            catch (Exception)
            {
                
            }
        }
        private void Uyelik_Aktarma_Load(object sender, EventArgs e)
        {
            Uye_Getir(dataGridView1, dataGridView2);
            textBox1.Focus();
            dataGridView1_Click(null, null);
            dataGridView2_Click(null, null);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                satisID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                UyeID_AL(dataGridView1, label2);
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                alanID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value);
                UyeID_AL(dataGridView2, label4);
            }
            catch (Exception)
            {
            }
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UyelikIslemleri g = new UyelikIslemleri();
            g.Show();
            this.Hide();
        }

        private void btn_Aktar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Uyelik Aktarılsın mı?","",MessageBoxButtons.YesNo);
            if(dr==DialogResult.Yes)
            {
                using (var context = new sporEntities())
                {
                    try
                    {
                        bitisTarihi = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value);
                        TimeSpan kalanGun = bitisTarihi.Subtract(bugun);
                        if (kalanGun.Days < 15)
                        {
                            throw new Exception("Aboneliğin bitimine 15 gün ya var ya da yok. Neyin aktarımı bu?");
                        }
                        if (uylikDurumu == 0)
                        {
                            throw new Exception("Bu abonelik aktrarılabilir durumda değil. Daha önce ya dondurulmuş ya da başka birine aktarılmış.");
                        }

                        context.uyelikDondur(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value));
                        context.Uyelik_Aktar(alanID, satisID);
                        context.SaveChanges();
                        Uyelik_Aktarma_Load(null, null);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("" + er.Message);
                    }
                }
            }
            else
                MessageBox.Show("tamam üyeliği aktarmadım");
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var context = new sporEntities();
            
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = context.Satis_Ara(textBox1.Text);
                    UyeID_AL(dataGridView1,label2);
                }
                else
                {
                    dataGridView1.DataSource = context.Satislari_Getir();
                    label2.Text = "";
                }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            var context = new sporEntities();
            
                if (textBox2.Text != "")
                    dataGridView2.DataSource = context.Satis_Ara(textBox2.Text);
                else
                {
                    dataGridView2.DataSource = context.Satislari_Getir();
                    label4.Text = "";
                }
            }
        }
    }
