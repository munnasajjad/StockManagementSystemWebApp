using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.BLL.Model
{
    public class Item
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }

    }
}