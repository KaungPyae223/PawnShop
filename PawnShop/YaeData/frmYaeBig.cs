using PawnShop.DBO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PawnShop.YaeData
{

    public partial class frmYaeBig : Form
    {
        public frmYaeBig()
        {
            InitializeComponent();
        }
        Boolean firsttime = true;
        clsMainDB objclsMain = new clsMainDB();
        CodeLibrary objclsCodelibrary = new CodeLibrary();
        string SP;
        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmYaeAdd frm = new frmYaeAdd();
            frm.ShowDialog();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            showData();
        }
        public void showData()
        {
            if (firsttime)
            {
                DataGridViewTextBoxColumn dgcol = new DataGridViewTextBoxColumn();
                dgcol.DefaultCellStyle.NullValue="+";
                dgcol.HeaderText="";
                dgcol.Width=30;
                dgcol.ReadOnly=true;
                dgcol.DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
                dgvYae.Columns.Add(dgcol);
                firsttime=false;
            }


            SP = string.Format("SelectYaeBig N'{0}', N'{1}', N'{2}'", dtpFrom.Text.ToString(), dtpTo.Text.ToString(), "1");

            dgvYae.DataSource = objclsMain.SelectData(SP);
            dgvYae.Columns[1].Width=(dgvYae.Width/100)*5;
            dgvYae.Columns[2].Width=(dgvYae.Width/100)*10;
            dgvYae.Columns[3].Width=(dgvYae.Width/100)*20;
            dgvYae.Columns[4].Width=(dgvYae.Width/100)*20;
            dgvYae.Columns[5].Width=(dgvYae.Width/100)*10;
            dgvYae.Columns[6].Width=(dgvYae.Width/100)*10;
            dgvYae.Columns[7].Width=(dgvYae.Width/100)*10;
            dgvYae.Columns[8].Width=(dgvYae.Width/100)*10;
            dgvYae.Columns[9].Width=(dgvYae.Width/100)*10;

            dgvYae.Columns[10].Visible=false;
            makecolors();
        }
        public void makecolors()
        {
            for (int i = 0; i<dgvYae.RowCount-1; i++)
            {
                if (dgvYae.Rows[i].Cells[9].Value.ToString().Contains("Lost Ticket"))
                {
                    dgvYae.Rows[i].DefaultCellStyle.BackColor=Color.DarkBlue;
                    dgvYae.Rows[i].DefaultCellStyle.ForeColor=Color.White;
                }
            }
        }
        private void frmYaeBig_Load(object sender, EventArgs e)
        {
            dtpFrom.Text=objclsCodelibrary.LastSixMonthes();
            showData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            Showentry();
        }
        public void Showentry()
        {
            if (dgvYae.CurrentRow.Cells[1].Value.ToString()==string.Empty)
            {
                MessageBox.Show("Please select a course to edit");
            }
            else
            {
                frmYaeAdd frm = new frmYaeAdd();
                frm.dateTimePicker1.Text=dgvYae.CurrentRow.Cells[8].Value.ToString();
                frm.txtInterest.Text=dgvYae.CurrentRow.Cells[6].Value.ToString();
                frm.txtNote.Text=dgvYae.CurrentRow.Cells[10].Value.ToString();
                frm.txtTotal.Text=dgvYae.CurrentRow.Cells[7].Value.ToString();
                frm.textBox1.Text = dgvYae.CurrentRow.Cells[2].Value.ToString();
                frm.btnSave.Text="Edit";
                frm.isEdit = true;
               
                frm.ShowDialog();
                

            }
        }
    }
}
