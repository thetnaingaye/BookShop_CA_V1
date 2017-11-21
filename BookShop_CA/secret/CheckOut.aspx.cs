using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop_CA.Models;

namespace BookShop_CA
{
    public partial class Checkout : System.Web.UI.Page
    {
        List<Book> blist;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRedirect.Visible = false;


            if (!IsPostBack)
            {
                BindGrid();

            }
            decimal totalPrice = 0;
            blist = (List<Book>)Session["CartList"];
            Mybooks context = new Mybooks();
            //float discountPer=context.PercentageDiscount
            Discount discount = context.Discounts.ToList()[0];




            foreach (Book B in blist)
            {

                totalPrice += B.Price;
            }
            txtTotalAmount.Text = Convert.ToString((String.Format("{0:c}", totalPrice)));
            if (blist != null)
            {
                Button1.Visible = true;
                if (discount.PercentageDiscount != 0 && (DateTime.Today >= discount.StartDate && DateTime.Today <= discount.EndDate))
                {

                    lblDiscount.Text = discount.PercentageDiscount + "% off your purchase!";
                    lblDiscount.Visible = true;
                    txtDiscount.Text = Convert.ToString(String.Format("{0:c}", (totalPrice * (Convert.ToDecimal(discount.PercentageDiscount)) / 100)));
                    txtFinalPrice.Text = Convert.ToString(String.Format("{0:c}", (totalPrice * (100 - Convert.ToDecimal(discount.PercentageDiscount)) / 100)));
                    lblDiscountedPrice.Visible = true;
                    txtDiscount.Visible = true;

                }
                else
                {
                    txtFinalPrice.Text = totalPrice.ToString();
                }
            }
            else
            {
                Button1.Visible = false;
            }
        }




        protected void BindGrid()
        {
            blist = (List<Book>)Session["CartList"];

            GridView1.DataSource = blist;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            blist = (List<Book>)Session["CartList"];
            string firstName = TxtFirstName.Text;
            string lastName = TxtLastName.Text;
            string address = txtAddress.Text;
            string contactNum = TxtContactNum.Text;
            BusinessLogic.AddTransaction(blist, firstName, lastName, address, contactNum);

            lblRedirect.Visible = true;
            Button1.Visible = false;



            Response.AddHeader("REFRESH", "10; URL=../Default.aspx");
            blist = ClearFieldAndReturnEmptyList();
            Session["CartList"] = blist;




        }

        protected List<Book> ClearFieldAndReturnEmptyList()
        {

            lblDiscount.Visible = false;
            lblDiscountedPrice.Visible = false;
            txtDiscount.Visible = false;
            TxtFirstName.Text = string.Empty;
            TxtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            TxtContactNum.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            List<Book> newlist = new List<Book>();
            return newlist;
        }

    }
}
