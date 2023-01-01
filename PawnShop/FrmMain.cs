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

namespace PawnShop
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (this.mainPannel.Controls.Count > 0)
            {
                this.mainPannel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPannel.Controls.Add(f);
            this.mainPannel.Tag = f;
            f.Show();
        }
        private void pawnBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmPawnBigData());
            mnuPawn.Text="အပေါင်ကြီး";
            mnuPawn.BackColor=Color.Bisque;
            mnuYae.Text="‌အရွေး";
            mnuYae.BackColor=Color.Silver;
        }

        private void pawnSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmPawnSmall());
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
            loadform(new frmYaeSmall());
            mnuYae.Text="‌အရွေးသေး";
            mnuYae.BackColor=Color.Bisque;
            mnuPawn.Text="အပေါင်";
            mnuPawn.BackColor=Color.Silver;
        }
    }
}
