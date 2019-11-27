using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Model;
using StockManagementSystemWebApp.BLL.View;

namespace StockManagementSystemWebApp.UI
{
    public partial class SearchAndViewItemsSummary : System.Web.UI.Page
    {
        private ItemManager itemManager;
        public SearchAndViewItemsSummary()
        {
            itemManager = new ItemManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    companyDropdownList.DataSource = itemManager.GetCompanies();
                    companyDropdownList.DataTextField = "CompanyName";
                    companyDropdownList.DataValueField = "Id";
                    companyDropdownList.DataBind();
                    companyDropdownList.Items.Insert(0, new ListItem("-Select a company-", "0"));

                    categoryDropdownList.DataSource = itemManager.GetAllCategories();
                    categoryDropdownList.DataTextField = "CategoryName";
                    categoryDropdownList.DataValueField = "Id";
                    categoryDropdownList.DataBind();
                    categoryDropdownList.Items.Insert(0, new ListItem("-Select an item-", "0"));
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }
            messageLabel.Text = "";
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (categoryDropdownList.SelectedIndex == 0 && companyDropdownList.SelectedIndex == 0)
            {
                LoadGridView();
            }
            else if (categoryDropdownList.SelectedIndex == 0 && companyDropdownList.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(companyDropdownList.SelectedValue);
                itemGridView.DataSource = itemManager.GetItemsByCompanyId(id);
                itemGridView.DataBind();
                messageLabel.Text = "Items found";
            }
            else if (categoryDropdownList.SelectedIndex != 0 && companyDropdownList.SelectedIndex == 0)
            {
                int id = Convert.ToInt32(categoryDropdownList.SelectedValue);
                itemGridView.DataSource = itemManager.GetItemsByCategoryId(id);
                itemGridView.DataBind();
                messageLabel.Text = "Items found";
            }
            else if (categoryDropdownList.SelectedIndex != 0 && companyDropdownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropdownList.SelectedValue);
                int categoryId = Convert.ToInt32(categoryDropdownList.SelectedValue);
                List<GetItemsSummary> getItemsSummaries = itemManager.GetItems(categoryId, companyId);
                if (getItemsSummaries.Count != 0)
                {
                    itemGridView.DataSource = itemManager.GetItems(categoryId, companyId);
                    itemGridView.DataBind();
                    messageLabel.Text = "Items found";
                }
                else
                {
                    messageLabel.Text = "Selected company doesn't have this types of items";
                    itemGridView.DataSource = null;
                    itemGridView.DataBind();
                    companyDropdownList.SelectedIndex = 0;
                    categoryDropdownList.SelectedIndex = 0;
                }
            }
        }

        public void LoadGridView()
        {
            itemGridView.DataSource = itemManager.GetAllItems();
            itemGridView.DataBind();
        }
    }
}