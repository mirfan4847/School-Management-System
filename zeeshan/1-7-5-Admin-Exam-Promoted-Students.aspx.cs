using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;

namespace Future
{
    public partial class _1_7_5_Admin_Exam_Promoted_Students : System.Web.UI.Page
    {
        int term = 1;
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
                DataTable Classes = new DataTable();
                Exam_bll bll = new Exam_bll();
                Classes = bll.getClasses();
                ddlClass.DataSource = Classes;
                ddlClass.DataTextField = "className";
                ddlClass.DataValueField = "classId";
                ddlClass.DataBind();

                DataTable Section = new DataTable();
                bll = new Exam_bll();
                Section = bll.getSection();
                ddlSection.DataSource = Section;
                ddlSection.DataTextField = "sectionName";
                ddlSection.DataValueField = "sectionId";
                ddlSection.DataBind();

                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);

                }
                lblTerm.Text = term.ToString();


            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex != 0)
            {
                ddlSection.Enabled = true;
            }
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlSection.SelectedIndex != 0)
            {


                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);
                }
                lblTerm.Text = term.ToString();
                Student st = new Student();
                st.currentClass = ddlClass.SelectedItem.Value;
                st.currentSection = ddlSection.SelectedItem.Value;
                st.termOfClass = term;
                Session["classForPromotedStudents"] = ddlClass.SelectedItem.Text;
                Session["sectionForPromotedStudents"] = ddlSection.SelectedItem.Text;
                Session["termForPromotedStudents"] = term;
                DataTable result = new DataTable();
                Exam_bll bll = new Exam_bll();
                result = bll.getPromotedStudents(st);

                if (result.Rows.Count < 1)
                {
                    lblStudentIdNotFound.Text = "Record Not Found";

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);


                    int p = 0;
                    while (p < dgvPromotedStudents.Columns.Count)
                    {
                        dgvPromotedStudents.Columns[p].Visible = false;
                        p++;

                    }
                }
                else
                {
                    int p = 0;
                    while (p < dgvPromotedStudents.Columns.Count)
                    {
                        dgvPromotedStudents.Columns[p].Visible = true;
                        p++;

                    }
                    dgvPromotedStudents.DataSource = result;
                    dgvPromotedStudents.DataBind();

                    ViewState["promotedStudents"] = result;

                }


            }
        }
        protected void btnEmail_Click(object sender, EventArgs e)
        {
            
            int trm=1;

            if (Request.QueryString["m"] != null)
            {
                trm = Convert.ToInt32(Request.QueryString["m"]);

            }

            string cls = ddlClass.SelectedItem.Text;
            string section = ddlSection.SelectedItem.Text;
            DataTable dt = new DataTable();

            dt = (DataTable)ViewState["promotedStudents"];
            Exam_bll bll = new Exam_bll();
            bll.SendEmailToAll(dt,cls,section,trm);

            lblStudentIdNotFound.Text = "Email Has Been Send TO All Students";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

        }

        protected void dgvPromotedStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int trm=1;

            if (Request.QueryString["m"] != null)
            {
                trm = Convert.ToInt32(Request.QueryString["m"]);

            }

            string cls = ddlClass.SelectedItem.Text;
            string section = ddlSection.SelectedItem.Text;
            if (e.CommandName == "dgvEmail")
            {
                int rowIndex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;

                String AddmissionId = e.CommandArgument.ToString();

                Exam_bll bll = new Exam_bll();
                bll.SendEmailToOne(AddmissionId,cls,section, trm);

                lblStudentIdNotFound.Text = "Email Has Been Send to" + " '" + AddmissionId + "'   ";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["RPromotedStudents"] = ViewState["promotedStudents"];
            Response.Redirect("Report-PromotedStudents.aspx");
        }


    }
}