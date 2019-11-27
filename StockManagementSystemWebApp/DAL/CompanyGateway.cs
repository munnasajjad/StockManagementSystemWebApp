using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Model;

namespace StockManagementSystemWebApp.DAL
{
    public class CompanyGateway : BaseGateway
    {
        public bool IsExistsCompany(string companyName)
        {
            string query = "SELECT * FROM Company WHERE CompanyName = '" + companyName + "' ";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExistsCompany = reader.HasRows;
            connection.Close();

            return IsExistsCompany;
        }

        public int Save(Company company)
        {
            string query = "INSERT INTO Company VALUES('" + company.CompanyName + "')";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public List<Company> GetAllCompanies()
        {
            string query = "SELECT * FROM Company";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();

            List<Company> companies = new List<Company>();
           // int serialNumber = 0;
            while (reader.Read())
            {
                //serialNumber++;
                Company company = new Company();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.CompanyName = reader["CompanyName"].ToString();
                companies.Add(company);
            }

            reader.Close();
            connection.Close();
            return companies;
        }

        public Company GetCompanyById(int id)
        {
            string query = "SELECT * FROM Company WHERE Id= " + id + " ";
            command = new SqlCommand(query, connection);
            connection.Open();
            Company company = null;
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                company = new Company();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.CompanyName = reader["CompanyName"].ToString();

            }
            connection.Close();
            return company;
        }

        public int UpdateCompanyById(Company company)
        {
            string query = "UPDATE  Company SET CompanyName = '"+company.CompanyName+"' WHERE Id= "+company.Id+" ";
            command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}