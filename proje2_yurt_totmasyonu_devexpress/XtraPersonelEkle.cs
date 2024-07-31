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
    public partial class XtraPersonelEkle : DevExpress.XtraEditors.XtraForm
    {
        public XtraPersonelEkle()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Personel", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // Personel adı alanını kontrol et
                if (string.IsNullOrEmpty(txtAdSoyad.Text))
                {
                    MessageBox.Show("Personel adı zorunlu bir alandır!");
                    return; // Metoddan çıkış yap
                }

                SqlCommand komut1 = new SqlCommand("insert into Personel (PersonelAdSoyad,PersonelDepartman) values (@p1,@p2)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                komut1.Parameters.AddWithValue("@p2", txtDepartman.Text);
               
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();

                Xtraprogres fr = new Xtraprogres();
                fr.Show();

                MessageBox.Show("Personel eklendi");
                fr.Hide();
                listele();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void XtraPersonelEkle_Load(object sender, EventArgs e)
        {
            listele();

            // Formun genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Üst kontrollerin yüksekliği
            int topControlsHeight = 150;

            // GridControl'ün konumu ve boyutları
            int gridControlX = 10; // Soldan boşluk
            int gridControlY = topControlsHeight + 50; // Üst kontrollerin altından boşluk
            int gridControlWidth = formWidth - 50; // Sağdan boşluk
            int gridControlHeight = formHeight - topControlsHeight - 120; // Alt boşluk

            gridControl1.Size = new Size(gridControlWidth, gridControlHeight);
            gridControl1.Location = new Point(gridControlX, gridControlY);
        }
    }
}