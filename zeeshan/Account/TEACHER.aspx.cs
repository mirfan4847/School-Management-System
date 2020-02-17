using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan.Account
{
    public partial class TEACHER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Authentication.aspx");
            }
            else if(!User.IsInRole("Teacher"))
            {
                Response.Redirect("~/Account/AUTHORIZATION.aspx");
            }
            else if (!IsPostBack)
            { 
                
            }
        }
    }
}