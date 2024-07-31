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
    public partial class XtraPersonelDuzenle : DevExpress.XtraEditors.XtraForm
    {
        public XtraPersonelDuzenle()
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
        private void XtraPersonelDuzenle_Load(object sender, EventArgs e)
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
            int gridControlHeight = formHeight - topControlsHeight - 200; // Alt boşluk

            gridControl1.Size = new Size(gridControlWidth, gridControlHeight);
            gridControl1.Location = new Point(gridControlX, gridControlY);


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr[0].ToString();
                txtAdSoyad.Text = dr[1].ToString();
                txtDepartman.Text = dr[2].ToString();
                
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("update Personel set PersonelAdSoyad=@p2,PersonelDepartman=@p3 where PersonelID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p3", txtDepartman.Text);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                //progress bar
                Xtraprogres fr = new Xtraprogres();
                fr.Show();
                MessageBox.Show("düzenleme işlemi gerçekleştirildi!");
                fr.Hide();

                listele();


            }
            catch (Exception)
            {
                MessageBox.Show("işlem gerçekleştirilmedi!");

            }
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut2 = new SqlCommand("delete from Personel where PersonelID=@p1", bgl.baglanti());
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
    }
}