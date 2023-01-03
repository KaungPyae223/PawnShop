using System;
using System.Windows.Forms;

namespace PawnShop.PawnData
{
    public partial class frmPawnSmall : Form
    {
        public frmPawnSmall()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmPawnAdd frm = new frmPawnAdd();
            frm.pawnbig=false;
            frm.ShowDialog();
        }
    }
}
