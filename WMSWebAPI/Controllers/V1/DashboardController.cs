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
    public class DashboardController : ApiController
    {
        DashboardUtility obj = new DashboardUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Dashboard.GetDropdownList)]
        public ResponceList GetDropdownList(GetDropdownListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.DropdownList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dashboard.GetDropdownList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Dashboard.getddlWarehouseList)]
        public ResponceList getWarehouseList(reqWarehouseList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {   
                if(ReqPara !=null)
                {
                    JObject result = obj.WarehouseList(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(),APIRoute.Dashboard.getddlWarehouseList,Int32.Parse(ReqPara.UserId));
            }
            return Response;

        }
    }
}