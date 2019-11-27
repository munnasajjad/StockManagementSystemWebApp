using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Model;
using StockManagementSystemWebApp.BLL.View;

namespace StockManagementSystemWebApp.DAL
{
    public class ItemGateway : BaseGateway
    {
        public List<Company> GetAllCompanies()
        {
            string query = "SELECT * FROM Company";
            command = new SqlCommand(query, connection);

            List<Company> companies = new List<Company>();
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.CompanyName = reader["CompanyName"].ToString();

                companies.Add(company);
            }
            connection.Close();

            return companies;
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM Category";
            command = new SqlCommand(query, connection);

            List<Category> categories = new List<Category>();
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();

                categories.Add(category);
            }
            connection.Close();

            return categories;
        }

        public int Save(Item item)
        {
            string query = "INSERT INTO Item VALUES(" + item.CategoryId + ", " + item.CompanyId + ",'" + item.ItemName + "'," + item.ReorderLevel + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsItemExists(string itemName)
        {
            string query = "SELECT * FROM Item WHERE ItemName = '" + itemName + "' ";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExistsItem = reader.HasRows;
            connection.Close();

            return isExistsItem;
        }

        public List<GetItemsSummary> GetItemsByCompanyId(int companyId)
        {
            string query = "SELECT * FROM GetItemsSummary WHERE CompanyId =" + companyId + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            List<GetItemsSummary> getItemsSummaries = new List<GetItemsSummary>();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetItemsSummary getItemsSummary = new GetItemsSummary();
                getItemsSummary.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                getItemsSummary.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                getItemsSummary.ItemId = Convert.ToInt32(reader["ItemId"]);
                getItemsSummary.ItemName = reader["ItemName"].ToString();
                getItemsSummary.CompanyName = reader["CompanyName"].ToString();
                getItemsSummary.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                getItemsSummary.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);

                getItemsSummaries.Add(getItemsSummary);
            }
            connection.Close();

            return getItemsSummaries;
        }

        public List<GetItemsSummary> GetItemsByCategoryId(int categoryId)
        {
            string query = "SELECT * FROM GetItemsSummary WHERE CategoryId =" + categoryId + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            List<GetItemsSummary> getItemsSummaries = new List<GetItemsSummary>();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetItemsSummary getItemsSummary = new GetItemsSummary();
                getItemsSummary.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                getItemsSummary.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                getItemsSummary.ItemId = Convert.ToInt32(reader["ItemId"]);
                getItemsSummary.ItemName = reader["ItemName"].ToString();
                getItemsSummary.CompanyName = reader["CompanyName"].ToString();
                getItemsSummary.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                getItemsSummary.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);

                getItemsSummaries.Add(getItemsSummary);
            }
            connection.Close();

            return getItemsSummaries;
        }


        public List<GetItemsSummary> GetItems(int categoryId, int companyId)
        {
            string query = "SELECT * FROM GetItemsSummary WHERE CategoryId =" + categoryId + " AND CompanyId= " + companyId + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            List<GetItemsSummary> getItemsSummaries = new List<GetItemsSummary>();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetItemsSummary getItemsSummary = new GetItemsSummary();
                getItemsSummary.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                getItemsSummary.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                getItemsSummary.ItemId = Convert.ToInt32(reader["ItemId"]);
                getItemsSummary.ItemName = reader["ItemName"].ToString();
                getItemsSummary.CompanyName = reader["CompanyName"].ToString();
                getItemsSummary.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                getItemsSummary.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);

                getItemsSummaries.Add(getItemsSummary);
            }
            connection.Close();

            return getItemsSummaries;
        }

        public List<GetItemsSummary> GetAllItems()
        {
            string query = "SELECT * FROM GetItemsSummary";
            command = new SqlCommand(query, connection);
            connection.Open();
            List<GetItemsSummary> getItemsSummaries = new List<GetItemsSummary>();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                GetItemsSummary getItemsSummary = new GetItemsSummary();
                getItemsSummary.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                getItemsSummary.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                getItemsSummary.ItemId = Convert.ToInt32(reader["ItemId"]);
                getItemsSummary.ItemName = reader["ItemName"].ToString();
                getItemsSummary.CompanyName = reader["CompanyName"].ToString();
                getItemsSummary.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                getItemsSummary.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);

                getItemsSummaries.Add(getItemsSummary);
            }
            connection.Close();

            return getItemsSummaries;
        }

    }
}