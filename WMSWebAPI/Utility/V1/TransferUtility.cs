using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class TransferUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public TransferUtility()
        {
            obj = new DBActivity();
        }
        public JObject TransferList(GetTransferListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlimit", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@companyid", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@userid", Int64.Parse(req.UserId)),
                        new SqlParameter("@customerid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@warehouseid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@searchfilter", req.Filter),
                        new SqlParameter("@searchvalue", req.Search)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getTransferListInternal", param));
        }
        public JObject GetLocation(LocationDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@LocationType",Int32.Parse(req.LocationType)),
                        new SqlParameter("@CompanyId", Int32.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerId",Int32.Parse(req.CustomerId)),
                        new SqlParameter("@checkLocAvl", req.checkLocAvl),                
                        new SqlParameter("@Filter", req.Filter)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetFromLocationInternal", param));
        }
        //To Location List
        
        public JObject GetToLocList(ToLocationReq req)
        {
        param = new SqlParameter[]
            {
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@LocationType",Int32.Parse(req.LocationType)),
                new SqlParameter("@CompanyId", Int32.Parse(req.CompanyId)),
                new SqlParameter("@CustomerId",Int32.Parse(req.CustomerId)),
                new SqlParameter("@checkLocAvl", req.checkLocAvl),              
                //new SqlParameter("@obj", req.obj),
                new SqlParameter("@Filter", req.Filter)
                //,  new SqlParameter("@FromTrId", req.FromTrId)
            };
        return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetToLocationInternal", param));
        }
        public JObject GetPallet(PalletDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@LocationID", Int64.Parse(req.LocationID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@Skuid", req.SkuId),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetPalletInternal", param));
        }
        public JObject GetSkuList(SkuDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@LocationID", Int64.Parse(req.LocationID)),
                        new SqlParameter("@PalletID", req.PalletId),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetSkuListInternal", param));
        }
        public JObject GetLotabledetail(LotableListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@LocationID", Int64.Parse(req.LocationId)),
                        new SqlParameter("@PalletID", req.PalletId),
                        new SqlParameter("@SKUId", Int64.Parse(req.SKUId)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetLotabledetailInternal", param));
        }
        public JObject getTRIDTO(ReqTRIDTO req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@FrTRID", req.FrTrID),
                        new SqlParameter("@FrLocId", req.FrLocId),
                        new SqlParameter("@FrPalletId", req.FrPalletId),
                        new SqlParameter("@tolocId", req.Tolocid),
                        new SqlParameter("@ToPalletId", req.ToPalletId),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetFromTrIdInternalTransfer", param));
        }
        //Save Head
        public string SaveHeadInternalTran(SaveTransferHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@transid", Int64.Parse(req.transid)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),                      
                        new SqlParameter("@TransferBy",req.TransferBy),
                        new SqlParameter("@remkar",req.Remark)    
                        
                    };
            return obj.Return_ScalerValue("TransferAddInternal", param);
        }


        //--Save Detail--
        public string saveTransferDetail(saveTransferDetails req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@transferId", Int32.Parse(req.transferId)),
                new SqlParameter("@CompanyId", Int32.Parse(req.ComapnyId)),
                new SqlParameter("@UserId", Int32.Parse(req.UserId)),
                new SqlParameter("@CustomerId", Int32.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int32.Parse(req.WarehouseId)),
                new SqlParameter("@FromLocation", Int32.Parse(req.fromLocationId)),
                new SqlParameter("@FromPallet",req.fromPallet),
                new SqlParameter("@SkuId", Int32.Parse(req.skuid)),
                new SqlParameter("@lot",req.Lottable),
                new SqlParameter("@Quantity", req.Quantity),     
                new SqlParameter("@ToLocation", Int32.Parse(req.ToLocationId)),
                new SqlParameter("@ToPallet", req.ToPallet),
                new SqlParameter("@FromLocationType",Int32.Parse(req.FromLocationType)),
                new SqlParameter("@ToLocationType",Int32.Parse(req.ToLocationType)) ,
                new SqlParameter("@FrTrId",req.FromTrId) ,
                new SqlParameter("@ToTrId",req.ToTrId)
            };
            return obj.Return_ScalerValue("SP_SaveIntTransWebInternal", param);
        }

        //Get Save Head List
        public JObject GetSaveHeadTransfer(reqTransferSaveHead req)
        {
            param = new SqlParameter[]
                    {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@TransferId", Int64.Parse(req.TransferId))
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getTranferHeadListInternal", param));
        }


        //Get Save Detail List
        public JObject GetTransferDetails(TransferDetailsRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId))                        

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getTranferDetailsInternal", param));
        }

        public JObject skuTransferList (reqTransferSkulist req)
        {
            param = new SqlParameter[]
                {
                new SqlParameter("@TransferId",Convert.ToInt32(req.TransferId)),
                new SqlParameter("@CustomerId",Convert.ToInt32(req.CustomerId)),
                new SqlParameter("@CompanyId",Convert.ToInt32(req.CompanyId)),
                new SqlParameter("@WarehouseId",Convert.ToInt32(req.WarehouseId))
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_TransferListInternal", param));
        }
        public JObject getViewTransferList (reqViewTransfer req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@UserId",req.UserId),
                new SqlParameter("@WarehouseId", req.WarehouseId),
                new SqlParameter("@CustomerId", req.CustomerId),
                new SqlParameter("@CompanyId", req.CompanyId),
                new SqlParameter("@TransferId", req.TransferId)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_viewTrasferRecordsInternal", param));
        }
        public JObject CheckBusinessRuleTranf(reqIntTranfBusinessRule req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CompanyId", req.CompanyId),
                new SqlParameter("@CustomerId", req.CustomerId),
                new SqlParameter("@UserId",req.UserId),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_checkTransBusinessRuleInternal", param));
        }

        public JObject getLocationTypeList (reqDDLLocationList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@UserId", req.UserId)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ddlLocationTypeList", param));
        }


    }
}