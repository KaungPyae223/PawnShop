using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawnShop.DBO;
namespace PawnShop.Monthly
{
    public partial class frmDaily : Form
    {
        public frmDaily()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            DailyAdd frmDailyAdd = new DailyAdd();
            frmDailyAdd.ShowDialog();

        }
        readonly clsMainDB objclsMainDB = new clsMainDB();
        readonly CodeLibrary objclsCodeLibary = new CodeLibrary();

        DataTable DT = new DataTable();
        String SP;
        private void frmDaily_Load(object sender, EventArgs e)
        {
            SP=string.Format("SP_SelectDaily N'{0}',N'{1}'", dtpFrom.Text.ToString(), "0");
            DT = objclsMainDB.SelectData(SP);
            dtpFrom.Text = DT.Rows[0][0].ToString();
            SP=string.Format("SP_SelectDaily N'{0}',N'{1}'", dtpFrom.Text.ToString(), "1");
            DT = objclsMainDB.SelectData(SP);
            dtpTo.Text = DT.Rows[0][0].ToString();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (objclsCodeLibary.dateDiff(dtpTo.Text, DateTime.Today.ToShortDateString()))
            {
                MessageBox.Show("Check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpTo.Text=DateTime.Now.ToString();
            }
            else
            {
                SP=string.Format("SP_SelectDaily N'{0}',N'{1}'", dtpFrom.Text.ToString(), "0");
                DT = objclsMainDB.SelectData(SP);
                dtpFrom.Text = DT.Rows[0][0].ToString();
            }    
            
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            
            
                SP=string.Format("SP_SelectDaily N'{0}',N'{1}'", dtpTo.Text.ToString(), "1");
                DT = objclsMainDB.SelectData(SP);
                dtpTo.Text = DT.Rows[0][0].ToString();
            
        }
    }
}
