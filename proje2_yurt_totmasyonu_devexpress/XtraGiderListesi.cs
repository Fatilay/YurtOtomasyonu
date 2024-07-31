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
    public partial class XtraGiderListesi : DevExpress.XtraEditors.XtraForm
    {
        public XtraGiderListesi()
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

        private void XtraGiderListesi_Load(object sender, EventArgs e)
        {
            listele();


        }
    }
}