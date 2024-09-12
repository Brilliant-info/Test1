using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility;
using WMSWebAPI.Utility.V1;
using static WMSWebAPI.Models.V1.Request.Conversion;

namespace WMSWebAPI.Controllers.V1
{
    public class ConversionController : ApiController
    {
        ConversionUtility obj = new ConversionUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetConversionSKUList)]
        public ResponceList GetConversionSKUList(GetConversionSKUListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetConversionSKUList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetConversionSKUList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetConvSKUSuggestion)]
        public ResponceList GetConvSKUSuggestion(GetConvSKUSuggestionRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetConvSKUSuggestion(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetConvSKUSuggestion, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetSkuConversionSave)]
        public Responce GetSkuConversionSave(GetSkuConversionSaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                //if (ReqPara != null)
                //{

                //    string[] res = obj.GetSkuConversionSave(ReqPara).Split('|');
                //    string result = res[0].ToString();
                //    if (result == "success")
                //    {
                //        Response = ResponceResult.SuccessResponseOrder(result, res[1].ToString());
                //    }

                //}
                //else
                //{
                //    Response = ResponceResult.ErrorResponseList("No record found..!");
                //}
                if (ReqPara != null)
                {
                    string[] res = obj.GetSkuConversionSave(ReqPara).Split('|');
                    string result = res[0].ToString();
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponseOrder(result, res[1].ToString());
                        
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetSkuConversionSave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ConversionSKU.SaveDTConverstion)]
        public ResponceList SaveDTConverstion(SkuConversionSaveRequestDT ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SaveDTConverstion(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetSkuConversionSave, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetconvDetail)]
        public ResponceList GetconvDetail(ConvDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetconvDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetconvDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetconvHead)]
        public ResponceList GetconvHead(ConvHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetconvHead(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.SO.GetSODetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

    }

}
