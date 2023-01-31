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
using PawnShop.DBO;

namespace PawnShop
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        clsMainDB objClsMain = new clsMainDB();
        CodeLibrary objClsCodeLibrary = new CodeLibrary();
        string SP;
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
            SP = string.Format("SP_SelectPawn  N'{0}',N'{1}',N'{2}','{3}'", Convert.ToDateTime(objClsCodeLibrary.LastSixMonthes()).ToShortTimeString(), DateTime.Now.ToString(), "0", "3");
            MakePawndgv(frm.dgvPawn);
            loadform(frm);
            mnuPawn.Text="အပေါင်ကြီး";
            mnuPawn.BackColor=Color.Bisque;
            mnuYae.Text="‌အရွေး";
            mnuYae.BackColor=Color.Silver;
        }
        public void MakePawndgv(DataGridView dgvPawn)
        {
            DataGridViewTextBoxColumn dgcol = new DataGridViewTextBoxColumn();
            dgcol.DefaultCellStyle.NullValue="+";
            dgcol.HeaderText="";
            dgcol.Width=30;
            dgcol.ReadOnly=true;
            dgcol.DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
            dgvPawn.Columns.Add(dgcol);

            dgvPawn.DataSource = objClsMain.SelectData(SP);
        }

        private void pawnSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPawnBigData frm = new frmPawnBigData();
            frm.a="SP_SelectPawnSmall  N'{0}',N'{1}',N'{2}','{3}'";
            frm.toolStripLabel1.Text="အပေါင်သေး";
            frm.big=false;
            SP = string.Format("SP_SelectPawnSmall  N'{0}',N'{1}',N'{2}','{3}'", Convert.ToDateTime(objClsCodeLibrary.LastSixMonthes()).ToShortTimeString(), DateTime.Now.ToString(), "0", "3");
            MakePawndgv(frm.dgvPawn);
            loadform(frm);
            mnuPawn.Text="အပေါင်သေး";
            mnuPawn.BackColor=Color.Bisque;
            mnuYae.Text="‌အရွေး";
            mnuYae.BackColor=Color.Silver;
        }

        private void အရToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYaeBig frm = new frmYaeBig("SP_SelectPawn  N'{0}',N'{1}',N'{2}','{3}'", "SelectYaeBig N'{0}', N'{1}', N'{2}'",true);
            frm.vourchertype="BigVourcherID";
            frm.toolStripLabel1.Text = "‌အရွေးကြီး";
            SP = string.Format("SelectYaeBig N'{0}', N'{1}', N'{2}'", Convert.ToDateTime(objClsCodeLibrary.LastSixMonthes()).ToShortTimeString(), DateTime.Now.ToString(), "1");

            MakePawndgv(frm.dgvYae);
            loadform(frm);
            mnuYae.Text="‌အရွေးကြီး";
            mnuYae.BackColor=Color.Bisque;
            mnuPawn.Text="အပေါင်";
            mnuPawn.BackColor=Color.Silver;
        }

        private void အရသToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmYaeBig frm = new frmYaeBig("SP_SelectPawn  N'{0}',N'{1}',N'{2}','{3}'", "SP_SelectYaeSmall N'{0}', N'{1}', N'{2}'",false);
            frm.toolStripLabel1.Text = "‌အရွေးသေး";
            SP = string.Format("SP_SelectYaeSmall N'{0}', N'{1}', N'{2}'", Convert.ToDateTime(objClsCodeLibrary.LastSixMonthes()).ToShortTimeString(), DateTime.Now.ToString(), "1");

            MakePawndgv(frm.dgvYae);
            loadform(frm);
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
