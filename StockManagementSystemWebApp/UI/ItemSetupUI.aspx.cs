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
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        private ItemManager itemManager;

        public ItemSetupUI()
        {
            itemManager = new ItemManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {

                    categoryDropdownList.DataSource = itemManager.GetAllCategories();
                    categoryDropdownList.DataTextField = "CategoryName";
                    categoryDropdownList.DataValueField = "Id";
                    categoryDropdownList.DataBind();
                    categoryDropdownList.Items.Insert(0, new ListItem("-Select a category-", "0"));

                    companyDropdownList.DataSource = itemManager.GetCompanies();
                    companyDropdownList.DataTextField = "CompanyName";
                    companyDropdownList.DataValueField = "Id";
                    companyDropdownList.DataBind();
                    companyDropdownList.Items.Insert(0, new ListItem("-Select a company-", "0"));

                    messageLabel.Text = "";
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }

        }

        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            if (categoryDropdownList.SelectedIndex != 0)
            {
                if (companyDropdownList.SelectedIndex != 0)
                {
                    if (itemNameTextBox.Text != "")
                    {
                        if (IsValidName(itemNameTextBox.Text))
                        {
                            if (IsAlphanumeric(reorderLevelTextBox.Text))
                            {
                                int reorderLevel;
                                if (reorderLevelTextBox.Text == "")
                                {
                                    reorderLevel = 0;
                                }
                                else
                                {
                                    reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                                }
                                Item item = new Item();
                                item.CategoryId = Convert.ToInt32(categoryDropdownList.SelectedValue);
                                item.CompanyId = Convert.ToInt32(companyDropdownList.SelectedValue);
                                item.ItemName = itemNameTextBox.Text;
                                item.ReorderLevel = reorderLevel;
                                bool isExistsItem = itemManager.IsExistsItem(item.ItemName);
                                if (isExistsItem)
                                {
                                    messageLabel.Text = "Item already exists!";
                                }
                                else
                                {
                                    string message = itemManager.Save(item);
                                    messageLabel.Text = message;
                                }
                            }
                            else
                            {
                                messageLabel.Text = "Invalid reorder level(positive numbers only)!";
                            }
                        }
                        else
                        {
                            messageLabel.Text = "Item name can't contain more than 3 digits";
                        }
                    }
                    else
                    {
                        messageLabel.Text = "Enter item name!";
                    }
                }
                else
                {
                    messageLabel.Text = "Please select a company";
                }
            }
            else
            {
                messageLabel.Text = "Please select a category";
            }

        }

        public bool IsAlphanumeric(string value)
        {
            char[] ch = new char[100];

            ch = value.ToCharArray();
            for (int i = 0; i < value.Length; i++)
            {
                if (ch[i] >= 48 && ch[i] <= 57)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidName(string value)
        {
            char[] ch = new char[100];
            int count = 0;
            ch = value.ToCharArray();
            for (int i = 0; i < value.Length; i++)
            {
                if (ch[i] >= 48 && ch[i] <= 57)
                {
                    count++;
                }
            }
            if (count <= 3)
            {
                return true;
            }
            return false;
        }

        //protected void categoryDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int id = Convert.ToInt32(categoryDropdownList.SelectedIndex);
        //    messageLabel.Text = id.ToString();
        //}
    }
}