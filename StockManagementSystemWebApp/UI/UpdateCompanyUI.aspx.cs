using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class UpdateCompanyUI : System.Web.UI.Page
    {
        private CompanyManager companyManager;

        public UpdateCompanyUI()
        {
            companyManager = new CompanyManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["Id"]);
                    Company company = companyManager.GetCompanyById(id);
                    idHiddenField.Value = company.Id.ToString();
                    updateCompanyTextBox.Text = company.CompanyName;
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }

        }

        protected void updateCompany_Click(object sender, EventArgs e)
        {
            if (IsString(updateCompanyTextBox.Text))
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(idHiddenField.Value);
                company.CompanyName = updateCompanyTextBox.Text;

                bool IsExistCompany = companyManager.IsExistsCompany(company.CompanyName);
                if (IsExistCompany)
                {
                    messageLabel.Text = "Company name already in the list!";
                }
                else
                {
                    string message = companyManager.UpdateCompanyById(company);
                    messageLabel.Text = message;
                    updateCompanyTextBox.Text = "";
                    Response.Redirect("SetupCompanyUI.aspx");
                }
            }
            else
            {
                messageLabel.Text = "Company name can't contain more than 2 digits!";
            }
        }

        public bool IsString(string value)
        {
            char[] ch = new char[100];
            ch = value.ToCharArray();
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (ch[i] >= 48 && ch[i] <= 57)
                {
                    count++;
                }
            }
            if (count >2)
            {
                return false;
            }
            return true;
        }
    }
}