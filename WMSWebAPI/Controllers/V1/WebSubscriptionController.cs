using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    public class WebSubscriptionController : ApiController
    {

        WebSubscriptionUtility obj = new WebSubscriptionUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Subscription.SaveCustSubscription)]
        public ResponceList SaveCustSubscription(WebSubscription ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SaveCustSubscription(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SaveCustSubscription, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.SaveSubscriptionPaymentDetails)]
        public ResponceList SaveSubscritionPaymentDetails(GetPaymentDetailsSaveRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SaveSubscriptionPaymentDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SaveSubscriptionPaymentDetails, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.UpdateCustSubscriptionHead)]
        public Responce UpdateCustSubscriptionHead(UpdateCustSubscriptionHeadRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateCustSubscriptionHead(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.UpdateCustSubscriptionHead, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.UpdatePaymentDetails)]
        public ResponceList UpdatePaymentDetails(UpdatePaymentDetailsRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.UpdatePaymentDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.UpdatePaymentDetails, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.GetCouponID)]
        public ResponceList GetCouponID(GetCouponIDRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetCouponID(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.GetCouponID, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.CustomerDetailList)]
        public ResponceList CustomerDetailList(CustomerDetailListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.CustomerDetailList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CustomerDetailList, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.SendEmailOtp)]
        public ResponceList SendEmailOtp(SendEmailOtpRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SendEmailOtp(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SendEmailOtp, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.SendSMSOtp)]
        public ResponceList SendSMSOtp(SendSMSOtpRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SendSMSOtp(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SendSMSOtp, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.EmailOtpVerification)]
        public ResponceList EmailOtpVerification(EmailOtpVerificationRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.EmailOtpVerification(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.EmailOtpVerification, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.MobileOtpVerification)]
        public ResponceList MobileOtpVerification(MobileOtpVerificationRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.MobileOtpVerification(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.MobileOtpVerification, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.CheckUserNameAvailability)]
        public ResponceList CheckUserNameAvailability(CheckUserNameAvailability ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.CheckUserNameAvailability(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.MobileOtpVerification, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.RazorPayClientCreateOrder)]
        public ResponceList RazorPayClientCreateOrder(RazorPayClientCreateOrderRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.RazorPayClientCreateOrder(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.RazorPayClientCreateOrder, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.GetSubscriptionPaymentList)]
        public ResponceList GetSubscriptionPaymentList(GetSubscriptionPaymentListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetSubscriptionPaymentList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CustomerDetailList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.GetSubscriptionTaxList)]
        public ResponceList GetSubscriptionTaxList(GetSubscriptionTaxListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetSubscriptionTaxList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CustomerDetailList, 0);
            }
            return Response;
        }
    }
}