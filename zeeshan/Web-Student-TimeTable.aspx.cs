using SchoolManagementSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;

namespace zeeshan
{
    public partial class Web_Student_TimeTable : System.Web.UI.Page
    {

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



                DataTable Cls = new DataTable();
                Web_Student_bll bll = new Web_Student_bll();

                String student = Context.User.Identity.GetUserName();


                string[] Id = student.Split('@');

                StudentId = Id[0].ToString();

                SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
                string que = "select Class,Section from AddStudent where AdmissionId='" + StudentId + "' ";

                SqlCommand com = new SqlCommand(que, conn);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable nm = new DataTable();
                da.Fill(nm);

                String Class=nm.Rows[0]["Class"].ToString();

                String Section = nm.Rows[0]["Section"].ToString();
               
                DataTable TimeTable = new DataTable();
                Admission_bll bll1 = new Admission_bll();
                TimeTable = bll1.ClassTimeTable(Class, Section);

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