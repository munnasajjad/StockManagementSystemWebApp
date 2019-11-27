using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Model;
using StockManagementSystemWebApp.BLL.View;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class StockOutManager
    {
        private StockOutGateway stockOutGateway;

        public StockOutManager()
        {
            stockOutGateway = new StockOutGateway();
        }

        public List<Company> GetAllCompanies()
        {
            return stockOutGateway.GetAllCompanies();
        }

        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            return stockOutGateway.GetAllItemsByCompanyId(companyId);
        }

        public Item GetReorderLevelByItemId(int itemId)
        {
            return stockOutGateway.GetReorderLevelByItemId(itemId);
        }

        public StockIn GetAvailableQuantityByItemId(int itemId)
        {
            return stockOutGateway.GetAvailableQuantityByItemId(itemId);
        }

        public string UpdateAvailableQuantityById(StockIn stockIn)
        {
            int rowAffect = stockOutGateway.UpdateAvailableQuantityByItemId(stockIn);

            if (rowAffect > 0)
            {
                return "Item stored before. Restored successfully! ";
            }
            else
            {
                return "Failed to restore item!";
            }
        }

        public int UpdateAvailableQuantity(StockOut stockOut)
        {
            int rowAffect = stockOutGateway.UpdateAvailableQuantity(stockOut);
            return rowAffect;
        }

        public string Save(StockOut stockOut)
        {
            int rowAffect = stockOutGateway.Save(stockOut);
            if (rowAffect > 0)
            {
                return "successfully!";
            }
            else
            {
                return "Failed to";
            }
        }
        public List<GetStockInfoView> GetDataBtnDate(string fromDate, string toDate)
        {
            return stockOutGateway.GetDataBtnDate(fromDate, toDate);
        }
    }
}