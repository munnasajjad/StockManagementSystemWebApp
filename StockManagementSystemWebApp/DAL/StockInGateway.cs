using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using StockManagementSystemWebApp.BLL.Model;
using StockManagementSystemWebApp.BLL.View;

namespace StockManagementSystemWebApp.DAL
{
    public class StockInGateway : BaseGateway
    {
        public List<Company> GetAllCompanies()
        {
            string query = "SELECT DISTINCT Id, CompanyName FROM Company ";
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

        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            string query = "SELECT * FROM Item WHERE CompanyId = " + companyId + " ";
            command = new SqlCommand(query, connection);

            connection.Open();
            List<Item> items = new List<Item>();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();

                items.Add(item);
            }
            connection.Close();

            return items;
        }

        public Item GetReorderLevelByItemId(int itemId)
        {
            string query = "SELECT ReorderLevel FROM Item WHERE Id = " + itemId + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            Item item = new Item();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
            }
            connection.Close();
            return item;
        }

        public StockIn GetAvailableQuantityByItemId(int itemId)
        {
            string query = "SELECT AvailableQuantity FROM StockIn WHERE ItemId =" + itemId + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            StockIn stockIn = new StockIn();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                stockIn.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
            }
            connection.Close();

            return stockIn;
        }

        public bool IsItemExists(int itemId)
        {
            string query = "SELECT * FROM StockIn WHERE ItemId = " + itemId + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsItemExists = reader.HasRows;
            connection.Close();

            return IsItemExists;
        }

        public int UpdateAvailableQuantityByItemId(StockIn stockIn)
        {
            string query = "UPDATE StockIn SET AvailableQuantity = " + stockIn.AvailableQuantity + " WHERE ItemId ="+stockIn.ItemId+"  ";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public int Save(StockIn stockIn)
        {
            string query = "INSERT INTO StockIn VALUES(" + stockIn.ItemId + ", " + stockIn.ReorderLevel + ", " +
                           stockIn.AvailableQuantity + ")";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
     }
}