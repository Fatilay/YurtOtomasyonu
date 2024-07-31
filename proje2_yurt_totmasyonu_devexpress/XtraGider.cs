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
using DevExpress.XtraGrid;

namespace proje2_yurt_totmasyonu_devexpress
{
    public partial class XtraGider : DevExpress.XtraEditors.XtraForm
    {
        public XtraGider()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Giderler", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into Giderler (Elektrik,Su,Yakıt,Internet,Gıda,Personel,Diger) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", txtSu.Text);
                komut.Parameters.AddWithValue("@p3", txtYakit.Text);
                komut.Parameters.AddWithValue("@p4", txtInternet.Text);
                komut.Parameters.AddWithValue("@p5", txtGida.Text);
                komut.Parameters.AddWithValue("@p6", txtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", txtdiger.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                //progress bar
                Xtraprogres fr = new Xtraprogres();
                fr.Show();
                MessageBox.Show("Kaydedildi.");
                fr.Hide();
                listele();


            }
            catch
            {
                MessageBox.Show("hata oluştu! yeniden deneyin");
            }
     



        }

        private void XtraGider_Load(object sender, EventArgs e)
        {
            listele();

            // Formun genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Üst kontrollerin yüksekliği
            int topControlsHeight = 150;

            // GridControl'ün konumu ve boyutları
            int gridControlX = 10; // Soldan boşluk
            int gridControlY = topControlsHeight + 110; // Üst kontrollerin altından boşluk
            int gridControlWidth = formWidth - 88; // Sağdan boşluk
            int gridControlHeight = formHeight - topControlsHeight - 120; // Alt boşluk

            gridControl1.Size = new Size(gridControlWidth, gridControlHeight);
            gridControl1.Location = new Point(gridControlX, gridControlY);


        }
    }
}