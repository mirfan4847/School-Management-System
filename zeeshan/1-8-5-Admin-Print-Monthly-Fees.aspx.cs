using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using System.Data;

namespace Future
{
    public partial class _1_8_5_Admin_Print_Monthlt_Fees : System.Web.UI.Page
    {
        int mnth = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                    if (Request.QueryString["m"] != null)
                    {
                        mnth = Convert.ToInt32(Request.QueryString["m"]);
                    }
                    lblMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mnth);


                    Fees_bll bll = new Fees_bll();
                    DataTable FeesMonthly = new DataTable();

                    FeesMonthly = bll.MonthlyFeeDetails(mnth);
                    if (FeesMonthly.Rows.Count != 0)
                    {
                        dgvMonthlyFee.DataSource = null;
                        dgvMonthlyFee.DataSource = FeesMonthly;
                        dgvMonthlyFee.DataBind();

                        int TotalAmount = 0;

                        for (int i = 0; i < FeesMonthly.Rows.Count; i++)
                        {
                            TotalAmount = TotalAmount + Convert.ToInt32(FeesMonthly.Rows[i]["Balance"].ToString());
                        }

                        ((Label)dgvMonthlyFee.FooterRow.FindControl("lblAmount")).Text = TotalAmount.ToString();




                    }
                    else
                    {
                        //for (int i = 0; i < 1; i++)
                        //{
                        //    dgvMonthlyFee.Rows[i].Cells.Clear();
                        //    dgvMonthlyFee.
                        //}
                        //FeesMonthly.Rows.Clear();
                        //FeesMonthly.AcceptChanges();
                        //dgvMonthlyFee.DataSource = null;
                        //dgvMonthlyFee.DataSource = FeesMonthly;
                        //dgvMonthlyFee.DataBind();
                        lblStudentIdNotFound.Text = "No Record to Show";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                    }
                }


              

            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report-MothlyFees.aspx");
        }
    }
}