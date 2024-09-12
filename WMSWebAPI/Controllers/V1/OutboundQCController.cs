using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    public class OutboundQCController : ApiController
    {
        OutboundQCUtility obj = new OutboundQCUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCList)]
        public ResponceList GetQCList(GetQCListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.QCList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        
        [HttpPost]
        [Route(APIRoute.OutboundQC.GetBatchQCList)]
        public ResponceList GetBatchQCList(GetBatchQCListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.BatchQCList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetBatchQCList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.QCRemoveSKU)]
        public ResponceList RemoveSKU(RemoveQCSKURequestOut ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.QCRemoveSKU(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record Not Save..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetBatchQCList, Int64.Parse(ReqPara.recordID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetReasonCode)]
        public ResponceList GetReasonCode(GetReasonCodeRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.ReasonCode(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetReasonCode, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCDetail)]
        public ResponceList GetQCDetail(GetQCDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.QCDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCSuggestSKU)]
        public ResponceList GetQCSuggestSKU(GetQCSKURequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.QCSuggestSKU(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCSuggestSKU, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCSKUDetail)]
        public ResponceList GetQCSKUDetail(GetQCSKUDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.QCSKUDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.SaveQCSKUDetail)]
        public Responce SaveQCSKUDetail(SaveQCSKUDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.SaveQCDetail(ReqPara).Split('|');
                    string result = res[0].ToString();
                    string Fresult = res[0].ToString() + '|' + res[1].ToString();
                    //string result = obj.SaveQCDetail(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(Fresult);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.SaveQCSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.FinalSaveQCDetail)]
        public Responce FinalSaveQCSKUDetail(FinalSaveQCSKUDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.FinalSaveQCDetail(ReqPara).Split('|');
                    string result = res[0].ToString();
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        if (res[2].ToString() == "YES")
                        {
                            obj.AutoPacking(Int64.Parse(ReqPara.BatchID), Int64.Parse(res[1].ToString()), Int64.Parse(ReqPara.CustomerId), Int64.Parse(ReqPara.WarehouseId), Int64.Parse(ReqPara.UserId));
                        }
                       
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }

                    //string result = obj.FinalSaveQCDetail(ReqPara);
                    //if (result == "success")
                    //{
                    //    Response = ResponceResult.SuccessResponse(result);
                    //}

                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.FinalSaveQCDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}