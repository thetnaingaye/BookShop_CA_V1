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
            if(endDate <= startDate)
            {
                LabelStatus.Text = string.Format("Error! End Date cannot occur before Start Date.");
            }
            else
            {
                double discountRate = Double.Parse(TxtBoxDiscount.Text);
                BusinessLogic.UpdateDiscount(startDate, endDate, discountRate);
                LabelStatus.Text = string.Format("Update Success! Storewide Discount of "+"<span style='font-weight:bold'>" + " {0}% " + "</span>" + "will occur between " + "<span style='font-weight:bold'>" +" {1}" + "</span>" + " till" + "<span style='font-weight:bold'>" + " {2}" + "</span>", discountRate, startDate.Date, endDate.Date);
            }

        }


    }
}