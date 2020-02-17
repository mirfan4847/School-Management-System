using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.IO;
namespace Future
{
    public partial class Set_Grades : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("data source=(local);database=School;integrated security=true;");
        SqlDataAdapter da = new SqlDataAdapter();
        Student st = new Student();
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

                da.SelectCommand = new SqlCommand("select classId,className from Class", conn);


                DataTable classNameDt = new DataTable();
                da.Fill(classNameDt);

                ddlClass.DataSource = classNameDt;
                ddlClass.DataTextField = "className";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();

                dgvGradesAndSubjects.ShowHeaderWhenEmpty = true;
                Print.Visible = false;

                DataTable deleteDt = new DataTable();
                deleteDt.Columns.Add("id");
                ViewState["deleteDt"] = deleteDt;
            }


        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex != 0)
            {


                DataTable dt = new DataTable();

                st.subject = ddlClass.SelectedItem.Value;
                Session["Class"] = ddlClass.SelectedItem.Text;
                Exam_bll bll = new Exam_bll();
                dt = bll.setSubject(st);





                if (dt.Rows.Count != 0)
                {

                    dgvGradesAndSubjects.DataSource = dt;

                    dgvGradesAndSubjects.DataBind();

                    ViewState["records"] = dt;
                }
                else
                {

                }
                if (ddlClass.SelectedItem.Value == "0")
                {
                    Print.Visible = false;
                }
                else
                {
                    Print.Visible = true;
                }


            }




        }

        protected void Update_Row(object sender, GridViewUpdateEventArgs e)
        {

            DataTable dt = (DataTable)ViewState["records"];

            dt.Rows[e.RowIndex]["Name"] = ((TextBox)dgvGradesAndSubjects.Rows[e.RowIndex].FindControl("txtEditSubject")).Text;
            dt.Rows[e.RowIndex]["SubjectMarks"] = ((TextBox)dgvGradesAndSubjects.Rows[e.RowIndex].FindControl("txtEditMarks")).Text;
            // dt.Rows[e.RowIndex]["GradeName"] = ((TextBox)dgvGradesAndSubjects.Rows[e.RowIndex].FindControl("txtEditSetGrades")).Text;
            //dt.Rows[e.RowIndex]["Percentage"] = ((TextBox)dgvGradesAndSubjects.Rows[e.RowIndex].FindControl("txtEditPercentage")).Text;
            dt.Rows[e.RowIndex]["ISUPDATE"] = "1";

            dgvGradesAndSubjects.EditIndex = -1;

            dgvGradesAndSubjects.DataSource = dt;
            dgvGradesAndSubjects.DataBind();

            ViewState["records"] = dt;
        }

        protected void Edit_Row(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["records"];

            dgvGradesAndSubjects.EditIndex = e.NewEditIndex;
            dgvGradesAndSubjects.DataSource = dt;
            dgvGradesAndSubjects.DataBind();



            string subjectname = dt.Rows[e.NewEditIndex]["Name"].ToString();
            string subjectmarks = dt.Rows[e.NewEditIndex]["SubjectMarks"].ToString();
            // string subjectgrades = dt.Rows[e.NewEditIndex]["GradeName"].ToString();
            // string subjectpercentage = dt.Rows[e.NewEditIndex]["Percentage"].ToString();

            ((TextBox)dgvGradesAndSubjects.Rows[e.NewEditIndex].FindControl("txtEditSubject")).Text = subjectname;
            ((TextBox)dgvGradesAndSubjects.Rows[e.NewEditIndex].FindControl("txtEditMarks")).Text = subjectmarks;
            // ((TextBox)dgvGradesAndSubjects.Rows[e.NewEditIndex].FindControl("txtEditSetGrades")).Text = subjectgrades;
            // ((TextBox)dgvGradesAndSubjects.Rows[e.NewEditIndex].FindControl("txtEditPercentage")).Text = subjectpercentage;
            ViewState["records"] = dt;


        }

        protected void Cancel_Editing(object sender, GridViewCancelEditEventArgs e)
        {

            DataTable dt = (DataTable)ViewState["records"];

            dgvGradesAndSubjects.EditIndex = -1;

            dgvGradesAndSubjects.DataSource = dt;
            dgvGradesAndSubjects.DataBind();

            ViewState["records"] = dt;


        }

        protected void Delete_Row(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["records"];

            DataTable dtDelete = (DataTable)ViewState["deleteDt"];

            // string subname = dt.Rows[e.RowIndex]["Name"].ToString();

            // da.SelectCommand = new SqlCommand("select id from Subject where Name='" + subname + "'", conn);

            //  DataTable getId = new DataTable();
            //da.Fill(getId);



            dtDelete.Rows.Add(dt.Rows[e.RowIndex]["id"].ToString());

            dt.Rows[e.RowIndex].Delete();
            dt.AcceptChanges();

            dgvGradesAndSubjects.DataSource = dt;
            dgvGradesAndSubjects.DataBind();

            ViewState["records"] = dt;
            ViewState["deleteDt"] = dtDelete;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)ViewState["records"];
            DataTable dtDelete = (DataTable)ViewState["deleteDt"];

            dt.TableName = "MYTABLE";
            dtDelete.TableName = "MYTABLE";

            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);

            String xml = sw.ToString();

            StringWriter swDelete = new StringWriter();
            dtDelete.WriteXml(swDelete);

            String xmlDelete = swDelete.ToString();


            SqlCommand comm = new SqlCommand("spSaveSubjects", conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@P1", xml));
            comm.Parameters.Add(new SqlParameter("@P2", xmlDelete));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();


            //        string eror = "Success";
            //        ClientScript.RegisterStartupScript(
            //this.GetType(), "myalert", "alert('" + eror + "');", true);
        }

        protected void btnFooterAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["records"];

            string name = ((TextBox)dgvGradesAndSubjects.FooterRow.FindControl("txtFooterSubjectName")).Text;
            string marks = ((TextBox)dgvGradesAndSubjects.FooterRow.FindControl("txtFooterSubjectMarks")).Text;
            int lastrow = dt.Rows.Count;
            lastrow = lastrow + 1;
            st.subject = ddlClass.SelectedItem.Value;
            if (name != "" && marks != "")
            {
                dt.Rows.Add(0, name, marks, "1", "0", lastrow, st.subject);

                dgvGradesAndSubjects.DataSource = dt;
                dgvGradesAndSubjects.DataBind();
            }
            ViewState["records"] = dt;
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            Session["SetSubjects"] = ViewState["records"];
            Response.Redirect("Report-SetSubjects.aspx");

        }
    }
}