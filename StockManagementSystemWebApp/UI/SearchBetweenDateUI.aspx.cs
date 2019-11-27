using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemWebApp.BLL.Manager;
using StockManagementSystemWebApp.BLL.View;

namespace StockManagementSystemWebApp.UI
{
    public partial class SearchBetweenDateUI : System.Web.UI.Page
    {
        private GetStockInfoView stockInfoView;
        private StockOutManager stockOutManager;

        public SearchBetweenDateUI()
        {
            stockInfoView = new GetStockInfoView();
            stockOutManager = new StockOutManager();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    fromDateCalender.Visible = false;
                    toDateCalender.Visible = false;
                }
                fromDateTextBox.Enabled = false;
                toDateTextBox.Enabled = false;
                messageLabel.Text = "";
            }
            else
            {
                Response.Redirect("IndexUI.aspx");
            }

        }


        protected void toDateImageButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (toDateCalender.Visible)
            {
                toDateCalender.Visible = false;
            }
            else
            {
                toDateCalender.Visible = true;
            }
        }

        protected void fromDateImageButton_OnClick(object sender, ImageClickEventArgs e)
        {
            if (fromDateCalender.Visible)
            {
                fromDateCalender.Visible = false;
            }
            else
            {
                fromDateCalender.Visible = true;
            }
        }

        protected void fromDateCalender_SelectionChanged(object sender, EventArgs e)
        {
            fromDateTextBox.Text = fromDateCalender.SelectedDate.ToString("yyyy/MM/dd");
            fromDateCalender.Visible = false;
        }

        protected void toDateCalender_SelectionChanged(object sender, EventArgs e)
        {
            toDateTextBox.Text = toDateCalender.SelectedDate.ToString("yyyy/MM/dd");
            toDateCalender.Visible = false;
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            CultureInfo myCultureInfo = new CultureInfo("de-DE");
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;


            if (fromDate == "" || toDate == "")
            {
                messageLabel.Text = "Please Select Date";
            }
            else
            {
                DateTime dt1 = DateTime.Parse(fromDate);
                DateTime dt2 = DateTime.Parse(toDate);

                if (dt1.Date > dt2.Date)
                {
                    messageLabel.Text = "Invalid date range!";
                    itemGridView.DataSource = null;
                    itemGridView.DataBind();
                }
                else
                {
                    List<GetStockInfoView> getStockInfoViews = stockOutManager.GetDataBtnDate(fromDate, toDate);

                    if (getStockInfoViews.Count == 0)
                    {
                        messageLabel.Text = "No data found!";
                    }
                    else
                    {
                        messageLabel.Text = "Data found!";
                        itemGridView.DataSource = stockOutManager.GetDataBtnDate(fromDate, toDate);
                        itemGridView.DataBind();
                    }
                   
                }
            }
        }
    }
}