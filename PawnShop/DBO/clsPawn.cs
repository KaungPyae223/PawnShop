using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PawnShop.DBO
{
    internal class clsPawn:clsMainDB
    {
        public string ID { get; set; }
        public string ItemName { get; set; }
        public string weight { get; set; }
        public int amount { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public int action { get; set; }
        public string yaeDate { get; set; }
 

        public void saveData()
        {
            try
            {
                DataBaseCon();

                SqlCommand sql = new SqlCommand("SP_InsertPawn", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@BigVourcherID", ID);
                sql.Parameters.AddWithValue("@ItemName",ItemName );
                sql.Parameters.AddWithValue("@amount", amount);
                sql.Parameters.AddWithValue("@CustomerName",name );
                sql.Parameters.AddWithValue("@CustomerLocation",location );
                sql.Parameters.AddWithValue("@PawnDate", date);
                sql.Parameters.AddWithValue("@Note", description);
                sql.Parameters.AddWithValue("@weight", weight);
                sql.Parameters.AddWithValue("@action", action);
                sql.Parameters.AddWithValue("@YaeDate", yaeDate);

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
