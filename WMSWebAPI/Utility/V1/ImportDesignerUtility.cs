using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class ImportDesignerUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ImportDesignerUtility()
        {
            obj = new DBActivity();
        }
        public JObject ImportDesignerList(ImportDesignerListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ImportDesignerlist", param));
        }
        public JObject ImportDesignerObjectList(ImportDesignerObjectListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                       // new SqlParameter("@ViewName", req.ViewName)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ObjectDropdown", param));
        }
        public JObject ImpDesignTableColoumlist(ImpDesignTableColoumRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@ImportID", Int64.Parse(req.ImportID)),
                        new SqlParameter("@TableNM", req.TableNM),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_TableColoumnList", param));
            
        }
        public JObject ImpDesignTblColoumDataType(ImpDesignTblColoumDataTypeRequest req)
        {
            param = new SqlParameter[]
                    {
                        
                        new SqlParameter("@ObjectID", Int64.Parse(req.ObjectID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID))

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetImportTemplateDatatype", param));
        }
        public string ImportDesignerSave(ImportDesignerSaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ColumnData", req.ColumnData),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@ImpID", Int64.Parse(req.ImpID)),
                      //  new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@ViewName", req.ViewName),
                        
                    };
            return obj.Return_ScalerValue("Sp_ImportdesignerSave", param);
        }
        public JObject ImportDesignerViewList(ImportDesignerViewListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ImportDesignerViewlist", param));
        }

        public JObject CustomImportDetailSavedata(CustomImportDetailSavedataRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_GetImportSavedData", param));
        }
    }
}