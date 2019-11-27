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
    public partial class SetupCompanyUI : System.Web.UI.Page
    {
        private CompanyManager companyManager;

        public SetupCompanyUI()
        {
            companyManager = new CompanyManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    companyGridView.DataSource = companyManager.GetAllCompanies();
                    companyGridView.DataBind();
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }
            messageLabel.Text = "";
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
            if (count > 2)
            {
                return false;
            }
            return true;
        }

        protected void setupCompanyButton_OnClick(object sender, EventArgs e)
        {
            if (companyTextBox.Text.Equals(""))
            {
                messageLabel.Text = "Please insert a company name";
            }
            else if (!IsString(companyTextBox.Text))
            {
                messageLabel.Text = "Company name can't contain more than 2 digits";
            }
            else
            {
                messageLabel.Text = "";
                Company company = new Company();
                company.CompanyName = companyTextBox.Text;

                string message = companyManager.Save(company);
                messageLabel.Text = message;

                companyGridView.DataSource = companyManager.GetAllCompanies();
                companyGridView.DataBind();
            }
        }

        protected void updateCompanyLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton updateLinkButton = (LinkButton)sender;
            DataControlFieldCell cell = updateLinkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField hiddenField = row.FindControl("idHiddenField") as HiddenField;
            Response.Redirect("UpdateCompanyUI.aspx?Id=" + hiddenField.Value);
        }
    }
}