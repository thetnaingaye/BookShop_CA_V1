using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.Security;

namespace BookShop_CA
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if(Page.User.IsInRole("owner"))
            {
                owner.Visible = true;
            }

        }
    }
}