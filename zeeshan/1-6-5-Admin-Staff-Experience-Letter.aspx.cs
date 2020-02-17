using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Future
{
    public partial class StaffThankingLetter : System.Web.UI.Page
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
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtSearchTeacher.Text);

            SqlConnection conn = new SqlConnection("data source=.;database=School;integrated security=true;");
            string query = "select StaffId,Name,FatherName,A_Qualification,CNIC,Address,Designation,HiringDate from AddStaff inner join StaffAcademicInformation on AddStaff.StaffId=StaffAcademicInformation.A_RegistrationNo where StaffId='" + id + "'";
            SqlCommand comm = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                UpdatedInfo.Text = "Record Not found. ";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "UpdatedSuccessfuly", "$('#UpdatedSuccessfuly').modal();", true);

            }
            if (dt.Rows.Count != 0)
            {

                txtRef.Text = dt.Rows[0]["StaffId"].ToString();
                TextBox1.Text = dt.Rows[0]["Name"].ToString();
                TextBox2.Text = dt.Rows[0]["FatherName"].ToString();
                TextBox3.Text = dt.Rows[0]["A_Qualification"].ToString();
                TextBox4.Text = dt.Rows[0]["CNIC"].ToString();
                TextBox5.Text = dt.Rows[0]["Address"].ToString();
                TextBox6.Text = dt.Rows[0]["Designation"].ToString();
                TextBox7.Text = dt.Rows[0]["HiringDate"].ToString();
            }
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ref");
            dt.Columns.Add("DateIssue");
            dt.Columns.Add("Name");
            dt.Columns.Add("Father");
            dt.Columns.Add("Education");
            dt.Columns.Add("NIC");
            dt.Columns.Add("Address");
            dt.Columns.Add("Designation");
            dt.Columns.Add("From");
            dt.Columns.Add("To");
            dt.Columns.Add("Body");


            dt.Rows.Add(txtRef.Text, txtdateIssue.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text,TextBox7.Text,TextBox8.Text,txtReason.Text);

            Session["StaffExperienceLetter"] = dt;

            Response.Redirect("~/Report-Staff-Experience-Letter.aspx");

        }
    }
}