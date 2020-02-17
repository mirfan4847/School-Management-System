using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.Data;
namespace Future
{
    public partial class ThankingLetter : System.Web.UI.Page
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
        public void ClearField()
        {
            txtParents.Text = "";
            txtStudentName.Text = "";
            txtStudentId.Text = "";
            txtdateIssue.Text = "";

        }
        public string SearchID { get; set; }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearField();
            SearchID = txtSearchAdmission.Text;

            Admission_bll bll = new Admission_bll();

            DataTable rules = new DataTable();


            rules = bll.InstituteRule_bll(SearchID);

            if (rules.Rows.Count == 1)
            {
                ClearField();
                txtStudentId.Text = rules.Rows[0]["AdmissionId"].ToString();
                txtParents.Text = rules.Rows[0]["Father"].ToString();
                txtStudentName.Text = rules.Rows[0]["Name"].ToString();
                


            }

            else
            {
                ClearField();
                lblStudentIdNotFound.Text = "Student Record Not Found";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                //upModal.Update();

            }
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("To");
            dt.Columns.Add("StudentName");
            dt.Columns.Add("AdmissionId");
            dt.Columns.Add("Subject");
            dt.Columns.Add("Body");
            dt.Columns.Add("Date");

            dt.Rows.Add(txtParents.Text, txtStudentName.Text, txtStudentId.Text, txtSubject.Text, txtReason.Text, txtdateIssue.Text);

            Session["Thanking-Letter"] = dt;

            Response.Redirect("~/Report-Student-Thanking-Letter.aspx");
        }

      
    }
}