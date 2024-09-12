﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    public class LoginpageController : ApiController
    {
        loginpageUtility Obj = new loginpageUtility();
        TokenAuthUtility tokenObj = new TokenAuthUtility();
        SysException exe = new SysException();
        [HttpPost]
        [Route(APIRoute.loginpage.GetLogin)]
        public ResponceList LoginDetailList(GetloginRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = Obj.Getlogin(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.GetLogin, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.loginpage.Logout)]
        public ResponceList LogoutWithToken(CloseTokenAuthRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = tokenObj.CloseAuthToken(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.GetLogin, 0);
            }
            return Response;
        }

        /* API to lock and unlock user sessions - 06 Dec 2023 */
        [HttpPost]
        [Route(APIRoute.loginpage.CloseUserSessions)]
        public ResponceList CloseUserSessions(CloseUserSessionsRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = tokenObj.CloseUserSessions(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.GetLogin, 0);
            }
            return Response;
        }
        /* API to lock and unlock user sessions - 06 Dec 2023 */

        [HttpPost]
        [Route(APIRoute.loginpage.ResetPassword)]
        public Responce ResetPassword(ResetPasswordRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = Obj.ResetPassword(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.ResetPassword, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.loginpage.ForgetPassword)]
        public Responce ForgetPassword(ForgetPasswordRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = Obj.ForgetPassword(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.ResetPassword, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.loginpage.sendOTP)]
        public Responce sendOTP(reqOTP ReqPara)
        {
            string email = ReqPara.EmailID;
            string getOTP = ReqPara.OTP;
            //int userID = Convert.ToInt32(ReqPara.UserID);
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {

                    string GetOtp = Obj.GetOTP();
                    if (getOTP == null || getOTP == "")
                    {
                        ReqPara.OTP = GetOtp;
                    }

                    string getresult = Obj.ReqOTP(ReqPara);


                    string[] getOtpdetils = getresult.Split('|');

                    if (getOtpdetils.Length > 0)
                    {
                        result = getOtpdetils[0];
                        getOTP = getOtpdetils[1];

                    }
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        string bodytext = "You Have Requsted To Forgot Password, Your OTP is <b>" + getOTP + "</b>,Please Validate Your OTP.";
                        string sessionVal = Obj.SendPasswordRestMailDynamic(email, bodytext);
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
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.getOTP, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.loginpage.validateOTP)]
        public Responce validateOTP(reqOTP ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = Obj.checkOTP(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.validateOTP, 0);
            }
            return Response;
        }


        //Forgot Password Password Reset
        [HttpPost]
        [Route(APIRoute.loginpage.UpdatePassword)]
        public Responce UpdatePassword(changePassword ReqPara)
        {
            Responce Response = new Responce();
            try
            {

                if (ReqPara != null)
                {
                    string result = Obj.newPasswordUpdate(ReqPara);
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.UpdatePassword, 0);
            }
            return Response;
        }

        //validate User
        [HttpPost]
        [Route(APIRoute.loginpage.validateUserName)]
        public Responce validateUserName(checkUserName ReqPara)
        {
            Responce Response = new Responce();
            try
            {

                if (ReqPara != null)
                {
                    string result = Obj.checkUserName(ReqPara);
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.loginpage.validateUserName, 0);
            }
            return Response;
        }
    }
}