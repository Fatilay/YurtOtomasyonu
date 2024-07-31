using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace proje2_yurt_totmasyonu_devexpress
{
    public class sqlBaglanti
    {
       public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-RIO0TGM;Initial Catalog=YurtOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;

        }

    }
}
