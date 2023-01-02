using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace PawnShop.DBO
{
    internal class clsMainDB
    {
        public SqlConnection con;

        public void DataBaseCon()
        {
            try
            {
                con = new SqlConnection(PawnShop.Properties.Settings.Default.PawnCon);
                if(con.State == ConnectionState.Open) 
                    con.Close();
                
                con.Open();
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString(),"Error in DataBase");
            }
        }
        public DataTable SelectData(string SPString)
        {
            SPString = SPString.Trim();
            DataTable DT = new DataTable();
            try
            {
                DataBaseCon();
                SqlDataAdapter ADpt = new SqlDataAdapter(SPString,con);
                ADpt.Fill(DT);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in select Data");
            }
            finally
            {
                con.Close();
            }
            return DT;
        }
    }
}
