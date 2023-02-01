using PawnShop.DBO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace PawnShop.Monthly
{
    public partial class DailyAdd : Form
    {
        public DailyAdd()
        {
            InitializeComponent();
        }
        clsMainDB objclsMain = new clsMainDB();
        string SP;
        readonly CodeLibrary objclsCodeLibary = new CodeLibrary();
        Boolean IsEdit = false;
        
        private void DailyAdd_Load(object sender, EventArgs e)
        {
            this.Size=new Size(530, 700);
            int h = Screen.PrimaryScreen.Bounds.Size.Height;
            int screenwidth = Screen.PrimaryScreen.Bounds.Size.Width;
            int formh = this.Height;
            int fontwidth = this.Width;
            this.Location=new Point((screenwidth-fontwidth)/2, (h-formh)/2);
            filldata();
        }
        public void fillTotalData()
        {

            int total = 0;
            total += Convert.ToInt32(txtYaeBig.Text);
            total += Convert.ToInt32(txtYaeBigToe.Text);
            total += Convert.ToInt32(txtYaeTae.Text);
            total += Convert.ToInt32(txtYaeToeTae.Text);
            total += Convert.ToInt32(txtSoneBig.Text);
            total += Convert.ToInt32(txtSoneBigToe.Text);
            total += Convert.ToInt32(txtSoneSmall.Text);
            total += Convert.ToInt32(txtSoneSmallToe.Text);
            total += Convert.ToInt32(txtNgaeYin.Text);
            txtTotalWinNgwe.Text = total.ToString();
            total = 0;
            total += Convert.ToInt32(txtPawnBig.Text);
            total += Convert.ToInt32(txtPawnSmall.Text);
            total += Convert.ToInt32(txtInterest.Text);
            total += Convert.ToInt32(txtUsage.Text);
            txtOutputmoney.Text = total.ToString();
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "4");
            DataTable DT = new DataTable();
            DT = objclsMain.SelectData(SP);
            int latkyan = Convert.ToInt32(DT.Rows[0][0].ToString());
            int final = (Convert.ToInt32(txtTotalWinNgwe.Text)+latkyan)-Convert.ToInt32(txtOutputmoney.Text);
            txtLatKyan.Text = final.ToString();
        }

        public void filldata()
        {
            SP = string.Format("SP_SelectPawn  N'{0}',N'{1}',N'{2}','{3}'", dtpDate.Text.ToString(), dtpDate.Text.ToString(), "0", "3");
            calculateTotal(txtPawnBig, 3, lblPawnBigQty);
            SP = string.Format("SP_SelectPawnSmall  N'{0}',N'{1}',N'{2}','{3}'", dtpDate.Text.ToString(), dtpDate.Text.ToString(), "0", "3");
            calculateTotal(txtPawnSmall, 3, lblPawnTaeQty);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "0");
            calculateTotal(txtYaeBig, 3, lblKyeeQty);
            calculateTotal(txtYaeBigToe, 4, lblKyeeQty);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "1");
            calculateTotal(txtYaeTae, 3, lblSmallQty);
            calculateTotal(txtYaeToeTae, 4, lblSmallQty);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "2");
            calculateTotal(txtSoneBig, 3, lblKyeeSoneQty);
            calculateTotal(txtSoneBigToe, 4, lblKyeeSoneQty);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "3");
            calculateTotal(txtSoneSmall, 3, lblTaeSoneQty);
            calculateTotal(txtSoneSmallToe, 4, lblTaeSoneQty);
            fillTotalData();

        }
        public void calculateTotal(TextBox bt, int index, Label lbl)
        {
            int total = 0;
            DataTable DT = new DataTable();
            DT=objclsMain.SelectData(SP);
            lbl.Text = "("+DT.Rows.Count+")";

            foreach (DataRow DR in DT.Rows)
            {
                total += Convert.ToInt32(DR[index].ToString());
            }
            bt.Text= total.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (objclsCodeLibary.dateDiff(dtpDate.Text, DateTime.Today.ToShortDateString()))
            {
                MessageBox.Show("Check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDate.Text=DateTime.Now.ToString();
            }
            filldata();
        }

        

        private void txtInterest_Leave(object sender, EventArgs e)
        {
            if (txtInterest.Text==string.Empty)
            {
                txtInterest.Text="0";
            }
        }

        private void txtUsage_Leave(object sender, EventArgs e)
        {
            if (txtUsage.Text==string.Empty)
            {
                txtUsage.Text="0";
            }
        }

        private void txtNgaeYin_Leave(object sender, EventArgs e)
        {
            if (txtNgaeYin.Text==string.Empty)
            {
                txtNgaeYin.Text="0";
            }
        }

        private void txtInterest_Click(object sender, EventArgs e)
        {
            if (txtInterest.Text=="0")
            {
                txtInterest.Text="";
            }
        }

        private void txtUsage_Click(object sender, EventArgs e)
        {

            if (txtUsage.Text=="0")
            {
                txtUsage.Text="";
            }
        }

        private void txtNgaeYin_Click(object sender, EventArgs e)
        {
            if (txtNgaeYin.Text=="0")
            {
                txtNgaeYin.Text="";
            }
        }


        public Boolean checkint(TextBox txt)
        {
            int OK;
            if (int.TryParse(txt.Text, out OK)==false)
            {
                MessageBox.Show("Check input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Text= "";
                txt.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtNgaeYin_TextChanged(object sender, EventArgs e)
        {
            if (txtNgaeYin.Text != string.Empty)
            {
                if (checkint(txtNgaeYin))
                {
                    fillTotalData();
                }
            }
        }

        private void txtInterest_TextChanged(object sender, EventArgs e)
        {
            if (txtInterest.Text!=string.Empty)
            {
                if (checkint(txtInterest))
                {
                    fillTotalData();
                }
            }
        }

        private void txtUsage_TextChanged(object sender, EventArgs e)
        {
            if (txtUsage.Text!=string.Empty)
            {
                if (checkint(txtUsage))
                {
                    fillTotalData();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "5");
            DataTable DT = new DataTable();
            DT = objclsMain.SelectData(SP);
            if (DT.Rows.Count > 0  && IsEdit == false)
            {
                MessageBox.Show("The data in "+dtpDate.Text+" is already exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDate.Focus();
            }
            else
            {
                clsDaily objclsDaily = new clsDaily();
                objclsDaily.YaeSmall = Convert.ToInt32(txtYaeTae.Text.ToString());
                objclsDaily.InsertSmall = Convert.ToInt32(txtYaeToeTae.Text.ToString());
                objclsDaily.YaeBig = Convert.ToInt32(txtYaeBig.Text.ToString());
                objclsDaily.InsertBig = Convert.ToInt32(txtYaeBigToe.Text.ToString());
                objclsDaily.SoneBig = Convert.ToInt32(txtSoneBig.Text.ToString());
                objclsDaily.SoneBigIntert = Convert.ToInt32(txtYaeBigToe.Text.ToString());
                objclsDaily.SoneSmall = Convert.ToInt32(txtSoneSmall.Text.ToString());
                objclsDaily.SoneSmallIntert = Convert.ToInt32(txtSoneSmallToe.Text.ToString());
                objclsDaily.TotalIncome = Convert.ToInt32(txtTotalWinNgwe.Text.ToString());
                objclsDaily.MainBalance = Convert.ToInt32(txtNgaeYin.Text.ToString());
                objclsDaily.PawnSmall = Convert.ToInt32(txtPawnSmall.Text.ToString());
                objclsDaily.PawnBig = Convert.ToInt32(txtPawnBig.Text.ToString());
                objclsDaily.Usage = Convert.ToInt32(txtUsage.Text.ToString());
                objclsDaily.TotalOutPut = Convert.ToInt32(txtOutputmoney.Text.ToString());
                objclsDaily.LatKyan = Convert.ToInt32(txtLatKyan.Text.ToString());
                objclsDaily.SarYinDate = dtpDate.Value.ToShortDateString();
                if (IsEdit)
                {

                }
                else
                {

                    objclsDaily.action=0;
                }
                if (MessageBox.Show("Please confirm to save", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    objclsDaily.saveData();
                    this.Close();
                }

            }
        }

        private void lblSmallYae_Click(object sender, EventArgs e)
        {
            frmDailyDetails frm = new frmDailyDetails();
            frm.Text = "Yae Tae Details";
            frm.lblDetails.Text = "Yae Tae data on "+dtpDate.Value.ToShortDateString();
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "1");
            Yaedgvformat(frm.dgvDetails);

            frm.ShowDialog();
        }
        private void Yaedgvformat(DataGridView dgv)
        {
            int total = 0;
            int total1 = 0;

            DataTable DT = new DataTable();
            DT = objclsCodeLibary.SelectData(SP);
            DataRow DRdata = DT.NewRow();
            foreach(DataRow dr in DT.Rows)
            {
                total += Convert.ToInt32(dr[3]);
                total1 += Convert.ToInt32(dr[4]);

            }
            DRdata[3] = total.ToString();
            DRdata[4] = total1.ToString();

            DRdata[2] = "Total";
            DT.Rows.Add(DRdata);
            dgv.DataSource= DT;
            dgv.Columns[0].Width = (dgv.Width/100)*20;
            dgv.Columns[1].Width = (dgv.Width/100)*25;
            dgv.Columns[2].Width = (dgv.Width/100)*25;
            dgv.Columns[3].Width = (dgv.Width/100)*15;
            dgv.Columns[4].Width = (dgv.Width/100)*15;
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void lblBigYae_Click(object sender, EventArgs e)
        {
            frmDailyDetails frm = new frmDailyDetails();
            frm.Text = "Yae Kyee Details";
            frm.lblDetails.Text = "Yae Kyee data on "+dtpDate.Value.ToShortDateString();
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "0");
            Yaedgvformat(frm.dgvDetails);

            frm.ShowDialog();
        }

        private void lblBigSone_Click(object sender, EventArgs e)
        {
            frmDailyDetails frm = new frmDailyDetails();
            frm.Text = "Yae Kyee Sone Details";
            frm.lblDetails.Text = "Yae Kyee Sone data on "+dtpDate.Value.ToShortDateString();
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "2");
            Yaedgvformat(frm.dgvDetails);

            frm.ShowDialog();
        }

        private void lblTaeSone_Click(object sender, EventArgs e)
        {
            frmDailyDetails frm = new frmDailyDetails();
            frm.Text = "Yae Tae Sone Details";
            frm.lblDetails.Text = "Yae Tae Sone data on "+dtpDate.Value.ToShortDateString();
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "3");
            Yaedgvformat(frm.dgvDetails);

            frm.ShowDialog();
        }

        private void lblPawnSmall_Click(object sender, EventArgs e)
        {
            frmDailyDetails frm = new frmDailyDetails();
            frm.Text = "Pawn Small Details";
            frm.lblDetails.Text = "Pawn Small data on "+dtpDate.Value.ToShortDateString();
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "7");
            PawnDgvformat(frm.dgvDetails);

            frm.ShowDialog();
        }
        public void PawnDgvformat(DataGridView dgv)
        {
            DataTable DT = new DataTable();
            DataRow DRdata;
            DT = objclsMain.SelectData(SP);
            DRdata = DT.NewRow();
            int total = 0;
            foreach (DataRow Dr in DT.Rows)
            {
                total += Convert.ToInt32(Dr[3]);
            }
            DRdata[3] = total.ToString();
            DRdata[2] = "Total";
            DT.Rows.Add(DRdata);
            dgv.DataSource= DT;
            dgv.Columns[0].Width = (dgv.Width/100)*20;
            dgv.Columns[1].Width = (dgv.Width/100)*30;
            dgv.Columns[2].Width = (dgv.Width/100)*30;
            dgv.Columns[3].Width = (dgv.Width/100)*20;
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void lblPawnBig_Click(object sender, EventArgs e)
        {
            frmDailyDetails frm = new frmDailyDetails();
            frm.Text = "Pawn Big Details";
            frm.lblDetails.Text = "Pawn Big data on "+dtpDate.Value.ToShortDateString();
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "6");
            PawnDgvformat(frm.dgvDetails);
            frm.ShowDialog();
        }
    }
}
