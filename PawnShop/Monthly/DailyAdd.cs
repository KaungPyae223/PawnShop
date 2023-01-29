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
        Boolean CanCulate = false;
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
            CanCulate = false;
            SP = string.Format("SP_SelectPawn  N'{0}',N'{1}',N'{2}','{3}'", dtpDate.Text.ToString(), dtpDate.Text.ToString(), "0", "3");
            calculateTotal(txtPawnBig, 3, lblPawnBig);
            SP = string.Format("SP_SelectPawnSmall  N'{0}',N'{1}',N'{2}','{3}'", dtpDate.Text.ToString(), dtpDate.Text.ToString(), "0", "3");
            calculateTotal(txtPawnSmall, 3, lblPawnSmall);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "0");
            calculateTotal(txtYaeBig, 3, lblBigYae);
            calculateTotal(txtYaeBigToe, 4, lblBigYae);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "1");
            calculateTotal(txtYaeTae, 3, lblSmallYae);
            calculateTotal(txtYaeToeTae, 4, lblSmallYae);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "2");
            calculateTotal(txtSoneBig, 3, lblBigSone);
            calculateTotal(txtSoneBigToe, 4, lblBigSone);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "3");
            calculateTotal(txtSoneSmall, 3, lblTaeSone);
            calculateTotal(txtSoneSmallToe, 4, lblTaeSone);
            fillTotalData();
            CanCulate = true;

        }
        public void calculateTotal(TextBox bt, int index, Label lbl)
        {
            int total = 0;
            DataTable DT = new DataTable();
            DT=objclsMain.SelectData(SP);
            lbl.Text = lbl.Text +" ("+DT.Rows.Count+")";

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

        private void label1_Click(object sender, EventArgs e)
        {

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
    }
}
