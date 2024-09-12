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
    public class DPDashbordController : ApiController
    {
        DPDashbordUtility Obj = new DPDashbordUtility();
        SysException exe = new SysException();
        [HttpPost]
        [Route(APIRoute.DPDashboard.CounterDPDashboardList)]
        public ResponceList CounterDPDashboard(CounterDPDashboardRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = Obj.CounterDPDashboard(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DPDashboard.CounterDPDashboardList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.DPDashboard.DispatchCountLast4MonthDP)]
        public ResponceList DispatchCountLast4MonthDP(DispatchCountLast4MonthDPRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = Obj.DispatchCountLast4MonthDP(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DPDashboard.DispatchCountLast4MonthDP, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}