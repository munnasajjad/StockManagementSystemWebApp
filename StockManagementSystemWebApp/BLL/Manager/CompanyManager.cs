using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.BLL.Model;
using StockManagementSystemWebApp.DAL;

namespace StockManagementSystemWebApp.BLL.Manager
{
    public class CompanyManager
    {
        private CompanyGateway companyGateway;

        public CompanyManager()
        {
            companyGateway = new CompanyGateway();
        }

        public string Save(Company company)
        {
            bool IsExistsCompany = companyGateway.IsExistsCompany(company.CompanyName);
            if (IsExistsCompany)
            {
                return "Company name already exist! Try another company name.";
            }
            else
            {
                int rowAffect = companyGateway.Save(company);
                if (rowAffect > 0)
                {
                    return "Company saved succesfully!";
                }
                else
                {
                    return "Failed to save company!";
                }
            }
        }

        public List<Company> GetAllCompanies()
        {
            return companyGateway.GetAllCompanies();
        }

        public Company GetCompanyById(int id)
        {
            return companyGateway.GetCompanyById(id);
        }

        public string UpdateCompanyById(Company company)
        {
            int rowAffect = companyGateway.UpdateCompanyById(company);
            if (rowAffect > 0)
            {
                return "Updated successfully!";
            }
            else
            {
                return "Failed to update!";
            }
        }

        public bool IsExistsCompany(string companyName)
        {
            return companyGateway.IsExistsCompany(companyName);
        }
    }
}