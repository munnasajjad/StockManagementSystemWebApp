using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.BLL.Model
{
    public class StockIn
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
    }
}