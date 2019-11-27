using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Web;

namespace StockManagementSystemWebApp.BLL.View
{
    public class GetItemsSummary
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
        
    }
}