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
    public class TaskAssingmetController : ApiController
    {
        TaskAssingmentUtility obj = new TaskAssingmentUtility();
        SysException exe = new SysException();
        [Route(APIRoute.TaskAssignment.CreteNewTask)]
        public Responce CreateAssingTask(TaskAssingment ReqPara)
        {
            Responce Response = new Responce();
            try
            { 
                if (ReqPara != null)
                {
                    string result = obj.CreateAssingment(ReqPara);
                    if (result == "Success")
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGRNSKUDetail, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.TaskList)]
        public ResponceList getassingUserList(getTaskListByObj ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getTaskList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetScanSuggest, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.TaskAssignment.GetAssingmentList)]
        public ResponceList getAssingmentlist(GetAssingmentList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getAssingmentTaskList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetScanSuggest, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.getAssingmentUserlist)]
        public ResponceList getassingUserList(Getuserlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.AssinguserList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetScanSuggest, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.TaskAssignment.getAssingGrouplist)]
        public ResponceList getassinggrouplist(AssingmentGroupList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getAssingmentGroupList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetScanSuggest, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.getuserSuggestlist)]
        public ResponceList GetUsersugetion(gerUserSuggetionList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getUsersuggetion(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.getuserSuggestlist,0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.getOrdervalidation)]
        public ResponceList getOrderValidation(validAssingorder ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getOrderValidation(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.getOrdervalidation, 0);
            }
            return Response;
        }
        //Reassign The Task
        [HttpPost]
        [Route(APIRoute.TaskAssignment.ReassignTask)]
        public Responce ReassignTask(reassignTask ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.ReassignTaskToUser(ReqPara);
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.ReassignTask, Convert.ToInt64(ReqPara.UserID));
            }
            return Response;
        }

        [Route(APIRoute.TaskAssignment.RemoveAssignmentTask)]
        public Responce CreateAssingTask(RemoveTaskAssingment ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveAssingment(ReqPara);
                    if (result == "Success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else if(result == "UnAssing")
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.RemoveAssignmentTask, 0);
            }
            return Response;
        }


        [Route(APIRoute.TaskAssignment.checkTaskAssignment)]
        public Responce checkTaskAssignment(checkTaskAssignment ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.checkTaskAssignment(ReqPara);
                    if (result == "YES")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else if (result == "NO")
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
                    Response = ResponceResult.ErrorResponse("Error..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.checkTaskAssignment, 0);
            }
            return Response;
        }

        

        [HttpPost]
        [Route(APIRoute.TaskAssignment.GetTaskAssignmentPOHead)]
        public ResponceList GetPOHead(TaskAssignmentPOHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetTaskAssignmentPOHead(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.GetTaskAssignmentPOHead, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}