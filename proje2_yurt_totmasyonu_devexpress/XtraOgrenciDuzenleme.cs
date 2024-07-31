using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace proje2_yurt_totmasyonu_devexpress
{
    public partial class XtraOgrenciDuzenleme : DevExpress.XtraEditors.XtraForm
    {
        public XtraOgrenciDuzenleme()
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

        

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr[0].ToString();
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                txtTc.Text = dr[3].ToString();
                txtTel.Text = dr[4].ToString();
                cmbBolum.Text = dr[5].ToString();
                txtDogumTarihi.Text = dr[6].ToString();
                cmbOdaNo.Text = dr[7].ToString();
                txtEposta.Text = dr[8].ToString();
                txtVeli.Text = dr[9].ToString();
                txtVeliTel.Text = dr[10].ToString();
                txtAdres.Text = dr[11].ToString();

            }
        }

        private void XtraOgrenciDuzenleme_Load(object sender, EventArgs e)
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
            int gridControlWidth = formWidth - 35; // Sağdan boşluk
            int gridControlHeight = formHeight - topControlsHeight - 200; // Alt boşluk

            gridControl1.Size = new Size(gridControlWidth, gridControlHeight);
            gridControl1.Location = new Point(gridControlX, gridControlY);



            //boş odaları listeleme
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbOdaNo.Properties.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();




            //bölümleri listeleme
            SqlCommand komut = new SqlCommand("select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbBolum.Properties.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();






        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2,OgrSoyad=@p3,OgrTCNo=@p4,OgrTelNo=@p5,OgrBolum=@p6,OgrDogumTarihi=@p7,OgrOdaNo=@p8,OgrEposta=@p9,OgrVeliAdSoyad=@p10,OgrVeliTelNo=@p11,OgrVeliAdres=@p12 where OgrId=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.Parameters.AddWithValue("@p2", txtAd.Text);
                komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p4", txtTc.Text);
                komut.Parameters.AddWithValue("@p5", txtTel.Text);
                komut.Parameters.AddWithValue("@p6", cmbBolum.Text);
                komut.Parameters.AddWithValue("@p7", txtDogumTarihi.Text);
                komut.Parameters.AddWithValue("@p8", cmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p9", txtEposta.Text);
                komut.Parameters.AddWithValue("@p10", txtVeli.Text);
                komut.Parameters.AddWithValue("@p11", txtVeliTel.Text);
                komut.Parameters.AddWithValue("@p12", txtAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                //progress bar
                Xtraprogres fr = new Xtraprogres();
                fr.Show();
                MessageBox.Show("düzenleme işlemi gerçekleştirildi!");
                fr.Hide();

                listele();

            }
            catch
            {
                MessageBox.Show("işlem gerçekleştirilmedi!");
            }
           





        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {

            try
            {

                SqlCommand komut2 = new SqlCommand("delete from Ogrenci where OgrId=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtId.Text);

                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //progress bar
                Xtraprogres fr = new Xtraprogres();
                fr.Show();
                MessageBox.Show("silme işlemi gerçekleştirildi!");
                fr.Hide();

                //oda kontenjanı azaltma
                SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif = OdaAktif-1 where OdaNo=@oda", bgl.baglanti());
                komutoda.Parameters.AddWithValue("@oda", cmbOdaNo.Text);
                komutoda.ExecuteNonQuery();
                bgl.baglanti().Close();

                // borç kaydını silme
                SqlCommand komutborc = new SqlCommand("delete from Borclar where ogrID=@p1", bgl.baglanti());
                komutborc.Parameters.AddWithValue("@p1", txtId.Text);
                komutborc.ExecuteNonQuery();
                bgl.baglanti().Close();


                listele();
            }
            catch
            {
                MessageBox.Show("işlem gerçekleştirilmedi!");

            }

        }
    }
}