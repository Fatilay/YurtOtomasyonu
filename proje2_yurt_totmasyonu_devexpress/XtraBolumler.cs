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
using DevExpress.XtraGrid.Views.Grid;

namespace proje2_yurt_totmasyonu_devexpress
{
    public partial class XtraBolumler : DevExpress.XtraEditors.XtraForm
    {
        public XtraBolumler()
        {
            InitializeComponent();
           

        }

        sqlBaglanti bgl = new sqlBaglanti();
       
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Bolumler", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        
        
        
        
        private void XtraBolumler_Load(object sender, EventArgs e)
        {
            listele();

            // Formun genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Üst kontrollerin yüksekliği
            int topControlsHeight = 150;

            // GridControl'ün konumu ve boyutları
            int gridControlX = 10; // Soldan boşluk
            int gridControlY = topControlsHeight +80; // Üst kontrollerin altından boşluk
            int gridControlWidth = formWidth - 194; // Sağdan boşluk
            int gridControlHeight = formHeight - topControlsHeight -80; // Alt boşluk

            gridControl1.Size = new Size(gridControlWidth, gridControlHeight);
            gridControl1.Location = new Point(gridControlX, gridControlY);

          

        }





        //ekle butonu
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBolumAd.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bölüm adı giriniz!");
                    return; // Butondan çık
                }

               
                SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtBolumAd.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();

                //progress bar
                Xtraprogres fr = new Xtraprogres();
                fr.Show();

                MessageBox.Show("Bölüm eklendi");
                fr.Hide();
                listele();
            }
            catch
            {
                MessageBox.Show("Hata oluştu! Yeniden deneyin.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
            
                SqlCommand komut2 = new SqlCommand("delete from Bolumler where BolumID=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtId.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
              
                //progress bar
                Xtraprogres fr = new Xtraprogres();
                fr.Show();
                MessageBox.Show("silme işlemi gerçekleştirildi!");
                fr.Hide();
                listele();
            }
            catch
            {
                MessageBox.Show("işlem gerçekleştirilmedi!");
            }
           

        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand komut3 = new SqlCommand("update Bolumler Set BolumAd=@p1 where BolumID=@p2", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", txtBolumAd.Text);
                komut3.Parameters.AddWithValue("@p2", txtId.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                //progress bar
                Xtraprogres fr = new Xtraprogres();
                fr.Show();
                MessageBox.Show("güncelleme gerçekleşti.");
                fr.Hide();
                listele();

            }
            catch
            {
                MessageBox.Show("hata!");
            }



        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }
     
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
          
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr[0].ToString();
                txtBolumAd.Text = dr[1].ToString();

            }
        }
    }
}