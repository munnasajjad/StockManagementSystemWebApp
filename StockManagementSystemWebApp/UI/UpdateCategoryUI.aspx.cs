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
    public partial class UpdateCategoryUI : System.Web.UI.Page
    {
        private CategoryManeger categoryManeger;

        public UpdateCategoryUI()
        {
            categoryManeger = new CategoryManeger();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["Id"]);
                    Category category = categoryManeger.GetCategoryById(id);
                    idHiddenField.Value = category.Id.ToString();
                    updateCategoryTextBox.Text = category.CategoryName;
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }

        }

        protected void updateCompany_Click(object sender, EventArgs e)
        {
            if (IsString(updateCategoryTextBox.Text))
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(idHiddenField.Value);
                category.CategoryName = updateCategoryTextBox.Text;

                bool IsExistsCategory = categoryManeger.IsExistsCategory(category.CategoryName);
                if (IsExistsCategory)
                {
                    messageLabel.Text = "Category already exist in the list. Update failed!";
                }
                else
                {
                    string message = categoryManeger.UpdateCategoryById(category);
                    messageLabel.Text = message;
                    updateCategoryTextBox.Text = "";
                    Response.Redirect("SetupCategoryUI.aspx");
                }
            }
            else
            {
                messageLabel.Text = "Category name can't contain any digit!";
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
            if (count > 0)
            {
                return false;
            }
            return true;
        }
    }
}