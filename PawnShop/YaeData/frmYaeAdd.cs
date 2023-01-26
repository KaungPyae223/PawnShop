using PawnShop.DBO;
using System;
using System.Data;
using System.Windows.Forms;

namespace PawnShop.YaeData
{
    public partial class frmYaeAdd : Form
    {
        public frmYaeAdd(Boolean isBig, string FY, string FP)
        {
            InitializeComponent();
            Big= isBig;
            frontyae = FY;
            frontPawn = FP;

        }
        CodeLibrary objclsCodelibrary = new CodeLibrary();
        clsMainDB objclsMainDB = new clsMainDB();
        string SPstring;
        public Boolean isEdit = false;
        public Boolean Big = true;
        public string frontyae;
        public string frontPawn;
        Boolean enabled = false;

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

            if ((textBox1.Text.Length == 7 && Big) || (textBox1.Text.Length == 5 && !Big))
            {
                SPstring = string.Format(frontPawn, textBox1.Text.Trim(), "0", "0", "2");
                DataTable DT = new DataTable();
                DT = objclsMainDB.SelectData(SPstring);
                if (DT.Rows.Count == 0)
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
                    enabled= true;
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
            if ((textBox1.Text.Trim().Length != 7 && Big) || (textBox1.Text.Trim().Length != 5 && !Big))
            {
                MessageBox.Show("Check Vourcher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if (enabled == false)
            {
                MessageBox.Show("The Vourcher ID is False", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SPstring=string.Format(frontyae, textBox1.Text.ToString().Trim(), "0", "0");
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
                        if (Big)
                            objclsYae.action = 1;
                        else
                            objclsYae.action = 4;

                        if (MessageBox.Show("Please confirm to Edit", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            objclsYae.SaveData();
                            objclsPawn.saveData();
                        }
                    }
                    else
                    {
                        if (Big)
                            objclsYae.action = 0;
                        else
                            objclsYae.action = 3;
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
            if (e.KeyCode == Keys.Enter)
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
