using SchoolManagementSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace zeeshan
{
    public partial class _2_16_Web_Teacher_Position_Holders : System.Web.UI.Page
    {
        int term = 1;
        String Class;
        String Section;
        string TeacherId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String Name = Context.User.Identity.GetUserName();
                if (Name == "")
                {
                    Response.Redirect("2-9-Web-login.aspx");
                }
                else if (!User.IsInRole("Teacher"))
                {
                    Response.Redirect("Authorized.aspx");
                }



               

                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();



                DataTable Cls = new DataTable();
                Web_Teacher_bll bll = new Web_Teacher_bll();

                String teacher = Context.User.Identity.GetUserName();


                string[] Id = teacher.Split('@');

                TeacherId = Id[0].ToString();

                Cls = bll.TeacherClassesOnload(TeacherId);

                ddlClass.DataSource = Cls;
                ddlClass.DataValueField = "classId";
                ddlClass.DataTextField = "className";

                ddlClass.DataBind();




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