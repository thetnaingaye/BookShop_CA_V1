using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop_CA.Models;

namespace BookShop_CA.secret
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string prevPage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
                prevPage = Request.UrlReferrer.ToString();
            }
        }

        protected void GetData()
        {
            Discount discount = BusinessLogic.GetDiscount();
            Calendar startDate = CalStartDate;
            Calendar endDate = CalEndDate;
            TextBox discountRate = TxtBoxDiscount;
            startDate.SelectedDate = startDate.VisibleDate = discount.StartDate.Value;
            endDate.SelectedDate = endDate.VisibleDate = discount.EndDate.Value;
            discountRate.Text = discount.PercentageDiscount.Value.ToString();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime startDate = CalStartDate.SelectedDate;
            DateTime endDate = CalEndDate.SelectedDate;
            double discountRate = Double.Parse(TxtBoxDiscount.Text);
            BusinessLogic.UpdateDiscount(startDate, endDate, discountRate);
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}