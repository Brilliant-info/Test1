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
    public class TranslodController : ApiController
    {
            TransloadUtility obj = new TransloadUtility();
            SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Transload.GetAll)]
        public ResponceList GetAll(ReqTransloadList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.TransloadListGetAll(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetAll, 0);
            }
            return Response;
        }

        [HttpPost]          
        [Route(APIRoute.Transload.TransloadListID)]
        public ResponceList TransloadListID(ReqTransloadListID ReqPara)
            {
            ResponceList Response = new ResponceList();
                try
                {                  
                    if (ReqPara != null)
                    {
                    
                        JObject result = obj.TransloadListID(ReqPara);
                     Response = ResponceResult.SuccessResponseList(result);
                       
                    }
                    else
                    {
                     Response = ResponceResult.ErrorResponseList("Record not found");                       
                    }

                }
                catch (System.Exception ex)
                {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransloadListID, ReqPara.UserId);
                    return Response;
                }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadSave)]
        public Responce TranloadSave(ReqTranloadSave ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSave(ReqPara);
                    if(result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                  
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSave, ReqPara.UserId);
                return Response;
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadSaveDT)]
        public Responce TranloadSaveDT(ReqTranloadSaveDT ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSaveDT(ReqPara);
                    if (result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");

                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSaveDT, 0);          
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadRemoveDT)]
        public Responce TranloadRemoveDT(ReqRemoveTransloadDT ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadRemoveDT(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");

                }

            }
            catch (Exception ex)
            {

                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadRemoveDT, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TransloadListReceving)]
        public ResponceList TransloadListReceving(ReqTransloadListReceving ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.TransloadListReceving(ReqPara);                
                    Response = ResponceResult.SuccessResponseList(result);                
                   
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransloadListReceving, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadSaveReceiving)]
        public Responce TranloadSave_Receiving(ReqSaveReceving ReqPara)
        {
            Responce Response = new Responce();
                try
                {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSave_Receiving(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");

                }
              }
                catch (Exception ex)
                {
                    Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                    exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSaveReceiving, 0);
                }
            return Response;
        }
        
        [HttpPost]
        [Route(APIRoute.Transload.ChangeOrdertype)] 
        public Responce ChangeOrdertype(ReqChangeOrderType ReqPara)
        {
            Responce Response = new Responce();           

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.ChangeOrdertype(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.ChangeOrdertype, 0);
            }
            return Response;
        }
       
        [HttpPost]
        [Route(APIRoute.Transload.TranloadSaveRecDT)]        
        public Responce TranloadSaveRecDT(ReqTTransload_RecDT ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSave_RecDT(ReqPara);
                    if (result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSaveRecDT, 0);
            }
            return Response;
        }
        
        [HttpPost]
        [Route(APIRoute.Transload.TranloadRemoveRecDT)]        
        public Responce TranloadRemoveRecDT(ReqRemoveTL_RecDT ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadRemove_RecDT(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadRemoveRecDT, ReqPara.UserId);
            }
            return Response;
        }
       
        [HttpPost]
        [Route(APIRoute.Transload.UpdateDockIdStatus)]        
        public Responce UpdateDockIdStatus(ReqUpdateDockIdStatus ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateDockIdStatus(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadRemoveRecDT, ReqPara.UserId);
            }
            return Response;
        }
        
        [HttpPost]
        [Route(APIRoute.Transload.RemoveDockIdStatus)]        
        public Responce RemoveDockIdStatus(ReqRemoveDockIdStatus ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveDockIdStatus(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.RemoveDockIdStatus, ReqPara.UserId);
            }
            return Response;
        }
        
        [HttpPost]
        [Route(APIRoute.Transload.GetDispatchDetails)] 
        public ResponceList GetDispatchDetails(ReqGetDispatchDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetDispatchDetails(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetDispatchDetails, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.SaveDispatchHead)]
        public Responce SaveDispatchHead(ReqSaveDispatchHead ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveDispatchHead(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.SaveDispatchHead, ReqPara.UserId);
            }
            return Response;

        }

        [HttpPost]
        [Route(APIRoute.Transload.clientSugg)]
        public ResponceList clientSugg(ReqClientList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                    {
                        JObject result = obj.clientList(reqpara);
                        Response = ResponceResult.SuccessResponseList(result);
                    }
                    else
                    {
                        Response = ResponceResult.ErrorResponseList("Record not found");
                    }
                }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.clientSugg, reqpara.userId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.UOMList)]
        public ResponceList UOMList(ReqUOMList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.UOMList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UOMList, reqpara.userId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.UOMSugg)]
        public ResponceList UOMSugg(ReqUOMSugg reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.UOMSugg(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UOMSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.PallettypeList)]
        public ResponceList PallettypeList(ReqPallettypeList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.PallettypeList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.PallettypeList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.RateActivitylist)]
        public ResponceList RateActivitylist(ReqRateActivitylist reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.RateActivitylist(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.RateActivitylist, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.StagingList)]
        public ResponceList StagingList(ReqStagingSugg reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.StagingSugg(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.StagingList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.StagingSugg)]
        public ResponceList StagingSugg(ReqStagingSugg reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.StagingSugg(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.StagingSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.OrderTypeList)]
        public ResponceList OrderTypeList(ReqOrderTypeList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.OrderTypeList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.OrderTypeList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.clientList)]
        public ResponceList clientList(ReqClientList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.clientList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.clientList, reqpara.userId);
            }
            return Response;
        }
        
        [HttpPost]
        [Route(APIRoute.Transload.AddList)]
        public ResponceList AddList(ReqAddressList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_AddressList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.AddList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.AddSugg)]
        public ResponceList AddSugg(ReqAddressList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_AddressList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.AddSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.DockList)]
        public ResponceList DockList(ReqDockList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_DockList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.DockList, reqpara.userId);
            }
            return Response;
        }
        //[HttpPost]
        //[Route(APIRoute.CommFunAPI.ScanDataAPI)]
        //public ResponceList ScanDataAPI(ReqScanDataAPI reqpara)
        //{
        //    ApiResponse Response = new ApiResponse();

        //    try
        //    {
        //        string Jsondata = ObjRepositry.ScanDataAPI(reqpara);
        //        if (Jsondata != "-1")

        //        {
        //            //string result = "";
        //            //Jsondata = ResponseOutPut.SplitStirng(Jsondata);
        //            Jsondata = "{\"jsonObject\":" + Jsondata + "}";
        //            Response = ResponseOutPut.SuccessResponse(MethodBase.GetCurrentMethod().Name, Jsondata);
        //            return Response;
        //        }
        //        else
        //        {
        //            Response = ResponseOutPut.ErrorReponse(MethodBase.GetCurrentMethod().Name, "Error found....");
        //            return Response;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponseOutPut.ErrorReponse(ex.Message, new { });
        //        return Response;
        //    }
        //}
        //[HttpPost]
        //[Route(APIRoute.CommFunAPI.Mob_ScanData)]
        //public ResponceList Mob_ScanData(ReqMob_ScanData reqpara)
        //{
        //    ApiResponse Response = new ApiResponse();

        //    try
        //    {
        //        string Jsondata = ObjRepositry.Mob_ScanData(reqpara);
        //        if (Jsondata != "-1")

        //        {
        //            //string result = "";
        //            //Jsondata = ResponseOutPut.SplitStirng(Jsondata);
        //            Jsondata = "{\"jsonObject\":" + Jsondata + "}";
        //            Response = ResponseOutPut.SuccessResponse(MethodBase.GetCurrentMethod().Name, Jsondata);
        //            return Response;
        //        }
        //        else
        //        {
        //            Response = ResponseOutPut.ErrorReponse(MethodBase.GetCurrentMethod().Name, "Error found....");
        //            return Response;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponseOutPut.ErrorReponse(ex.Message, new { });
        //        return Response;
        //    }
        //}
        [HttpPost]
        [Route(APIRoute.Transload.DockSugg)]
        public ResponceList DockSugg(ReqDockList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_DockList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.DockSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.TransportList)]
        public ResponceList TransportList(ReqvendorList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_vendorList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransportList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.TransportSugg)]
        public ResponceList TransportSugg(ReqvendorList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_vendorList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransportSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.PalletList)]
        public ResponceList PalletList(ReqTransPalletList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_PalletList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.PalletList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.PalletSugg)]
        public ResponceList PalletSugg(ReqTransPalletList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.Get_PalletList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.PalletSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.TLHeadDetail)]
        public ResponceList TLHeadDetail(ReqTLHeadDetail reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.TLHeadDetail(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TLHeadDetail, reqpara.userId);
            }
            return Response;
        }

        //Order Adjustment
        [HttpPost]
        [Route(APIRoute.Transload.GetOrderAdjList)]
        public ResponceList GetOrderAdjList(ReqOrderAdjList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.GetOrderAdjList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetOrderAdjList, reqpara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.AddPalletList)]
        public ResponceList AddPalletList(ReqOrderPalletList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.AddPalletList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.AddPalletList, reqpara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.OrderAdjSave)]
        public Responce OrderAdjSave(ReqOrderAdjSave reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.OrderAdjSave(reqpara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.OrderAdjSave, reqpara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.OrderAdjRemove)]
        public Responce OrderAdjRemove(ReqOrderAdjRemove reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.OrderAdjRemove(reqpara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.OrderAdjRemove, reqpara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.UpdateStagingTraDetail)]
        public Responce UpdateStagingTraDetail(ReqStagingTraDetail reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.UpdateStagingTraDetail(reqpara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UpdateStagingTraDetail, reqpara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.GetStagingTraDetail)]
        public ResponceList GetStagingTraDetail(ReqGetStagingTraDetail reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.StagingTraDetailGetAll(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetStagingTraDetail, reqpara.UserId);
            }
            return Response;
        }


        //Transpoter Detail
        [HttpPost]
        [Route(APIRoute.Transload.UpdateTransportDetail)]
        public Responce UpdateTransportDetail(ReqTransportDetail reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.UpdateTransportDetail(reqpara);
                    if (result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UpdateStagingTraDetail, reqpara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.GetTransportDetailList)]
        public ResponceList GetTransportDetailList(ReqGetTransportDetail reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JObject result = obj.GetAllTransportDetailList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetTransportDetailList, reqpara.UserId);
            }
            return Response;
        }

       


    }
}