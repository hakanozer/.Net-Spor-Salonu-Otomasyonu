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
    public partial class uyePanel : Screen
    {
        public uyePanel()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
   
        sporEntities se = new sporEntities();
        string path = "";
        bool deger = false;
        private void button1_Click(object sender, EventArgs e)
        {
            deger = false;
            dataGridView1.DataSource = null;
            int a = Convert.ToInt32(textBox1.Text);
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                using (var ts = new sporEntities())
                {
                    dataGridView1.DataSource = ts.uyedataGetir(a);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        deger = true;
                        try
                        {
                            path = row.Cells[3].Value.ToString();
                            if (path != null)
                            {
                                pictureBox1.Load(path);
                            }
                           
                        }
                        catch (Exception )
                        {

                            pictureBox1.Load("resimler\\photo.jpg");
                        }
                    }
                   
                }

               
                if (!deger)
                {
                    pictureBox1.Load("resimler\\photo.jpg");
                    MessageBox.Show("Üye Bulunamadı");
                    
                }
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       
    } 
}
