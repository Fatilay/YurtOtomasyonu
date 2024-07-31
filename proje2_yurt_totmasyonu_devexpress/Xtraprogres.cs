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
    public partial class Xtraprogres : DevExpress.XtraEditors.XtraForm
    {
        public Xtraprogres()
        {
            InitializeComponent();
        }

        private void Xtraprogres_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            progressBarControl1.EditValue = i;
        }

        private void progressBarControl1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}