using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using ClosedXML.Excel;

namespace NetFitnessProject
{
    public partial class BackupRapor : Screen
    {
        public BackupRapor()
        {
            InitializeComponent();
        }
        sporEntities db = new sporEntities();
        decimal ToplamCiro = 0;

        

        private void btnGetir_Click(object sender, EventArgs e)
        {
             try
            {
                dataGridView1.DataSource = null;
                if (cmbRapor.Text == "Paketler Rapor")
                {
                    using (var context = new sporEntities())
                    {
                        IEnumerable<paketlerRapor_Result> collection = context.paketlerRapor(dtpTarih1.Value, dtpTarih2.Value);
                        IList<paket> myList = new List<paket>();
                        ToplamCiro = 0;
                        foreach (paketlerRapor_Result item in collection)
                        {
                            ToplamCiro += Convert.ToDecimal(item.satisUcreti);
                            paket rapor = new paket();
                            rapor.PaketAdi = item.paketAdi;
                            rapor.PaketKategorisi = item.kategoriID.ToString();
                            rapor.PaketUcreti = item.paketUcreti.ToString();
                            rapor.OdemeTuru = Convert.ToInt32(item.odemeTuru);
                            rapor.SatisUcreti = item.satisUcreti.ToString();
                            rapor.SatısTarihi = item.tarih.ToString();
                            rapor.Toplam = ToplamCiro.ToString();
                            myList.Add(rapor);
                        }
                        dataGridView1.DataSource = myList;
                    }
                }
                else if (cmbRapor.Text == "Üyeler Rapor")
                {
                    using (var context = new sporEntities())
                    {
                        IEnumerable<uyelerRapor_Result> collection = context.uyelerRapor(dtpTarih1.Value, dtpTarih2.Value);
                        IList<uyeRpr> myList = new List<uyeRpr>();
                        ToplamCiro = 0;
                        foreach (uyelerRapor_Result item in collection)
                        {
                            ToplamCiro += Convert.ToDecimal(item.satisUcreti);
                            uyeRpr rapor = new uyeRpr();
                            rapor.UyeAdı = item.adi;
                            rapor.UyeSoyadı = item.soyadi;
                            rapor.UyeTelefonu = item.telefon.ToString();
                            rapor.SatisUcreti = item.satisUcreti.ToString();
                            rapor.SatısTarihi = item.tarih.ToString();
                            rapor.Toplam = ToplamCiro.ToString();
                            myList.Add(rapor);
                        }
                        dataGridView1.DataSource = myList;
                    }
                }
               
                else
                {

                    MessageBox.Show("Cari Hesap Seçimi Yapınız");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri Getirme Hatası :" + ex);
            }

       
        }

        private void btnYazdır_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbExcel.Checked)
                {
                    DataTable dt = new DataTable();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }
                    string folderPath = "C:\\Excel\\";
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    //string excelName = "Rapor" + Guid.NewGuid().ToString(); 
                    string excelName = "RaporEXCEL" + DateTime.Now.Millisecond;

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Rapor");
                        wb.SaveAs(folderPath + excelName + ".xlsx");
                    }
                    MessageBox.Show("Raporunuz oluşturuldu. Dosya Yolu : C:\\Excel\\" + excelName);

                }
                else
                {
                    MessageBox.Show("Lütfen rapor türünü seçiniz.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor oluşturulamadı..Tablonuzu oluşturun :"+ex);
            }
        }

        private void BackupRapor_Load(object sender, EventArgs e)
        {

        }
    }
}
