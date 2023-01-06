using System;
using System.Data;
using System.Windows.Forms;

namespace PawnShop.DBO
{
    internal class CodeLibrary
    {
        DataTable DT;
        string SP;
        clsMainDB objclsMain = new clsMainDB();

        public int dateDiff(string date1, string date2)
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", date1, date2, "5");
            DT = objclsMain.SelectData(SP);
            return Convert.ToInt32(DT.Rows[0]["NO"]);
        }
        public string LastSixMonthes()
        {
            SP = string.Format("SP_SelectPawn N'{0}',N'{1}',N'{2}'", "0", "0", "4");
            DT = objclsMain.SelectData(SP);
            return DT.Rows[0][0].ToString();
        }
        
         
    }
}
