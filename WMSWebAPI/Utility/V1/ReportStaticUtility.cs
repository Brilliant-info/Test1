using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1;

namespace WMSWebAPI.Utility.V1
{
    public class ReportStaticUtility
    {
        SqlParameter[] param;
        DBActivity obj;

        public ReportStaticUtility()
        {
            obj = new DBActivity();
        }

        public JObject GlobalReportList(reqPurchaseOrderList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue", req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate", req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getPurchaseOrderlistReport", param));

        }

        //GRN List
        public JObject GRNList(reqGrnList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue", req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate", req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getGRNListReport", param));
        }

        //QC List
        public JObject getQCList(reqQCList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getQCListReport", param));
        }

        //PutInlist
        public JObject getPutInList(reqPutInList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getPutInlist", param));
        }

        //Allocationlist
        public JObject getAllocationList(reqAllocationList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getAllocationlist", param));
        }

        //Pickuplist
        public JObject getPickupList(reqPickuplist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getPickUplist", param));
        }

        //QCOutlist
        public JObject getQCOutList(reqQCOutlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getQCOutlist", param));
        }

        //Packinglist
        public JObject getPackingList(reqPackinglist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getPackinglist", param));
        }

        //Dispatchlist
        public JObject getDispatchList(reqDispatchlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getDispatchlist", param));
        }

        //Internal Transfer List
        public JObject getInternalTransferList(reqInternalTransferList req)
        {
            param = new SqlParameter[]
           {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@ordertype",req.ordertype)
           };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getInternalTransferlist", param));
        }

        //Cycle Count List
        public JObject getCycleCountList(reqCycleCountList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getCycleCountlist", param));
        }

        //So List
        public JObject getSoList(reqSOList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getSolist", param));
        }

        //AllocationShrotge List
        public JObject getAllocationShrtageList(reqAlocationShrotage req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_AllocationShrotage", param));
        }

        //NearexpairyReport List
        public JObject getNearexpairyReportList(reqNearexpairyReport req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                 new SqlParameter("@lastSeqno",Int64.Parse(req.lastSeqno)),
                 new SqlParameter("@filterLottable", req.filterLottable),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_NearExpairySku", param));
        }

        //NearexpairyReport List
        public JObject getABCAnalysisReportList(reqABCAnalysisReport req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_ABCAnalysis", param));
        }

        //SalesReturnReport List
        public JObject getSalesReturnReportList(reqSalesReturnReport req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_SalesReturn", param));
        }

