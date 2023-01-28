using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace PawnShop.DBO
{
    internal class clsYae:clsMainDB
    {
        public string ID { get; set; }
        public int Interest { get; set; }

        public  int Total { get; set; }

        public string YaeDate { get; set; }
        public string Note { get; set; }
        public int action { get; set; }

        public void SaveData()
        {
            try
            {
                DataBaseCon();

                SqlCommand sql = new SqlCommand("SP_InsertYaeBig", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@para1", ID);
                sql.Parameters.AddWithValue("@para2", Interest);
                sql.Parameters.AddWithValue("@para3", Total);
                sql.Parameters.AddWithValue("@para4", YaeDate);
                sql.Parameters.AddWithValue("@para5", Note);
                sql.Parameters.AddWithValue("@action", action);


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
