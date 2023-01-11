using PawnShop.DBO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

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
        public string a;
        public Boolean big;

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmPawnAdd frm = new frmPawnAdd();
            frm.pawnbig=big;
            frm.a=this.a;
            frm.ShowDialog();
        }

        private void frmPawnBigData_Load(object sender, EventArgs e)
        {

            dtpFrom.Text=objclsCodeLibrary.LastSixMonthes();
            SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "CustomerName");
            ShowData();

        }
        public void ShowData()
        {
            SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            dgvPawn.DataSource = objclsMain.SelectData(SP);

            dgvPawn.Columns[0].Width = (dgvPawn.Width/100)*5;
            dgvPawn.Columns[1].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[2].Width = (dgvPawn.Width/100)*15;
            dgvPawn.Columns[3].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[4].Width = (dgvPawn.Width/100)*18;
            dgvPawn.Columns[5].Width = (dgvPawn.Width/100)*12;
            dgvPawn.Columns[6].Width = (dgvPawn.Width/100)*15;
            dgvPawn.Columns[7].Visible = false;
            dgvPawn.Columns[8].Visible = false;
            dgvPawn.Columns[9].Width = (dgvPawn.Width/100)*20;

            MakeColors();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();

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
                frm.a=this.a;
                frm.pawnbig=big;
                frm.ShowDialog();
                ShowData();
                

            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text=="Customer Name")
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, "6");
            else if (tslLabel.Text=="Amount")
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, "8");
            else
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, "9");

            dgvPawn.DataSource = objclsMain.SelectData(SP);
            MakeColors();

        }


        private void tsmAmount_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Amount";
            SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "Amount");
            toolStripTextBox1.Text="";

        }

        private void TsbItemName_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Item Name";
            SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "ItemName");
            toolStripTextBox1.Text="";

        }

        private void TsmCustomerName_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Customer Name";
            string a = "SP_SelectPawn";
            SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "CustomerName");
            toolStripTextBox1.Text="";

        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (dgvPawn.Rows.Count>1)
            {
                
            }
            else
            {
                MessageBox.Show("There is no data");
            }
        }

        private void dgvPawn_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void MakeColors()
        {
            for (int i = 0; i<dgvPawn.RowCount-1; i++)
            {
                if (dgvPawn.Rows[i].Cells[7].Value.ToString().Length>0)
                {
                    dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Aquamarine;
                    dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.Black;
                }
                else
                {

                    int diff = DateTime.Compare(Convert.ToDateTime(dgvPawn.Rows[i].Cells[6].Value.ToString()), Convert.ToDateTime(objclsCodeLibrary.LastSixMonthes()));
                    if (diff < 0)
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Pink;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.Black;

                    }

                }
                if (dgvPawn.Rows[i].Cells[8].Value.ToString() != null)
                {
                    if (dgvPawn.Rows[i].Cells[8].Value.ToString().Contains("Lost Ticket"))
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Red;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.White;
                    }

                    if (dgvPawn.Rows[i].Cells[8].Value.ToString().Contains("Lost Ticket") && dgvPawn.Rows[i].Cells[7].Value.ToString() != null)
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.DarkBlue;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.White;
                    }
                }


            }
        }
    }
}
