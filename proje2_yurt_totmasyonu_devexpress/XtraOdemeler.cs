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
using System.Data.SqlClient;


namespace proje2_yurt_totmasyonu_devexpress
{
    public partial class XtraOdemeler : DevExpress.XtraEditors.XtraForm
    {
        public XtraOdemeler()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        sqlBaglanti bgl = new sqlBaglanti();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Borclar", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void XtraOdemeler_Load(object sender, EventArgs e)
        {
            listele();

            // Formun genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Üst kontrollerin yüksekliği
            int topControlsHeight = 150;

            // GridControl'ün konumu ve boyutları
            int gridControlX = 10; // Soldan boşluk
            int gridControlY = topControlsHeight + 60; // Üst kontrollerin altından boşluk
            int gridControlWidth = formWidth; // Sağdan boşluk
            int gridControlHeight = formHeight - topControlsHeight - 100; // Alt boşluk

            gridControl1.Size = new Size(gridControlWidth, gridControlHeight);
            gridControl1.Location = new Point(gridControlX, gridControlY);



        }

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            //ödenen tutarı kalan tutardan çıkartma
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt32(txtOdenen.Text);
            kalan = Convert.ToInt32(txtKalan.Text);
            yeniborc = kalan - odenen;
            txtKalan.Text = yeniborc.ToString();

            //yeni tutarı veritabanına kaydetme (güncelleme)
            SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where OgrID=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", txtID.Text);
            komut.Parameters.AddWithValue("@p1",txtKalan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            Xtraprogres fr = new Xtraprogres();
            fr.Show();

            MessageBox.Show("ödeme alındı.");
            fr.Hide();

            listele();

            //kasa tablosuna ekleme yapma
            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy,OdemeMiktar) values (@k1,@k2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1", txtOdenenAy.Text);
            komut2.Parameters.AddWithValue("@k2", txtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();





            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr[0].ToString();
                txtOgrenciAd.Text = dr[1].ToString();
                txtOgrenciSoyad.Text = dr[2].ToString();
                txtKalan.Text = dr[3].ToString();
               

            }
        }
    }
}