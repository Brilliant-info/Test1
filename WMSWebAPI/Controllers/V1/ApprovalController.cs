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
    public class ApprovalController : ApiController
    {
        SysException exe = new SysException();
        ApprovalUtility obj = new ApprovalUtility();

        #region Start Main Approval Master Code


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApplication)]
        public ResponceList GetApplication(GetApplicationReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetApplicationUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApplication, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApproObject)]
        public ResponceList GetApproObject(GetObjectReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetObjectUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApproObject, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApproEvent)]
        public ResponceList GetApproEvent(GetEventReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetEventUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApproEvent, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApproverList)]
        public ResponceList GetApproverList(GetApproverReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetApproverlistUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApproverList, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveApprovalHead)]
        public Responce SaveApprovalHead(AddMApprovalHeadReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.AddApprovalHeadUtil(ReqPara).Split('|');
                    string result = res[0].ToString();
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponseOrder(result, res[1].ToString());
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Saved..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveApprovalHead, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveApprovalDetail)]
        public Responce SaveApprovalDetail(AddMApprovalDetailReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddMApprovalDetailUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveApprovalDetail, ReqPara.UserID);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetMApprovalhead)]
        public ResponceList GetMApprovalhead(GetMApproheadReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetMApproheadUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetMApprovalhead, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetMApprovalDetail)]
        public ResponceList GetMApprovalDetail(GetMApprodetailReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetMApprodetailUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetMApprovalDetail, ReqPara.UserID);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.RemoveApprovalUser)]
        public Responce RemoveApprovalUser(RemoveApproUserReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveApproUserUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.RemoveApprovalUser, ReqPara.ModifiedByID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveRemoveApprovalRec)]
        public Responce SaveRemoveApprovalRec(SaveCancelApproReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveCancelApproUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveRemoveApprovalRec, ReqPara.UserID);
            }
            return Response;
        }


        #endregion End Main Approval Master Code

        #region Start Main Approval Transaction Code
        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveapprovalTrans)]
        public Responce SaveapprovalTrans(SaveApprovalTransReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveApprovalTransUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveapprovalTrans, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApprovalTrans)]
        public ResponceList GetApprovalTrans(GetApprovalTransReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetApprovalTransUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApprovalTrans, ReqPara.UserID);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.UpdateApprovalTrans)]
        public Responce UpdateApprovalTrans(UpdateApprovalTransReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateApprovalTransUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.UpdateApprovalTrans, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.InsertApprovalTrans)]
        public Responce InsertApprovalTrans(InsertApprovalTransReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.InsertApprovalTransUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Inserted..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.InsertApprovalTrans, ReqPara.UserID);
            }
            return Response;

        }

        #endregion
    }
}
