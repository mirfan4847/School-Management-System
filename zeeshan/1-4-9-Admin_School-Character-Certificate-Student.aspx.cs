using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;

namespace Future
{
    public partial class CharacterCertificate : System.Web.UI.Page
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
            else if (User.IsInRole("Admin") || User.IsInRole("Accountant"))
            {



                Admission_bll bll = new Admission_bll();

                DataTable Class = new DataTable();
                Class = bll.ClassOnload();

                ddlPresent.DataSource = Class;
                ddlPresent.DataValueField = "classId";
                ddlPresent.DataTextField = "className";
                ddlPresent.DataBind();
            }
        }
        public void ClearField()
        {
            ImgCharacter.ImageUrl = "~/Images/Student_Img.jpg";
            txtAdminId.Text = "";

            txtName.Text = "";
            txtFather.Text = "";
            txtSessionFrom.Text = "";
            txtSessionTO.Text = "";

            txtBirth.Text = "";
            ddlPresent.SelectedIndex = 0;

            txtBoard.Text = "";
            txtDateExam.Text = "";
            txtBoardRoll.Text = "";
            txtMarksObtained.Text = "";
            txtTotalMarks.Text = "";
            txtPercentage.Text = "";
            txtGrade.Text = "";

            txtGeneralRemarks.Text = "";
            txtdateIssue.Text = "";

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearField();
            String Id = txtSearchAdmission.Text;
            DataTable character = new DataTable();
            Admission_bll bll = new Admission_bll();
            character = bll.SchoolCharacter(Id);

            if (character.Rows.Count == 1)
            {


                string img = character.Rows[0]["Picture"].ToString();
                ImgCharacter.ImageUrl = img;
                txtAdminId.Text = character.Rows[0]["AdmissionId"].ToString();

                txtName.Text = character.Rows[0]["Name"].ToString();
                txtFather.Text = character.Rows[0]["Father"].ToString();
                txtSessionFrom.Text = character.Rows[0]["Session"].ToString();
                txtSessionTO.Text = character.Rows[0]["Session"].ToString();

                txtBirth.Text = character.Rows[0]["DOB"].ToString();



                String Present = character.Rows[0]["className"].ToString();

                ddlPresent.SelectedIndex = ddlPresent.Items.IndexOf
                      (ddlPresent.Items.FindByText(Present));






            }

            else
            {
                ClearField();
                lblStudentIdNotFound.Text = "Student Record Not Found";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                //upModal.Update();

            }





        }

        //protected void Print_Click(object sender, EventArgs e)
        //{
        //}

        protected void txtTotalMarks_TextChanged(object sender, EventArgs e)
        {
            if (txtMarksObtained.Text != "")
            {
                float Obtained = Convert.ToInt32(txtMarksObtained.Text);
                float total = Convert.ToInt32(txtTotalMarks.Text);
                float percentage = (Obtained / total) * 100;
                txtPercentage.Text = percentage.ToString();
            }
        }

        protected void Print_Click1(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Father");
            dt.Columns.Add("Admission");
            dt.Columns.Add("From");
            dt.Columns.Add("To");
            dt.Columns.Add("DOB");
            dt.Columns.Add("Class");
            dt.Columns.Add("BRoll");
            dt.Columns.Add("Marks");
            dt.Columns.Add("Percentage");
            dt.Columns.Add("Grade");
            dt.Columns.Add("IssueDate");

            dt.Rows.Add(txtName.Text, txtFather.Text, txtAdminId.Text, txtSessionFrom.Text, txtSessionTO.Text, txtBirth.Text, ddlPresent.SelectedItem.Text, txtBoardRoll.Text, txtMarksObtained.Text, txtPercentage.Text, txtGrade.Text, txtdateIssue.Text);

            Session["Character-Certificate"] = dt;

            Response.Redirect("~/Printing-Reports/PrintCharacterReport.aspx");
        }
    }
}