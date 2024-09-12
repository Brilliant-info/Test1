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
    public class IOTConfigController : ApiController
    {
        IOTConfigUtility obj = new IOTConfigUtility();
        SysException exe = new SysException();
        // GET: IOTConfig
        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.IOTConfigList)]
        public ResponceList GetIOTConfigList(GetIOTConfigRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.IOTConfigList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTConfigList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.SaveIOTConfig)]
        public ResponceList SaveIOTConfig(GetSaveIOTConfigRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SaveIOTConfig(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.SaveIOTConfig, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.LocationTypeIOTConfig)]
        public ResponceList LocationTypeIOTConfig(GetLocationTypeIOTConfigRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.LocationTypeIOTConfig(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.LocationTypeIOTConfig, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.deviceTypeIOTConfig)]
        public ResponceList deviceTypeIOTConfig(GetdeviceTypeIOTConfigRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.deviceTypeIOTConfig(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.deviceTypeIOTConfig,Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.IOTConfigTemp)]
        public ResponceList IOTConfigTemp(GetIOTConfigTempRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.IOTConfigTemp(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTConfigTemp, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.IOTConfigReport)]
        public ResponceList IOTConfigReport(GetIOTConfigReportRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.IOTConfigReport(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTConfigReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.IOTLocbind)]
        public ResponceList IOTLocbind(GetIOTLocbindRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.IOTLocbind(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTLocbind, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [System.Web.Http.Route(APIRoute.IOTConfig.IOTdeviceIDbind)]
        public ResponceList IOTdeviceIDbind(GetIOTdeviceIDbindRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.IOTdeviceIDbind(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTdeviceIDbind, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