        //Product Report List
        public JObject getProductlistReportList(reqProductlistReport req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@filterLottable", req.filterLottable),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_Productlist", param));
        }

        //location Report List
        public JObject getlocationReportList(reqlocationlistReport req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                //new SqlParameter("@loctype",req.loctype)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_locationlist", param));
        }

        //EmptylocationReport List
        public JObject getEmptylocationReportList(reqEmptylocationlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_locationlist", param));
        }

        //DailyStock Report list
        public JObject getDailyStockReportList(reqDailyStocklist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                  new SqlParameter("@filterLottable", req.filterLottable),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_DailyStocklist", param));
        }

        //StockSummary Report list
        public JObject getStockSummaryReportList(reqStockSummarylist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getCurrentStocksummury", param));
        }

        //DatewiseEmail Report list
        public JObject getDatewiseEmailReportList(reqDatewiseEmaillist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_DatewiseEmailList", param));
        }


        //Movement Report list
        public JObject getMovementReportList(reqMovementlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),
                new SqlParameter("@lastSeqno",Int64.Parse(req.lastSeqno))
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_MovementList", param));
        }
        public JObject getClientList(reqClientlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getclientList", param));
        }
        public JObject getVendorList(reqVendorlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getVendorList", param));
        }

        public JObject getCurrentStockList(reqCurrentStocklist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                 new SqlParameter("@filterLottable", req.filterLottable),

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getCurrentStockdetail", param));
        }



        public JObject getOccupencyDropDown(reqOccupencyDropDown req)
        {
            param = new SqlParameter[]
            {

                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompID", Int64.Parse(req.CompID)),
                new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_occupencydropdown", param));
        }

        public JObject getInventoryAging(reqOccupencyDropDown req)
        {
            param = new SqlParameter[]
            {

                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId))

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_occupencydropdown", param));
        }
        public JObject WHOccupancy(getWHOccupancy req)
        {
            param = new SqlParameter[]
            {

                new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                 new SqlParameter("@LocationID", Int64.Parse(req.LocationID)),
                //new SqlParameter("@Building", req.Building),
                //new SqlParameter("@Floor", req.Floor),
                //new SqlParameter("@Section",req.Section),
                //new SqlParameter("@Passage",req.Passage),
                //new SqlParameter("@Rack", req.Rack),
                //new SqlParameter("@RptFilter", req.RptFilter)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_WhOccupency", param));
        }
        public JObject SelfLifeAgingReport(getSelfLifeAgingReport req)
        {
            param = new SqlParameter[]
            {

                new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                new SqlParameter("@ProdGrpId", Int64.Parse(req.ProdGrpId)),
                new SqlParameter("@PrdId", Int64.Parse(req.PrdId)),
                new SqlParameter("@LocId",Int64.Parse(req.LocId)),
                new SqlParameter("@AgingDay",Int64.Parse(req.AgingDay)),
                 new SqlParameter("@filterLottable", req.filterLottable),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_SelfLifeAgingReport", param));
        }
        public JObject InventoryAgingReport(getInventoryAgingReport req)
        {
            param = new SqlParameter[]
            {

                new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                new SqlParameter("@ProdGrpId", Int64.Parse(req.ProdGrpId)),
                new SqlParameter("@PrdId", Int64.Parse(req.PrdId)),
                new SqlParameter("@LocId",Int64.Parse(req.LocId)),
                new SqlParameter("@AgingDay",Int64.Parse(req.AgingDay)),
                 new SqlParameter("@filterLottable", req.filterLottable),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_InventoryAgingReport", param));
        }

        public JObject InventoryDropdown(getInventoryDropdown req)
        {
            param = new SqlParameter[]
            {

                new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@CompId", Int64.Parse(req.CompId)),

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_InventoryDropdown", param));
        }

        public JObject OrderwiseSummary(getOrderwiseSummary req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId) ),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_OrderwiseSummaryReport", param));
        }
        //location Report List
        public JObject StockledgerReport(getStockledgerReport req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                new SqlParameter("@skuId", Int64.Parse(req.skuId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue",req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate",req.toDate),

            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_stockledgerl", param));
        }
            public JObject getFSNReport(getFSNReport req)
            {
                param = new SqlParameter[]
                {

                new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                new SqlParameter("@FrmDate", (req.FrmDate)),
                new SqlParameter("@ToDate", (req.ToDate)),
                new SqlParameter("@skuid",Int64.Parse(req.skuid))
                };
                return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_FSNReport", param));
            }
        public JObject StockledgerSkuDropdown(getStockledgerSkuDropdown req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@companyId",Int64.Parse(req.companyId)),
                new SqlParameter("@custId", Int64.Parse(req.custId)),
                new SqlParameter("@whId", Int64.Parse(req.whId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_RPT_StockledgerSkuDropdown ", param));
        }

        public JObject getLocationListddl(getLocaionddl req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CompanyID",Int32.Parse(req.Companyid)),
                new SqlParameter("@CustomerID", Int32.Parse(req.Customerid)),
                new SqlParameter("@WarehouseID",Int32.Parse(req.Warehouseid))
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getLocationType", param));
        }
        public JObject getCustomerSummary(getCustomerSummary req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId",Int32.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int32.Parse(req.WarehouseId)),
                new SqlParameter("@CompanyID",Int32.Parse(req.CompanyID)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                 new SqlParameter("@SearchFilter",(req.SearchFilter)),
                  new SqlParameter("@SearchValue",(req.SearchValue))
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getCustomerSummaryReport", param));
        }
        // InwardDetailList
        public JObject InwardDetailList(reqInwardDetailList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue", req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate", req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getInwardDetailReport", param));

        }


        // OutwardDetailList
        public JObject OutwardDetailList(reqOutwardDetailList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompnayId", Int64.Parse(req.CompnayId)),
                new SqlParameter("@SearchFilter", req.SearchFilter),
                new SqlParameter("@SearchValue", req.SearchValue),
                new SqlParameter("@fromDate", req.fromDate),
                new SqlParameter("@toDate", req.toDate),
                new SqlParameter("@OrderType",req.OrderType)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RPT_getOutwardDetailReport", param));

        }
        public JObject AssetReportlist(reqAssetReportlist req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@WhId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompId", Int64.Parse(req.CompanyId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                new SqlParameter("@DepartmentType",req.DepartmentType),
                new SqlParameter("@ProjectName",req.ProjectName),
                new SqlParameter("@Location",req.Location),
                new SqlParameter("@EmpID",req.EmpID),
                new SqlParameter("@BUHead",req.BUHead),
                new SqlParameter("@Title",req.Title) ,
                new SqlParameter("@flag",req.flag)
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_VWAssetReport", param));

        }
        public JObject AssetReportDropdown(reqAssetReportDropdown req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustId", Int64.Parse(req.CustomerId)),
                new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@CompID", Int64.Parse(req.CompanyId)),
                new SqlParameter("@UserId", Int64.Parse(req.UserId)),
            };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_Assetdropdown", param));

        }
   


    }
}




