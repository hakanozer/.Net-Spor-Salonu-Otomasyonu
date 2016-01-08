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
    public partial class Form2 : Screen
    {
        public int newID;
        public Form2(int id)
        {
            InitializeComponent();
            newID = id;
        }
        UyeForm1 frm1 = new UyeForm1();
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            
            using (var context =new sporEntities())
            {
                context.newProUyeGuncelle(newID, txtAd.Text, txtSoyad.Text, txtTel.Text, txtTc.Text,txtMail.Text, Convert.ToByte(rdbErkek.Checked ? 0 : 1), dtpKayit.Value,dtpDogum.Value,txtAdres.Text);

                MessageBox.Show("Güncelleme yapıldı.");
                this.Close();
            }
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
