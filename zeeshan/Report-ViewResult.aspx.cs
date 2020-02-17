using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class Report_ViewResult : System.Web.UI.Page
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
                string subjects = Session["RViewResult"].ToString();
                if (subjects != "")
                {
                    DataTable dt = (DataTable)Session["RViewResult"];
                    gvSetSubjects.DataSource = dt;
                    gvSetSubjects.DataBind();
                    lblHeader.Text = Session["classForViewResult"].ToString()+" For Term ";
                    lblTerm.Text = Session["termForViewResult"].ToString() + " Of Section ";
                    lblSection.Text = Session["sectionForViewResult"].ToString();
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