﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class DPDashbordUtility
    {

        SqlParameter[] param;
        DBActivity obj;
        public DPDashbordUtility()
        {
            obj = new DBActivity();
        }
        public JObject CounterDPDashboard(CounterDPDashboardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CounterDPDashboard", param));
        }
        public JObject DispatchCountLast4MonthDP(DispatchCountLast4MonthDPRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_DispatchCountLast4MonthDP", param));
        }
    }
}