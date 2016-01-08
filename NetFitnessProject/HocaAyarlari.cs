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
    public partial class HocaAyarlari : Screen
    {
        public HocaAyarlari()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {

                using (var context = new sporEntities())
                {
                    programlar pro = new programlar();

                    if (!string.IsNullOrEmpty(txtMail.Text) && !string.IsNullOrEmpty(txtTel.Text) && !string.IsNullOrEmpty(txtCep.Text) && !string.IsNullOrEmpty(txtAdres.Text) && !string.IsNullOrEmpty(txtSifre.Text))
                    {
                        
                      //  context.guncelleme(txtTel.Text,txtCep.Text,txtAdres.Text,txtMail.Text,txtSifre.Text);
                        context.guncelleme(txtMail.Text, txtTel.Text, txtCep.Text, txtAdres.Text, txtSifre.Text);
                    MessageBox.Show("Güncelleme Başarılı");
                    }
                    else
                    {
                      

                        MessageBox.Show("Güncelleme İçin Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Güncelleme  Başarısız." + ex);
            }

           
        }

        private void HocaAyarlari_Load(object sender, EventArgs e)
        {
            sporEntities db = new sporEntities();
            try
            {
                using (var context = new sporEntities())
                {

                    context.hocalars.SqlQuery("select *from hocalar where hocaID='" + hocaGiris.ID + "')");
                    IEnumerable<hocalar> uyeListe = db.hocalars;
                    ArrayList ls = new ArrayList();
                    foreach (var item in uyeListe)
                    {
                        hocalar hc = new hocalar();
                        hc.mail = item.mail;
                        hc.telefon = item.telefon;
                        hc.cep = item.cep;
                        hc.adres = item.adres;
                        hc.sifre = item.sifre;
                        txtMail.Text = hc.mail;
                        txtTel.Text = hc.telefon;
                        txtCep.Text = hc.cep;
                        txtAdres.Text = hc.adres;
                        txtSifre.Text = hc.sifre;


                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("HATA" + ex);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            hocaGiris frm = new hocaGiris();
            frm.Show();
            this.Hide();
        }
    }
}
