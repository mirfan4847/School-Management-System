using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.Globalization;


namespace Future
{
    public partial class _1_8_2_Admin_Fees_Collection : System.Web.UI.Page
    {
        int mnth=1;
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
                Session["classForFeesCollection"] = ddlClass.SelectedItem.Text;
                Session["sectionForFeesCollection"] = ddlSection.SelectedItem.Text;
                DataTable Collection = new DataTable();
                Fees_bll bll = new Fees_bll();

                if (Request.QueryString["m"] != null)
                {
                    mnth = Convert.ToInt32(Request.QueryString["m"]);
                }
                lblMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mnth);

                Collection = bll.FeeCollection(Class, Section, mnth);
                if (Collection.Rows.Count != 0)
                {
                    dgvFee.DataSource = null;
                    dgvFee.DataSource = Collection;
                    dgvFee.DataBind();

                    ViewState["State"] = Collection;


                }
                else
                {
                    ddlClass.SelectedIndex = 0;
                    ddlSection.SelectedIndex = 0;
                    Collection.Clear();
                    dgvFee.DataSource = null;

                    lblStudentIdNotFound.Text = "No Record to Show";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                }

            }
        }


        protected void dgvFee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvFee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];
            dgvFee.EditIndex = e.NewEditIndex;
            dgvFee.DataSource = dt;
            dgvFee.DataBind();


            String FeeStatus = dt.Rows[e.NewEditIndex]["FeeStatus"].ToString();

            ((TextBox)dgvFee.Rows[e.NewEditIndex].FindControl("txtFees")).Text = FeeStatus;


            String Fine = dt.Rows[e.NewEditIndex]["lateFeeFine"].ToString();
            ((TextBox)dgvFee.Rows[e.NewEditIndex].FindControl("txtFine")).Text = Fine;



            String Date = dt.Rows[e.NewEditIndex]["Paid_Date"].ToString();

            ((TextBox)dgvFee.Rows[e.NewEditIndex].FindControl("txtDate")).Text = Date;


            String Slip = dt.Rows[e.NewEditIndex]["Slip"].ToString();

            ((TextBox)dgvFee.Rows[e.NewEditIndex].FindControl("txtSlip")).Text = Slip;

            String Fee_Status = dt.Rows[e.NewEditIndex]["Fee_Status"].ToString();

            ((DropDownList)dgvFee.Rows[e.NewEditIndex].FindControl("ddlFeeStatus")).SelectedValue = Fee_Status;


            ViewState["State"] = dt;

        }


        protected void dgvFee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];
            dgvFee.EditIndex = -1;

            dgvFee.DataSource = dt;
            dgvFee.DataBind();
            ViewState["State"] = dt;
        }

        protected void dgvFee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];
            dt.Rows[e.RowIndex]["FeeStatus"] = ((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtFees")).Text;

            string id = dt.Rows[e.RowIndex]["AdmissionId"].ToString();

            String fine = ((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtFine")).Text;
            if (string.IsNullOrWhiteSpace(fine))
            {
                dt.Rows[e.RowIndex]["lateFeeFine"] = "0";
            }
            else
            {
                dt.Rows[e.RowIndex]["lateFeeFine"] = ((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtFine")).Text;
            }


            float TFess = Convert.ToInt32(((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtFees")).Text);


            float TFine = Convert.ToInt32(dt.Rows[e.RowIndex]["lateFeeFine"]);


            float TBalance = TFess + TFine;
            string paydate = ((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtDate")).Text;

            dt.Rows[e.RowIndex]["Balance"] = TBalance;
            dt.Rows[e.RowIndex]["Paid_Date"] = paydate;
            dt.Rows[e.RowIndex]["Slip"] = ((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtSlip")).Text;
            // dt.Rows[e.RowIndex]["Fee_Month"] = ((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtMonth")).Text;
            //dt.Rows[e.RowIndex]["Fee_Status"] = ((TextBox)dgvFee.Rows[e.RowIndex].FindControl("txtFeeStatus")).Text;

            dt.Rows[e.RowIndex]["Fee_Status"] = ((DropDownList)dgvFee.Rows[e.RowIndex].FindControl("ddlFeeStatus")).SelectedItem.Text;
            //if (!string.IsNullOrWhiteSpace(paydate))
            //{
            dt.Rows[e.RowIndex]["ISUPDATE"] = "1";
            //}

            dgvFee.EditIndex = -1;

            dgvFee.DataSource = dt;
            dgvFee.DataBind();
            ViewState["State"] = dt;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)ViewState["State"];

            Fees_bll bll = new Fees_bll();
            bll.AddFeesCollection_bll(dt);
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["RFeesCollection"] = ViewState["State"];
            Response.Redirect("Report-FeesCollection.aspx");
        }



    }
}