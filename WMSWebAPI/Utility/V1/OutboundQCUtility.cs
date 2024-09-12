using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class OutboundQCUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public OutboundQCUtility()
        {
            obj = new DBActivity();
        }
        
        public JObject QCList(GetQCListRequest req)
        {
            DataSet ds = new DataSet();
            if (req.whereFilterCondtion == null || req.whereFilterCondtion == "All") { req.whereFilterCondtion = ""; }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@curentpg", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@limit", Int32.Parse(req.recordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@scol", req.whereFilterCondtion),
                        new SqlParameter("@skey", req.SearchValue),
                        new SqlParameter("@clientid", Int64.Parse(req.ClientId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId))
                    };
            ds = obj.Return_DataSet("SP_QCList", param);
            int totcnt = 0, socnt = 0, allocnt = 0, pickcnt = 0, stgcnt = 0, cnclcnt = 0, packing = 0, qccnt = 0;            

            String jsonString = String.Empty;
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRecords"]);
                    socnt = Convert.ToInt32(ds.Tables[0].Rows[0]["OutboundOrder"]);
                    allocnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Allocated"]);
                    pickcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Picking"]);
                    packing = Convert.ToInt32(ds.Tables[0].Rows[0]["Packing"]);
                    stgcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Dispatch"]);
                    cnclcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["CancelOrder"]);
                    qccnt = Convert.ToInt32(ds.Tables[0].Rows[0]["QC"]);
                }

                jsonString = "{\"QCListResult\":[{";
                jsonString = jsonString + "\"CurrentPage\":\"" + req.CurrentPage + "\",";
                jsonString = jsonString + "\"TotalRecords\":\"" + totcnt + "\",";
                jsonString = jsonString + "\"Dashboard\":[{";
                jsonString = jsonString + "\"OutboundOrder\":\"" + socnt + "\",";
                jsonString = jsonString + "\"Allocated\":\"" + allocnt + "\",";
                jsonString = jsonString + "\"Picking\":\"" + pickcnt + "\",";
                jsonString = jsonString + "\"QC\":\"" + qccnt + "\",";
                jsonString = jsonString + "\"Packing\":\"" + packing + "\",";
                jsonString = jsonString + "\"Shipped\":\"" + stgcnt + "\",";
                jsonString = jsonString + "\"CancelOrder\":\"" + cnclcnt + "\"";
                jsonString = jsonString + "}],";               

                if (totcnt > 0)
                {
                    jsonString = jsonString + "\"QCList\":";
                    jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]);
                }
                else
                {
                    jsonString = jsonString + "\"QCList\":[]";
                }
                jsonString = jsonString + "}]}";


            }
            catch (Exception ex) { }
            return JObject.Parse(jsonString);
        }
        public JObject BatchQCList(GetBatchQCListRequest req)
        {
            DataSet ds = new DataSet();
            string Header = "Batch No,Batch Name,Pick Up No,Pick Up Date,Pick Up By,Status";
            String jsonString = String.Empty;
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", req.BatchID),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@OrderId", req.OrderId)
                    };
            ds = obj.Return_DataSet("SP_BatchQCList", param);
            jsonString = "{\"BatchQCListResult\":[{";

            jsonString = jsonString + "\"HeaderList\":\"" + Header + "\",";
            if (ds.Tables[0].Rows.Count > 0)
            {
                jsonString = jsonString + JsonConvert.SerializeObject(ds).TrimStart('{').TrimEnd('}');
            }
            else
            {
                jsonString = jsonString + "\"BatchQCList\":[]";
            }
            jsonString = jsonString + "}]}";

            return JObject.Parse(jsonString);
        }
        public JObject ReasonCode(GetReasonCodeRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId))
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_ReasonCode", param));
        }
        public JObject QCDetail(GetQCDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@Soid", Int64.Parse(req.SOID)),
                        new SqlParameter("@QCIDPara", Int64.Parse(req.QCIDPara)),
                    };
            
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetQCHeadDetail", param));
        }
        public JObject QCRemoveSKU(RemoveQCSKURequestOut req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@gid", Int64.Parse(req.gID)),
                        new SqlParameter("@recordID", Int64.Parse(req.recordID)),
                        new SqlParameter("@obj",req.obj)

                    };

            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_RemoveQCOutBSKU", param));
        }
        public JObject QCSuggestSKU(GetQCSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@skey", req.skey),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SOID", Int64.Parse(req.SOID)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("QCSuggestSKU", param));
        }
        public JObject QCSKUDetail(GetQCSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@skuid", Int64.Parse(req.SKUID)),
                        new SqlParameter("@lot", req.Lot),
                        new SqlParameter("@SOID", req.SOID),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("GetQCSKUDetail", param));
        }
        public string SaveQCDetail(SaveQCSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@remark", req.Remark),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@prdid", Int64.Parse(req.ProdId)),
                        new SqlParameter("@lot1", req.Lot1),
                        new SqlParameter("@lot2", req.Lot2),
                        new SqlParameter("@lot3", req.Lot3),
                        new SqlParameter("@lot4", req.Lot4),
                        new SqlParameter("@lot5", req.Lot5),
                        new SqlParameter("@lot6", req.Lot6),
                        new SqlParameter("@lot7", req.Lot7),
                        new SqlParameter("@lot8", req.Lot8),
                        new SqlParameter("@lot9", req.Lot9),
                        new SqlParameter("@lot10", req.Lot10),
                        new SqlParameter("@qty", Decimal.Parse(req.Qty)),
                        new SqlParameter("@rejqty", Decimal.Parse(req.RejectQty)),
                        new SqlParameter("@rid", Int64.Parse(req.ReasonID)),
                        new SqlParameter("@soid", Int64.Parse(req.SOID)),
                        new SqlParameter("@qcidPara", Int64.Parse(req.qcidPara)),
                    };
            return obj.Return_ScalerValue("SaveQCDetailWeb", param);
        }
        public string FinalSaveQCDetail(FinalSaveQCSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SOID", Int64.Parse(req.SOID))
                    };
            return obj.Return_ScalerValue("FinalSaveQCDetail", param);
        }
        public string AutoPacking(Int64 BatchId, Int64 PickUpId, Int64 CustomerId, Int64 WarehouseId, Int64 UserId)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", BatchId),
                        new SqlParameter("@pkid", PickUpId),
                       /// new SqlParameter("@compId", compid),
                        new SqlParameter("@custid", CustomerId),
                        new SqlParameter("@wrid", WarehouseId),
                        new SqlParameter("@uid", UserId)
                        ///new SqlParameter("@OrderId",OrderId)
                    };
            return obj.Return_ScalerValue("AutoPackingOrders", param);
        }
    }
}