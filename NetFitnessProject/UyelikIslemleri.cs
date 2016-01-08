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
    public partial class UyelikIslemleri : Screen
    {
        public UyelikIslemleri()
        {
            InitializeComponent();
        }
        sporEntities db = new sporEntities();
        private void UyelikIslemleri_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            var context = new sporEntities();
            dataGridView1.DataSource = context.Uyeleri_Getir();

            dataGridView1_Click(null, null);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[14].Value) == false)
                    btn_UyelikDurumu.Text = "Üyeliği Aktiflelştir";
                else
                    btn_UyelikDurumu.Text = "Üyeliği Dondur";
            }
            catch (Exception)
            {
            }
                   
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var context = new sporEntities();
            if (textBox1.Text == "")
                dataGridView1.DataSource = context.Uyeleri_Getir();
            else
                dataGridView1.DataSource = context.Uye_Ara(textBox1.Text);
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
             DialogResult dr = MessageBox.Show("Uyelik Silinsin mi?","",MessageBoxButtons.YesNo);
             if (dr == DialogResult.Yes)
             {
                 try
                 {
                     int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                     String query = "delete from satislar where uyeID = {0}";
                     db.uyelers.Remove(db.uyelers.Find(id));
                     var row = db.Database.ExecuteSqlCommand(query, id);
                     db.SaveChanges();
                     UyelikIslemleri_Load(null, null);
                 }
                 catch (Exception er)
                 {
                     MessageBox.Show(er.Message);
                 }
             }
             else
                 MessageBox.Show("Üyelik silinmedi");
        }

        private void btn_UyelikDurumu_Click(object sender, EventArgs e)
        {
                try
            {
                int uyeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                Boolean durum = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[14].Value);
                if (durum == false)
                    durum = true;
                else
                    durum = false;

                String query = "update uyeler set uyelikDurumu = '" + durum + "' where uyeID = {0}";
                var rows = db.Database.ExecuteSqlCommand(query, uyeID);
                UyelikIslemleri_Load(null, null);
            }
                catch (Exception er)
                {
                    MessageBox.Show("üyelik durumunu değiştirmedim." + er.Message);
                }
        }

        private void üyelikAktarmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uyelik_Aktarma g = new Uyelik_Aktarma();
            g.Show();
            this.Hide();
        }
        }
    }
