using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop_CA.Models;

namespace BookShop_CA
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        List<Book> blist;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                if(Session["CartList"] == null)
                {
                    BtnCheckout.Visible = false;
                    LabelStatus.Text = "There is no item in shopping cart. Please visit book page to add items to cart";
                }
            }

        }

        protected void BindGrid()
        {
            blist = (List<Book>)Session["CartList"];

            GridView1.DataSource = blist;
            GridView1.DataBind();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            List<Book> currentList = (List<Book>)Session["CartList"];
            List<Book> bList2 = BusinessLogic.DeleteOrder(currentList, bookID);
            BindGrid();
            Session["CartList"] = bList2;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //foreach (GridViewRow item in GridView1.SelectedRow)
            //{
            //    GridView1.Rows.RemoveAt(item.RowIndex);
            //}
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/secret/Checkout.aspx");
        }
    }
}