using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class Report_SetSubjects : System.Web.UI.Page
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
                string subjects = Session["SetSubjects"].ToString();
                if (subjects != "")
                {
                    DataTable dt = (DataTable)Session["SetSubjects"];
                    gvSetSubjects.DataSource = dt;
                    gvSetSubjects.DataBind();
                    lblHeader.Text = Session["Class"].ToString();
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