using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.Data;
using System.Globalization;

namespace Future
{
    public partial class _1_8_3_Admin_Fees_Defaulters : System.Web.UI.Page
    {
        int mnth = 1;
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
                    Admission_bll bll = new Admission_bll();

                    DataTable Class = new DataTable();
                    Class = bll.ClassOnload();

                    ddlClass.DataSource = Class;
                    ddlClass.DataValueField = "classId";
                    ddlClass.DataTextField = "className";

                    ddlClass.DataBind();

                    DataTable Section = new DataTable();
                    Section = bll.SectionOnload();
                    ddlSection.DataSource = Section;
                    ddlSection.DataValueField = "sectionId";
                    ddlSection.DataTextField = "sectionName";
                    ddlSection.DataBind();

                    if (Request.QueryString["m"] != null)
                    {
                        mnth = Convert.ToInt32(Request.QueryString["m"]);
                    }
                    lblMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mnth);
                }



              
            }
        }






        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex.Equals(0))
            {
                ddlSection.SelectedIndex = 0;
                lblStudentIdNotFound.Text = "Select Your Class";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

            }
            else
            {

                String Class = ddlClass.SelectedIndex.ToString();
                String Section = ddlSection.SelectedIndex.ToString();
                Session["classForFeesDefaulter"] = ddlClass.SelectedItem.Text;
                Session["sectionForFeesDefaulter"] = ddlSection.SelectedItem.Text;
                DataTable Defaulters = new DataTable();
                Fees_bll bll = new Fees_bll();

                if (Request.QueryString["m"] != null)
                {
                    mnth = Convert.ToInt32(Request.QueryString["m"]);
                }
                lblMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mnth);

                Defaulters = bll.FeeDefaulters(Class, Section, mnth);
                if (Defaulters.Rows.Count != 0)
                {
                    dgvFee.DataSource = null;
                    dgvFee.DataSource = Defaulters;
                    dgvFee.DataBind();
                    ViewState["FeeDefaulter"] = Defaulters;


                }
                else
                {
                    ddlClass.SelectedIndex = 0;
                    ddlSection.SelectedIndex = 0;
                    Defaulters.Clear();
                    dgvFee.DataSource = null;

                    lblStudentIdNotFound.Text = "No Record to Show";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                }

            }

        }

       



        protected void btnAllDefaulters_Click(object sender, EventArgs e)
        {
            ddlClass.SelectedIndex = 0;
            ddlSection.SelectedIndex = 0;
            DataTable Defaulters = new DataTable();
            Fees_bll bll = new Fees_bll();

            if (Request.QueryString["m"] != null)
            {
                mnth = Convert.ToInt32(Request.QueryString["m"]);
            }
            lblMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mnth);

            Defaulters = bll.AllFeeDefaulters(mnth);
            if (Defaulters.Rows.Count != 0)
            {
                dgvFee.DataSource = null;
                dgvFee.DataSource = Defaulters;
                dgvFee.DataBind();
                ViewState["FeeDefaulter"] = Defaulters;

            }
            else
            {
                ddlClass.SelectedIndex = 0;
                ddlSection.SelectedIndex = 0;


                lblStudentIdNotFound.Text = "No Record to Show";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }
        }

        protected void dgvFee_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (Request.QueryString["m"] != null)
            {
                mnth = Convert.ToInt32(Request.QueryString["m"]);
            }

            if (e.CommandName == "dgvEmail")
            {
                int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;

                String AddmissionId = e.CommandArgument.ToString();

                Fees_bll bll = new Fees_bll();
                bll.SendEmailToOne(AddmissionId, mnth);

                lblStudentIdNotFound.Text = "Email Has Been Send to"+" '"+AddmissionId+"'   ";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }
        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["m"] != null)
            {
                mnth = Convert.ToInt32(Request.QueryString["m"]);
            }

            DataTable dt = new DataTable();

            dt = (DataTable)ViewState["FeeDefaulter"];
            Fees_bll bll = new Fees_bll();
            bll.SendEmailToAll(dt, mnth);

            lblStudentIdNotFound.Text = "Email Has Been Send TO All Students";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["RFeesDefaulter"] = ViewState["FeeDefaulter"];
            Response.Redirect("Report-FeesDefaulters.aspx");
        }
    }
}