using System;
using System.Collections;
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
    public partial class bansKonrol : Screen
    {
        public bansKonrol()
        {
            InitializeComponent();
        }
        sporEntities spr = new sporEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBrans1.Text.Trim()) && cmbKa1.SelectedIndex > -1)
            {
                branslar brns = new branslar();

                int sayac = 0;
                int secilenId = -1;
                foreach (var item in k)
                {
                    ktgr sec = (ktgr)k[sayac];
                    if (sec.K_ad.Contains(cmbKa1.SelectedItem.ToString()))
                    {
                        secilenId = Convert.ToInt32(sec.K_id);
                    }
                    sayac++;
                }
                brns.kategoriID = secilenId;
                //brns.kategoriID = Convert.ToInt32(kt[comboBox1.SelectedIndex]);
                brns.bransAdi = txtBrans1.Text;
                brns.tarih = DateTime.Now;

                spr.branslars.Add(brns);
                spr.SaveChanges();


                cmbKa1.SelectedIndex = -1;
                txtBrans1.Text = "";
                //dataGetir();
                bransGetir();
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
                txtBrans1.Focus();
            }
        }

        ArrayList kt = new ArrayList();
        ArrayList k = new ArrayList();
        bool secim;
        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<kategoriler> liste = spr.kategorilers;
            foreach (var item in liste)
            {
                kategoriler c = new kategoriler();
                c.adi = item.adi;
                c.kategoriID = item.kategoriID;
                cmbKa1.Items.Add(c.adi);
                cmbKa2.Items.Add(c.adi);
                kt.Add(c.kategoriID);

                ktgr ktgr = new ktgr();
                ktgr.K_ad = item.adi;
                ktgr.K_id = item.kategoriID.ToString();
                k.Add(ktgr);


            }
            secim = false;
            //dataGetir();
            bransGetir();
        }

        int secId = -1;

        private void button2_Click(object sender, EventArgs e)
        {
            if (secim == true)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    secId = Convert.ToInt32(id);
                    try
                    {
                        spr.branslars.Remove(spr.branslars.Find(secId));
                        spr.SaveChanges();
                        bransGetir();
                        secim = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme Hatası: " + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmek İçin İlgili Sütunu Tıklayıp Seçiniz!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (secim == true)
            {
                if (dataGridView2.Rows.Count != 0)
                {
                    if (!String.IsNullOrEmpty(txtBrans2.Text.Trim()) && cmbKa2.SelectedIndex > -1)
                    {
                        String id = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                        secId = Convert.ToInt32(id);

                        branslar brns = spr.branslars.FirstOrDefault(gncl => gncl.bransID == secId);
                        if (brns != null)
                        {
                            brns.kategoriID = Convert.ToInt32(kt[cmbKa2.SelectedIndex]);
                            brns.bransAdi = txtBrans2.Text;
                            brns.tarih = DateTime.Now;

                            spr.SaveChanges();
                            cmbKa2.SelectedIndex = -1;
                            txtBrans2.Text = "";
                            //dataGetir();
                            bransGetir();
                            secim = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
                        txtBrans2.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Güncellemek İçin İlgili Sütunu Tıklayıp Seçiniz!");
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secim = true;
            int sayac = 0;
            String secilenAd = null;
            foreach (var item in k)
            {
                ktgr sec = (ktgr)k[sayac];
                if (sec.K_id.Contains(dataGridView2.CurrentRow.Cells[1].Value.ToString()))
                {
                    secilenAd = sec.K_ad;
                }
                sayac++;
            }

            int secilen = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
            txtBrans2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cmbKa2.SelectedItem = secilenAd;
        }

        private void bransGetir()
        {
            dataGridView1.DataSource = spr.pro_BransGetir();
            dataGridView2.DataSource = spr.pro_BransGetir();
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            secim = true;
        }
    }
}
