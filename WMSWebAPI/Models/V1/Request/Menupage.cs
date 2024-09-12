using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class MenupageRequest
    {
        public string UserID { get; set; }
        public string UserType { get; set; }
        public string ParentId { get; set; }

    }
}
