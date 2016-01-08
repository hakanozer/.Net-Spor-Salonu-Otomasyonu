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


    public partial class kategori_Kontrol : Screen
    {
        public kategori_Kontrol()
        {
            InitializeComponent();
        }


        sporEntities db = new sporEntities();
        int silID = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txtAdı.Text == "")
                    throw new Exception("Kategori adı boş bırakılamaz");
                kategoriler kt = new kategoriler();

                kt.adi = txtAdı.Text;
                kt.tarih = DateTime.Now;

                db.kategorilers.Add(kt);
                db.SaveChanges();
                Form1_Load(null,null);
            }
            catch (Exception er)
            {

                MessageBox.Show("" + er.Message);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGetir();
            silID = -1;
            txtAdı.Text = "";
            txtAdı.Focus();
        }


        //int did = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && silID != -1)
            {
                

                //String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                //did = Convert.ToInt32(id);
                db.kategorilers.Remove(db.kategorilers.Find(silID));
                try
                {
                    db.SaveChanges();
                    Form1_Load(null, null);
                    //button2_Click(null, null);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme Hatası : " + ex);
                }

                //dataGetir();
                //dataGridView1_DataBindingComplete(null,null);
               
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && silID != -1 && !string.IsNullOrEmpty(txtAdı.Text))
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                try
                {
                    var context = new sporEntities();
                    kategoriler kt = context.kategorilers.FirstOrDefault(sil => sil.kategoriID == id);
                    if (kt != null)
                    {
                        kt.adi = txtAdı.Text;
                        kt.tarih = DateTime.Now;
                        
                        context.SaveChanges();
                        Form1_Load(null,null);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Alanlar boş bırakılamaz " );
                }

              
               
            }

        }

        private void dataGetir()
        {
            dataGridView1.DataSource = null;



            using (sporEntities db2 = new sporEntities())
            {
                List<kategoriler> liste2 = new List<kategoriler>();

                liste2 = db2.kategorilers.ToList();
                if (liste2 != null)
                {
                    dataGridView1.DataSource = liste2;
                }
            }


            //IEnumerable<kategoriler> liste = db.kategorilers;
            //ArrayList ls = new ArrayList();
            //foreach (var item in liste)
            //{
            //    kategoriler c = new kategoriler();
            //    c.kategoriID = item.kategoriID;
            //    c.adi = item.adi;
            //    c.tarih = item.tarih;
            //    //c.Picture = item.Picture;
            //    ls.Add(c);
            //}
            //dataGridView1.DataSource = ls;


        }



        //private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        //{

            
        //    try
        //    {
        //        if (dataGridView1.Rows.Count == 0)
        //            throw new Exception("Seçili alan yok");

        //        txtAdı.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
        //        txtTarihi.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
        //    }
        //    catch (Exception er)
        //    {

        //        MessageBox.Show(""+er.Message);

        //    }


        //}

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                silID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {

                
            } 
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void txtAdı_TextChanged(object sender, EventArgs e)
        {

        }

       

        }
    }

