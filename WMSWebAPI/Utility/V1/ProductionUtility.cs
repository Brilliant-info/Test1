using DocumentFormat.OpenXml.Drawing;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class ProductionUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ProductionUtility()
        {
            obj = new DBActivity();

        }
        public JObject GetProductionlist(GetProductionlistRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                     //   new SqlParameter("@Search",req.Search),
                        new SqlParameter("@Filter",req.Filter),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ProductionRequestList", param));

        }

        public JObject ProdHead(ProdHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                        //new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        //new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        //new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId))
                        //new SqlParameter("@ordertype", req.OrderType)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_ProdHead", param));
        }

      
        public JObject GetSaverequestHead(SaverequestHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@orderdate", req.orderdate),
                        new SqlParameter("@orderrefNo", req.orderrefNo),
                        new SqlParameter("@Line",  req.Line),
                        new SqlParameter("@Remark", req.Remark),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_SaverequestHead", param));
         
        }

        public string GetSaverequestdetail(GetSaverequestdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@PRHeadID", Int64.Parse(req.PRHeadID)),
                        new SqlParameter("@SkuCode", req.SkuCode),
                        new SqlParameter("@SkuName", req.SkuName),
                        new SqlParameter("@SkuDescription", req.SkuDescription),
                        new SqlParameter("@reqQty", req.reqQty),
                        new SqlParameter("@UOM",req.UOM),
                        new SqlParameter("@orderQty",req.orderQty),
                        new SqlParameter("@Lottable", req.Lottable),
                        new SqlParameter("@CaseNetweight", req.CaseNetweight),
                        new SqlParameter("@CaseGrossweight", req.CaseGrossweight),
                        new SqlParameter("@TotalCartan", req.TotalCartan),
                    };
            return obj.Return_ScalerValue("SP_Saverequestdetail", param);
        }

        public JObject GetDispSaverequestdetail(GetDispSaverequestdetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderid", Int64.Parse(req.orderid)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_DispProdDetail", param));

        }

        public string RemoveProdSKU(RemoveProdSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderid", Int64.Parse(req.orderid)),
                    };
            return obj.Return_ScalerValue("SP_RemoveProdSKU", param);
        }


    }
}