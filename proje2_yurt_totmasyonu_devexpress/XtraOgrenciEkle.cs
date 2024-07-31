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
    public partial class XtraOgrenciEkle : DevExpress.XtraEditors.XtraForm
    {
        public XtraOgrenciEkle()
        {
            InitializeComponent();
        }
       
        sqlBaglanti bgl = new sqlBaglanti();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Ogrenci", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void XtraOgrenciEkle_Load(object sender, EventArgs e)
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


            //bölümleri listeleme
            SqlCommand komut = new SqlCommand("select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbBolum.Properties.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();
             

            //boş odaları listeleme
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbOdaNo.Properties.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();


        }
        private void OdalariListele()
        {
            // Boş odaları listeleme
            cmbOdaNo.Properties.Items.Clear();
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where OdaKapasite > OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbOdaNo.Properties.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Ad ve soyad alanlarının boş olup olmadığını kontrol et
                if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text))
                {
                    MessageBox.Show("Öğrenci adı ve soyadı zorunlu alanlardır!");
                    return;
                }


                SqlCommand komut1 = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTCNo,OgrTelNo,OgrBolum,OgrDogumTarihi,OgrOdaNo,OgrEposta,OgrVeliAdSoyad,OgrVeliTelNo,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtAd.Text);
                komut1.Parameters.AddWithValue("@p2", txtSoyad.Text);
                komut1.Parameters.AddWithValue("@p3", txtTc.Text);
                komut1.Parameters.AddWithValue("@p4", txtTel.Text);
                komut1.Parameters.AddWithValue("@p5", cmbBolum.Text);
                komut1.Parameters.AddWithValue("@p6", txtDogumTarihi.Text);
                komut1.Parameters.AddWithValue("@p7", cmbOdaNo.Text);
                komut1.Parameters.AddWithValue("@p8", txtEposta.Text);
                komut1.Parameters.AddWithValue("@p9", txtVeli.Text);
                komut1.Parameters.AddWithValue("@p10", txtVeliTel.Text);
                komut1.Parameters.AddWithValue("@p11", txtAdres.Text);

                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();

                // OdaAktif değerini güncelleme
                SqlCommand komut2 = new SqlCommand("update Odalar set OdaAktif = OdaAktif + 1 where OdaNo = @odaNo", bgl.baglanti());
                komut2.Parameters.AddWithValue("@odaNo", cmbOdaNo.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();


                //öğrenci id yi label a çekme

                SqlCommand komut = new SqlCommand("select OgrId from Ogrenci",bgl.baglanti());
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    labelControl12.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();


                //öğrenci borç alanı oluşturma
                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (ogrID,OgrAd,OgrSoyad) values(@b1,@b2,@b3) ", bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", labelControl12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", txtAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3",txtSoyad.Text);  
                komutkaydet2.ExecuteNonQuery();
                bgl.baglanti().Close();

                Xtraprogres fr = new Xtraprogres();
                fr.Show();
              
                MessageBox.Show("Öğrenci eklendi");
                fr.Hide();
                listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu.Lütfen tekrar deneyin.");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           

        }
    }
}