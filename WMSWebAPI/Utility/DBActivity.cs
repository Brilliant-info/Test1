using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Utility
{
    public class DBActivity
    {
        string connstr = string.Empty;
        public DBActivity()
        {
            connstr = ConfigurationManager.AppSettings["ConStr"].ToString();
        }
        public string Return_ScalerValue(string ProcName, params SqlParameter[] Param)
        {
            SqlCommand cmd;
            string result = "";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    cmd = new SqlCommand(ProcName, conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    if (Param != null)
                    {
                        foreach (SqlParameter p in Param)
                        {
                            cmd.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    result = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    conn.Close();
                }
                return result;
            }
        }
        public DataSet Return_DataSet(string procName, params SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(procName, connstr);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        foreach (SqlParameter p in param)
                        {
                            da.SelectCommand.Parameters.Add(p);
                        }
                    }
                    conn.Open();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return ds;
            }

        }
        public DataTable exeSP_DT_adapter(string procName, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(procName, connstr);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        foreach (SqlParameter p in param)
                        {
                            da.SelectCommand.Parameters.Add(p);
                        }
                    }
                    DataTable _dt = new DataTable();
                    _dt = new DataTable();
                    conn.Open();
                    da.Fill(_dt);
                    return _dt;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public string ConvertDataSetToJSON(DataSet dataSet)
        {

            string JSONString = string.Empty;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dataSet);
            }
            else
            { JSONString = "{\"Table\":[]}"; }

            return JSONString;
        }
        public JObject ConvertDataSetToJObject(DataSet dataSet)
        {
            string JSONString = string.Empty;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                JSONString = JsonConvert.SerializeObject(dataSet);
            }
            else
            { JSONString = "{\"Table\":[]}"; }
           
            JObject respjson = JObject.Parse(JSONString);
            return respjson;
        }
    }
}