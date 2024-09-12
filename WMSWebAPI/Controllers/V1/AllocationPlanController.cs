using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    public class AllocationPlanController : ApiController
    {
        AllocationUtility obj = new AllocationUtility();
        SysException exe = new SysException();
        [HttpPost]
        [Route(APIRoute.AllocationPlan.BatchList)]
        public ResponceList BatchList(BatchListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.BatchList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.BatchList, Convert.ToInt64(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.saveplandirect)]
        public Responce saveplandirect(saveplandirectrequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.saveplandirect(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.saveplandirect, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.getallocationplansumry)]
        public ResponceList getallocationplansumry(getallocationplansumryrequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getallocationplansumry(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.getallocationplansumry, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.Getalcplndtl)]
        public ResponceList Getalcplndtl(Getalcplndtlrequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.Getalcplndtl(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.Getalcplndtl, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.getSearchalcplndtls)]
        public ResponceList getSearchalcplndtls(allocationplandtlsearchRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.allocationplandtlsearch(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.getSearchalcplndtls, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.updateallocationplanQty)]
        public Responce updateallocationplanQty(updateallocationplanQty ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updateallocationplanQty(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.updateallocationplanQty, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.updateallocationplanintransitQty)]
        public Responce updallocationplanintransitquantity(updateallocationplanQty ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updallocationplanintransitquantity(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.updateallocationplanintransitQty, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.CreateCustomBatch)]
        public Responce CreateCustomBatch(getbatchidbysoids ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateResurveqty(Convert.ToInt64(obj.getbatchidbysoids(ReqPara)),ReqPara.confirm);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else if(result == "confirm")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.updateallocationplanintransitQty, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.CancelBatch)]
        public Responce cancelCustomBatch(cancelbatchRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string batchid = obj.getbatchidbysoid(Convert.ToInt64(ReqPara.soid));
                    string result = obj.cancelbatch(Convert.ToInt64(batchid));
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.CancelBatch, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.GetManualAllocationofSku)]
        public ResponceList GetManualAllocationofSku(GetManualAllocationofSkuRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getmanualallocationplanskuwise(ReqPara.ProdID,ReqPara.soid);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.GetManualAllocationofSku, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.ManualallocationSearch)]
        public ResponceList ManualallocationSearch(searchmanualalocrequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = new JObject();
                    if (ReqPara.whereFilterCondition != null)
                    {
                        result = obj.searchmanualallocation(ReqPara.whereFilterCondition,ReqPara.prdid, ReqPara.soid);
                    }
                    else
                    {
                        result = obj.getmanualallocationplanskuwise(ReqPara.prdid, ReqPara.soid);
                    }
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.GetManualAllocationofSku, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.UpdateQtyManualallocation)]
        public Responce UpdateQtyManualallocation(updatemanualqtyrequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updatemanualallocationqty(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.UpdateQtyManualallocation, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.DeAllocate)]
        public Responce DeAllocateBatch(DeAllocateRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.DeAllocate(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.DeAllocate, Convert.ToInt64(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.TotalShrotQty)]
        public ResponceList TotalShrotQty(TotalShrotQtyRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.TotalShrotQty(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.TotalShrotQty, Convert.ToInt64(ReqPara.CustId));
            }
            return Response;
        }

    }
}
