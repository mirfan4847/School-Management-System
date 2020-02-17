using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;

namespace zeeshan
{
    public partial class _1_7_7_Admin_Exam_Set_Grades : System.Web.UI.Page
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
            

            SqlConnection con = new SqlConnection("Data Source=(local); Database=School; Integrated Security=true;");
            SqlDataAdapter da = new SqlDataAdapter();
            string query = "select '0' AS ISUPDATE,Id,GradeName,Percentage,Status from SetGrades";
            if (!IsPostBack)
            {
                da.SelectCommand = new SqlCommand(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count < 1)
                {
                    DataTable gradesAndSubjects = new DataTable();


                    gradesAndSubjects.Columns.Add("Id");
                    gradesAndSubjects.Columns.Add("GradeName");
                    gradesAndSubjects.Columns.Add("Percentage");
                    gradesAndSubjects.Columns.Add("Status");
                    gradesAndSubjects.Columns.Add("ISUPDATE");

                    gradesAndSubjects.Rows.Add("1", "A+", "95%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("2", "A", "85%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("3", "B+", "80%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("4", "B", "75%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("5", "C+", "70%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("6", "C", "65%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("7", "D", "60%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("8", "E", "55%", "Promoted", "0");
                    gradesAndSubjects.Rows.Add("9", "F", "Below of 50%", "Failed", "0");
                    gradesAndSubjects.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));
                    for (int i = 0; i < gradesAndSubjects.Rows.Count; i++)
                    {
                        gradesAndSubjects.Rows[i]["Sr"] = i + 1;
                    }

                    dgvSetGrades.DataSource = gradesAndSubjects;
                    dgvSetGrades.DataBind();
                    ViewState["setGrades"] = gradesAndSubjects;
                }
                else
                {
                    dt.Columns.Add(new DataColumn("Sr", Type.GetType("System.String")));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Sr"] = i + 1;
                    }
                    dgvSetGrades.DataSource = dt;
                    dgvSetGrades.DataBind();
                    ViewState["setGrades"] = dt;
                }
                DataTable grades = (DataTable)ViewState["setGrades"];
                Exam_bll bll = new Exam_bll();
                bll.insertGrades(grades);


            }
        }
        protected void Update_Row(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["setGrades"];

            dt.Rows[e.RowIndex]["GradeName"] = ((TextBox)dgvSetGrades.Rows[e.RowIndex].FindControl("txtEditSetGrades")).Text;
            dt.Rows[e.RowIndex]["Percentage"] = ((TextBox)dgvSetGrades.Rows[e.RowIndex].FindControl("txtEditPercentage")).Text;
            dt.Rows[e.RowIndex]["Status"] = ((TextBox)dgvSetGrades.Rows[e.RowIndex].FindControl("txtEditStatus")).Text;
            dt.Rows[e.RowIndex]["ISUPDATE"] = 1;

            dgvSetGrades.EditIndex = -1;

            dgvSetGrades.DataSource = dt;
            dgvSetGrades.DataBind();

            ViewState["setGrades"] = dt;
        }

        protected void Edit_Row(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["setGrades"];

            dgvSetGrades.EditIndex = e.NewEditIndex;
            dgvSetGrades.DataSource = dt;
            dgvSetGrades.DataBind();



            string gradename = dt.Rows[e.NewEditIndex]["GradeName"].ToString();
            string grademarks = dt.Rows[e.NewEditIndex]["Percentage"].ToString();
            string gradestatus = dt.Rows[e.NewEditIndex]["Status"].ToString();


            ((TextBox)dgvSetGrades.Rows[e.NewEditIndex].FindControl("txtEditSetGrades")).Text = gradename;
            ((TextBox)dgvSetGrades.Rows[e.NewEditIndex].FindControl("txtEditPercentage")).Text = grademarks;
            ((TextBox)dgvSetGrades.Rows[e.NewEditIndex].FindControl("txtEditStatus")).Text = gradestatus;

            ViewState["setGrades"] = dt;
        }



        protected void Cancel_Editing(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["setGrades"];

            dgvSetGrades.EditIndex = -1;

            dgvSetGrades.DataSource = dt;
            dgvSetGrades.DataBind();

            ViewState["setGrades"] = dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["setGrades"];


            dt.TableName = "MYTABLE";


            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);

            String xml = sw.ToString();



            SqlConnection conn = new SqlConnection("Data Source=(local); Database=School; Integrated Security=true");
            SqlCommand comm = new SqlCommand("spGardes", conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@P1", xml));


            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["RSetGrades"] = ViewState["setGrades"];
            Response.Redirect("Report-SetGrades.aspx");
        }
    }
}