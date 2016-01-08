using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace GRAFİK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.chart1.Series.Clear();
            comboBox1.Items.Add("Satışlar");
            comboBox1.Items.Add("Demirbaş");
            comboBox1.Items.Add("cinsiyet");
            comboBox1.Items.Add("En Cok Satılan Paketler");
            comboBox1.Items.Add("En Cok Hitap Edilen Yaş ve Cinsiyetler");
            comboBox1.Items.Add("Derslerin Doluluk Oranları");

        }



        public void doldur()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            this.chart1.Titles.Clear();//Chart da varsayılan olarak gelen başlıkları temizliyoruz.
            this.chart1.Series.Clear();//Chart da varsayılan olarak gelen series (Liste) temizliyoruz.

            if (comboBox1.SelectedIndex == 0)
            {


                using (var contex = new sporEntities())
                {
                    dataGridView1.DataSource = contex.satış(dateTimePicker1.Value, dateTimePicker2.Value);

                    string[] x = new string[dataGridView1.Rows.Count];
                    int[] y = new int[dataGridView1.Rows.Count];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        x[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        y[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                    }
                    this.chart1.Series.Add("satış");
                    chart1.Series[0].Points.DataBindXY(x, y);
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    chart1.Titles.Add("satışlar");
                    chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    chart1.Legends[0].Enabled = true;
                }




            }
            else

                if (comboBox1.SelectedIndex == 1)
                {
                    using (var contex = new sporEntities())
                    {
                        dataGridView1.DataSource = contex.Demirbas(dateTimePicker1.Value, dateTimePicker2.Value);

                        string[] x = new string[dataGridView1.Rows.Count];
                        int[] y = new int[dataGridView1.Rows.Count];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            x[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            y[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                        }
                        this.chart1.Series.Add("Demirbaş");
                        chart1.Series[0].Points.DataBindXY(x, y);
                        chart1.Series[0].ChartType = SeriesChartType.Pie;
                        chart1.Titles.Add("Demirbaş");
                        chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                        chart1.Legends[0].Enabled = true;
                    }

                }
                else
                    if (comboBox1.SelectedIndex == 2)
                    {
                        using (var contex = new sporEntities())
                        {
                            dataGridView1.DataSource = contex.UyelerCinsiyett(dateTimePicker1.Value, dateTimePicker2.Value);

                            string[] x = new string[dataGridView1.Rows.Count];
                            int[] y = new int[dataGridView1.Rows.Count];
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                x[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                y[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                            }
                            this.chart1.Series.Add("CİNSİYET");
                            chart1.Series[0].Points.DataBindXY(x, y);
                            chart1.Series[0].ChartType = SeriesChartType.Column;
                            chart1.Titles.Add("En Çok Satılan Paketler");
                            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                            chart1.Legends[0].Enabled = true;
                        }

                    }
                    else
                        if (comboBox1.SelectedIndex == 3)
                        {
                            using (var contex = new sporEntities())
                            {
                                dataGridView1.DataSource = contex.EnCokSatilanPaket(dateTimePicker1.Value, dateTimePicker2.Value);

                                string[] x = new string[dataGridView1.Rows.Count];
                                int[] y = new int[dataGridView1.Rows.Count];
                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                {
                                    x[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                    y[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                                }
                                this.chart1.Series.Add("Paketler");
                                chart1.Series[0].Points.DataBindXY(x, y);
                                chart1.Series[0].ChartType = SeriesChartType.Pyramid;
                                chart1.Titles.Add("En Çok Satılan Paketler");
                                chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                                chart1.Legends[0].Enabled = true;
                            }
                        }
                        else
                            if (comboBox1.SelectedIndex == 4)
                            {
                                using (var contex = new sporEntities())
                                {
                                    dataGridView1.DataSource = contex.UyeYasDagılımı(dateTimePicker1.Value, dateTimePicker2.Value);

                                    string[] x = new string[dataGridView1.Rows.Count];
                                    int[] y = new int[dataGridView1.Rows.Count];
                                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                    {
                                        x[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                        y[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                                    }
                                    this.chart1.Series.Add("Yaş Dağılımı");
                                    chart1.Series[0].Points.DataBindXY(x, y);
                                    chart1.Series[0].ChartType = SeriesChartType.Line;
                                    chart1.Titles.Add("En Çok Satılan Paketler");
                                    chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                                    chart1.Legends[0].Enabled = true;
                                }

                            }
                            else
                                if (comboBox1.SelectedIndex == 5)
                                {
                                    using (var contex = new sporEntities())
                                    {
                                        dataGridView1.DataSource = contex.doluluk(dateTimePicker1.Value, dateTimePicker2.Value);

                                        string[] x = new string[dataGridView1.Rows.Count];
                                        int[] y = new int[dataGridView1.Rows.Count];
                                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                        {
                                            x[i] = dataGridView1.Rows[i].Cells[3].Value.ToString();
                                            y[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                                        }
                                        this.chart1.Series.Add("Doluluk Oranı");
                                        chart1.Series[0].Points.DataBindXY(x, y);
                                        chart1.Series[0].ChartType = SeriesChartType.Column;
                                        chart1.Titles.Add("En Çok Satılan Paketler");
                                        chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                                        chart1.Legends[0].Enabled = true;
                                    }

                                }

        }





    }
}

