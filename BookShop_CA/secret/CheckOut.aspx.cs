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
        List<Book> bookCart;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRedirect.Visible = false;
            if (!IsPostBack)
            {
                BindGrid();
                DisplayCartPrice();

                if (Session["CartList"] == null)
                {
                    Response.Redirect("../BookDisplayPage.aspx");
                }

            }

        }

        protected void BindGrid()
        {
            bookCart = (List<Book>)Session["CartList"];

            GridView1.DataSource = bookCart;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            bookCart = (List<Book>)Session["CartList"];
            string firstName = TxtFirstName.Text;
            string lastName = TxtLastName.Text;
            string address = txtAddress.Text;
            string contactNum = TxtContactNum.Text;
            BusinessLogic.AddTransaction(bookCart, firstName, lastName, address, contactNum);

            lblRedirect.Visible = true;
            Button1.Visible = false;



            Response.AddHeader("REFRESH", "10; URL=Default.aspx");
            bookCart = ClearFieldAndReturnEmptyList();
            Session["CartList"] = bookCart;




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

        protected void DisplayCartPrice()
        {
            bookCart = (List<Book>)Session["CartList"];
            txtTotalAmount.Text =
                string.Format("{0:c}", BusinessLogic.GetShoppingCartPrice(bookCart).ToString());
            Discount discount = BusinessLogic.GetDiscount();

            lblDiscount.Text = discount.PercentageDiscount.ToString() + "% off your purchase!";
            lblDiscount.Visible = true;
            txtDiscount.Text =
                string.Format("{0}:c", BusinessLogic.CalculateCartDiscount(BusinessLogic.GetShoppingCartPrice(bookCart)).ToString());
            if (txtDiscount.Text != "0")
                txtDiscount.Visible = true;
            txtFinalPrice.Text =
                string.Format("{0:c}", decimal.Parse(txtTotalAmount.Text) - decimal.Parse(txtDiscount.Text));
            lblDiscountedPrice.Visible = true;
        }

    }
}
