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
    public partial class frmDailyDetails : Form
    {
        public frmDailyDetails()
        {
            InitializeComponent();
        }

        private void frmDailyDetails_Load(object sender, EventArgs e)
        {
            dgvDetails.Rows[dgvDetails.Rows.Count- 2].DefaultCellStyle.BackColor= Color.Yellow;

        }
    }
}
