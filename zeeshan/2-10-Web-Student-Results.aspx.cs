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
    public partial class _2_10_Web_Student_Area : System.Web.UI.Page
    {
        int term = 1;
        int Class;
        string StudentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String Name = Context.User.Identity.GetUserName();
                if (Name == "")
                {
                    Response.Redirect("2-9-Web-login.aspx");
                }
                else if (!User.IsInRole("Student"))
                {
                    Response.Redirect("Authorized.aspx");
                }


                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();
               


                DataTable Cls = new DataTable();
                Web_Student_bll bll = new Web_Student_bll();

                String student = Context.User.Identity.GetUserName();


                string[] Id = student.Split('@');

                StudentId = Id[0].ToString();

                Cls = bll.StudentClassesOnload(StudentId);

                ddlClass.DataSource = Cls;
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataTextField = "className";

                ddlClass.DataBind();


            }


        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           


            if (ddlClass.SelectedIndex.Equals(0))
            {
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

                Class = ddlClass.SelectedIndex;
                String student = Context.User.Identity.GetUserName();


                string[] Id = student.Split('@');

                StudentId = Id[0].ToString();


                Web_Student_bll bll = new Web_Student_bll();

                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();
                DataTable Collection = new DataTable();

                Collection = bll.ShowResults(Class, term, StudentId);

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
            int trm = 1;

            if (Request.QueryString["m"] != null)
            {
                trm = Convert.ToInt32(Request.QueryString["m"]);


            }
            int cls = ddlClass.SelectedIndex;
            String student = Context.User.Identity.GetUserName();
            string[] Id = student.Split('@');
            StudentId = Id[0].ToString();


            Web_Student_bll bll = new Web_Student_bll();
            DataTable maindt = new DataTable();
            maindt=bll.ShowResults(Class, term, StudentId);


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
        }

        
    }
}
