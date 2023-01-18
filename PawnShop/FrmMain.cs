using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawnShop.PawnData;
using PawnShop.YaeData;
using PawnShop.Monthly;
namespace PawnShop
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public void loadform(Form f)
        {
            if (this.mainPannel.Controls.Count > 0)
            {
                this.mainPannel.Controls.RemoveAt(0);
            }
            
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPannel.Controls.Add(f);
            this.mainPannel.Tag = f;
            f.Show();
        }
        private void pawnBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPawnBigData frm = new frmPawnBigData();
            frm.a="SP_SelectPawn  N'{0}',N'{1}',N'{2}','{3}'";
            frm.big = true;
            loadform(frm);
            mnuPawn.Text="အပေါင်ကြီး";
            mnuPawn.BackColor=Color.Bisque;
            mnuYae.Text="‌အရွေး";
            mnuYae.BackColor=Color.Silver;
        }

        private void pawnSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPawnBigData frm = new frmPawnBigData();
            frm.a="SP_SelectPawnSmall  N'{0}',N'{1}',N'{2}','{3}'";
            frm.toolStripLabel1.Text="အပေါင်သေး";
            frm.big=false;
            loadform(frm);
            mnuPawn.Text="အပေါင်သေး";
            mnuPawn.BackColor=Color.Bisque;
            mnuYae.Text="‌အရွေး";
            mnuYae.BackColor=Color.Silver;
        }

        private void အရToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmYaeBig());
            mnuYae.Text="‌အရွေးကြီး";
            mnuYae.BackColor=Color.Bisque;
            mnuPawn.Text="အပေါင်";
            mnuPawn.BackColor=Color.Silver;
        }

        private void အရသToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmYaeBig());
            mnuYae.Text="‌အရွေးသေး";
            mnuYae.BackColor=Color.Bisque;
            mnuPawn.Text="အပေါင်";
            mnuPawn.BackColor=Color.Silver;
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmDaily());
        }
    }
}
