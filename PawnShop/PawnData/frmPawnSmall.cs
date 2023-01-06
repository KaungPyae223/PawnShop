using PawnShop.DBO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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

            DataTable DT;
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", "0", "0", "4");
            DT = objClsMain.SelectData(SP);
            dtpFrom.Text=DT.Rows[0][0].ToString();
            ShowData();

        }
        public void ShowData()
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "3");
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

            

            for (int i = 0; i<dgvPawn.RowCount-1; i++)
            {
                if (dgvPawn.Rows[i].Cells[7].Value.ToString().Length>0)
                {
                    dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Aquamarine;
                    dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.Black;
                }
                else
                {
                    DataTable DT;
                    SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", "0", "0", "4");
                    DT = objClsMain.SelectData(SP);
                    int diff = DateTime.Compare(Convert.ToDateTime(dgvPawn.Rows[i].Cells[6].Value.ToString()), Convert.ToDateTime(DT.Rows[0][0].ToString()));
                    if (diff < 0)
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Pink;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.Black;

                    }

                }
                if (dgvPawn.Rows[i].Cells[8].Value.ToString() != null)
                {
                    if (dgvPawn.Rows[i].Cells[8].Value.ToString().Contains("Lost Ticket"))
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Red;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.White;
                    }

                    if (dgvPawn.Rows[i].Cells[8].Value.ToString().Contains("Lost Ticket") && dgvPawn.Rows[i].Cells[7].Value.ToString().Length>0)
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.DarkBlue;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.White;
                    }
                }


            }


        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            DataTable DT;
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", dtpFrom.Text, dtpTo.Text, "5");
            DT = objClsMain.SelectData(SP);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["NO"]);
            if (DateDiff<0)
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
            DT = objClsMain.SelectData(SP);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["NO"]);
            if (DateDiff<0)
            {
                MessageBox.Show("Plese check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFrom.Focus();
            }
            else
                ShowData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
