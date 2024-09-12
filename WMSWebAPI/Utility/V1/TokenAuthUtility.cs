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
    public class TokenAuthUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public TokenAuthUtility()
        {
            obj = new DBActivity();
        }
        public string AuthApiAccess(AuthApiAccessRequest req)
        {
            string authResult = "";
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserID),
                        new SqlParameter("@AuthToken", req.Token)

                    };
            DataSet authDataSet = obj.Return_DataSet("APIAuthlogin", param);
            authResult = authDataSet.Tables[0].Rows[0]["Result"].ToString();
            return authResult;
        }

        public string SaveAuthToken(SaveNewTokenAuthRequest req)
        {
            string authResult = "";
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Token", req.Token),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerId)

                    };
            // Example: tokenInsertDetails 'TKM-288833',1,'BrillAdmin',1,1
            DataSet authDataSet = obj.Return_DataSet("APIAuthlogin", param);
            authResult = authDataSet.Tables[0].Rows[0]["Result"].ToString();
            return authResult;
        }

        public JObject CloseAuthToken(CloseTokenAuthRequest req)
        {
            string authResult = "";
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Token", req.Token),
                        new SqlParameter("@UserId", req.UserID),
                        new SqlParameter("@CompanyId", req.CompanyID)
                    };
            //  DataSet authDataSet = obj.Return_DataSet("tokenclosesession", param);
            //  authResult = authDataSet.Tables[0].Rows[0]["Result"].ToString();
            // return authResult;
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("tokenclosesession", param));
        }

        public string GetActiveTokenForUser(GetActiveTokenForUserRequest req)
        {
            string authResult = "";
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Token", req.UserID)
                    };
            DataSet authDataSet = obj.Return_DataSet("tokenchecksession", param);
            authResult = authDataSet.Tables[0].Rows[0]["Result"].ToString();
            return authResult;
        }

        public string GenerateTokenCode()
        {
            string authResult = "";
            param = new SqlParameter[]
                    {
                    };
            DataSet authDataSet = obj.Return_DataSet("createTokenCode", param);
            authResult = authDataSet.Tables[0].Rows[0]["Result"].ToString();
            return authResult;
        }
        /* API to lock and unlock user sessions - 06 Dec 2023 */
        public JObject CloseUserSessions(CloseUserSessionsRequest req)
        {
            string authResult = "";
            param = new SqlParameter[]
                    {
                        new SqlParameter("@RequesterUserId", req.RequesterUserId),
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@SessionUserId", req.SessionUserId),
                        new SqlParameter("@SessionCompanyId", req.SessionCompanyId)
                    };
            //  DataSet authDataSet = obj.Return_DataSet("tokenclosesession", param);
            //  authResult = authDataSet.Tables[0].Rows[0]["Result"].ToString();
            // return authResult;
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("CloseAllUserSessions", param));
        }
        /* API to lock and unlock user sessions - 06 Dec 2023 */
    }
}