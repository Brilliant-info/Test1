﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using WMSWebAPI.Controllers.V1;
using WMSWebAPI.Models.V1.Request;
namespace WMSWebAPI.Utility.V1
{
    public class BusinessRuleUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public BusinessRuleUtility()
        {
            obj = new DBActivity();
        }

        public JObject BusinessRuleList(GetBusinessRule req)
        {
            param = new SqlParameter[]
                   {                        
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),                        
                        new SqlParameter("@CreatedBy", req.CreatedBy)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_ApproverList", param));
        }
        public string setBusinessRule(AddBusinessRuleRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", req.CompanyID),
                        new SqlParameter("@CustomerId", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),
                        new SqlParameter("@UserId", req.CreatedBy),
                        new SqlParameter("@BusinessCode", req.BusinessCode),
                        new SqlParameter("@Active", req.Active)

                    };
            return obj.Return_ScalerValue("SP_ActiveBusinessLogic", param);

        }

    }
}