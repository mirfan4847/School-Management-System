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
    public partial class _1_7_8_Admin_Exam_Position_Holders : System.Web.UI.Page
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


                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);
                }
                lblTerm.Text = term.ToString();

                String Class = ddlClass.SelectedItem.Value;


                DataTable result = new DataTable();
                Exam_bll bll = new Exam_bll();
                result = bll.getPositionHolders(Class, term);

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
    }
}