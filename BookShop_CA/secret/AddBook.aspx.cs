using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop_CA.Models;
using System.Transactions;
using System.IO;


namespace BookShop_CA.secret
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControl();
            }

        }

        protected void BtnAddBook_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                string bookTitle = TxtBoxTitle.Text;
                int categoryID = Convert.ToInt32(DdlCategory.SelectedValue);
                string isbn = TxtBoxISBN.Text;
                string author = TxtBoxAuthor.Text;
                int stock = Convert.ToInt32(TxtBoxStock.Text);
                decimal bookPrice = Convert.ToDecimal(TxtBoxPrice.Text);
                SaveImage();
                BusinessLogic.Addbook(bookTitle, categoryID, isbn, author, stock, bookPrice);
                int bookID = BusinessLogic.GetBookID(isbn);
                LabelStatus.Text = string.Format("Book Added Successfully, BookID is {0}", bookID);
                scope.Complete();

            }

            ClearField();
        }

        protected void SaveImage()
        {
            if (UploadBookImage.HasFile)
            {
                try
                {
                    if (UploadBookImage.PostedFile.ContentType == "image/jpeg")
                    {
                        if (UploadBookImage.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(UploadBookImage.FileName);
                            UploadBookImage.SaveAs(Server.MapPath("~/images/") + TxtBoxISBN.Text + ".jpg");
                            LabelStatus.Text = "Upload status: File uploaded!";
                        }
                        else
                            LabelStatus.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        LabelStatus.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    LabelStatus.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected void BindControl()
        {
            DropDownList ddl = DdlCategory;
            if (ddl != null)
            {
                ddl.DataSource = BusinessLogic.BookCategory();
                ddl.DataTextField = "Name";
                ddl.DataValueField = "CategoryID";
                ddl.DataBind();
            }
        }

        protected void ClearField()
        {
            TxtBoxTitle.Text = string.Empty;
            DdlCategory.SelectedIndex = 1;
            TxtBoxISBN.Text = string.Empty;
            TxtBoxAuthor.Text = string.Empty;
            TxtBoxStock.Text = string.Empty;
            TxtBoxPrice.Text = string.Empty;
        }

    }
}