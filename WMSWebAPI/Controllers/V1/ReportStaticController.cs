using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMSWebAPI.Models.V1;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    public class ReportStaticController : ApiController
    {
        ReportStaticUtility obj = new ReportStaticUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.ReportStatic.PurchaseOrderReport)]

        public ResponceList getPurchaseList(reqPurchaseOrderList ReqPara)
        {
            
            
            ResponceList Response = new ResponceList();
            try
                {
                if (ReqPara != null)
                {
                    JObject result = obj.GlobalReportList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(),APIRoute.ReportStatic.PurchaseOrderReport, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        //GRN List
        [HttpPost]
        [Route(APIRoute.ReportStatic.GRNListReport)]
        public ResponceList getGRNListReport(reqGrnList ReqPara)
        {
            
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GRNList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.GRNListReport, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        //QC List
        [HttpPost]
        [Route(APIRoute.ReportStatic.QCReport)]

        public ResponceList getQCReportList (reqQCList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                   if(ReqPara != null)
                {
                    JObject result = obj.getQCList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.QCReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //PutIn List
        [HttpPost]
        [Route(APIRoute.ReportStatic.PutInReport)]

        public ResponceList getPutInReportList(reqPutInList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getPutInList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.PutInReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Allocation List
        [HttpPost]
        [Route(APIRoute.ReportStatic.AllocationReport)]

        public ResponceList getAllocationReportList(reqAllocationList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getAllocationList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AllocationReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        //PickUp List
        [HttpPost]
        [Route(APIRoute.ReportStatic.PickUpReport)]

        public ResponceList getPickUpReportList(reqPickuplist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getPickupList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.PickUpReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //QCOut List
        [HttpPost]
        [Route(APIRoute.ReportStatic.QCOutReport)]

        public ResponceList getQCOutReportList(reqQCOutlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getQCOutList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.QCOutReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Packing List
        [HttpPost]
        [Route(APIRoute.ReportStatic.PackingReport)]

        public ResponceList getPackingReportList(reqPackinglist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getPackingList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.PackingReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Dispatch List
        [HttpPost]
        [Route(APIRoute.ReportStatic.DispatchReport)]

        public ResponceList getDispatchReportList(reqDispatchlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getDispatchList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.DispatchReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Internal Transfer List
        [HttpPost]
        [Route(APIRoute.ReportStatic.InternalTransferReport)]

        public ResponceList getInternalTransferReportList(reqInternalTransferList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getInternalTransferList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.InternalTransferReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Cycle Count List
        [HttpPost]
        [Route(APIRoute.ReportStatic.CycleCountReport)]

        public ResponceList getCycleCountReportList(reqCycleCountList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getCycleCountList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.CycleCountReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //So List
        [HttpPost]
        [Route(APIRoute.ReportStatic.SoReport)]

        public ResponceList getSoReportList(reqSOList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getSoList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.SoReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //AllocationShrotge List
        [HttpPost]
        [Route(APIRoute.ReportStatic.AllocatonShrotage)]

        public ResponceList getAllocatonShrotageReportList(reqAlocationShrotage ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getAllocationShrtageList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AllocatonShrotage, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //NearExpairy List
        [HttpPost]
        [Route(APIRoute.ReportStatic.NearexpairyReport)]

        public ResponceList getNearexpairyReportList(reqNearexpairyReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getNearexpairyReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.NearexpairyReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //ABCAnalysis List
        [HttpPost]
        [Route(APIRoute.ReportStatic.ABCAnalysisReport)]

        public ResponceList getABCAnalysisReportList(reqABCAnalysisReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getABCAnalysisReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.ABCAnalysisReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //SalesReturn List
        [HttpPost]
        [Route(APIRoute.ReportStatic.SalesReturnReport)]

        public ResponceList getSalesReturnReportList(reqSalesReturnReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getSalesReturnReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.SalesReturnReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Product List
        [HttpPost]
        [Route(APIRoute.ReportStatic.ProductlistReport)]

        public ResponceList getProductlistReportList(reqProductlistReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getProductlistReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.ProductlistReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //location List
        [HttpPost]
        [Route(APIRoute.ReportStatic.locationlistReport)]

        public ResponceList getlocationReportList(reqlocationlistReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getlocationReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.locationlistReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Emptylocation List
        [HttpPost]
        [Route(APIRoute.ReportStatic.EmptylocationlistReport)]

        public ResponceList getEmptylocationReportList(reqEmptylocationlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getEmptylocationReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.EmptylocationlistReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Daily Stock List
        [HttpPost]
        [Route(APIRoute.ReportStatic.DailyStockReport)]

        public ResponceList getDailyStockReportList(reqDailyStocklist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getDailyStockReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.DailyStockReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //StockSummary List
        [HttpPost]
        [Route(APIRoute.ReportStatic.StockSummaryReport)]

        public ResponceList getStockSummaryReportList(reqStockSummarylist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getStockSummaryReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.StockSummaryReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //DatewiseEmail List
        [HttpPost]
        [Route(APIRoute.ReportStatic.DatewiseEmailReport)]

        public ResponceList getDatewiseEmailReportList(reqDatewiseEmaillist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getDatewiseEmailReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.DatewiseEmailReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Movement List
        [HttpPost]
        [Route(APIRoute.ReportStatic.MovementReport)]

        public ResponceList getMovemetReportList(reqMovementlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getMovementReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.MovementReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.ClientReport)]

        public ResponceList getClientList(reqClientlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getClientList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.ClientReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Vendor List

        [HttpPost]
        [Route(APIRoute.ReportStatic.VendorReport)]

        public ResponceList getVendorList(reqVendorlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getVendorList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.VendorReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Current Stock Report List

        [HttpPost]
        [Route(APIRoute.ReportStatic.CurrentStockReport)]

        public ResponceList getCurrentStockList(reqCurrentStocklist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getCurrentStockList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.CurrentStockReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Occupency DropDown

        [HttpPost]
        [Route(APIRoute.ReportStatic.OccupencyDropDown)]

        public ResponceList getOccupencyDropDown(reqOccupencyDropDown ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getOccupencyDropDown(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.OccupencyDropDown, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        // FSN Line Report 

        [HttpPost]
        [Route(APIRoute.ReportStatic.getWHOccupancy)]

        public ResponceList WHOccupancy(getWHOccupancy ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.WHOccupancy(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getWHOccupancy, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getSelfLifeAgingReport)]

        public ResponceList SelfLifeAgingReport(getSelfLifeAgingReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SelfLifeAgingReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getSelfLifeAgingReport, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getInventoryAgingReport)]

        public ResponceList InventoryAgingReport(getInventoryAgingReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.InventoryAgingReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getInventoryAgingReport, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getInventoryDropdown)]

        public ResponceList InventoryDropdown(getInventoryDropdown ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.InventoryDropdown(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getInventoryDropdown, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getOrderwiseSummaryReport)]

        public ResponceList OrderwiseSummaryReport(getOrderwiseSummary ReqPara)
        {
            string getFromDate = ReqPara.fromDate;
            string getToDate = ReqPara.toDate;
            if (getFromDate == "-")
            {
                ReqPara.fromDate = "";
                ReqPara.toDate = "";
            }
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.OrderwiseSummary(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getOrderwiseSummaryReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getStockledgerReport)]

        public ResponceList StockledgerReport(getStockledgerReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.StockledgerReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getStockledgerReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getFSNReport)]

        public ResponceList getFSNReport(getFSNReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getFSNReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getFSNReport, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getStockledgerSkuDropdown)]

        public ResponceList StockledgerReport(getStockledgerSkuDropdown ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.StockledgerSkuDropdown(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getStockledgerSkuDropdown, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getLocationlTypeList)]
        public ResponceList getLocationList (getLocaionddl ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject Result = obj.getLocationListddl(ReqPara);
                    Response = ResponceResult.SuccessResponseList(Result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Error Found..!!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getLocationlTypeList, Int64.Parse(ReqPara.Customerid));
            }
            
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getCustomerSummary)]
        public ResponceList getCustomerSummary(getCustomerSummary ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject Result = obj.getCustomerSummary(ReqPara);
                    Response = ResponceResult.SuccessResponseList(Result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Error Found..!!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getCustomerSummary, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.InwardDetailList)]

        public ResponceList InwardDetailList(reqInwardDetailList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.InwardDetailList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.InwardDetailList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }


        // OutwardDetailList
        [HttpPost]
        [Route(APIRoute.ReportStatic.OutwardDetailList)]

        public ResponceList OutwardDetailList(reqOutwardDetailList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.OutwardDetailList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.OutwardDetailList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.AssetReportlist)]

        public ResponceList AssetReportlist(reqAssetReportlist ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.AssetReportlist(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AssetReportlist, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }


        //AssetReportDropdown
        [HttpPost]
        [Route(APIRoute.ReportStatic.AssetReportDropdown)]

        public ResponceList AssetReportDropdown(reqAssetReportDropdown ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.AssetReportDropdown(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AssetReportDropdown, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        

    }
}