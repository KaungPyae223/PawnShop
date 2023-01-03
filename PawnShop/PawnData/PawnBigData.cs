using PawnShop.DBO;
using System;
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
            ShowData();
        }
        public void ShowData()
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}'", "0", "3");
            dgvPawn.DataSource = objclsMain.SelectData(SP);
            dgvPawn.Columns[0].Width = (dgvPawn.Width/100)*5;
            dgvPawn.Columns[1].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[2].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[3].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[4].Width = (dgvPawn.Width/100)*20;
            dgvPawn.Columns[5].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[6].Width = (dgvPawn.Width/100)*15;
            dgvPawn.Columns[7].Visible = false;
            dgvPawn.Columns[8].Visible = false;
            dgvPawn.Columns[9].Width = (dgvPawn.Width/100)*20;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
