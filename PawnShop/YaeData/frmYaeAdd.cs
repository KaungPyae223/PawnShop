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
        public Boolean isEdit = false;
        public Boolean Big = true;
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
                    txtInterest.Focus();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveData();
        }
        private void saveData()
        {
            int OK;
            if (textBox1.Text.Trim().Length != 7 && Big)
            {
                MessageBox.Show("Check Vourcher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if (txtInterest.Text.Trim() == "" || int.TryParse(txtInterest.Text, out OK) == false)
            {
                MessageBox.Show("Check Interest", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInterest.Focus();
            }
            else if (txtTotal.Text.Trim() == "" || int.TryParse(txtTotal.Text, out OK) == false)
            {
                MessageBox.Show("Check Total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotal.Focus();
            }
            else
            {
                SPstring=string.Format("SelectYaeBig N'{0}',N'{1}',N'{2}'", textBox1.Text.ToString().Trim(),"0", "0");
                DataTable DT = new DataTable();
                DT = objclsMainDB.SelectData(SPstring);

                if (DT.Rows.Count > 0 && isEdit == false)
                {
                    MessageBox.Show("The Vourcher is already finished", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else
                {
                    clsYae objclsYae = new clsYae();
                    clsPawn objclsPawn = new clsPawn();
                    objclsYae.ID = textBox1.Text.ToString();
                    objclsYae.Note = txtNote.Text;
                    objclsYae.Interest=Convert.ToInt32(txtInterest.Text);
                    objclsYae.Total=Convert.ToInt32(txtTotal.Text);
                    objclsYae.YaeDate = dateTimePicker1.Text;
                    objclsPawn.yaeDate= dateTimePicker1.Text;
                    objclsPawn.ID= textBox1.Text.ToString();
                    objclsPawn.action =6;
                    if (isEdit)
                    {
                        objclsYae.action = 1;
                        if (MessageBox.Show("Please confirm to Edit", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            objclsYae.SaveData();
                            objclsPawn.saveData();
                        }
                    }
                    else
                    {
                        objclsYae.action = 0;
                        if (MessageBox.Show("Please confirm to save", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            objclsYae.SaveData();
                            objclsPawn.saveData();
                        }
                    }
                    Reset();
                }
            }
        }
        private void Reset()
        {
            textBox1.Text="";
            txtInterest.Text="";
            txtNote.Text="";
            txtTotal.Text="";
        }

        private void txtNote_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                saveData();
            }
        }

        private void frmYaeAdd_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
