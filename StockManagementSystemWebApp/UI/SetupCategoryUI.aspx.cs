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
    public partial class SetupCategoryUI : System.Web.UI.Page
    {
        private CategoryManeger setupCategoryManeger;

        public SetupCategoryUI()
        {
            setupCategoryManeger = new CategoryManeger();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    categoryGridView.DataSource = setupCategoryManeger.GetAllCategories();
                    categoryGridView.DataBind();
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
            if (count > 0)
            {
                return false;
            }
            return true;
        }

        protected void setupCategoryButton_OnClick(object sender, EventArgs e)
        {
            if (setupCategoryTextBox.Text.Equals(""))
            {
                messageLabel.Text = "Please insert a category name";
            }
            else if (!IsString(setupCategoryTextBox.Text))
            {
                messageLabel.Text = "Category name can't contain any digit!";
            }
            else
            {
                messageLabel.Text = "";
                Category category = new Category();
                category.CategoryName = setupCategoryTextBox.Text;

                string message = setupCategoryManeger.Save(category);
                messageLabel.Text = message;

                categoryGridView.DataSource = setupCategoryManeger.GetAllCategories();
                categoryGridView.DataBind();

            }
        }

        protected void updateCategoryLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton updateLinkButton = (LinkButton)sender;
            DataControlFieldCell cell = updateLinkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField hiddenField = row.FindControl("idHiddenField") as HiddenField;
            Response.Redirect("UpdateCategoryUI.aspx?Id=" + hiddenField.Value);
        }
    }
}