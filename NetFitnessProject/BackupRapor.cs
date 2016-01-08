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
                else if (cmbRapor.Text == "Hocalar Rapor")
                {
                    using (var context = new sporEntities())
                    {
                        IEnumerable<hocalarRapor_Result> collection = context.hocalarRapor(dtpTarih1.Value, dtpTarih2.Value);
                        IList<hocaRpr> myList = new List<hocaRpr>();
                        ToplamCiro = 0;
                        foreach (hocalarRapor_Result item in collection)
                        {
                            ToplamCiro += Convert.ToDecimal(item.satisUcreti);
                            hocaRpr rapor = new hocaRpr();
                            rapor.HocaAdı = item.adi;
                            rapor.HocaSoyadı = item.soyadi;
                            rapor.HocaTelefonu = item.telefon;
                            rapor.satısTarihi = item.tarih.ToString();
                            rapor.SatisUcreti = item.satisUcreti.ToString();
                            rapor.Toplam = ToplamCiro.ToString();
                            myList.Add(rapor);
                        }
                        dataGridView1.DataSource = myList;
                    }
                }
                else if(cmbRapor.Text == "Demirbaş Listesi")
                {
                    using (var context = new sporEntities())
                    {
                        IEnumerable<demirbasRapor_Result> collection = context.demirbasRapor(dtpTarih1.Value, dtpTarih2.Value);
                        IList<demirbasRpr> myList = new List<demirbasRpr>();
                        ToplamCiro = 0;
                        foreach (demirbasRapor_Result item in collection)
                        {
                            ToplamCiro += Convert.ToDecimal(item.fiyati);
                            demirbasRpr rapor = new demirbasRpr();
                            rapor.DemirbasAdı = item.adi;
                            rapor.DemirbasSerino = item.serino;
                            rapor.DemirbasMarkası = item.markasi;
                            rapor.DemirbasFiyatı = item.fiyati;
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
                else if (rbPdf.Checked)
                {
                    PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                    pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 90;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 1;

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        //cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                        pdfTable.AddCell(cell);
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                pdfTable.AddCell(cell.Value.ToString());
                            }
                            else
                            {
                                pdfTable.AddCell("-");
                            }
                        }
                    }
                    string folderPath = "C:\\PDFs\\";
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string wordName = "Rapor" + DateTime.Now.Millisecond;
                    using (FileStream stream = new FileStream(folderPath + wordName + ".pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(pdfTable);
                        pdfDoc.Close();
                        stream.Close();
                    }
                    MessageBox.Show("Raporunuz oluşturuldu. Dosya Yolu : C:\\PDFs\\" + wordName);
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
