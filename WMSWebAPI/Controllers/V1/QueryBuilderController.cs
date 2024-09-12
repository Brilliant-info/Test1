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
    public class QueryBuilderController : ApiController
    {

        QueryBuilderUtility obj = new QueryBuilderUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderList)]
        public ResponceList QueryBuilderList(QueryBuilderListRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.QueryBuilderList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderExec)]
        public ResponceList QueryBuilderExec(QueryBuilderExecRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.QueryBuilderExec(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderExec, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderObject)]
        public ResponceList QueryBuilderObject(QueryBuilderObjectRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.QueryBuilderObject(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderObject, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderAddUpdateDetail)]
        public Responce QueryBuilderAddUpdateDetail(QueryBuilderAddUpdateDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderAddUpdateDetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderAddUpdateDetail, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderAddUpdateNotifications)]
        public Responce QueryBuilderAddUpdateNotifications(QueryBuilderAddUpdateNotificationsRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderAddUpdateNotifications(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderAddUpdateNotifications, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderNotificationSave)]
        public Responce QueryBuilderNotificationSave(QueryBuilderNotificationSaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderNotificationSave(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderNotificationSave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderRemoveNotification)]
        public Responce QueryBuilderRemoveNotification(QueryBuilderNotificationRemoveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderNotificationRemove(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderRemoveNotification,Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryExecButton)]
        public ResponceList QueryExecButton(QueryExecButtonRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.QueryExecButton(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryExecButton,Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderObjectCol)]
        public ResponceList QueryBuilderObjectCol(QueryBuilderObjectColRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.QueryBuilderObjectCol(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderObjectCol, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderQuerySave)]
        public ResponceList QueryBuilderQuerySave(SaveQueryRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.SaveQuery(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderQuerySave, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderQueryFlag)]
        public ResponceList QueryBuilderQueryFlag(FlagQueryRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JObject result = obj.QueryFlag(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderQueryFlag, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
    }
}