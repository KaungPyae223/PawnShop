﻿using PawnShop.DBO;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using PawnShop.Report;

namespace PawnShop.PawnData
{
    public partial class frmPawnBigData : Form
    {
        public frmPawnBigData()
        {
            InitializeComponent();
        }
        string SP;
        clsMainDB objclsMain = new clsMainDB();
        CodeLibrary objclsCodeLibrary = new CodeLibrary();

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmPawnAdd frm = new frmPawnAdd();
            frm.pawnbig=true;
            frm.ShowDialog();
        }

        private void frmPawnBigData_Load(object sender, EventArgs e)
        {

            dtpFrom.Text=objclsCodeLibrary.LastSixMonthes();
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "CustomerName");
            ShowData();

        }
        public void ShowData()
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(),"0", "3");
            dgvPawn.DataSource = objclsMain.SelectData(SP);
            objclsCodeLibrary.DGVpawnEdid(ref dgvPawn);

            objclsCodeLibrary.MakeColors(ref dgvPawn);
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            objclsCodeLibrary.MakeColors(ref dgvPawn);

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {


            if (objclsCodeLibrary.dateDiff(dtpFrom.Text, dtpTo.Text))
            {
                MessageBox.Show("Plese check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFrom.Text=objclsCodeLibrary.LastSixMonthes();

                dtpFrom.Focus();
            }
            else
                ShowData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

            if (objclsCodeLibrary.dateDiff(dtpFrom.Text, dtpTo.Text))
            {
                MessageBox.Show("Plese check Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpTo.Text=DateTime.Today.ToString();
                dtpFrom.Focus();
            }
            else
                ShowData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            showEntry();

        }
        public void showEntry()
        {
            if (dgvPawn.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Please select a course to edit");
            }
            else
            {
                frmPawnAdd frm = new frmPawnAdd();
                frm.isedit= true;
                frm.txtVourcher.Text = dgvPawn.CurrentRow.Cells[1].Value.ToString();
                frm.txtItemName.Text = dgvPawn.CurrentRow.Cells[2].Value.ToString();
                frm.txtAmount.Text= dgvPawn.CurrentRow.Cells["amount"].Value.ToString();
                frm.txtName.Text=dgvPawn.CurrentRow.Cells[4].Value.ToString();
                frm.txtLocation.Text= dgvPawn.CurrentRow.Cells[5].Value.ToString();
                frm.dtpPawn.Text= dgvPawn.CurrentRow.Cells[6].Value.ToString();
                frm.txtNote.Text= dgvPawn.CurrentRow.Cells[8].Value.ToString();
                string[] z = dgvPawn.CurrentRow.Cells[9].Value.ToString().Split(' ');
                frm.txtKyat.Text=z[0];
                frm.cboPae.Text=z[3];
                frm.cboYae.Text=z[6];
                frm.txtKyat.Enabled=false;
                frm.cboPae.Enabled=false;
                frm.cboYae.Enabled=false;
                frm.dtpPawn.Enabled=false;
                frm.txtVourcher.Enabled=false;
                frm.btnSave.Text="Edit";
                frm.ShowDialog();
                ShowData();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(tslLabel.Text=="Customer Name")
                SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, "6");
            else if (tslLabel.Text=="Amount")
                SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, "8");
            else
                SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, "9");

            dgvPawn.DataSource = objclsMain.SelectData(SP);
            objclsCodeLibrary.MakeColors(ref dgvPawn);

        }

        
        private void tsmAmount_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Amount";
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(),"0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "Amount");
            toolStripTextBox1.Text="";

        }

        private void TsbItemName_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Item Name";
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "ItemName");
            toolStripTextBox1.Text="";

        }

        private void TsmCustomerName_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Customer Name";
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "CustomerName");
            toolStripTextBox1.Text="";

        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if(dgvPawn.Rows.Count>1)
            {
                DataTable DT = new DataTable();
                DT = objclsMain.SelectData(SP);   
                frm_Report frm = new frm_Report();
                Crpt_PawnBig crpt= new Crpt_PawnBig();
                crpt.SetDataSource(DT);
                frm.crystalReportViewer1.ReportSource= crpt;
                frm.ShowDialog();
                ShowData();
            }
            else
            {
                MessageBox.Show("There is no data");
            }
        }
    }
}
