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
       
         
        
    }
}
