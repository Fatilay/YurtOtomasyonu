using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace proje2_yurt_totmasyonu_devexpress
{
    public partial class XtraHome : DevExpress.XtraEditors.XtraForm
    {
        public XtraHome()
        {
            InitializeComponent();
        }
      

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        XtraOgrenciListesi fr5;
        private void btnOgrenciListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new XtraOgrenciListesi();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        XtraBolumler fr2;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new XtraBolumler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }
        XtraBolumler fr3;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new XtraBolumler();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }

        private void XtraHome_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
        }


        //ödemeler

        XtraOdemeler fr4;
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new XtraOdemeler();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }


        XtraOgrenciEkle fr;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new XtraOgrenciEkle();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        XtraOgrenciDuzenleme fr6;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new XtraOgrenciDuzenleme();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        XtraGider fr7;
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new XtraGider();
                fr7.MdiParent = this;
                fr7.Show();
            }

        }

        XtraGiderListesi fr8;
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr8 == null || fr8.IsDisposed)
            {
                fr8 = new XtraGiderListesi();
                fr8.MdiParent = this;
                fr8.Show();
            }
           

        }

        //XtraChart fr9;
        //private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    fr9 = new XtraChart();
        //    fr9.MdiParent = this;
        //    fr9.Show();

        //}

        XtraGelirListesi fr10;
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fr10 == null || fr10.IsDisposed)
            {
                fr10 = new XtraGelirListesi();
                fr10.MdiParent = this;
                fr10.Show();
            }
           
        }

        XtraPersonelDuzenle fr11;
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new XtraPersonelDuzenle();
                fr11.MdiParent = this;
                fr11.Show();
            }
           
        }


        XtraPersonelEkle fr12;
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new XtraPersonelEkle();
                fr12.MdiParent = this;
                fr12.Show();
            }
            
        }

        XtraGorseller fr13;
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                fr13 = new XtraGorseller();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }

        XtraMap fr14;
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new XtraMap();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }
    }
}