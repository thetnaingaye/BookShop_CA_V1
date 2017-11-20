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
    public partial class BookDetails : System.Web.UI.Page
    {
        Mybooks context = new Mybooks();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Book> GetDetails([QueryString("bookID")] int? bookId)
        {
            IQueryable<Book> query = context.Books;
            if (bookId.HasValue && bookId > 0)
            {
                query = query.Where(p => p.BookID == bookId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public string GetCategory(int categoryID)
        {
            Category c = context.Categories.Where(x => x.CategoryID == categoryID).First();
            return c.Name;
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tempText = btn.CommandArgument.ToString();
            int bookID = Convert.ToInt32(tempText);

            Book b = context.Books.Where(x => x.BookID == bookID).First();
            

            List<Book> temp = (List<Book>)Session["CartList"];
            temp.Add(b);
            Session["CartLists"] = temp;
        }
    }
}