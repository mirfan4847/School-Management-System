using SchoolManagementSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class _1_8_11_Admin_Total_Students : System.Web.UI.Page
    {
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


             SqlConnection conn = new SqlConnection("data source=.;database=School;integrated security=true;");
             String query = "Select AdmissionId,Name,className,sectionName,Picture from AddStudent  INNER JOIN Class  ON AddStudent.Class=Class.classId INNER JOIN Section On Section.sectionId=AddStudent.Section   where className='" + ddlClass.SelectedItem.Text + "' and sectionName='" + ddlSection.SelectedItem.Text + "'";
            
             
             SqlCommand comm = new SqlCommand(query, conn);
             conn.Open();
             SqlDataAdapter da = new SqlDataAdapter(comm);
             DataTable dt = new DataTable();
             da.Fill(dt);


             if (dt.Rows.Count != 0)
             {

                 string im = dt.Rows[0]["Picture"].ToString();



                 DataList1.DataSource = dt;
                 DataList1.DataBind();
                 conn.Close();
             }

             else
             {

                 lblStudentIdNotFound.Text = "No Record To Display";

                 ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
             }
         }
            

    }
}