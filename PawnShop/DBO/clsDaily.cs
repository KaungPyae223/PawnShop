using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PawnShop.DBO
{
    internal class clsDaily:clsMainDB
    {
        public int YaeSmall { get; set; }
        public int InsertSmall { get; set; }
        public int YaeBig { get; set; }
        public int InsertBig { get; set; }
        public int SoneSmall { get; set; }
        public int SoneSmallIntert { get; set; }
        public int SoneBig { get; set; }
        public int SoneBigIntert { get; set; }
        public int TotalIncome { get; set; }
        public int MainBalance { get; set; }
        public int PawnSmall { get; set; }
        public int PawnBig { get; set; }
        public int Usage { get; set; }
        public int TotalOutPut { get; set; }
        public int LatKyan { get; set; }
        public int action { get; set; }
        public string SarYinDate { get; set; }
        public int PyanTwin { get; set; }
        public void saveData()
        {
            try
            {
                DataBaseCon();

                SqlCommand sql = new SqlCommand("SP_insertDaily", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@para1", YaeSmall);
                sql.Parameters.AddWithValue("@para2", InsertSmall);
                sql.Parameters.AddWithValue("@para3", YaeBig);
                sql.Parameters.AddWithValue("@para4", InsertBig);
                sql.Parameters.AddWithValue("@para5", SoneBig);
                sql.Parameters.AddWithValue("@para6", SoneBigIntert);
                sql.Parameters.AddWithValue("@para7", SoneSmall);
                sql.Parameters.AddWithValue("@para8", SoneSmallIntert);
                sql.Parameters.AddWithValue("@para9", TotalIncome);
                sql.Parameters.AddWithValue("@para10", MainBalance);
                sql.Parameters.AddWithValue("@para11", PawnSmall);
                sql.Parameters.AddWithValue("@para12", PawnBig);
                sql.Parameters.AddWithValue("@para13", Usage);
                sql.Parameters.AddWithValue("@para14", TotalOutPut);
                sql.Parameters.AddWithValue("@para15", LatKyan);
                sql.Parameters.AddWithValue("@para16", SarYinDate);
                sql.Parameters.AddWithValue("@action", action);
                sql.Parameters.AddWithValue("@para17", PyanTwin);

                sql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                con.Close();
            }
        }


    }
}
