using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.BLL.Model
{
    [Serializable]
    public class StockOutExtend
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
    }
}