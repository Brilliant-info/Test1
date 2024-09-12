using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class DashboardpageUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public DashboardpageUtility()
        {
            obj = new DBActivity();
        }
        public JObject TopInwardOutward(DashboardTopInwardOutwardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@WarehouseId", req.WarehouseID),
                        new SqlParameter("@UserId", req.UserID),
                        new SqlParameter("@VendorID", req.VendorID),
                        new SqlParameter("@ClientId", req.ClientID),
                        new SqlParameter("@CustomerId", req.CustomerID),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("DashboardtopInwardOtward", param));
        }
        public JObject TopInventory(DashboardTopInventoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("DashboardtopInventory", param));
        }
        public JObject CounterDashboard(CounterDashboardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_CounterDashboard", param));
        }
        public JObject InwardBarchart(InwardBarchartRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@VendorID", Int64.Parse(req.VendorID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),


                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_InwardBarchart", param));
        }
        public JObject OutwardPieChart(OutwardPieChartRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientID", Int64.Parse(req.ClientID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_OutwardPieChart", param));
        }
        public JObject DispatchCountLast4Month(DispatchCountLast4MonthRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientID)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseID)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_DispatchCountLast4Month", param));
        }
    }
}