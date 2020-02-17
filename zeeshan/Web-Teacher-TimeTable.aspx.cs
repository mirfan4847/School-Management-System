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
    public partial class Web_Teacher_TimeTable : System.Web.UI.Page
    {

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

                DataTable Cls = new DataTable();
                Web_Teacher_bll bll = new Web_Teacher_bll();

                String teacher = Context.User.Identity.GetUserName();


                string[] Id = teacher.Split('@');

                TeacherId = Id[0].ToString();

                DataTable TimeTable = new DataTable();
                Admission_bll blll = new Admission_bll();
                TimeTable = blll.TeacherTimeTable(TeacherId);

                if (TimeTable.Rows.Count != 0)
                {
                    dgvClass.DataSource = null;

                    dgvClass.DataSource = TimeTable;
                    dgvClass.DataBind();

                    ViewState["State"] = TimeTable;

                }

                else
                {
                    lblStudentIdNotFound.Text = "Record Not Found";

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);


                }



            }
        }
    }
}