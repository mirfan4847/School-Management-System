using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data;
using SchoolManagementSystem.Bll;

namespace zeeshan
{
    public partial class _2_13_Web_Teacher_View_Results : System.Web.UI.Page
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



                Admission_bll Admin = new Admission_bll();
                DataTable Section = new DataTable();
                Section = Admin.SectionOnload();
                ddlSection.DataSource = Section;
                ddlSection.DataValueField = "sectionId";
                ddlSection.DataTextField = "sectionName";
                ddlSection.DataBind();


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



        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex.Equals(0))
            {
                ddlSection.SelectedIndex = 0;
                lblStudentIdNotFound.Text = "Select Your Class";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);


                int p = 0;
                while (p < 15)
                {
                    dgvEnterMarks.Columns[p].Visible = false;
                    p++;

                }

            }
            else
            {

                Class = ddlClass.SelectedIndex.ToString();
                Section = ddlSection.SelectedIndex.ToString();


                Exam_bll bll = new Exam_bll();

                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();
                DataTable Collection = new DataTable();

                Collection = bll.ViewMarks(Class, Section, term);
                ViewState["gvData"] = Collection;

                if (Collection.Rows.Count != 0)
                {
                    int p = 0;
                    while (p < 15)
                    {
                        dgvEnterMarks.Columns[p].Visible = true;
                        p++;

                    }
                    dgvEnterMarks.DataSource = null;
                    dgvEnterMarks.DataSource = Collection;
                    dgvEnterMarks.DataBind();




                }
                else
                {
                    ddlClass.SelectedIndex = 0;
                    ddlSection.SelectedIndex = 0;
                    Collection.Clear();
                    dgvEnterMarks.DataSource = null;

                    lblStudentIdNotFound.Text = "No Record to Show";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

                    int p = 0;
                    while (p < 15)
                    {
                        dgvEnterMarks.Columns[p].Visible = false;
                        p++;

                    }
                }

            }
        }

        protected void dgvEnterMarks_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            String cls = ddlClass.SelectedIndex.ToString();
            String section = ddlSection.SelectedIndex.ToString();
            int trm = 1;

            if (Request.QueryString["m"] != null)
            {
                trm = Convert.ToInt32(Request.QueryString["m"]);


            }

            DataTable maindt = new DataTable();
            Exam_bll bll = new Exam_bll();
            maindt = bll.ViewMarks(cls, section, trm);



            int q = Convert.ToInt32(maindt.Columns["TotalSubject"].DefaultValue.ToString());
            int z = 0;



            for (z = 0; z < q; z++)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                    ((Label)e.Row.FindControl("lblSub" + z) as Label).Text = maindt.Columns["S" + z].DefaultValue.ToString();
            }

            int j = q;

            if (j < 8)
            {
                int p = z + 1;
                while (p < 10)
                {
                    dgvEnterMarks.Columns[p].Visible = false;
                    p++;

                }
                j = 9;

            }
            // dgvEnterMarks.Columns[2].HeaderText = maindt.Columns["S0"].DefaultValue.ToString();





        }

        
    }
}