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
    public class BillofLandingController : ApiController
    {
        BillOfLandingUtility obj = new BillOfLandingUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.BillofLanding.UpdateData)]
        public ResponceList UpdateData(BillofLanding ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.UpdateData(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.BillofLanding.UpdateData, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.BillofLanding.GetData)]
        public ResponceList GetData(BillOfLandingGetData ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetData(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(),APIRoute.BillofLanding.GetData, ReqPara.BillORDER_ID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.BillofLanding.MasterBOL)]
        public ResponceList MasterBOL(reqMasterBOL ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.MasterBOL(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.BillofLanding.MasterBOL, ReqPara.customerId);
            }
            return Response;
        }
    }
}
