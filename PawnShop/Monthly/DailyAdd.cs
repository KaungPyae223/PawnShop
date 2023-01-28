using PawnShop.DBO;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
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
            calculateTotal(txtPawnBig, 3);
            SP = string.Format("SP_SelectPawnSmall  N'{0}',N'{1}',N'{2}','{3}'", dtpDate.Text.ToString(), dtpDate.Text.ToString(), "0", "3");
            calculateTotal(txtPawnSmall, 3);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "0");
            calculateTotal(txtYaeBig, 3);
            calculateTotal(txtYaeBigToe, 4);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "1");
            calculateTotal(txtYaeTae, 3);
            calculateTotal(txtYaeToeTae, 4);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "2");
            calculateTotal(txtSoneBig, 3);
            calculateTotal(txtSoneBigToe, 4);
            SP = string.Format("SP_SelectDailyAdd N'{0}', N'{1}'", dtpDate.Text.ToString(), "3");
            calculateTotal(txtSoneSmall, 3);
            calculateTotal(txtSoneSmallToe, 4);
            fillTotalData();
            CanCulate = true;

        }
        public void calculateTotal(TextBox bt, int index)
        {
            int total = 0;
            DataTable DT = new DataTable();
            DT=objclsMain.SelectData(SP);
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
            if(int.TryParse(txt.Text, out OK)==false)
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
            if(txtNgaeYin.Text != string.Empty)
            {
                if (checkint(txtNgaeYin))
                {
                    fillTotalData();
                }
            }
        }

        private void txtInterest_TextChanged(object sender, EventArgs e)
        {
            if(txtInterest.Text!=string.Empty)
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

        
    }
}
