﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetDropdownListRequest
    {
        public string UserId { get; set; }
    }
    public class reqWarehouseList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
    }
}