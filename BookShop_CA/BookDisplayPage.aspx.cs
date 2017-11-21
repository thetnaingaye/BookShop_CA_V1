using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using BookShop_CA.Models;

namespace BookShop_CA
{
    public partial class BookDisplayPage : System.Web.UI.Page
    {
        Mybooks context = new Mybooks();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["CartList"] != null)
                {
                    List<Book> temp = (List<Book>)Session["CartList"];
                    //    Label1.Text = "number of books in cart : " + (temp.Count() + 0).ToString();


                }
                else
                {
                    List<Book> temp = new List<Book>();
                    Session["CartList"] = temp;
                    //    Label1.Text = "number of books in cart : " + (temp.Count() + 0).ToString();

                }

            }
            else
            {
                List<Book> temp = (List<Book>)Session["CartList"];

                // Gotta direct this to the navbar at the top, specifically at the cart qty
                //txtSearchField.Text = (temp.Count() + 1).ToString();
               //Label1.Text =  "number of books in cart : "+(temp.Count() + 1).ToString();

            }
        }

        public IQueryable<Book> GetBooks([QueryString("id")] int? categoryId)
        {
            IQueryable<Book> query = context.Books;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tempText = btn.CommandArgument.ToString();
            int bookID = Convert.ToInt32(tempText);

            Book b = context.Books.Where(x => x.BookID == bookID).First();

            //test
            //txtSearchField.Text = b.Title;

            List<Book> temp = (List<Book>)Session["CartList"];
            temp.Add(b);
            Session["CartLists"] = temp;
        }
    }
}