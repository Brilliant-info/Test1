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
    public class EmailSmsController : ApiController
    {
        EmailSmsUtility obj = new EmailSmsUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.EmailSmSList)]
        public ResponceList EmailSmSList(getEmailSmsList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getEmailSmSList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.EmailSmSList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        [HttpPost]

        [Route(APIRoute.EmailSmSNotification.EmailSmsActive)]
        public Responce EmailSmsActive(getEmailSmSActive ReqPara)
        {
            string result = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.getEmailSmSActive(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.EmailSmsActive, Int64.Parse(ReqPara.TemplateID));
            }
            return Response;
        }


        [HttpPost]

        [Route(APIRoute.EmailSmSNotification.EmailSMSTemplate)]
        public ResponceList EmailSMSTemplate(getEmailSMSTemplate ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getEmailSMSTemplate(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.EmailSMSTemplate, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.SaveEmailSMS)]
        public Responce SaveEmailSMS(GetSaveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetSaveEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.SaveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.GetroleSaveEmailSMS)]
        public Responce GetroleSaveEmailSMS(GetroleSaveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetroleSaveEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.SaveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }
        //RemoveRoleEmailSMS
        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.RemoveRoleEmailSMS)]
        public Responce RemoveRoleEmailSMS(GetRoleRemoveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveRoleEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.RemoveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.RemoveEmailSMS)]
        public Responce RemoveEmailSMS(GetRemoveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetRemoveEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.RemoveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }

    }
}