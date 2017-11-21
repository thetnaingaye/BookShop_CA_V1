using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Security;
using BookShop_CA.Models;

namespace BookShop_CA
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Book> temp = (List<Book>)Session["CartList"];
            if (Session["CartList"] != null)
            {
                int count = temp.Count;
                Label_cartitem.Text = string.Format("({0})", count);
            }

            if (Page.User.IsInRole("owner"))
            {
                owner.Visible = true;
                owner_addbook.Visible = true;
                owner_setdiscount.Visible = true;
                login_menu.Visible = false;
                signup_menu.Visible = false;
                Label_user.Text = "You are currently logged in as owner role : " + Page.User.Identity.Name;
                logout_menu.Visible = true;


            }
            else if (Page.User.IsInRole("agent"))
            {
                login_menu.Visible = false;
                signup_menu.Visible = false;
                Label_user.Text = "You are currently logged in as user role : " + Page.User.Identity.Name;
                logout_menu.Visible = true;
            }
            else
            {
                owner.Visible = false;
                login_menu.Visible = true;
                signup_menu.Visible = true;
                Label_user.Visible = false;
                logout_menu.Visible = false;
            }

        }

        protected void LinkButton_logout_Click(object sender, EventArgs e)
        {
        }
    }
}