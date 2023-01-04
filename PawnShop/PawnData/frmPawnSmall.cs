using System;
using System.Drawing;
using System.Windows.Forms;
using PawnShop.DBO;

namespace PawnShop.PawnData
{
    public partial class frmPawnSmall : Form
    {
        public frmPawnSmall()
        {
            InitializeComponent();
        }
        string SP;
        clsMainDB objClsMain = new clsMainDB();
        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmPawnAdd frm = new frmPawnAdd();
            frm.pawnbig=false;
            frm.ShowDialog();
        }

        private void frmPawnSmall_Load(object sender, EventArgs e)
        {
            ShowData();

        }
        public void ShowData()
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}'", "0", "3");
            dgvPawn.DataSource = objClsMain.SelectData(SP);
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
    }
}
