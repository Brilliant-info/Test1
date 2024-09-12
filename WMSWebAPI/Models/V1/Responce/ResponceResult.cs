using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Responce
{
    public class ResponceResult
    {
        public static ResponceList SuccessResponseList(JObject Message)
        {
            var Response = new ResponceList();
            Response.Status = "200";
            Response.StatusCode = "Success";
            Response.Result = Message;
            return Response;
        }
        public static ResponceList ErrorResponseList(string Message)
        {
            var Response = new ResponceList();
            Response.Status = "400";
            Response.StatusCode = "failed";
            Response.Result = JObject.Parse(stringtoJSON(Message));
            return Response;
        }
        public static Responce SuccessResponse(string Message)
        {
            var Response = new Responce();
            Response.Status = "200";
            Response.StatusCode = "Success";
            Response.Result = JObject.Parse(stringtoJSON(Message));
            return Response;
        }
        public static Responce SuccessResponseOrder(string Message,string orderno)
        {
            var Response = new Responce();
            Response.Status = "200";
            Response.StatusCode = "Success";
            Response.Result = JObject.Parse(stringtoJSONOrder(Message, orderno));
            return Response;
        }
        public static Responce ValidateResponse(string Message)
        {
            var Response = new Responce();
            Response.Status = "300";
            Response.StatusCode = "Validate";
            Response.Result = JObject.Parse(stringtoJSON(Message));
            return Response;
        }
        public static Responce ErrorResponse(string Message)
        {
            var Response = new Responce();
            Response.Status = "400";
            Response.StatusCode = "failed";
            Response.Result = JObject.Parse(stringtoJSON(Message));
            return Response;
        }
        public static string stringtoJSON(string Message)
        {
            string result = "{\"Message\":\"" + Message + "\"}";
            return result;
        }
        public static string stringtoJSONOrder(string Message, string orderno)
        {
            string result = "{\"Message\":\"" + Message + "\",\"OrderNo\":\"" + orderno + "\"}";
            return result;
        }
    }
}