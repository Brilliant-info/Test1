using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    public class DocumentController : ApiController
    {
        DocumentUtility Obj = new DocumentUtility();
        SysException exe = new SysException();
        [HttpPost]
        [Route(APIRoute.Document.GetDocumentList)]
        public ResponceList DocumentList(GetDocumentList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = Obj.GetAll(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Document.GetDocumentList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Document.UploadDocument)]
        public string UploadDocument(long OrderID, string uploadedfilename, string objectname)
        {
            var exMessage = string.Empty;
            String jsonString = String.Empty;

            SavedocumentRequest doc = new SavedocumentRequest();

            try
            {
                HttpPostedFile file = null;
                string fname;

                string documentDownloadPath1;
                string docSave1;
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    HttpContext.Current.Response.ContentType = "text/plain";
                    jsonString = "{\n\"upload_result\": [\n";   /*json Loop Start*/
                    HttpFileCollection files = HttpContext.Current.Request.Files;

                    file = files[0];
                    fname = file.FileName;
                    string dirattachment = HttpContext.Current.Server.MapPath("~/Attachment/Document/" + OrderID);
                    if (!Directory.Exists(dirattachment))
                    {
                        Directory.CreateDirectory(dirattachment);
                    }

                    fname = Path.Combine(HttpContext.Current.Server.MapPath("~/Attachment/Document/" + OrderID + "/"), uploadedfilename);
                    file.SaveAs(fname);
                    documentDownloadPath1 = "../Attachment/Document/" + OrderID + "/" + uploadedfilename + "";
                    docSave1 = fname;

                    doc.DocumentDownloadPath = fname;                    
                  //  Obj.SaveDocument(doc);

                    string AttachfileName = Path.GetFileName(fname);
                    jsonString = jsonString + "{\n";
                    if (File.Exists(fname))
                    {

                        jsonString = jsonString + "\"status\": \"success\",\n";
                        jsonString = jsonString + "\"path\": \"" + OrderID + "/" + AttachfileName + "\"\n";

                    }
                    else
                    {
                        jsonString = jsonString + "\"status\": \"success\"\n";
                    }

                    jsonString = jsonString + "}\n";
                    jsonString = jsonString + "]\n}";  /*json Loop End*/
                }
                return jsonString;

            }

            catch (Exception ex)
            {
                exMessage = ex.Message;
                return exMessage;
            }
        }
        [HttpPost]
        [Route(APIRoute.Document.Savedocument)]
        public Responce SaveDocument(SavedocumentRequest ReqPara)
        {
            //ReqPara = new SavedocumentRequest();

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                   string serverFilePath = HttpContext.Current.Server.MapPath("~/Attachment/Document/"+ReqPara.DocumentSavePath);
                   string downPath = "/Attachment/Document/" + ReqPara.DocumentDownloadPath;
                    ReqPara.DocumentDownloadPath = serverFilePath;
                    string result = Obj.SaveDocument(ReqPara, downPath);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Document.Savedocument, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Document.RemoveDocument)]
        public Responce RemoveDocument(RemoveDocumentRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = Obj.RemoveDocument(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Document.RemoveDocument, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

    }
}