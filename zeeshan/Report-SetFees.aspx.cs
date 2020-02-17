using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class Report_SetFees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("NotAuthenticated.aspx");
            }
            else if (!User.IsInRole("Accountant") && !User.IsInRole("Admin"))
            {
                Response.Redirect("Authorized.aspx");
            }

            else if (!IsPostBack)
            {
                string subjects = Session["RSetFees"].ToString();
                if (subjects != "")
                {
                    DataTable dt = (DataTable)Session["RSetFees"];
                    gvSetSubjects.DataSource = dt;
                    gvSetSubjects.DataBind();

                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:prints(); ", true);

                    
                }
                else
                {
                    Response.Write("Error in database");
                }
            }
        }
    }
}