using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Model;

namespace StockManagementSystemWebApp.DAL
{
    public class CategoryGateway : BaseGateway
    {
        public bool IsExistsCategory(string categoryName)
        {
            string query = "SELECT * FROM Category WHERE CategoryName = '" + categoryName + "' ";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExistsCategory = reader.HasRows;
            connection.Close();

            return IsExistsCategory;
        }

        public int Save(Category category)
        {
            string query = "INSERT INTO Category VALUES('" + category.CategoryName + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM Category";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Category> categories = new List<Category>();
          //  int serialNumber = 0;
            while (reader.Read())
            {
            //    serialNumber++;
                Category category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();
            //    category.SerialNumber = serialNumber;

                categories.Add(category);
            }

            reader.Close();
            connection.Close();
            return categories;
        }

        public  Category GetCategoryById(int id)
        {
            string query = "SELECT * FROM Category WHERE Id= " + id + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            Category category = null;
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.CategoryName = reader["CategoryName"].ToString();

            }
            connection.Close();
            return category;
        }

        public int UpdateCategoryById(Category category)
        {
            string query = "UPDATE  Category SET CategoryName = '" + category.CategoryName + "' WHERE Id= " + category.Id + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}