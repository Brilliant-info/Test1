﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;
using System.Data;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Text;

namespace WMSWebAPI.Utility.V1
{
    public class WinAppUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public WinAppUtility()
        {
            obj = new DBActivity();
        }

        public JObject InboundOrderNo(GetWinInboundRequest req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {
                       
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Warehouseid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                       
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_InboundList", param));

        }
        public JObject InboundOrderNoDetails(GetWinInboundReqDetails req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {

                        new SqlParameter("@OrderRefNo", req.OrderRefNo),
                        new SqlParameter("@POID", Int64.Parse(req.POID)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_InboundDetails", param));

        }
        public JObject ProdOrderNo(GetWinInboundRequest req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {

                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Warehouseid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_ProdList", param));

        }
        public JObject ProdDetails(GetWinInboundReqDetails req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {

                        new SqlParameter("@OrderRefNo", req.OrderRefNo),
                        new SqlParameter("@POID", Int64.Parse(req.POID)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_ProdDetails", param));

        }
        public JObject GetLabelfileName(GetLabelfileName req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {

                        new SqlParameter("@companyid",Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@LabelType", req.LabelType),
                        new SqlParameter("@LabelSize",req.LabelSize),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetLabelPrintPRN", param));

        }
        public JObject GetInboundPrintBarcode(GetInboundPrintBarcode req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {

                        new SqlParameter("@PKID",req.PKID),
                        new SqlParameter("@type",  req.type)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_Inboundbarcodelblprint", param));

        }
        public JObject SaveGatePassLottable(WinSaveGatePassLottableRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@GetPassID", Convert.ToInt64(req.GetPassID)),
                        new SqlParameter("@SkuId", Convert.ToInt64(req.SkuId)),
                        new SqlParameter("@Qty", Convert.ToInt64(req.Qty)),
                        new SqlParameter("@GrnId", Convert.ToInt64(req.GrnId)),
                        new SqlParameter("@Lottable1", req.Lottable1),
                        new SqlParameter("@Lottable2", req.Lottable2),
                        new SqlParameter("@Lottable3", req.Lottable3),
                         new SqlParameter("@Lottable4", req.Lottable4),
                        new SqlParameter("@Lottable5", req.Lottable5),
                        new SqlParameter("@Lottable6", req.Lottable6),
                         new SqlParameter("@Lottable7", req.Lottable7),
                        new SqlParameter("@Lottable8", req.Lottable8),
                        new SqlParameter("@Lottable9", req.Lottable9),
                         new SqlParameter("@Lottable10", req.Lottable10),
                        new SqlParameter("@UomId", Convert.ToInt64(req.UomId)),
                        new SqlParameter("@UOM", req.UOM),
                        new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@WarehouseId", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@InwardOrderNo", Convert.ToInt64(req.InwardOrderNo)),
                        new SqlParameter("@Packsize",  req.PackSize ),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_SaveGatepassLottables", param));
        }
        public JObject SaveBarcodeHistory(WinSaveBarcodeHistoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SkuId", Convert.ToInt64(req.SkuId)),
                        new SqlParameter("@JobOrderNo",  req.JobOrderNo ),
                        new SqlParameter("@OperatorCode", req.OperatorCode),
                        new SqlParameter("@Scanbarcode", req.Scanbarcode),
                        new SqlParameter("@Lottable1", req.Lottable1),
                        new SqlParameter("@Lottable2", req.Lottable2),
                        new SqlParameter("@Lottable3", req.Lottable3),
                         new SqlParameter("@Lottable4", req.Lottable4),
                        new SqlParameter("@Lottable5", req.Lottable5),
                        new SqlParameter("@Lottable6", req.Lottable6),
                         new SqlParameter("@Lottable7", req.Lottable7),
                        new SqlParameter("@Lottable8", req.Lottable8),
                        new SqlParameter("@Lottable9", req.Lottable9),
                         new SqlParameter("@Lottable10", req.Lottable10),
                        new SqlParameter("@Weight",  req.Weight ),
                        new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                        new SqlParameter("@WarehouseId", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@CompanyId", Convert.ToInt64(req.CompanyId)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_SaveBarcodeHistory", param));
        }
        public JObject GetBarcodeWthlottable(GetBarcodeWthlottable req)
        {
            param = new SqlParameter[]
                    {
                        
                        new SqlParameter("@Barcode",  req.Barcode ),
                        new SqlParameter("@JobOrderNo",  req.JobOrderNo ),
                        new SqlParameter("@OperatorCode",  req.OperatorCode ),
                        new SqlParameter("@Weight",  req.Weight ),
                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@WHID", Convert.ToInt64(req.WHID)),
                        new SqlParameter("@customerID", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_scan_Serialised", param));
        }
        public JObject GetBOMDDL(GetBOMDDL req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@WHID", Convert.ToInt64(req.WHID)),
                        new SqlParameter("@customerID", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetBOMDDL", param));
        }
        public JObject GetBOMDetails(GetBOMDetails req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@BOMID", Convert.ToInt64(req.BOMID)),
                        new SqlParameter("@Barcode",  req.Barcode),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@warehouseID", Convert.ToInt64(req.warehouseID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetBOMDetails", param));
        }
        public JObject GetFGDDL(GetFGDDL req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@WHID", Convert.ToInt64(req.WHID)),
                        new SqlParameter("@customerID", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetFGDDL", param));
        }
        public JObject GetFGDetails(GetFGDetails req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@FGID", Convert.ToInt64(req.BOMID))

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetFGDetails", param));
        }
        public JObject GetBOMLIST(GetBOMLIST req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@warehouseID", Convert.ToInt64(req.WHID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetBOMList", param));
        }
        public JObject GetBOMEdit(GetBOMEdit req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@BOMID", Convert.ToInt64(req.BOMID)),
                        new SqlParameter("@warehouseID", Convert.ToInt64(req.WHID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetBOMEdit", param));
        }
        public JObject GetBOMSkuList(GetBOMSkuList req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@warehouseID", Convert.ToInt64(req.WHID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetSkulist", param));
        }
        public JObject GetBOMDetailsEdit(GetBOMDetailsEdit req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UID", Convert.ToInt64(req.UID)),
                        new SqlParameter("@CustomerId", Convert.ToInt64(req.customerID)),
                        new SqlParameter("@warehouseID", Convert.ToInt64(req.WHID)),
                        new SqlParameter("@companyId", Convert.ToInt64(req.companyId)),
                        new SqlParameter("@BOMID", Convert.ToInt64(req.BOMID)),

                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("WinApp_GetBOMDetailsEdit", param));
        }
    }
}