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
    public class TransferController : ApiController
    {
        TransferUtility obj = new TransferUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Transfer.GetTransferList)]
        public ResponceList GetTransferList(GetTransferListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.TransferList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetTransferList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetLocation)]
        public ResponceList GetLocation(LocationDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetLocation(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetLocation, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //To Location List
        [HttpPost]
        [Route(APIRoute.Transfer.GetToLocation)]
        public ResponceList GetToLocation(ToLocationReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetToLocList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetToLocation, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetPallet)]
        public ResponceList GetPallet(PalletDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetPallet(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetPallet, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetSkuList)]
        public ResponceList GetSkuList(SkuDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetSkuList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetSkuList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetLottableList)]
        public ResponceList GetLotabledetail(LotableListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetLotabledetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetLottableList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transfer.getTRIDTO)]
        public ResponceList getTRIDTO(ReqTRIDTO ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getTRIDTO(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetLottableList, ReqPara.FrTrID);
            }
            return Response;
        }

        //Save Head
        [HttpPost]
        [Route(APIRoute.Transfer.SaveHeadInternalTrans)]
        public Responce SaveHead (SaveTransferHeadRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string [] res = obj.SaveHeadInternalTran(ReqPara).Split('|');
                    string result = res[0].ToString();
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponseOrder(result,res[1].ToString());
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.SaveHeadInternalTrans, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //--Save Detail--
        [HttpPost]
        [Route(APIRoute.Transfer.saveDetailList)]
        public Responce saveTransferData (saveTransferDetails ReqPara)
        {
            Responce responce = new Responce();
            try
            {
                if(ReqPara != null)
                {                 
                    string result = obj.saveTransferDetail(ReqPara);

                    if (result == "success")
                    {                        
                        responce = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        responce = ResponceResult.ValidateResponse(result);
                    }
                }   
                else
                {
                    responce = ResponceResult.ErrorResponse("Fail To Save..!!");
                }
            }
            catch (Exception ex)
            {
                responce = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.saveDetailList, Int64.Parse(ReqPara.UserId));
            }
            return responce;
        }

        //Get Transfer Head List
        [HttpPost]
        [Route(APIRoute.Transfer.getHeadList)]
        public ResponceList getSaveTransferHead(reqTransferSaveHead ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetSaveHeadTransfer(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.getHeadList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Get Transfer Details
        [HttpPost]
        [Route(APIRoute.Transfer.getTransferDetails)]
        public ResponceList getTransferDetails(TransferDetailsRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetTransferDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.getTransferDetails, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.getTransferSkuList)]
        public ResponceList getTransferSkuList (reqTransferSkulist reqPara)
        {
            ResponceList Response = new ResponceList();
            JObject result;
            try
            {
                if(reqPara !=null)
                {
                    result = obj.skuTransferList(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }

            }
            catch(Exception ex)
            {
            Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.getTransferSkuList, Int64.Parse(reqPara.TransferId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.viewTransferList)]
        public ResponceList viewTransferList (reqViewTransfer reqPara)
        {
            ResponceList Responce = new ResponceList();
            JObject result;
            try
            {
                if(reqPara != null)
                {
                    result = obj.getViewTransferList(reqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(),
                APIRoute.Transfer.viewTransferList,Int32.Parse(reqPara.UserId));
            }
            return Responce;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.checkTransfBusinessRule)]
        public ResponceList checkTransfBusinessRule(reqIntTranfBusinessRule reqPara)
        {
            ResponceList Responce = new ResponceList();
            JObject result;
            try
            {
                if (reqPara != null)
                {
                    result = obj.CheckBusinessRuleTranf(reqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(),
                APIRoute.Transfer.checkTransfBusinessRule, Int32.Parse(reqPara.UserId));
            }
            return Responce;
        }


        [HttpPost]
        [Route(APIRoute.Transfer.ddlTransferLocationList)]
        public ResponceList ddlTransferLocList (reqDDLLocationList ReqPara)
        {
            ResponceList Response = new ResponceList();
            JObject result;
            try
            {
                if(ReqPara != null)
                {
                    result = obj.getLocationTypeList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
         
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record Not Found..!!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.ddlTransferLocationList, 0);
                return Response;
            }
        return Response;
        }

    }
}