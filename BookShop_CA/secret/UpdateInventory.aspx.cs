using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop_CA.Models;

namespace BookShop_CA.secret
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                //Label1.Text = "Your are logged in as" + String.Format(User.IsInRole("owner")? "Owner" : "Agent");
            }
        }

        protected void BindGrid()
        {
            using (Mybooks b = new Mybooks())
            {
                GridView1.DataSource = b.Books.ToList<Book>();
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int BookId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            BusinessLogic.DeleteBook(BookId);
            BindGrid();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int bookId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            int bookStock = Convert.ToInt32((row.FindControl("TxtBoxStock") as TextBox).Text);
            decimal bookPrice = Convert.ToDecimal((row.FindControl("TxtBoxPrice") as TextBox).Text);
            BusinessLogic.UpdateBook(bookId, bookStock, bookPrice);
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Book book = (Book)e.Row.DataItem;
                int Bookid = book.BookID;
            }
        }
    }
    }
