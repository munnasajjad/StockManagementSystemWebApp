using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.View;

namespace StockManagementSystemWebApp.BLL.Model
{
    [Serializable]
    public class StockOut : StockOutExtend
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }
        public int StockOutQuantity { get; set; }
        public DateTime StockOutDate { get; set; }
        public string Action { get; set; }
    }
}