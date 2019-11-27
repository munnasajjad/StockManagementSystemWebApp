using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        private StockInManager stockInManager;

        public StockInUI()
        {
            stockInManager = new StockInManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {

                    companyDropdownList.DataSource = stockInManager.GetAllCompanies();
                    companyDropdownList.DataTextField = "CompanyName";
                    companyDropdownList.DataValueField = "Id";
                    companyDropdownList.DataBind();
                    companyDropdownList.Items.Insert(0, new ListItem("-Select a company-", "0"));
                    itemDropdownList.Items.Insert(0, new ListItem("-Select a item-", "0"));
                    itemDropdownList.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }

        }

        public bool IsAlphaneumeric(string value)
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

        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            bool IsNeumeric = IsAlphaneumeric(stockInTextBox.Text);
            if (IsNeumeric)
            {
                int checkQuantity;
                if (stockInTextBox.Text == "")
                {
                    checkQuantity = 0;
                }
                else
                {
                    checkQuantity = Convert.ToInt32(stockInTextBox.Text);
                }
                if (Convert.ToInt32(companyDropdownList.SelectedIndex) != 0)
                {
                    if (Convert.ToInt32(itemDropdownList.SelectedIndex) != 0)
                    {
                        if (checkQuantity > 0)
                        {
                            int id = Convert.ToInt32(itemDropdownList.SelectedValue);
                            bool IsExistsItem = stockInManager.IsItemExists(id);

                            if (IsExistsItem)
                            {
                                int availableQuantity = Convert.ToInt32(quantityTextBox.Text);
                                int stockInQuantity = Convert.ToInt32(stockInTextBox.Text);
                                int totalQuantity = availableQuantity + stockInQuantity;

                                StockIn stockIn = new StockIn();
                                stockIn.ItemId = Convert.ToInt32(itemDropdownList.SelectedValue);
                                stockIn.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                                stockIn.AvailableQuantity = totalQuantity;

                                string message = stockInManager.UpdateAvailableQuantityById(stockIn);
                                messageLabel.Text = message;
                                ClearField();
                            }
                            else
                            {
                                int totalQuantity = Convert.ToInt32(stockInTextBox.Text);
                                StockIn stockIn = new StockIn();
                                stockIn.ItemId = Convert.ToInt32(itemDropdownList.SelectedValue);
                                stockIn.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                                stockIn.AvailableQuantity = totalQuantity;

                                string message = stockInManager.Save(stockIn);
                                messageLabel.Text = message;
                                ClearField();

                            }
                        }
                        else
                        {
                            messageLabel.Text = "Quantity must be greater than 0!";
                        }
                    }
                    else
                    {
                        messageLabel.Text = "Select an item!";
                    }
                }
                else
                {
                    messageLabel.Text = "Select a company!";
                }
            }
            else
            {
                messageLabel.Text = "Invalid stock in quantity(positive numbers only)!";
            }
        }

        protected void companyDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(companyDropdownList.SelectedValue);
            itemDropdownList.DataSource = stockInManager.GetAllItemsByCompanyId(id);
            itemDropdownList.DataTextField = "ItemName";
            itemDropdownList.DataValueField = "Id";
            itemDropdownList.DataBind();
            itemDropdownList.Items.Insert(0, new ListItem("-Select item-", "0"));
            itemDropdownList.Enabled = true;
        }

        protected void itemDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            reorderLevelTextBox.Enabled = false;
            quantityTextBox.Enabled = false;
            int id = Convert.ToInt32(itemDropdownList.SelectedValue);
            if (id == 0)
            {
                reorderLevelTextBox.Text = 0.ToString();
            }
            else
            {
                Item item = stockInManager.GetReorderLevelByItemId(id);
                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
            }
            StockIn stockIn = stockInManager.GetAvailableQuantityByItemId(id);
            int quantity = stockIn.AvailableQuantity;
            if (quantity == 0)
            {
                quantityTextBox.Text = 0.ToString();
            }
            else
            {
                quantityTextBox.Text = quantity.ToString();
            }
        }

        public void ClearField()
        {
            companyDropdownList.SelectedIndex = 0;
            itemDropdownList.SelectedIndex = 0;
            reorderLevelTextBox.Text = "";
            quantityTextBox.Text = "";
            stockInTextBox.Text = "";
        }
    }
}