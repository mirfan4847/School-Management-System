using SchoolManagementSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class Report_DailyFees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("NotAuthenticated.aspx");
                }
                else if (!User.IsInRole("Accountant") && !User.IsInRole("Admin"))
                {
                    Response.Redirect("Authorized.aspx");
                }
                else if (User.IsInRole("Admin") || User.IsInRole("Accountant"))
                {
                    lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

                    //String Date = "06/02/2015 2:49 PM";
                    DataTable dt = new DataTable();
                    String Date = DateTime.Now.ToString("dd-MM-yyyy");
                    Fees_bll bll = new Fees_bll();

                    dt = bll.DailyFeeDetails(Date);

                    if (dt.Rows.Count != 0)
                    {
                        dgvDailFee.DataSource = null;
                        dgvDailFee.DataSource = dt;
                        dgvDailFee.DataBind();
                        int TotalAmount = 0;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TotalAmount = TotalAmount + Convert.ToInt32(dt.Rows[i]["Balance"].ToString());
                        }

                        ((Label)dgvDailFee.FooterRow.FindControl("lblAmount")).Text = TotalAmount.ToString();




                    }
                    else
                    {
                       // lblStudentIdNotFound.Text = "No Record to Show";

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);


                    }
                }





            }
        }

       

    }
}