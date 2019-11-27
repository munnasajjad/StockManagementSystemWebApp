using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.Model;

namespace StockManagementSystemWebApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        private StockOutManager stockOutManager;
        List<StockOut> stockOutList = new List<StockOut>();
        public StockOutUI()
        {
            stockOutManager = new StockOutManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {

                    companyDropdownList.DataSource = stockOutManager.GetAllCompanies();
                    companyDropdownList.DataTextField = "CompanyName";
                    companyDropdownList.DataValueField = "Id";
                    companyDropdownList.DataBind();
                    companyDropdownList.Items.Insert(0, new ListItem("-Select a company-", "0"));
                    itemDropdownList.Items.Insert(0, new ListItem("-Select a item-", "0"));
                    itemDropdownList.Enabled = false;
                    sellButton.Visible = false;
                    damageButton.Visible = false;
                    lostButton.Visible = false;
                }
                messageLabel.Text = "";
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }
        }

        protected void companyDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(companyDropdownList.SelectedValue);
            itemDropdownList.DataSource = stockOutManager.GetAllItemsByCompanyId(id);
            itemDropdownList.DataTextField = "ItemName";
            itemDropdownList.DataValueField = "Id";
            itemDropdownList.DataBind();
            itemDropdownList.Items.Insert(0, new ListItem("-Select item-", "0"));
            itemDropdownList.Enabled = true;

            itemDropdownList.SelectedIndex = 0;
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            stockOutTextBox.Text = "";
            messageLabel.Text = "";
        }

        protected void itemDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            reorderLevelTextBox.Enabled = false;
            availableQuantityTextBox.Enabled = false;
            int id = Convert.ToInt32(itemDropdownList.SelectedValue);
            if (id == 0)
            {
                reorderLevelTextBox.Text = 0.ToString();
            }
            else
            {
                Item item = stockOutManager.GetReorderLevelByItemId(id);
                reorderLevelTextBox.Text = item.ReorderLevel.ToString();
            }
            StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
            int quantity = stockIn.AvailableQuantity;
            if (quantity == 0)
            {
                availableQuantityTextBox.Text = 0.ToString();
            }
            else
            {
                List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
                if (stockOutList != null)
                {
                    availableQuantityTextBox.Text = quantity.ToString();
                    foreach (StockOut stockOut in stockOutList)
                    {
                        int tempCompanyId = Convert.ToInt32(companyDropdownList.SelectedValue);
                        int tempItemId = Convert.ToInt32(itemDropdownList.SelectedValue);
                        int companyId = stockOut.CompanyId;
                        int itemId = stockOut.ItemId;
                        if (tempCompanyId == companyId && tempItemId == itemId)
                        {
                            int stockOutQuantity = stockOut.StockOutQuantity;
                            availableQuantityTextBox.Text = (quantity - stockOutQuantity).ToString();
                            break;
                        }
                        else
                        {
                            availableQuantityTextBox.Text = quantity.ToString();
                        }
                    }
                }
                else
                {
                    availableQuantityTextBox.Text = quantity.ToString();
                }
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            bool IsNeumeric = IsAlphaneumeric(stockOutTextBox.Text);
            if (companyDropdownList.SelectedIndex != 0)
            {
                if (itemDropdownList.SelectedIndex != 0)
                {
                    if (IsNeumeric)
                    {
                        if (stockOutTextBox.Text != "" && Convert.ToInt32(stockOutTextBox.Text) != 0 && Convert.ToInt32(stockOutTextBox.Text) > 0)
                        {
                            int stock = Convert.ToInt32(availableQuantityTextBox.Text) -
                                        Convert.ToInt32(stockOutTextBox.Text);
                            if (stock >= 0)
                            {
                                int id = Convert.ToInt32(itemDropdownList.SelectedValue);
                                StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                                int quantity = stockIn.AvailableQuantity;
                                StockOut stockOut = new StockOut();
                                stockOut.CompanyId = Convert.ToInt32(companyDropdownList.SelectedValue);
                                stockOut.CompanyName = companyDropdownList.SelectedItem.ToString();
                                stockOut.ItemId = Convert.ToInt32(itemDropdownList.SelectedValue);
                                stockOut.ItemName = itemDropdownList.SelectedItem.ToString();
                                stockOut.AvailableQuantity = quantity;
                                stockOut.StockOutQuantity = Convert.ToInt32(stockOutTextBox.Text);
                                stockOut.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                                if (ViewState["StockOut"] == null)
                                {
                                    stockOutList.Add(stockOut);
                                    ViewState["StockOut"] = stockOutList;
                                    stockOutGridView.DataSource = stockOutList;
                                    stockOutGridView.DataBind();
                                    sellButton.Visible = true;
                                    damageButton.Visible = true;
                                    lostButton.Visible = true;
                                    InitialPosition();
                                }
                                else
                                {
                                    List<StockOut> stockOutList = (List<StockOut>) ViewState["StockOut"];
                                    int count = 0;
                                    foreach (StockOut value in stockOutList)
                                    {
                                        int tempItemId = value.ItemId;
                                        int tempCompanyId = value.CompanyId;
                                        int companyId = stockOut.CompanyId;
                                        int itemId = stockOut.ItemId;
                                        if (tempCompanyId == companyId && tempItemId == itemId)
                                        {
                                            stockOut.StockOutQuantity += value.StockOutQuantity;
                                            if (stockOut.StockOutQuantity > stockOut.AvailableQuantity)
                                            {
                                                stockOut.StockOutQuantity = value.StockOutQuantity;
                                                stockOutList.RemoveAt(count);
                                                messageLabel.Text = "Stock out of bound!";
                                                break;
                                            }
                                            else
                                            {
                                                stockOutList.RemoveAt(count);
                                                count++;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            count++;
                                            continue;
                                        }
                                    }
                                    stockOutList.Add(stockOut);
                                    ViewState["StockOut"] = stockOutList;
                                    stockOutGridView.DataSource = stockOutList;
                                    stockOutGridView.DataBind();
                                    sellButton.Visible = true;
                                    damageButton.Visible = true;
                                    lostButton.Visible = true;
                                    InitialPosition();
                                }
                            }
                            else
                            {
                                messageLabel.Text = "Stock out gets out of range!";
                            }
                        }
                        else
                        {
                            messageLabel.Text = "Stock out quantity must be greater than 0!";
                        }
                    }
                    else
                    {
                        messageLabel.Text = "Invalid stockout quantity(positive numbers only)!";
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

        public void InitialPosition()
        {
            stockOutTextBox.Text = "";
            companyDropdownList.SelectedIndex = 0;
            itemDropdownList.SelectedIndex = 0;
            itemDropdownList.Enabled = false;
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
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

        protected void sellButton_Click(object sender, EventArgs e)
        {
            string action = "Sell";
            List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
            if (stockOutList != null)
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    int stockOutQuantity = stockOut.StockOutQuantity;
                    int id = stockOut.ItemId;
                    StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                    int availableQuantity = stockIn.AvailableQuantity;
                    int grossQuantity = availableQuantity - stockOutQuantity;
                    stockOut.AvailableQuantity = grossQuantity;
                    stockOut.Action = action;
                    stockOutManager.UpdateAvailableQuantity(stockOut);
                    messageLabel.Text = "Items sold " + stockOutManager.Save(stockOut);
                }
                stockOutGridView.DataSource = null;
                stockOutGridView.DataBind();
                stockOutList.Clear();
                sellButton.Visible = false;
                damageButton.Visible = false;
                lostButton.Visible = false;
            }
            else
            {
                messageLabel.Text = "No data";
            }

        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            string action = "Damage";
            List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
            if (stockOutList != null)
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    int stockOutQuantity = stockOut.StockOutQuantity;
                    int id = stockOut.ItemId;
                    StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                    int availableQuantity = stockIn.AvailableQuantity;
                    int grossQuantity = availableQuantity - stockOutQuantity;
                    stockOut.AvailableQuantity = grossQuantity;
                    stockOut.Action = action;
                    stockOutManager.UpdateAvailableQuantity(stockOut);
                    messageLabel.Text = "Items set as damaged " + stockOutManager.Save(stockOut);
                }
                stockOutGridView.DataSource = null;
                stockOutGridView.DataBind();
                stockOutList.Clear();
                sellButton.Visible = false;
                damageButton.Visible = false;
                lostButton.Visible = false;
            }
            else
            {
                messageLabel.Text = "No data";
            }

        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            string action = "Lost";
            List<StockOut> stockOutList = (List<StockOut>)ViewState["StockOut"];
            if (stockOutList != null)
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    int stockOutQuantity = stockOut.StockOutQuantity;
                    int id = stockOut.ItemId;
                    StockIn stockIn = stockOutManager.GetAvailableQuantityByItemId(id);
                    int availableQuantity = stockIn.AvailableQuantity;
                    int grossQuantity = availableQuantity - stockOutQuantity;
                    stockOut.AvailableQuantity = grossQuantity;
                    stockOut.Action = action;
                    stockOutManager.UpdateAvailableQuantity(stockOut);
                    messageLabel.Text = "Items set as lost " + stockOutManager.Save(stockOut);
                }
                stockOutGridView.DataSource = null;
                stockOutGridView.DataBind();
                stockOutList.Clear();
                sellButton.Visible = false;
                damageButton.Visible = false;
                lostButton.Visible = false;
            }
            else
            {
                messageLabel.Text = "No data";
            }
        }
    }
}