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
    public class ImportDesignerController : ApiController
    {
        ImportDesignerUtility obj = new ImportDesignerUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerList)]
        public ResponceList ImportDesignerList(ImportDesignerListRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.ImportDesignerList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerObjectList)]
        public ResponceList ImportDesignerObjectList(ImportDesignerObjectListRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.ImportDesignerObjectList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerObjectList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImpDesignTableColoumlist)]
        public ResponceList ImpDesignTableColoumlist(ImpDesignTableColoumRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.ImpDesignTableColoumlist(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImpDesignTableColoumlist, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImpDesignTblColoumDataType)]
        public ResponceList ImpDesignTblColoumDataType(ImpDesignTblColoumDataTypeRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.ImpDesignTblColoumDataType(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImpDesignTblColoumDataType, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerSave)]
        public Responce ImportDesignerSave(ImportDesignerSaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.ImportDesignerSave(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Removed..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerSave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerViewList)]
        public ResponceList ImportDesignerViewList(ImportDesignerViewListRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.ImportDesignerViewList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerViewList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ImportDesigner.CustomImportDetailSavedata)]
        public ResponceList CustomImportDetailSavedata(CustomImportDetailSavedataRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.CustomImportDetailSavedata(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.CustomImportDetailSavedata, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
    }
}