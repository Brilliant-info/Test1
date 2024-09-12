using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Utility.V1
{
    public class Authontication
    {
        static string Constr = ConfigurationManager.AppSettings["ConStr"].ToString();
        public static DataSet GetAuthorazationKey(long compid)
        {
            DataSet ds = new DataSet();
            SqlConnection strcon = new SqlConnection(Constr);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GetAuthoKey";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@compid", compid);
                        cmd.Connection = strcon;
                        cmd.Connection.Open();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex) { }
            finally { }
            return ds;
        }
    }
}