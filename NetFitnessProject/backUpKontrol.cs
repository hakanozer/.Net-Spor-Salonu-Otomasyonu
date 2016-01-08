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
using System.Data.SqlClient;

namespace NetFitnessProject
{
    public partial class backUpKontrol : Screen
    {
        DB db = new DB();
        public backUpKontrol()
        {
            InitializeComponent();
        }
        private void btnBackup_Click(object sender, EventArgs e)
        {
            db.ac();
           
            try
            {
                foreach (Control radio in grpBackup.Controls)
                {
                    if (radio is RadioButton)
                    {
                        RadioButton rdb = (RadioButton)radio;
                        if (!rdb.Checked)
                        {
                            MessageBox.Show("Lütfen seçim yapınız.");
                            
                        }
                      
                        else if (rdb.Checked)
                        {
                            SaveFileDialog sf = new SaveFileDialog();
                            string FileName = "";
                            sf.InitialDirectory = "";
                            sf.FileName = "";
                            sf.RestoreDirectory = true;
                            if (sf.ShowDialog() == DialogResult.OK)
                            {
                                if (!string.IsNullOrEmpty(sf.FileName))
                                {
                                    SqlCommand cm;
                                    cm = new SqlCommand(@"backup database " + rdb.Text + " to disk='" + sf.FileName + ".bak' with init, stats=10", db.conn);
                                    cm.ExecuteNonQuery();

                                    MessageBox.Show("Backup işlemi başarılı");

                                }

                            }
                            else
                            {
                                MessageBox.Show("Lütfen dosya ismi veriniz");
                            }
                            db.kapat();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı yedeği alınamadı !! :" + ex); ;
            }
        }

        private void backUpKontrol_Load(object sender, EventArgs e)
        {

        }
    }
}
