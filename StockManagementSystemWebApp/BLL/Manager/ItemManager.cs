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
    public class ItemManager
    {
        private ItemGateway itemGateway;

        public ItemManager()
        {
            itemGateway = new ItemGateway();
        }

        public List<Company> GetCompanies()
        {
            return itemGateway.GetAllCompanies();
        }

        public List<Category> GetAllCategories()
        {
            return itemGateway.GetAllCategories();
        }

        public string Save(Item item)
        {
            int rowAffect = itemGateway.Save(item);
            if (rowAffect > 0)
            {
                return "Saved succesfully!";
            }
            else
            {
                return "Falied to save!";
            }
        }

        public bool IsExistsItem(string itemName)
        {
            return itemGateway.IsItemExists(itemName);
        }

        public List<GetItemsSummary> GetItemsByCompanyId(int companyId)
        {
            return itemGateway.GetItemsByCompanyId(companyId);
        }

        public List<GetItemsSummary> GetItemsByCategoryId(int categoryId)
        {
            return itemGateway.GetItemsByCategoryId(categoryId);
        }


        public List<GetItemsSummary> GetItems(int categoryId, int companyId)
        {
            return itemGateway.GetItems(categoryId, companyId);
        }

        public List<GetItemsSummary> GetAllItems()
        {
            return itemGateway.GetAllItems();
        }

    }
}