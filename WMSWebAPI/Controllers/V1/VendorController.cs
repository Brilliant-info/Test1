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
    public class VendorController : ApiController
    {
        VendorUtility obj = new VendorUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Vendor.GetVendorList)]
        public ResponceList GetVendorList(GetVendorListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.VendorList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Vendor.GetVendorList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Vendor.AddEditVendor)]
        public Responce SaveVendorDetails(AddEditVendorRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddEditVendor(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Vendor.AddEditVendor, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
     
        [HttpPost]
        [Route(APIRoute.Vendor.vendorType)]
        public ResponceList vendorType()
        {
            ResponceList Response = new ResponceList();
            try
            {  
                    JObject result = obj.vendorTypeList();

                    Response = ResponceResult.SuccessResponseList(result);                            
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Vendor.vendorType, 0);
            }
            return Response;
        }

    }
}