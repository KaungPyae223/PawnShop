using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawnShop.DBO
{
    internal class CodeLibrary
    {
        DataTable DT;
        string SP;
        clsMainDB objclsMain = new clsMainDB();

        public Boolean dateDiff(string date1, string date2)
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}',N'{3}'", date1, date2,"0", "5");
            DT = objclsMain.SelectData(SP);
            if (Convert.ToInt32(DT.Rows[0]["NO"])<0)
                return true;
            else
                return false;
        }
        public string LastSixMonthes()
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}',N'{3}'", "0", "0","0" ,"4");
            DT = objclsMain.SelectData(SP);
            return DT.Rows[0][0].ToString();
        }
       
         public void DGVpawnEdid(ref DataGridView dgvPawn)
        {
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
        }
        public void MakeColors(ref DataGridView dgvPawn)
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
                    DataTable DT;
                    SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}','{3}'", "0", "0", "0", "4");
                    DT = objclsMain.SelectData(SP);
                    int diff = DateTime.Compare(Convert.ToDateTime(dgvPawn.Rows[i].Cells[6].Value.ToString()), Convert.ToDateTime(DT.Rows[0][0].ToString()));
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
