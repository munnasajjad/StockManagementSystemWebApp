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
    public partial class IndexUI : System.Web.UI.Page
    {
        private UserManager userManager;

        public IndexUI()
        {
            userManager = new UserManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID"] = null;
            if (!IsPostBack)
            {
                userNameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }

        protected void loginButton_OnClick(object sender, EventArgs e)
        {

            User user = new User();
            user.UserName = userNameTextBox.Text;
            user.Password = passwordTextBox.Text;

            bool IsExistsUser = userManager.IsExistsUser(user.UserName, user.Password);

            if (IsExistsUser)
            {
                Session["ID"] = user.UserName;
                Response.Redirect("HomeUI.aspx");
            }
            else
            {
                messageLabel.Text = "Invalid username or password!";
                userNameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }
    }
}