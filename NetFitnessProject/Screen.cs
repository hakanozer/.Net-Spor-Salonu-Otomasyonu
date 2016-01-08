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
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            menuStrip1.ForeColor = Color.MediumSpringGreen;
            menuStrip1.Renderer = new MyRenderer();
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.White; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemBorder
            {
                get
                {
                    return Color.Gray;
                }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.DarkGray;
                }
            }
        }

        private void kategoriKontrolüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kategori_Kontrol kKontrol = new kategori_Kontrol();
            kKontrol.DesktopLocation = this.DesktopLocation;
            kKontrol.Visible = true;
            this.Hide();
        }

        private void demirbaşKontrolüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            demirbaslarKontrol dKontrol = new demirbaslarKontrol();
            dKontrol.DesktopLocation = this.DesktopLocation;
            dKontrol.Visible = true;
            this.Hide();
        }

        private void kayıtDondurmaSilmeDevretmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UyelikIslemleri uyeKontrol = new UyelikIslemleri();
            uyeKontrol.DesktopLocation = this.DesktopLocation;
            uyeKontrol.Visible = true;
            this.Hide();
        }

        private void paketSatışKontrolüSüreEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satis stsKontrol = new Satis();
            stsKontrol.DesktopLocation = this.DesktopLocation;
            stsKontrol.Visible = true;
            this.Hide();
        }

        private void branşKontrolüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bansKonrol stsKontrol = new bansKonrol();
            stsKontrol.DesktopLocation = this.DesktopLocation;
            stsKontrol.Visible = true;
            this.Hide();
        }

        private void hocaKontrolüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HocaKontrol stsKontrol = new HocaKontrol();
            stsKontrol.DesktopLocation = this.DesktopLocation;
            stsKontrol.Visible = true;
            this.Hide();
        }

        private void paketKontrolüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaketKontrol stsKontrol = new PaketKontrol();
            stsKontrol.DesktopLocation = this.DesktopLocation;
            stsKontrol.Visible = true;
            this.Hide();
        }

        private void üyeliğiBitenlerİçinMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mailto mail = new mailto();
            mail.DesktopLocation = this.DesktopLocation;
            mail.Visible = true;
            this.Hide();
        }

        private void üyeKontrolüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uyePanel uyepanel = new uyePanel();
            uyepanel.DesktopLocation = this.DesktopLocation;
            uyepanel.Visible = true;
            this.Hide();
        }

        private void haritaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Harita map = new Harita();
            map.DesktopLocation = this.DesktopLocation;
            map.Visible = true;
            this.Hide();
        }

        private void güvenliÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminGiris giris = new adminGiris();
            giris.Visible = true;
            this.Hide();
        }

        private void ayarlarŞifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SifreDegis pswrd = new SifreDegis();
            pswrd.DesktopLocation = this.DesktopLocation;
            pswrd.Visible = true;
            this.Hide();
        }

        private void resimDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResimCek image = new ResimCek();
            image.Visible = true;
            this.Hide();
        }

        private void programYedeğiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backUpKontrol backKntrl = new backUpKontrol();
            backKntrl.DesktopLocation = this.DesktopLocation;
            backKntrl.Visible = true;
            this.Hide();
        }

        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupRapor backRpr = new BackupRapor();
            backRpr.DesktopLocation = this.DesktopLocation;
            backRpr.Visible = true;
            this.Hide();
        }

        private void üyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UyeForm1 backRpr = new UyeForm1();
            backRpr.DesktopLocation = this.DesktopLocation;
            backRpr.Visible = true;
            this.Hide();
        }

        private void şirketBilgileriKontrolüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sirketBilgileriDuzenle backRpr = new sirketBilgileriDuzenle();
            backRpr.DesktopLocation = this.DesktopLocation;
            backRpr.Visible = true;
            this.Hide();
        }
    }
}
