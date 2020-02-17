using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class _1_8_10_Admin_Total_Staff : System.Web.UI.Page
    {
        String select = "Science";

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
           

            if (Request.QueryString["m"] != null)
            {
                select = Request.QueryString["m"];


            }

            lblTerm.Text = select;

            SqlConnection conn = new SqlConnection("data source=.;database=School;integrated security=true;");
            SqlCommand comm = new SqlCommand("select Picture,Name,Designation,Qualification,cast( AddStaff.Date AS date) as Date from AddStaff WHERE Catogary='" + select + "'", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count != 0)
            {

                string im = dt.Rows[0]["Picture"].ToString();



                DataList1.DataSource = dt;
                DataList1.DataBind();
                conn.Close();
            }

            else
            {

                lblStudentIdNotFound.Text = "No Record To Display";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }

        }
    }
}