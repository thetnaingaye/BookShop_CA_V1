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
            if (!IsPostBack)
            {
                BindGrid();
            }
            decimal totalPrice = 0;
			blist = (List<Book>)Session["CartList"];

			foreach (Book B in blist)
            {

                totalPrice += B.Price;
            }
            txtTotalAmount.Text = totalPrice.ToString();
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
            BusinessLogic.AddTransaction(blist,firstName,lastName,address,contactNum);

			Response.Redirect("CheckoutSuccessful.aspx");
        }

      
        }
    }
