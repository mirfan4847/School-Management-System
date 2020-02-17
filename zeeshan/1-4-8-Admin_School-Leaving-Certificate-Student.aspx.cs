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
    public partial class _1_4_8_Admin_School_Leaving_Certificate_Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                    ddlClass.DataSource = Class;
                    ddlClass.DataValueField = "classId";
                    ddlClass.DataTextField = "className";
                    ddlClass.DataBind();

                    ddlPresent.DataSource = Class;
                    ddlPresent.DataValueField = "classId";
                    ddlPresent.DataTextField = "className";
                    ddlPresent.DataBind();


                    DataTable Section = new DataTable();
                    Section = bll.SectionOnload();
                    ddlSection.DataSource = Section;
                    ddlSection.DataValueField = "sectionId";
                    ddlSection.DataTextField = "sectionName";
                    ddlSection.DataBind();

                }



            }
        }




        public void ClearField()
        {
            ImgLeaving.ImageUrl = "~/Images/Student_Img.jpg";
            txtAdminId.Text = "";

            txtName.Text = "";
            txtFather.Text = "";
            txtBirth.Text = "";
            txtAdmissionDate.Text = "";
            ddlClass.SelectedIndex = 0;
            ddlSection.SelectedIndex = 0;
            ddlCurricular.SelectedIndex = 0;
            ddlPresent.SelectedIndex = 0;
            txtOcupation.Text = "";
            txtReligion.Text = "";
            txtHome.Text = "";
            txtAttendanceFrom.Text = "";
            txtAttendanceTo.Text = "";
            txtDateLeaving.Text = "";
            txtFeeDue.Text = "";
            txtReason.Text = "";
            txtFeeRemarks.Text = "";
            txtGeneralRemarks.Text = "";
            txtdateIssue.Text = "";


            //Form2



            //Form3







        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearField();
            String Id = txtSearchAdmission.Text;
            DataTable leaving = new DataTable();
            Admission_bll bll = new Admission_bll();
            leaving = bll.SchoolLeaving(Id);


            if (leaving.Rows.Count == 1)
            {


                string img = leaving.Rows[0]["Picture"].ToString();
                ImgLeaving.ImageUrl = img;
                txtAdminId.Text = leaving.Rows[0]["AdmissionId"].ToString();
                txtName.Text = leaving.Rows[0]["Name"].ToString();
                txtFather.Text = leaving.Rows[0]["Father"].ToString();
                txtBirth.Text = leaving.Rows[0]["DOB"].ToString();
                txtAdmissionDate.Text = leaving.Rows[0]["AdmissionDate"].ToString();

                String Class = leaving.Rows[0]["className"].ToString();

                ddlClass.SelectedIndex = ddlClass.Items.IndexOf
                      (ddlClass.Items.FindByText(Class));


                String Present = leaving.Rows[0]["className"].ToString();

                ddlPresent.SelectedIndex = ddlPresent.Items.IndexOf
                      (ddlPresent.Items.FindByText(Present));

                String Section = leaving.Rows[0]["sectionName"].ToString();

                ddlSection.SelectedIndex = ddlSection.Items.IndexOf
                      (ddlSection.Items.FindByText(Section));






                txtOcupation.Text = leaving.Rows[0]["FOccupation"].ToString();
                txtReligion.Text = leaving.Rows[0]["Religion"].ToString();
                txtHome.Text = leaving.Rows[0]["Address"].ToString();

                String Curricular = leaving.Rows[0]["Curricular"].ToString();

                ddlCurricular.SelectedIndex = ddlCurricular.Items.IndexOf
                     (ddlCurricular.Items.FindByText(Curricular));






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
            dt.Columns.Add("AdminId");
            dt.Columns.Add("Name");
            dt.Columns.Add("Father");
            dt.Columns.Add("DOB");
            dt.Columns.Add("AdmissionDate");
            dt.Columns.Add("Class");
            dt.Columns.Add("Section");
            dt.Columns.Add("FOccupation");
            dt.Columns.Add("Religion");
            dt.Columns.Add("Address");
            dt.Columns.Add("Curricular");
            dt.Columns.Add("AttendanceFrom");
            dt.Columns.Add("AttendanceTo");
            dt.Columns.Add("DateofLeaving");
            dt.Columns.Add("FeeDue");
            dt.Columns.Add("ReasonofLeaving");
            dt.Columns.Add("FeeRemarks");
            dt.Columns.Add("GeneralRemarks");
            dt.Columns.Add("DateofIssue");

            dt.Rows.Add(txtAdminId.Text, txtName.Text, txtFather.Text, txtBirth.Text, txtAdmissionDate.Text, ddlPresent.SelectedItem.Text, ddlSection.SelectedItem.Text, txtOcupation.Text, txtReligion.Text, txtHome.Text, ddlCurricular.SelectedItem.Text, txtAttendanceFrom.Text, txtAttendanceTo.Text, txtDateLeaving.Text, txtFeeDue.Text, txtReason.Text, txtFeeRemarks.Text, txtGeneralRemarks.Text, txtdateIssue.Text);

            Session["Leaving-Certificate"] = dt;

            Response.Redirect("~/Report-Sudent-Leaving.aspx");

        }


    }
}