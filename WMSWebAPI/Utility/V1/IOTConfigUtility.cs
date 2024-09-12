using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WMSWebAPI.Models.V1.Request;
using Newtonsoft.Json.Linq;

namespace WMSWebAPI.Utility.V1
{
    public class IOTConfigUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public IOTConfigUtility()
        {
            obj = new DBActivity();
        }
        public JObject IOTConfigList(GetIOTConfigRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Currentpage ", Int64.Parse(req.Currentpage)),
                        new SqlParameter("@Recordlimit", Int64.Parse(req.Recordlimit)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@Search",req.Search),
                        new SqlParameter("@Filter",req.Filter)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_IoTConfigList", param));
        }
        public JObject SaveIOTConfig(GetSaveIOTConfigRequest req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@Locationtype",req.Locationtype),
                        new SqlParameter("@Pathway",req.Pathway),
                        new SqlParameter("@Section",req.Section),
                        new SqlParameter("@Shelf",req.Shelf),
                        new SqlParameter("@devicetype",req.devicetype),
                        new SqlParameter("@devicecode",req.devicecode),
                        new SqlParameter("@minTemp", decimal.Parse(req.minTemp)),
                        new SqlParameter("@maxTemp", decimal.Parse(req.maxTemp)),
                        new SqlParameter("@minhumidity", decimal.Parse(req.minhumidity)),
                        new SqlParameter("@maxhumidity", decimal.Parse(req.maxhumidity)),
                        new SqlParameter("@Currtemp", decimal.Parse(req.Currtemp)),
                        new SqlParameter("@CurrHumidity", decimal.Parse(req.CurrHumidity)),
                        new SqlParameter("@IOTConfigID", Int64.Parse(req.IOTConfigID)),
                        new SqlParameter("@Active",req.Active)

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_SaveIOTConfig", param));
        }
        public JObject LocationTypeIOTConfig(GetLocationTypeIOTConfigRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@LocationType", Int64.Parse(req.LocationType)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_locationType", param));
        }
        public JObject deviceTypeIOTConfig(GetdeviceTypeIOTConfigRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ddldeviceType", param));
        }
        public JObject IOTConfigTemp(GetIOTConfigTempRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                        new SqlParameter("@deviceId",req.deviceId),
                        new SqlParameter("@Date",req.Date),
                        new SqlParameter("@obj",req.obj)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_IOTConfigTemp", param));
        }
        public JObject IOTConfigReport(GetIOTConfigReportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                        new SqlParameter("@fromDate",req.fromDate),
                        new SqlParameter("@toDate",req.toDate),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_IOTConfigReport", param));
        }
        public JObject IOTLocbind(GetIOTLocbindRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@LocID", Int64.Parse(req.LocID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_LocDT_IOTConfig", param));
        }
        public JObject IOTdeviceIDbind(GetIOTdeviceIDbindRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("IOT_GetdeviceID", param));
        }
    }
}