using PawnShop.DBO;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PawnShop.PawnData
{
    public partial class frmPawnBigData : Form
    {
        public frmPawnBigData()
        {
            InitializeComponent();
        }
        string SP;
        clsMainDB objclsMain = new clsMainDB();
        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmPawnAdd frm = new frmPawnAdd();
            frm.pawnbig=true;
            frm.ShowDialog();
        }

        private void frmPawnBigData_Load(object sender, EventArgs e)
        {
            
            DataTable DT;
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'","0","0", "4");
            DT = objclsMain.SelectData(SP);
            dtpFrom.Text=DT.Rows[0][0].ToString();
            ShowData();
        }
        public void ShowData()
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'",dtpFrom.Text.ToString(),dtpTo.Text.ToString(), "3");
            dgvPawn.DataSource = objclsMain.SelectData(SP);
            dgvPawn.Columns[0].Width = (dgvPawn.Width/100)*5;
            dgvPawn.Columns[1].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[2].Width = (dgvPawn.Width/100)*15;
            dgvPawn.Columns[3].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[4].Width = (dgvPawn.Width/100)*18;
            dgvPawn.Columns[5].Width = (dgvPawn.Width/100)*12;
            dgvPawn.Columns[6].Width = (dgvPawn.Width/100)*15;
            dgvPawn.Columns[7].Visible = false;
            dgvPawn.Columns[8].Visible = false;
            dgvPawn.Columns[9].Width = (dgvPawn.Width/100)*20;

          

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            
            DataTable DT;
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", dtpFrom.Text, dtpTo.Text, "5");
            DT = objclsMain.SelectData(SP);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["NO"]);
            if(DateDiff<0)
            {
                MessageBox.Show("Plese check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFrom.Focus();
            }
            else
                ShowData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            DataTable DT;
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", dtpFrom.Text, dtpTo.Text, "5");
            DT = objclsMain.SelectData(SP);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["NO"]);
            if (DateDiff<0)
            {
                MessageBox.Show("Plese check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFrom.Focus();
            }
            else
                ShowData();
        }
    }
}
