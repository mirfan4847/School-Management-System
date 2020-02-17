using SchoolManagementSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Future
{
    public partial class _1_8_6_Admin_Print_Yearly_Fees : System.Web.UI.Page
    {

        String year = DateTime.Now.ToString("yyyy");

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
                    lblYear.Text = year;

                    Fees_bll bll = new Fees_bll();
                    DataTable allyear = new DataTable();
                    //To Get All Year in ddlYear
                    allyear = bll.GetAllYear();
                    ddlYear.DataSource = allyear;
                    ddlYear.DataTextField = "dateyear";
                    ddlYear.DataBind();




                    //END Get All Year in ddlYear






                    DataTable FeesYearly = new DataTable();

                    FeesYearly = bll.YearlyFeeDetailsOnLoad(year);
                    if (FeesYearly.Rows.Count != 0)
                    {
                        dgvYearlyFee.DataSource = null;
                        dgvYearlyFee.DataSource = FeesYearly;
                        dgvYearlyFee.DataBind();

                        int TotalAmount = 0;

                        for (int i = 0; i < FeesYearly.Rows.Count; i++)
                        {
                            TotalAmount = TotalAmount + Convert.ToInt32(FeesYearly.Rows[i]["Balance"].ToString());
                        }

                        ((Label)dgvYearlyFee.FooterRow.FindControl("lblAmount")).Text = TotalAmount.ToString();




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

        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblYear.Text = ddlYear.SelectedValue;
            year = ddlYear.SelectedValue;
            Fees_bll bll = new Fees_bll();
            DataTable FeesYearly = new DataTable();

            FeesYearly = bll.YearlyFeeDetailsOnLoad(year);
            if (FeesYearly.Rows.Count != 0)
            {
                dgvYearlyFee.DataSource = null;
                dgvYearlyFee.DataSource = FeesYearly;
                dgvYearlyFee.DataBind();

                int TotalAmount = 0;

                for (int i = 0; i < FeesYearly.Rows.Count; i++)
                {
                    TotalAmount = TotalAmount + Convert.ToInt32(FeesYearly.Rows[i]["Balance"].ToString());
                }

                ((Label)dgvYearlyFee.FooterRow.FindControl("lblAmount")).Text = TotalAmount.ToString();




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