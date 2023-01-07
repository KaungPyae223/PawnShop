using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnShop.Monthly
{
    public partial class frmDaily : Form
    {
        public frmDaily()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            DailyAdd frmDailyAdd = new DailyAdd();
            frmDailyAdd.ShowDialog();

        }
    }
}
