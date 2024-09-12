using ConnectCode.BarcodeFonts2D;
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
    public class GRNController : ApiController
    {
        GRNActivity obj = new GRNActivity();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.GRN.GetSKUList)]
        public ResponceList GetSKUList(GetGRNSKUListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetGRNSKUDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetSKUList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.GRN.SaveSKUDetails)]
        public Responce SaveSKUDetails(SaveGRNSKUListRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveGRNSKUDetail(ReqPara);
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
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveSKUDetails, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.GRN.RemoveSKU)]
        public Responce RemoveSKU(RemoveGRNSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveGRNSKUDetail(ReqPara);
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
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.RemoveSKU, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.GRN.Closegrnpopup)]
        public Responce CloseGRNSKU(CloseGRNSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.CloseGRNSKUDetail(ReqPara);
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
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.RemoveSKU, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.GRN.GetTransportList)]
        public ResponceList GetTransportList(GetGRNTransportListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetGRNTransportDetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetTransportList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.GRN.SaveGRNTransport)]
        public Responce SaveGRNTransport(SaveGRNTransportRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveTransportDetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGRNTransport,ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.GRN.SaveGatePass)]
        public Responce SaveGatePass(SaveGRNTransportRequest ReqPara)
        {
            string getPoOrderID = ReqPara.OrderId;
            string result = "";

            string[] getOrderId = getPoOrderID.Split(',');


            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    for (int i = 0; i < getOrderId.Length; i++)
                    {
                        
                        ReqPara.OrderId = Convert.ToString(getOrderId[i]);
                        result = obj.savegetPassdetails(ReqPara);
                    }
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGRNTransport, ReqPara.UserId);
            }
            return Response;
        }

        /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
        [HttpPost]
        [Route(APIRoute.GRN.SaveGatePassLottable)]
        public ResponceList SaveGatePassLottable(SaveGatePassLottableRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SaveGatePassLottable(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGatePassLottable, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
        /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */
        [HttpPost]
        [Route(APIRoute.GRN.CreateGatePassSkuSerials)]
        public ResponceList CreateGatePassSkuSerials(CreateGatePassSkuSerialsRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.CreateGatePassSkuSerials(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.CreateGatePassSkuSerials, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */

        [HttpPost]       
        [Route(APIRoute.GRN.GetGRNHead)]
        public ResponceList GetGRNHead(GRNHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GRNHead(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNHead, Int64.Parse(ReqPara.UserId));
            }
            return Response;
            
        }


        [HttpPost]        

        [Route(APIRoute.GRN.SaveGRNSKUDetail)]
        public Responce SaveGRNDetail(SaveGRNDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveGRNSKUDetail (ReqPara);
                    if (result != "0"&&result!= "Lotfaild")
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

        [Route(APIRoute.GRN.UpdateGrnStatus)]
        public Responce UpdateGrn(UpdatGrnStatus ReqPara)
        {

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.Updategrn(ReqPara);
                    if (result != "fail")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.UpdateGrnStatus, 0);
            }
            return Response;
        }
        
        [HttpPost]
       
        [Route(APIRoute.GRN.GetGRNDetail)]
        public ResponceList GetGRNDetail(GRNDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GRNDetails(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;

        }

        [HttpPost]
        
        [Route(APIRoute.GRN.getGRNID)]
        public ResponceList getgrnvalues(poidreq ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getGrnID(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNDetail, 0);
            }
            return Response;

        }
        [HttpPost]

        [Route(APIRoute.GRN.getPass)]
        public ResponceList getPass(poidreq ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getPass(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNDetail, 0);
            }
            return Response;

        }
        [HttpPost]

            [Route(APIRoute.GRN.GetGRNTransportDetail)]
        public ResponceList GetGRNTransport(GetGRNTransportDetailtRequest ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetGRNTransport(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNDetail, 0);
            }
            return Response;

        }

        

        [HttpPost]      
        [Route(APIRoute.GRN.GetGatePassDetail)]
        public ResponceList GetgetpassDetail(GatePassDetailRequest ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getPassDetails(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.GetGRNDetail, 0);
            }
            return Response;

        }
        [HttpPost]
        [Route(APIRoute.GRN.viewGetPass)]
        public ResponceList viewGetPass (viewGetPass Reqpara)
        {
            ResponceList Response = new ResponceList();
           try
            {

            if(Reqpara != null)
            {
                JObject result = obj.sp_getVendorListRecord(Reqpara);
                Response = ResponceResult.SuccessResponseList(result);
                return Response;
            }
            else
            {
                Response = ResponceResult.ErrorResponseList("No record found..!");
                return Response;
            }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.viewGetPass, 0);
            }
            return Response; 
        }

        [HttpPost]
        [Route(APIRoute.GRN.getPassIdListByID)]
        public ResponceList getPassIdListByID (getPassListById ReqPara)
        {
            ResponceList Responce = new ResponceList();

            try
            {
                if(ReqPara !=null)
                {
                    JObject result = obj.getPassIDList(ReqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                    return Responce;

                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No Record Found");
                    return Responce;
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.viewGetPass, 0);

            }
            return Responce;
        }

        /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */
        [HttpPost]
        [Route(APIRoute.GRN.getBarcodeAsPerConfig)]
        public ResponceList getBarcodeAsPerConfig(getBarcodeAsPerConfig ReqPara)
        {
            ResponceList Responce = new ResponceList();

            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getBarcodeAsPerConfig(ReqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                    return Responce;

                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No Record Found");
                    return Responce;
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.viewGetPass, 0);

            }
            return Responce;
        }

        [HttpPost]
        [Route(APIRoute.GRN.getBarcodePrintData)]
        public ResponceList getBarcodePrintData(getBarcodePrintData ReqPara)
        {
            ResponceList Responce = new ResponceList();

            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.getBarcodePrintData(ReqPara);
                    JObject QRCodeResult = new JObject();
                    JArray jrQRCode = new JArray();
                    int QRType = 0;
                    int PrefixType = 0;
                    var jResult = result["Table"];
                    
                    for (int i=0; i < jResult.Count(); i++)
                    {
                        var jSkuItem = jResult[i];
                        var getBarcodeText = jSkuItem["BarcodeString"];
                        DataMatrix dm = new DataMatrix(getBarcodeText.ToString(), QRType, PrefixType);
                        string outputstr = dm.Encode();
                        result["Table"][i]["QRCode"] = outputstr;
                    }
                    Responce = ResponceResult.SuccessResponseList(result);
                    return Responce;
                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No Record Found");
                    return Responce;
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.viewGetPass, 0);

            }
            return Responce;
        }
        /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */
        /* GET BARCODE TO PRINT AS PER PATTERN - 19 DEC 2023 */
        [HttpPost]
        [Route(APIRoute.GRN.ShowGeneratedSerialList)]
        public ResponceList ShowGeneratedSerialList(ShowGeneratedSerialList ReqPara)
        {
            ResponceList Responce = new ResponceList();

            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.ShowGeneratedSerialList(ReqPara);
                    JObject QRCodeResult = new JObject();
                    JArray jrQRCode = new JArray();
                    int QRType = 0;
                    int PrefixType = 0;
                    var jResult = result["Table"];

                    for (int i = 0; i < jResult.Count(); i++)
                    {
                        var jSkuItem = jResult[i];
                        var getBarcodeText = jSkuItem["BarcodeString"];
                        DataMatrix dm = new DataMatrix(getBarcodeText.ToString(), QRType, PrefixType);
                        string outputstr = dm.Encode();
                        result["Table"][i]["QRCode"] = outputstr;
                    }
                    Responce = ResponceResult.SuccessResponseList(result);
                    return Responce;

                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No Record Found");
                    return Responce;
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.ShowGeneratedSerialList, 0);

            }
            return Responce;
        }
        /* GET BARCODE TO PRINT AS PER PATTERN - 19 DEC 2023 */

        /* BARCODE SELECTED PRINT LABEL - 03 JUNE 2024 */
        [HttpPost]
        [Route(APIRoute.GRN.GetGrnPrintLabelStyle)]
        public ResponceList GetGrnPrintLabelStyle(GetGrnPrintLabelStyle ReqPara)
        {
            ResponceList Responce = new ResponceList();

            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.GetGrnPrintLabelStyle(ReqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                    return Responce;

                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No Record Found");
                    return Responce;
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.viewGetPass, 0);

            }
            return Responce;
        }
        [HttpPost]
        [Route(APIRoute.GRN.SaveGrnPrintLabelStyle)]
        public ResponceList SaveGrnPrintLabelStyle(SaveGrnPrintLabelStyle ReqPara)
        {
            ResponceList Responce = new ResponceList();

            try
            {
                if (ReqPara != null)
                {
                    JObject result = obj.SaveGrnPrintLabelStyle(ReqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                    return Responce;

                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No Record Found");
                    return Responce;
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.viewGetPass, 0);

            }
            return Responce;
        }
        /* BARCODE SELECTED PRINT LABEL - 03 JUNE 2024 */
    }
}