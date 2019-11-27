using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.BLL.View
{
    [Serializable]
    public class GetStockInfoView
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CategoryId { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
        public int StockOutQuantity { get; set; }
        public DateTime EntryDate { get; set; }
        public string Action { get; set; }
    }
}