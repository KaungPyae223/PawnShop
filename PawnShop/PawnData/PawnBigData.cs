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
        public Boolean big;
        public string a;
        UserControl PawnDetails;
        int con;
        int Action;
        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmPawnAdd frm = new frmPawnAdd();
            frm.pawnbig=big;
            frm.front = a;
            frm.ShowDialog();

            relode();
        }

        private void frmPawnBigData_Load(object sender, EventArgs e)
        {

            SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
            Action = 3;
            dtpFrom.Text=objclsCodeLibrary.LastSixMonthes();
            cboCondition.SelectedIndex= 0;
            ShowData();
            ShowDetails();
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "CustomerName");
            MakeColors();


        }
        public void ShowDetails()
        {
            PawnDetails = new ctl_PawnDetails();

            PawnDetails.Hide();
            Controls.Add(PawnDetails);
            Controls.SetChildIndex(PawnDetails, 0);
        }
        public void ShowData()
        {

            dgvPawn.DataSource = objclsMain.SelectData(SP);

            dgvPawn.Columns[1].Width = (dgvPawn.Width/100)*5;
            dgvPawn.Columns[2].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[3].Width = (dgvPawn.Width/100)*15;
            dgvPawn.Columns[4].Width = (dgvPawn.Width/100)*10;
            dgvPawn.Columns[5].Width = (dgvPawn.Width/100)*18;
            dgvPawn.Columns[6].Width = (dgvPawn.Width/100)*12;
            dgvPawn.Columns[7].Width = (dgvPawn.Width/100)*15;
            dgvPawn.Columns[8].Visible = false;
            dgvPawn.Columns[9].Visible = false;
            dgvPawn.Columns[10].Width = (dgvPawn.Width/100)*20;
            dgvPawn.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            MakeColors();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            relode();

        }
        public void relode()
        {
            cboCondition.SelectedIndex= 0;
            tslLabel.Text="Customer Name";
            toolStripTextBox1.Text="";
            MakeColors();
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
            {
                FillData();
            }

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
            {
                FillData();
            }

        }
        public void FillData()
        {
            SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text,Action);
            dgvPawn.DataSource = objclsMain.SelectData(SP);
            MakeColors();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            showEntry();

        }
        public void showEntry()
        {
            if (dgvPawn.CurrentRow.Cells[1].Value.ToString() == string.Empty)
            {
                MessageBox.Show("Please select a course to edit");
            }
            else
            {
                frmPawnAdd frm = new frmPawnAdd();
                frm.isedit= true;
                frm.txtVourcher.Text = dgvPawn.CurrentRow.Cells[2].Value.ToString();
                frm.txtItemName.Text = dgvPawn.CurrentRow.Cells[3].Value.ToString();
                frm.txtAmount.Text= dgvPawn.CurrentRow.Cells["amount"].Value.ToString();
                frm.txtName.Text=dgvPawn.CurrentRow.Cells[5].Value.ToString();
                frm.txtLocation.Text= dgvPawn.CurrentRow.Cells[6].Value.ToString();
                frm.dtpPawn.Text= dgvPawn.CurrentRow.Cells[7].Value.ToString();
                frm.txtNote.Text= dgvPawn.CurrentRow.Cells[9].Value.ToString();
                string[] z = dgvPawn.CurrentRow.Cells[10].Value.ToString().Split(' ');
                frm.txtKyat.Text=z[0];
                frm.cboPae.Text=z[3];
                frm.cboYae.Text=z[6];
                frm.txtKyat.Enabled=false;
                frm.cboPae.Enabled=false;
                frm.cboYae.Enabled=false;
                frm.dtpPawn.Enabled=false;
                frm.txtVourcher.Enabled=false;
                frm.btnSave.Text="Edit";
                frm.pawnbig=big;
                frm.front = a;
                frm.ShowDialog();
                relode();
                MakeColors();

            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (tslLabel.Text=="Customer Name")
            {
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, con*3+0);
                Action = con*3+0;
            }
            else if (tslLabel.Text=="Amount")
            {
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, con*3+1);
                Action = con*3+1;

            }
            else
            {
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), toolStripTextBox1.Text, con*3+2);
                Action = con*3+2;

            }
            dgvPawn.DataSource = objclsMain.SelectData(SP);
            MakeColors();

        }


        private void tsmAmount_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Amount";
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "Amount");
            toolStripTextBox1.Text="";

        }

        private void TsbItemName_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Item Name";
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, "ItemName");
            toolStripTextBox1.Text="";

        }

        private void TsmCustomerName_Click(object sender, EventArgs e)
        {
            tslLabel.Text="Customer Name";
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


        public void MakeColors()
        {

            for (int i = 0; i<dgvPawn.RowCount-1; i++)
            {
                if (dgvPawn.Rows[i].Cells[8].Value.ToString() != string.Empty)
                {
                    dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Aquamarine;
                    dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.Black;
                }
                else
                {

                    int diff = DateTime.Compare(Convert.ToDateTime(dgvPawn.Rows[i].Cells[7].Value.ToString()), Convert.ToDateTime(objclsCodeLibrary.LastSixMonthes()));
                    if (diff < 0)
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Pink;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.Black;

                    }

                }
                if (dgvPawn.Rows[i].Cells[9].Value.ToString().Trim() != string.Empty)
                {

                    if (dgvPawn.Rows[i].Cells[9].Value.ToString().Contains("Lost Ticket") && dgvPawn.Rows[i].Cells[8].Value.ToString() != string.Empty)
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.DarkBlue;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.White;
                    }
                    else
                    {
                        dgvPawn.Rows[i].DefaultCellStyle.BackColor=Color.Red;
                        dgvPawn.Rows[i].DefaultCellStyle.ForeColor=Color.White;
                    }

                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvPawn.CurrentRow.Cells[1].Value.ToString()== null)
                MessageBox.Show("Plesase select row to delete");
            else
            {

                clsPawn objclsPawn = new clsPawn();
                clsYae objclsYae = new clsYae();
                string SPstring = string.Format("SelectYaeBig N'{0}',N'{1}',N'{2}'", dgvPawn.CurrentRow.Cells[2].Value.ToString(), "0", "0");
                DataTable DT = new DataTable();
                DT = objclsMain.SelectData(SPstring);
                if (DT.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure to delete. This data is contain both pawn and yae. It you delte the two data are deleted", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        objclsPawn.ID=dgvPawn.CurrentRow.Cells[2].Value.ToString();
                        objclsYae.ID=dgvPawn.CurrentRow.Cells[2].Value.ToString();
                        if (big)
                        {
                            objclsPawn.action=4;
                            objclsYae.action=3;
                        }
                        else
                        {
                            objclsPawn.action=5;
                            objclsYae.action=6;
                        }
                        objclsPawn.saveData();
                        objclsYae.SaveData();
                    }

                }
                else
                {
                    objclsPawn.ID=dgvPawn.CurrentRow.Cells[2].Value.ToString();

                    if (big)
                        objclsPawn.action=4;
                    else
                        objclsPawn.action=5;

                    if (MessageBox.Show("Are you sure to delete", "Comfirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        objclsPawn.saveData();
                }

                relode();
            }

        }

        private void dgvPawn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex== 0)
            {
                if (dgvPawn[e.ColumnIndex, e.RowIndex].Value==null)
                {
                    dgvPawn[e.ColumnIndex, e.RowIndex].Value="+";
                }
                if (dgvPawn[e.ColumnIndex, e.RowIndex].Value.ToString().Trim()=="+")
                {
                    Rectangle cellBounds = dgvPawn.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    Point offsetLocation = new Point(cellBounds.X+30, cellBounds.Y+cellBounds.Height);
                    offsetLocation.Offset(dgvPawn.Location);
                    PawnDetails.Location = offsetLocation;
                    PawnDetails.Name= dgvPawn.CurrentRow.Cells[2].Value.ToString();
                    Label l1 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblVourcherID;
                    Label l2 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblItem;
                    Label l3 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblWeight;
                    Label l4 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblAmount;
                    Label l5 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblCustomername;
                    Label l6 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblLocation;
                    Label l7 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblPawnDate;
                    Label l8 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblYaeDate;
                    Label l9 = ((PawnShop.PawnData.ctl_PawnDetails)(PawnDetails)).lblNote;
                    l1.Text = dgvPawn.CurrentRow.Cells[2].Value.ToString();
                    l2.Text = dgvPawn.CurrentRow.Cells[3].Value.ToString();
                    l3.Text= dgvPawn.CurrentRow.Cells[10].Value.ToString();
                    l4.Text= dgvPawn.CurrentRow.Cells["amount"].Value.ToString();
                    l5.Text=dgvPawn.CurrentRow.Cells[5].Value.ToString();
                    l6.Text= dgvPawn.CurrentRow.Cells[6].Value.ToString();
                    l7.Text= Convert.ToDateTime(dgvPawn.CurrentRow.Cells[7].Value.ToString()).ToShortDateString();
                    string[] a = dgvPawn.CurrentRow.Cells[8].Value.ToString().Split(' ');
                    l8.Text= a[0];
                    l9.Text= dgvPawn.CurrentRow.Cells[9].Value.ToString();


                    PawnDetails.Show();

                    dgvPawn[e.ColumnIndex, e.RowIndex].Value="-";
                }
                else
                {
                    PawnDetails.Hide();
                    dgvPawn[e.ColumnIndex, e.RowIndex].Value="+";

                }
            }
        }

        private void cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCondition.SelectedIndex == 0)
            {
                con = 2;
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", "3");
                Action = 3;

            }
            if (cboCondition.SelectedIndex == 1)
            {
                con = 3;
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", 20);
                Action = 20;

            }
            if (cboCondition.SelectedIndex == 2)
            {
                con = 4;
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", 21);
                Action = 21;

            }
            if (cboCondition.SelectedIndex == 3)
            {
                con = 5;
                SP = string.Format(a, dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "0", 22);
                Action = 22;
            }
            dgvPawn.DataSource= objclsMain.SelectData(SP);
            string name = tslLabel.Text.Replace(" ", "");
            objclsMain.toolStripTextBoxdata(ref toolStripTextBox1, SP, name);
            MakeColors();

        }


    }
}
