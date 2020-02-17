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
    public partial class _1_4_3_Admin_Fill_Form_Student : System.Web.UI.Page
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

                lblRecordNotFound.Visible = false;
                Admission_bll bll = new Admission_bll();

                DataTable Class = new DataTable();
                Class = bll.ClassOnload();

                ddlClass.DataSource = Class;
                ddlClass.DataValueField = "classId";
                ddlClass.DataTextField = "className";

                ddlClass.DataBind();

                DataTable Section = new DataTable();
                Section = bll.SectionOnload();
                ddlSection.DataSource = Section;
                ddlSection.DataValueField = "sectionId";
                ddlSection.DataTextField = "sectionName";
                ddlSection.DataBind();
            }
        }

        public void ClearField()
        {
            Image1.ImageUrl = "~/Images/Student_Img.jpg";
            txtName.Text = "";
            txtFather.Text = "";
            txtBirth.Text = "";
            ddlPlaceOfBirth.SelectedIndex = 0;
            txtBform.Text = "";
            ddlBloodGroup.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            txtCnic.Text = "";
            txtOcupation.Text = "";
            txtIncome.Text = "";
            txtReligion.Text = "";
            txtGuardian.Text = "";
            txtGuardianCnic.Text = "";
            txtGuardianEducation.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtHomeTel.Text = "";
            ddlHostel.SelectedIndex = 0;
            ddlCare.SelectedIndex = 0;
            txtHome.Text = "";

            //Form2
            txtInstitute.Text = "";
            txtInstituteAdmissionNo.Text = "";
            txtAddress.Text = "";
            txtClass.Text = "";
            txtCertificate.Text = "";
            ddlCurricular.SelectedIndex = 0;
            txtSiblingName1.Text = "";
            ddlStatus1.SelectedIndex = 0;
            txtAdminNo1.Text = "";
            txtSiblingName2.Text = "";
            ddlStatus2.SelectedIndex = 0;
            txtAdminNo2.Text = "";
            txtSiblingName3.Text = "";
            ddlStatus3.SelectedIndex = 0;
            txtAdminNo3.Text = "";


            //Form3
            txtFee.Text = "";
            ddlDiscount.SelectedIndex = 0;
            ddlClass.SelectedIndex = 0;
            ddlSection.SelectedIndex = 0;
            ddlMedium.SelectedIndex = 0;
            txtAdminId.Text = "";
            txtSession.Text = "";
            txtFee.Text = "";
            txtFamilyNo.Text = "";
            txtAdmissionDate.Text = "";
            txtRemarks.Text = "";
            ddlApproved.SelectedIndex = 0;

        }


        public String SearchID { get; set; }

       

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearField();
            SearchID = txtSearchAdmission.Text;

            Admission_bll bll = new Admission_bll();

            DataTable edit = new DataTable();

            edit = bll.EditStudent_bll(SearchID);

            if (edit.Rows.Count == 1)
            {
                Session["studentAdmissionForm"] = edit;

                lblRecordNotFound.Visible = true;
                lblRecordNotFound.Text = "Record Found";


                string img = edit.Rows[0]["Picture"].ToString();
                Image1.ImageUrl = img;


                txtName.Text = edit.Rows[0]["Name"].ToString();
                txtFather.Text = edit.Rows[0]["Father"].ToString();
                txtBirth.Text = edit.Rows[0]["DOB"].ToString();

                String place = edit.Rows[0]["Place"].ToString();
                ddlPlaceOfBirth.SelectedIndex = ddlPlaceOfBirth.Items.IndexOf
                      (ddlPlaceOfBirth.Items.FindByText(place));

                txtBform.Text = edit.Rows[0]["BForm"].ToString();

                String BloodGroup = edit.Rows[0]["Blood"].ToString();

                ddlBloodGroup.SelectedIndex = ddlBloodGroup.Items.IndexOf
                      (ddlBloodGroup.Items.FindByText(BloodGroup));

                String Gender = edit.Rows[0]["Gender"].ToString();

                ddlGender.SelectedIndex = ddlGender.Items.IndexOf
                      (ddlGender.Items.FindByText(Gender));

                txtCnic.Text = edit.Rows[0]["FCnic"].ToString();
                txtOcupation.Text = edit.Rows[0]["FOccupation"].ToString();
                txtIncome.Text = edit.Rows[0]["FIncome"].ToString();
                txtReligion.Text = edit.Rows[0]["Religion"].ToString();
                txtGuardian.Text = edit.Rows[0]["GName"].ToString();
                txtGuardianCnic.Text = edit.Rows[0]["GCnic"].ToString();
                txtGuardianEducation.Text = edit.Rows[0]["GEducation"].ToString();
                txtEmail.Text = edit.Rows[0]["Email"].ToString();
                txtMobile.Text = edit.Rows[0]["Mobile"].ToString();
                txtHomeTel.Text = edit.Rows[0]["HomeTel"].ToString();

                String Hostel = edit.Rows[0]["Hostel"].ToString();

                ddlHostel.SelectedIndex = ddlHostel.Items.IndexOf
                      (ddlHostel.Items.FindByText(Hostel));

                String Care = edit.Rows[0]["Care"].ToString();

                ddlCare.SelectedIndex = ddlCare.Items.IndexOf
                       (ddlCare.Items.FindByText(Care));

                txtHome.Text = edit.Rows[0]["Address"].ToString();

                //Form2
                txtInstitute.Text = edit.Rows[0]["PInstitutionName"].ToString();
                txtInstituteAdmissionNo.Text = edit.Rows[0]["PAdmissionId"].ToString();
                txtAddress.Text = edit.Rows[0]["PInstitutionAddress"].ToString();
                txtClass.Text = edit.Rows[0]["PInstitutionClass"].ToString();
                txtCertificate.Text = edit.Rows[0]["PInstitutionCertificate"].ToString();

                String Curricular = edit.Rows[0]["Curricular"].ToString();

                ddlCurricular.SelectedIndex = ddlCurricular.Items.IndexOf
                     (ddlCurricular.Items.FindByText(Curricular));


                txtSiblingName1.Text = edit.Rows[0]["SiblingName1"].ToString();

                String Status1 = edit.Rows[0]["SiblingStatus1"].ToString();


                ddlStatus1.SelectedIndex = ddlStatus1.Items.IndexOf
                      (ddlStatus1.Items.FindByText(Status1));


                txtAdminNo1.Text = edit.Rows[0]["SiblingId1"].ToString();
                txtSiblingName2.Text = edit.Rows[0]["SiblingName2"].ToString();


                String Status2 = edit.Rows[0]["SiblingStatus2"].ToString();


                ddlStatus2.SelectedIndex = ddlStatus2.Items.IndexOf
                      (ddlStatus2.Items.FindByText(Status2));

                txtAdminNo2.Text = edit.Rows[0]["SiblingId2"].ToString();
                txtSiblingName3.Text = edit.Rows[0]["SiblingName3"].ToString();



                String Status3 = edit.Rows[0]["SiblingStatus3"].ToString();


                ddlStatus3.SelectedIndex = ddlStatus3.Items.IndexOf
                      (ddlStatus3.Items.FindByText(Status3));

                txtAdminNo3.Text = edit.Rows[0]["SiblingId3"].ToString();


                //Form3

                String Class = edit.Rows[0]["className"].ToString();

                ddlClass.SelectedIndex = ddlClass.Items.IndexOf
                      (ddlClass.Items.FindByText(Class));

                String Section = edit.Rows[0]["sectionName"].ToString();

                ddlSection.SelectedIndex = ddlSection.Items.IndexOf
                      (ddlSection.Items.FindByText(Section));





                String Medium = edit.Rows[0]["Medium"].ToString();
                ddlMedium.SelectedIndex = ddlMedium.Items.IndexOf
                       (ddlMedium.Items.FindByText(Medium));


                txtAdminId.Text = edit.Rows[0]["AdmissionId"].ToString();
                txtSession.Text = edit.Rows[0]["Session"].ToString();
                txtFee.Text = edit.Rows[0]["FeeStatus"].ToString();
                txtFamilyNo.Text = edit.Rows[0]["FamilyNo"].ToString();
                txtAdmissionDate.Text = edit.Rows[0]["AdmissionDate"].ToString();
                txtRemarks.Text = edit.Rows[0]["Remarks"].ToString();



                String Approved = edit.Rows[0]["Approval"].ToString();

                ddlApproved.SelectedIndex = ddlApproved.Items.IndexOf
                     (ddlApproved.Items.FindByText(Approved));

                //gv.DataSource = null;
                //gv.DataSource = edit;
                //gv.DataBind();

            }

            else
            {
                ClearField();
                lblRecordNotFound.Visible = true;
                lblRecordNotFound.Text = "Record not found";

                lblStudentIdNotFound.Text = "Student Record Not Found";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                //upModal.Update();
            }


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

           
            Session["AdmissionForm"] = (DataTable) Session["studentAdmissionForm"];

            Response.Redirect("~/Report-Student-Admission-Form.aspx");

        }
    }
}