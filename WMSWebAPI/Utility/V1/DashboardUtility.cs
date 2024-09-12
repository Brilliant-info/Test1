using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class DashboardUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public DashboardUtility()
        {
            obj = new DBActivity();
        }
        public JObject DropdownList(GetDropdownListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@uid", req.UserId)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetCustWareList", param));
        }
        public JObject WarehouseList(reqWarehouseList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@CustomerId", req.CustomerId)

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_WarehouseCustomerWiseList", param));
        }
    }
}