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
namespace PawnShop.PawnData
{
    public partial class frmPawnAdd : Form
    {
        public frmPawnAdd()
        {
            InitializeComponent();
        }

        public Boolean pawnbig = true;
        int OK;
        public string SPstring;
        public DataTable DT;
        clsMainDB objclsMainDB = new clsMainDB();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtVourcher.Text.Length!=7 && pawnbig==true )
            {
                MessageBox.Show("Vourcher ID must have 7 words", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVourcher.Focus();
            }
            else if (txtVourcher.Text.Length!=6 && pawnbig==false)
            {
                MessageBox.Show("Vourcher ID must have 6 words", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVourcher.Focus();
            }
            else if (txtItemName.Text.Trim()=="")
            {
                MessageBox.Show("Please type item Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemName.Focus();
            }
            else if((txtKyat.Text == "0" && cboPae.SelectedIndex==0 && cboYae.SelectedIndex==0) || int.TryParse(txtKyat.Text,out OK)==false) 
            { 
                MessageBox.Show("Please select weight", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(int.TryParse(txtAmount.Text,out OK)==false || Convert.ToInt32(txtAmount.Text.Trim())<=999 || txtAmount.Text.Trim()=="")
            {
                MessageBox.Show("Please type an amount and amount should be number and amound must be greather than 1000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
            }
            else if(txtName.Text.Trim()=="")
            {
                MessageBox.Show("Please type Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else if (txtLocation.Text.Trim()=="")
            {
                MessageBox.Show("Please type Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
            }
        }

        private void txtVourcher_TextChanged(object sender, EventArgs e)
        {
            if (txtVourcher.Text.Length>7 && pawnbig==true)
            {
                MessageBox.Show("Vourcher ID must have 7 words", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVourcher.Focus();
                txtVourcher.Text=txtVourcher.Text.Remove(7, 1);
            }
            else if (txtVourcher.Text.Length!=6 && pawnbig==false)
            {
                MessageBox.Show("Vourcher ID must have 6 words", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVourcher.Focus();
                txtVourcher.Text=txtVourcher.Text.Remove(6, 1);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void dtpPawn_ValueChanged(object sender, EventArgs e)
        {
            SPstring = string.Format("SP_SelectPawn N'{0}',N'{1}'", dtpPawn.Text, "0");
            DT = objclsMainDB.SelectData(SPstring);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["NO"]);
            if (DateDiff > 0) 
            {
                MessageBox.Show("Plese check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpPawn.Value=DateTime.Today;
                dtpPawn.Focus();
            }
        }
    }
}
