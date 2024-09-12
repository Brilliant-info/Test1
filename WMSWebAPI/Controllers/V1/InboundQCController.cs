using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Web.Http;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;
using static WMSWebAPI.Models.V1.Request.InboundQC;

namespace WMSWebAPI.Controllers.V1
{
    public class InboundQCController : ApiController

    {
        InboundQCUtility obj = new InboundQCUtility();
        SysException exe = new SysException();

        [HttpPost]       
        [Route(APIRoute.InboundQC.QCList)]
        public ResponceList GetQclist(QCDetailRequest ReqPara)
        {

            
            DataSet ds = new DataSet();
            DataSet dsuom = new DataSet();
            String jsonString = String.Empty;
            
            ResponceList Response = new ResponceList();

            try
            {

                if (ReqPara != null) 
                {
                    JObject result = obj.QClist(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.QCList, 0);
            }
            return Response;

                   
        }
        [HttpPost]
        [Route(APIRoute.InboundQC.GetQCHead)]
        public ResponceList GetQCHead(QCHeadRequest req)
        {
            ResponceList Response = new ResponceList();

            try
            {

                if (req != null)
                {
                    JObject result = obj.QCHead(req);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.GetQCHead, 0);
            }
            return Response;

        }

        
        [HttpPost]       
        [Route(APIRoute.InboundQC.getQCID)]
        public ResponceList getQCID(grnidreq req)
        {
            ResponceList Response = new ResponceList();

            try
            {

                if (req != null)
                {
                    JObject result = obj.getQCID(req);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.GetQCHead, 0);
            }
            return Response;

        }


        [HttpPost]      

        [Route(APIRoute.InboundQC.GetQCDetail)]
        public ResponceList GetGRNDetail(QCRequest req)
        {
            ResponceList Response = new ResponceList();

            try
            {

                if (req != null)
                {
                    JObject result = obj.QCDetails(req);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.GetQCDetail, 0);
            }
            return Response;

        }

        [HttpPost]

        [Route(APIRoute.InboundQC.GetReasoncode)]
        public ResponceList GetReasoncode(QCReasonRequest req)
        {
            ResponceList Response = new ResponceList();
            try
            {

                if (req != null)
                {
                    JObject result = obj.getReasonCode(req);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.GetQCDetail, 0);
            }
            return Response;

        }
        [HttpPost]        
        [Route(APIRoute.InboundQC.SaveQCDetail)]
        public Responce SaveGRNDetail(SaveQCDetailRequest req)
        {

            Responce Response = new Responce();
            try
            {
                if (req != null)
                {
                    string result = obj.SaveQCDetail(req);
                    if (result != "0")
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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.SaveQCDetail, 0);
            }
            return Response;
        }

        [HttpPost]

        [Route(APIRoute.InboundQC.UpdateQCStatus)]
        public Responce UpdateQC(UpdatQCStatus ReqPara)
        {

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateQCStatus(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        string rek = obj.ReciveNotification(ReqPara);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.UpdateGrnStatus, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.InboundQC.RemoveQCSKU)]
        public Responce RemoveQCSKU(RemoveQCSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveQCSKUDetail(ReqPara);
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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.RemoveSKU, 0);
            }
            return Response;
        }

    }
}
