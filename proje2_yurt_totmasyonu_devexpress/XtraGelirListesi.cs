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
    public partial class XtraGelirListesi : DevExpress.XtraEditors.XtraForm
    {
        public XtraGelirListesi()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kasa", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void XtraGelirListesi_Load(object sender, EventArgs e)
        {
            listele();

        }
    }
}