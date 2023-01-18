using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawnShop.YaeData
{
    public partial class frmYaeBig : Form
    {
        public frmYaeBig()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmYaeAdd frm = new frmYaeAdd();
            frm.ShowDialog();
        }
    }
}
