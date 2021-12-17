using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BT_Tuan09.Data
{
    public class DataProvider
    {

        public static SqlConnection connectDB()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-60NT41SF\HODUCDUY;Initial Catalog=BT_Tuan09;Integrated Security=True");
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static DataTable getDataTable(string sQuery, SqlParameter[] paras)
        {
            SqlConnection con = connectDB();
            if (con == null)
            {
                return null;
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sQuery, con);
                if (paras != null)
                {
                    da.SelectCommand.Parameters.AddRange(paras);
                }
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public static bool execNonQuery(string sQuery, SqlParameter[] paras)
        {
            SqlConnection con = connectDB();
            if (con == null)
            {
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand(sQuery, con);
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
