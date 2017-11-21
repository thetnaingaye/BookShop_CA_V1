using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop_CA
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(User.Identity.IsAuthenticated)
            {
                System.Web.Security.FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Login1.Visible = false;
            CreateUserWizard1.Visible = true;

        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {

            string username = CreateUserWizard1.UserName;
            Roles.AddUserToRole(username, "agent");


        }

        protected void CreateUserWizard1_ContinueButtonClick(object sender, EventArgs e)
        {
            CreateUserWizard1.Visible = false;
            Login1.Visible = true;
        }

        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            Session["owner"] = User.IsInRole("owner");
        }
    }
}