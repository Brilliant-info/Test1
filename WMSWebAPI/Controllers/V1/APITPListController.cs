﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    public class APITPListController : ApiController
    {


        APITPListUtility obj = new APITPListUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.APITP.GetAPITPList)]

        public ResponceList GetAPITPList(APITPList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetAPITPList(ReqPara);


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

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.GetAPITPList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }



        [HttpPost]
        [Route(APIRoute.APITP.APITPSave)]
        public Responce APITPSave(RequestAPITPSave ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.APITPSave(ReqPara);
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPSave, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.APITP.APITPActiveList)]

        public ResponceList APITPActiveList(RequestAPITPActiveList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.APITPActiveList(ReqPara);


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

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPActiveList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }


        [HttpPost]
        [Route(APIRoute.APITP.APITPLogList)]

        public ResponceList APITPLogList(RequestAPITPLogList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.APITPLogList(ReqPara);


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

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPLogList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.APITP.APITPKEY)]

        public ResponceList APITPKEY(RequestAPITPKEY ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.APITPKEY(ReqPara);


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

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPKEY, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.APITP.APITPReqReadJSON)]

        public ResponceList APITPReqReadJSON(RequestAPIJSON ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.APITPReqReadJSON(ReqPara);


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

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPKEY, Int64.Parse("0"));
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.APITP.APITPRespReadJSON)]

        public ResponceList APITPRespReadJSON(ResponseAPIJSON ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.APITPRespReadJSON(ReqPara);


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

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPKEY, Int64.Parse("0"));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.APITP.getAPITPParameterlist)]

        public ResponceList getAPITPParameterlist(APITPParameterlist ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getAPITPParameterlist(ReqPara);


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

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.getAPITPParameterlist, 0);
            }

            return Response;
        }
    }
}
