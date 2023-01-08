﻿using PawnShop.DBO;
using System;
using System.Data;
using System.Windows.Forms;
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
        public Boolean isedit = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtVourcher.Text.Length!=7 && pawnbig==true)
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
            else if ((txtKyat.Text == "0" && cboPae.SelectedIndex==0 && cboYae.SelectedIndex==0) || int.TryParse(txtKyat.Text, out OK)==false)
            {
                MessageBox.Show("Please select weight", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (int.TryParse(txtAmount.Text, out OK)==false || Convert.ToInt32(txtAmount.Text.Trim())<=999 || txtAmount.Text.Trim()=="")
            {
                MessageBox.Show("Please type an amount and amount should be number and amound must be greather than 1000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
            }
            else if (txtName.Text.Trim()=="")
            {
                MessageBox.Show("Please type Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else if (txtLocation.Text.Trim()=="")
            {
                MessageBox.Show("Please type Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocation.Focus();
            }
            else
            {
                saveData();

            }
        }
        private void reload()
        {
            addvourcher();
            txtAmount.Text="";
            txtItemName.Text="";
            txtKyat.Text="0";
            txtLocation.Text="";
            txtNote.Text="";
            txtName.Text="";
            cboPae.SelectedIndex=0;
            cboYae.SelectedIndex=0;
            txtItemName.Focus();
        }
        private void addvourcher()
        {
            if (isedit==false)
            {
                if (pawnbig)
                {
                    SPstring = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpPawn.Text, "0","0", "1");

                    DT = objclsMainDB.SelectData(SPstring);
                    string ID = DT.Rows[0]["ID"].ToString();
                    string[] z = ID.Split(' ');
                    string p = z[1].Trim();
                    int i = Convert.ToInt32(p);
                    if (i== 999)
                    {
                        MessageBox.Show("Please enter a new vourcher");
                        txtVourcher.Text="";
                        txtVourcher.Focus();
                        return;
                    }
                    else
                    {
                        i++;
                        ID = z[0].Trim() +" "+i.ToString("000");
                        txtVourcher.Text = ID;
                    }
                }

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
            else if (txtVourcher.Text.Length>6 && pawnbig==false)
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
            SPstring = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpPawn.Text, "0","0", "0");
            DT = objclsMainDB.SelectData(SPstring);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["NO"]);
            if (DateDiff > 0)
            {
                MessageBox.Show("Plese check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpPawn.Value=DateTime.Today;
                dtpPawn.Focus();
            }
        }

        private void frmPawnAdd_Load(object sender, EventArgs e)
        {
            addvourcher();
            txtItemName.Focus();
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                txtAmount.Focus();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                txtLocation.Focus();
            }
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                txtNote.Focus();
            }
        }

        private void txtNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                saveData();
            }
        }
        public void saveData()
        {
            SPstring = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", txtVourcher.Text.Trim(), "0","0", "2");
            DT=objclsMainDB.SelectData(SPstring);
            if (DT.Rows.Count>0 && isedit==false)
            {
                MessageBox.Show("ID is already exit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVourcher.Focus();
            }
            else
            {
                string weight = txtKyat.Text.Trim()+" ကျပ်  "+cboPae.SelectedItem.ToString()+" ပဲ  "+cboYae.SelectedItem.ToString()+" ရွေး";
                clsPawn objclsPawn = new clsPawn();
                objclsPawn.weight = weight;
                objclsPawn.date=dtpPawn.Text;
                objclsPawn.ID=txtVourcher.Text.Trim();
                objclsPawn.ItemName = txtItemName.Text.Trim();
                objclsPawn.amount = Convert.ToInt32(txtAmount.Text.Trim());
                objclsPawn.name= txtName.Text.Trim();
                objclsPawn.location= txtLocation.Text.Trim();
                objclsPawn.description = txtNote.Text.Trim();
                objclsPawn.yaeDate="";

                if (isedit)
                {
                    objclsPawn.action =1;
                    if (MessageBox.Show("Please confirm to edit", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        objclsPawn.saveData();
                        this.Close();
                    }
                }
                else
                {
                    objclsPawn.action = 0;
                    if (MessageBox.Show("Please confirm to save", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        objclsPawn.saveData();
                        reload();
                    }

                }

            }
        }
    }
}
