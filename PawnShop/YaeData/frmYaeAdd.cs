using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawnShop.DBO;

namespace PawnShop.YaeData
{
    public partial class frmYaeAdd : Form
    {
        public frmYaeAdd()
        {
            InitializeComponent();
        }
        CodeLibrary objclsCodelibrary = new CodeLibrary();
        clsMainDB objclsMainDB = new clsMainDB();
        string SPstring;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (objclsCodelibrary.dateDiff(dateTimePicker1.Text, DateTime.Today.ToShortDateString()))
            {
                MessageBox.Show("Check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Text=DateTime.Now.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 7) 
            {
                SPstring = string.Format("SP_SelectPawn  N'{0}',N'{1}',N'{2}','{3}'", textBox1.Text.Trim(), "0", "0", "2");
                DataTable DT= new DataTable();
                DT = objclsMainDB.SelectData(SPstring);
                if(DT.Rows.Count == 0 ) 
                { 
                    MessageBox.Show("The Vourcher Do not Exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
                else 
                {
                    textBox1.Text = textBox1.Text.ToUpper();
                    lblAmount.Text=DT.Rows[0][2].ToString();
                    lblCustomerName.Text=DT.Rows[0][3].ToString();
                    lblItemName.Text= DT.Rows[0][1].ToString();
                    lblPawnDate.Text=Convert.ToDateTime(DT.Rows[0][5].ToString()).ToShortDateString();
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtInterest.Focus();
            }
        }

        private void txtInterest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotal.Focus();
            }
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNote.Focus();
            }
        }
    }
}
