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
    public class AllocationUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public AllocationUtility()
        {
            obj = new DBActivity();
        }
        public JObject BatchList(BatchListRequest req)
        {
            DataSet ds = new DataSet();
            if (req.filterval == null || req.filtercol == "All") { req.filtercol = ""; }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpg", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlmt", Int32.Parse(req.recordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@skeycol", req.filtercol),
                        new SqlParameter("@skeyval", req.filterval),
                        new SqlParameter("@clientid", Int64.Parse(req.ClientId))
                    };
            
            ds = obj.Return_DataSet("Sp_GetBatchList", param);
            
            int totcnt = 0, socnt = 0, allocnt = 0, pickcnt = 0, stgcnt = 0, cnclcnt = 0, packing = 0, qccnt = 0;
            string IsQC = "NO";

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
                    IsQC = ds.Tables[0].Rows[0]["IsQC"].ToString();
                }

                jsonString = "{\"BatchListResult\":[{";
                jsonString = jsonString + "\"CurrentPage\":\"" + req.CurrentPage + "\",";
                jsonString = jsonString + "\"TotalRecords\":\"" + totcnt + "\",";
                jsonString = jsonString + "\"Dashboard\":[{";
                jsonString = jsonString + "\"OutboundOrder\":\"" + socnt + "\",";
                jsonString = jsonString + "\"Allocated\":\"" + allocnt + "\",";
                jsonString = jsonString + "\"Picking\":\"" + pickcnt + "\",";
                jsonString = jsonString + "\"QC\":\"" + qccnt + "\",";
                jsonString = jsonString + "\"Packing\":\"" + packing + "\",";
                jsonString = jsonString + "\"Shipped\":\"" + stgcnt + "\",";
                jsonString = jsonString + "\"CancelOrder\":\"" + cnclcnt + "\",";
                jsonString = jsonString + "\"IsQC\":\"" + IsQC + "\"";
                jsonString = jsonString + "}],";

                if (totcnt > 0)
                {
                    jsonString = jsonString + "\"BatchList\":";
                    jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]);
                }
                else
                {
                    jsonString = jsonString + "\"BatchList\":[]";
                }
                jsonString = jsonString + "}]}";


            }
            catch (Exception ex) { }
            return JObject.Parse(jsonString);
        }

        #region Allocation Plan
        public string saveplandirect(saveplandirectrequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SONO", req.ordernumber),
                        new SqlParameter("@userid", Int64.Parse(req.userid)),
                        new SqlParameter("@customerid", Int64.Parse(req.customerid))
                    };
            return obj.Return_ScalerValue("createbatchdirectnew", param);
        }
        public JObject getallocationplansumry(getallocationplansumryrequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SONO", req.orderid)                      
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("AllocationPlanSummaryDirect", param));
        }
        public JObject Getalcplndtl(Getalcplndtlrequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SONO", Int64.Parse(req.orderid))
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("allocationplandtl", param));
        }
        public JObject allocationplandtlsearch(allocationplandtlsearchRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@whrcondition", req.wherecondition),
                        new SqlParameter("@ordrids", req.ordrid)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("allocationplandtlsearch", param));
        }
        public string updateallocationplanQty(updateallocationplanQty req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@alcplnid", Convert.ToInt64(req.ID)),
                        new SqlParameter("@newqty", Decimal.Parse(req.newqty)),
                        new SqlParameter("@orgqty", Decimal.Parse(req.originalqty)),
                        new SqlParameter("@obj", req.Object)
                    };
            return obj.Return_ScalerValue("updallocationplanquantity", param);
        }
        public string updallocationplanintransitquantity(updateallocationplanQty req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@alcplnid", Convert.ToInt64(req.ID)),
                        new SqlParameter("@newqty", Decimal.Parse(req.newqty)),
                        new SqlParameter("@orgqty", Decimal.Parse(req.originalqty))
                    };
            return obj.Return_ScalerValue("updallocationplanintransitquantity", param);
        }
        public string getbatchidbysoids(getbatchidbysoids req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", req.soid)
                    };
            return obj.Return_ScalerValue("getbatchidbysoids", param);
        }
        public string getbatchidbysoid(long soid)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", soid)
                    };
            return obj.Return_ScalerValue("getbatchidbysoids", param);
        }
        public string UpdateResurveqty(long batchid,string confirm)
        {
            DataSet ds = new DataSet();
            string res = "";
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", batchid)
                    };
            int result = Convert.ToInt32(obj.Return_ScalerValue("CheckPickloc", param));
            param = null;

            if(result == 0)
            {
                param = new SqlParameter[]
                   {
                        new SqlParameter("@batchID", batchid)
                   };
                res = obj.Return_ScalerValue("SP_UpdateResurveqty", param);
            }
            else if (result > 0 && confirm == "yes")
            {
                param = new SqlParameter[]
                   {
                        new SqlParameter("@batchID", batchid)
                   };
                res = obj.Return_ScalerValue("SP_UpdateResurveqty", param);
            }
            else if(result > 0 && confirm == "no")
            {
                res = "confirm";
            }
            return res;
        }
        public string cancelbatch(long batchid)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@batchID", batchid)
                    };
            return obj.Return_ScalerValue("cancelbatch", param);
        }
        public string DeAllocate(DeAllocateRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@batchid", Convert.ToInt64(req.BatchId)),
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId))
                    };
            return obj.Return_ScalerValue("SP_DeallocateBatch", param);
        }

        #endregion

        #region Manual Allocation
        public JObject getmanualallocationplanskuwise(string Prd, string soid)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", soid),
                        new SqlParameter("@Prd", Prd)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("getmanualallocationofsku", param));
        }
        public JObject searchmanualallocation(string whrcond, string ordrid, string prdid)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@whrcondition", whrcond),
                        new SqlParameter("@ordrid", ordrid),
                        new SqlParameter("@prdid", prdid)
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("searchmanualallocation", param));
        }
        public string updatemanualallocationqty(updatemanualqtyrequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@alcplnid", req.id),
                        new SqlParameter("@newqty", req.newQty),
                        new SqlParameter("@oldqty", req.orgQty)
                    };
            return obj.Return_ScalerValue("updateManualallocationQty", param);
        }
        #endregion
        public JObject TotalShrotQty(TotalShrotQtyRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderId", Int64.Parse(req.OrderId)),
                        new SqlParameter("@BatchId", Int64.Parse(req.BatchId)),
                        new SqlParameter("@BatchName", req.BatchName),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@whId", Int64.Parse(req.whId)),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_TotalShortQty", param));
        }

    }
}