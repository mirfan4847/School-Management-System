using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.Data;

namespace Future
{
    public partial class InsitutionRules : System.Web.UI.Page
    {
        public String SearchID { get; set; }
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
            else if (User.IsInRole("Admin") || User.IsInRole("Accountant"))
            {
                if(!IsPostBack)
                {
                    Admission_bll bll = new Admission_bll();

                    DataTable Class = new DataTable();
                    Class = bll.ClassOnload();

                    ddlClass.DataSource = Class;
                    ddlClass.DataValueField = "classId";
                    ddlClass.DataTextField = "className";

                    ddlClass.DataBind();
                }
                
            }




        }


        public void ClearField()
        {
            txtAdminId.Text = "";
            txtName.Text = "";
            txtFather.Text = "";
            ddlClass.SelectedIndex = 0;
            txtMobile.Text = "";

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearField();
            SearchID = txtSearchAdmission.Text;

            Admission_bll bll = new Admission_bll();

            DataTable rules = new DataTable();


            rules = bll.InstituteRule_bll(SearchID);

            if (rules.Rows.Count == 1)
            {

                txtAdminId.Text = rules.Rows[0]["AdmissionId"].ToString();
                txtName.Text = rules.Rows[0]["Name"].ToString();
                txtFather.Text = rules.Rows[0]["Father"].ToString();
                String Class = rules.Rows[0]["className"].ToString();

                ddlClass.SelectedIndex = ddlClass.Items.IndexOf
                      (ddlClass.Items.FindByText(Class));
                txtMobile.Text = rules.Rows[0]["Mobile"].ToString();


            }

            else
            {
                ClearField();
                lblStudentIdNotFound.Text = "Student Record Not Found";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                //upModal.Update();

            }















        }

        protected void Print_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Father");
            dt.Columns.Add("AdminId");
            dt.Columns.Add("Class");
            dt.Columns.Add("Mobile");
            dt.Columns.Add("Terms");
            dt.Columns.Add("Deposit");
            dt.Columns.Add("SchoolFee");
            dt.Columns.Add("Cancel");
            dt.Columns.Add("Transport");

            dt.Columns.Add("Read");

            dt.Columns.Add("IssueDate");

            dt.Rows.Add(txtName.Text, txtFather.Text, txtAdminId.Text, ddlClass.SelectedItem.Text, txtMobile.Text, txtTerms.Text, txtDeposit.Text, txtFeesRule.Text, txtCancelWithDrawal.Text, txtBus.Text, txtReadCarefully.Text, txtdateIssue.Text);

            Session["Institution-Rules"] = dt;

            Response.Redirect("~/Report-Institution-Rules.aspx");
        }
    }
}