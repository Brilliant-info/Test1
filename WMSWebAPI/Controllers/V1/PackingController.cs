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
    public class PackingController : ApiController
    {
        PackingUtility obj = new PackingUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Packing.GetStagingList)]
        public ResponceList GetStagingList(GetStagingListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.StagingList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.GetStagingList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.GetStagingSOList)]
        public ResponceList GetStagingSOList(GetStagingSOListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.StagingSOList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.GetStagingSOList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.GetStagingSODetail)]
        public ResponceList GetStagingSODetail(GetStagingSODetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.StagingSODetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.GetStagingSODetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.ShippingPallet)]
        public ResponceList ShippingPallet(GetShippingPalletRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.ShippingPallet(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.ShippingPallet, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.StagingSKUList)]
        public ResponceList StagingSKUList(GetStagingSKUListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.StagingSKUList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.StagingSKUList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.StagingSKUDetail)]
        public ResponceList StagingSKUDetail(GetStagingSKUDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.StagingSKUDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.StagingSKUDetail, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.SaveStagingSKUDetail)]
        public Responce SaveStagingSKUDetail(SaveStagingSKUDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] arr = obj.SaveStagingDetail(ReqPara).Split('|');
                    string result = arr[0].ToString();
                    if ((result == "success") || (result == "completed"))
                    {
                        Response = ResponceResult.SuccessResponseOrder(result,arr[1].ToString());
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponseOrder(result,"0");
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.SaveStagingSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.RemoveSKUDetail)]
        public Responce RemoveSKUDetail(RemveSkuRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveSku(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.RemoveSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.FinalSavePacking)]
        public Responce FinalSavePacking(FinalSavePackingRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.FinalSave(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.FinalSavePacking, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Packing.DirectPackingOrders)]
        public Responce DirectPackingOrders(DirectPackingOrdersRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.DirectPackingOrders(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.FinalSavePacking, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Packing.getTransportList)]
        public ResponceList getTransportList(transportList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.TransportDDList(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.getTransportList, Int32.Parse(ReqPara.UserID));
            }
            return Response;
        }
        
        [HttpPost]
        [Route(APIRoute.Packing.UpdateTranspoter)]
        public Responce UpdateTranspoter(TranspoteUpdate ReqPara)
        {
            Responce response = new Responce();
            try
            {              
            if(ReqPara !=null)
            {
                string result = obj.saveTranspoter(ReqPara);
            if(result == "success")
            {
                    response = ResponceResult.SuccessResponse(result);
            }
            else
            {
                    response = ResponceResult.SuccessResponse(result);
            }
            }
            else
            {
                response = ResponceResult.ErrorResponse("Record Not Found..!!");
            }
            }
            catch (Exception ex)
            {
                response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.UpdateTranspoter, Int32.Parse(ReqPara.UserId));
            }
            return response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.PackingLocation)]
        public ResponceList PackingLocation(GetPackingLocationRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.PackingLocation(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.PackingLocation, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}