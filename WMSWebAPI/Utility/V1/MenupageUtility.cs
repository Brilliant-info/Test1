using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class MenupageUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public MenupageUtility()
        {
            obj = new DBActivity();
        }
        public JObject GetMenu(MenupageRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserID)),
                        new SqlParameter("@UserType", req.UserType),
                        new SqlParameter("@ParentId", Int64.Parse(req.ParentId)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("MenuPage", param));
        }
    }
}