using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Model;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class StockInManager
    {
        private StockInGateway stockInGateway;

        public StockInManager()
        {
            stockInGateway = new StockInGateway();
        }

        public List<Company> GetAllCompanies()
        {
            return stockInGateway.GetAllCompanies();
        }

        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            return stockInGateway.GetAllItemsByCompanyId(companyId);
        }

        public Item GetReorderLevelByItemId(int itemId)
        {
            return stockInGateway.GetReorderLevelByItemId(itemId);
        }

        public StockIn GetAvailableQuantityByItemId(int itemId)
        {
            return stockInGateway.GetAvailableQuantityByItemId(itemId);
        }

        public bool IsItemExists(int itemId)
        {
            return stockInGateway.IsItemExists(itemId);
        }

        public string UpdateAvailableQuantityById(StockIn stockIn)
        {
            int rowAffect = stockInGateway.UpdateAvailableQuantityByItemId(stockIn);

            if (rowAffect > 0)
            {
                return "Item stored before. Restored successfully! ";
            }
            else
            {
                return "Failed to restore item!";
            }
        }

        public string Save(StockIn stockIn)
        {
            int rowAffect = stockInGateway.Save(stockIn);

            if (rowAffect > 0)
            {
                return "Item stored successfully! ";
            }
            else
            {
                return "Failed to store item!";
            }
        }
    }
}