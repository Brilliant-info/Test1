using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WMSWebAPI.Models.V1;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        string apiReferer = "";
        string apiRequestedUrl = "";
        string apiRequestedFile = "";
        string apiRequestKey = "";
        string apiAccessKey = "";
        string apiStatus = "success";
        string apiStatusCode = "200";
        string apiMessage = "";

        List<string> exceptionalReferer = new List<string>
        {
            "easycloudwms.com",
            "www.easycloudwms.com",
            "webuat.easycloudwms.com"
        };

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {


            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:50068");
            // if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            //  {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, api-access-key, api-request-key");
            HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");

            //}



            //------Authontication Start -----//
            string apiComp = string.Empty;

            apiComp = ConfigurationManager.AppSettings["apilive"].ToString();
            string appURL = apiComp.ToString();
            string loginURL = apiComp.ToString() + "Login/";
            string isLocalDev = isLocalDevelopement();
            string isNativeApp = getisNativeApp();
            string isLiveServer = isLiveEnviornment();
            string isExcepRequester = isExceptionalRequester();
            try
            {
                apiStatus = "success";
                apiStatusCode = "200";
                if (HttpContext.Current.Request.UrlReferrer != null)
                {
                    apiReferer = HttpContext.Current.Request.UrlReferrer.ToString().Trim();
                }
                else
                {
                    apiReferer = "";
                }

                apiRequestedUrl = HttpContext.Current.Request.Url.ToString();
                apiRequestedFile = getRequestedFile(apiRequestedUrl);

                if (apiRequestedFile == "PickingDetailsExportCsv")
                {
                    isLocalDev = "yes";
                }

                //if (apiReferer == "http://localhost/")

                if ((apiReferer.ToString() == appURL) || (apiReferer.ToString() == loginURL) || (isLocalDev == "yes") || (isExcepRequester == "yes") || ( isNativeApp == "yes"))
                //if (isLiveServer == "yes" || (isLocalDev == "yes"))
                {
                    if ((isNativeApp == "yes")) { 
                    
                    }
                    else { 
                    if ((isLocalDev == "yes") )
                    {
                        apiAccessKey = HttpContext.Current.Request.Form["apiRequestKey"];
                        apiRequestKey = HttpContext.Current.Request.Form["apiAccessKey"];
                    }
                    else
                    {
                        apiAccessKey = HttpContext.Current.Request.Headers.Get("api-access-key");
                        apiRequestKey = HttpContext.Current.Request.Headers.Get("api-request-key");
                    }
                    if (apiRequestKey == null || apiAccessKey == null)
                    {
                        apiStatus = "failed";
                        apiStatusCode = "600";
                        apiMessage = "API access key or request key is not provided!!";
                    }
                    else if (apiRequestKey.Trim() == "ECW63725lys86^DJD83774nlWs")
                    {
                        if (apiAccessKey.Trim() != "235XsPn38482^Nswlsi34BMsT")
                        {
                            string getAuthResult = AuthApiCredential(apiAccessKey);
                            if (getAuthResult != "success")
                            {
                                apiStatus = "failed";
                                apiStatusCode = "601";
                                apiMessage = "Invalid API Key!!";
                            }
                        }
                        else if (apiRequestedFile != "GetLogin" && apiRequestedFile != "validateUserName" && apiRequestedFile != "getOTP" && apiRequestedFile != "PickingDetailsExportCsv" && isExcepRequester != "yes")
                        {
                            apiStatus = "failed";
                            apiStatusCode = "602";
                            apiMessage = "You do not have access to this service!!";
                        }
                    }
                    }
                }
                else
                {
                    apiStatus = "failed";
                    apiStatusCode = "603";
                    apiMessage = "You do not have access to this service!! ";
                    // apiMessage = "req:" + HttpContext.Current.Request.Url.ToString() + "| Ref:"+ apiReferer + "| isExe:" + isExcepRequester + "| isLoc:" + isLocalDev;
                    //apiMessage = apiReferer;
                }

            }
            catch (Exception ex)
            {
                apiStatus = "failed";
                apiStatusCode = "604";
                apiMessage = "You do not have access to this service!!";
            }
            if ((apiStatus != "success") && (isLocalDev != "yes") && (isNativeApp != "yes"))
            {
                HttpContext.Current.Response.End();
            }
            //------Authontication End -----//
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {

            string isLocalDev = isLocalDevelopement();
            if (apiStatus != "success" && isLocalDev != "yes")
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write("{\"status\":\"" + apiStatus + "\",\"StatusCode\":\"" + apiStatusCode + "\",\"Result\":{\"Message\":\"" + apiMessage + "\"}}");
            }

        }

        private string AuthApiCredential(string apiSecretKey)
        {
            string authResult = "failed";
            TokenAuthUtility obj = new TokenAuthUtility();
            string result = "";
            string objectName = "";
            string getresult = "";
            // Responce Response = new Responce();
            try
            {
                string[] splitKey = apiSecretKey.Split('^');
                AuthApiAccessRequest ReqPara = new AuthApiAccessRequest();
                ReqPara.UserID = splitKey[0];
                ReqPara.Token = splitKey[1];
                if (ReqPara != null)
                {
                    authResult = obj.AuthApiAccess(ReqPara);
                }
            }
            catch (Exception ex)
            {
                // Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                // exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.UserLogin, 0);
            }
            return authResult;
        }

        private string getRequestedFile(string fileURL)
        {
            string requestedFile = "";
            string[] breakFilePath = fileURL.Split('/');
            requestedFile = breakFilePath[breakFilePath.Length - 1];
            return requestedFile;
        }

        private string isLocalDevelopement()
        {
            string apiRequestedUrl = HttpContext.Current.Request.Url.ToString();
            string isLocalDev = "no";
            string getRefererUrlSub = apiRequestedUrl.Substring(0, 17);
            if ((getRefererUrlSub == "http://localhost/") || (getRefererUrlSub == "http://localhost:") || (getRefererUrlSub == "http://127.0.0.1/") || (getRefererUrlSub == "http://127.0.0.1:"))
            {
                isLocalDev = "yes";
            }
            return isLocalDev;
        }
        private string getisNativeApp()
        {
            string isNativeApp = "no";
            string getapiAccessKey = HttpContext.Current.Request.Headers.Get("api-access-key");
            string getapiRequestKey = HttpContext.Current.Request.Headers.Get("api-request-key");
            if ((getapiAccessKey == "Desktop-235QpHw38482^Psqlsi34JTwO") && (getapiRequestKey == "Desktop-NUG63725eot86^UQW83774khRy"))
            {
                isNativeApp = "yes";
            }
            return isNativeApp;
        }

        private string isLiveEnviornment()
        {
            string isLiveEnviornment = "no";
            try
            {
                string apiComp = string.Empty;
                apiComp = ConfigurationManager.AppSettings["apilive"].ToString();

                string apiRequestedUrl = HttpContext.Current.Request.Url.ToString();

                string getRefererUrlSub = apiRequestedUrl.Substring(0, apiComp.Length);
                if (getRefererUrlSub == apiComp)
                {
                    isLiveEnviornment = "yes";
                }
            }
            catch (Exception ex)
            {

            }
            return isLiveEnviornment;
        }

        private string isExceptionalRequester()
        {
            string isExceptional = "no";
            string apiRequesterUrl = "";
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                apiRequesterUrl = HttpContext.Current.Request.UrlReferrer.ToString().Trim();
                string[] breakURL = apiRequesterUrl.Split('/');
                string isHttpOrHttps = breakURL[0];
                string extractDomain = breakURL[2];
                for (int i = 0; i < exceptionalReferer.Count; i++)
                {
                    string getExceptionalRef = exceptionalReferer[i].ToString();
                    if ((isHttpOrHttps == "http:" || isHttpOrHttps == "https:"))
                    {
                        if (extractDomain == getExceptionalRef)
                        {
                            isExceptional = "yes";
                        }
                    }
                }
            }
            else
            {
                apiRequesterUrl = "";
            }
           
            return isExceptional;
        }
    }
}
