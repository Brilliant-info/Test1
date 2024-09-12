﻿using Newtonsoft.Json.Linq;
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
    public class ProductionController : ApiController
    {
        ProductionUtility obj = new ProductionUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Production.GetProductionlist)]
        public ResponceList GetBillingGroupList(GetProductionlistRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetProductionlist(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Production.GetProductionlist, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Production.ProdHead)]
        public ResponceList ProdHead(ProdHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.ProdHead(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Production.ProdHead, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Production.SaverequestHead)]
        public ResponceList SaverequestHead(SaverequestHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetSaverequestHead(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Production.SaverequestHead,0);
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.Production.GetSaverequestdetail)]
        public Responce GetSaverequestdetail(GetSaverequestdetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetSaverequestdetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Production.GetSaverequestdetail, Int64.Parse(ReqPara.CustomerID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Production.GetDispSaverequestdetail)]
        public ResponceList GetDispSaverequestdetail(GetDispSaverequestdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetDispSaverequestdetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Production.GetDispSaverequestdetail, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Production.RemoveProdSKU)]
        public Responce RemoveProdSKU(RemoveProdSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveProdSKU(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Production.RemoveProdSKU, 0);
            }
            return Response;
        }
    }
}