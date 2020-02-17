using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Future
{
    public partial class Update_Staff_Info : System.Web.UI.Page
    {

        public void emptyFields()
        {

            txtRgNo.Text = "";
            txtName.Text = "";
            txtFather.Text = "";
            txtBirth.Text = "";
            txtCnic.Text = "";
            txtPhoneNo.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtQualification.Text = "";
            ddlBloodGroup.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            txtHireDate.Text = "";
            txtExperience.Text = "";
            txtFavSbj.Text = "";
            txtDesignation.Text = "";
            txtSection.Text = "";
            txtclg.Text = "";
            txtSalary.Text = "";
            txtAnnualInc.Text = "";
            txtBps.Text = "";
            ddlAppointedAs.SelectedIndex = 0;
            ddlTrialPer.SelectedIndex = 0;
            txtContract.Text = "";
            txtDate.Text = "";
        }


        SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
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
            int seachid = Convert.ToInt32(txtSearchAdmission.Text);


            conn.Open();
            SqlCommand comm = new SqlCommand("select * from AddStaff where StaffId='" + seachid + "'", conn);
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

                txtRgNo.Text = dt.Rows[0]["StaffId"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtFather.Text = dt.Rows[0]["FatherName"].ToString();
                txtBirth.Text = dt.Rows[0]["DOB"].ToString();
                txtCnic.Text = dt.Rows[0]["CNIC"].ToString();
                txtPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtMobile.Text = dt.Rows[0]["MobileNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtQualification.Text = dt.Rows[0]["Qualification"].ToString();
                ddlBloodGroup.SelectedItem.Text = dt.Rows[0]["BloodGroup"].ToString();
                ddlGender.Text = dt.Rows[0]["Gender"].ToString();
                txtHireDate.Text = dt.Rows[0]["HiringDate"].ToString();
                txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                txtExperience.Text = dt.Rows[0]["Experience"].ToString();
                txtFavSbj.Text = dt.Rows[0]["FavSubject"].ToString();
                txtSection.Text = dt.Rows[0]["Section"].ToString();
                txtclg.Text = dt.Rows[0]["Institute"].ToString();
                txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                txtAnnualInc.Text = dt.Rows[0]["AnnualIncreament"].ToString();
                txtBps.Text = dt.Rows[0]["BPS"].ToString();
                ddlAppointedAs.SelectedItem.Text = dt.Rows[0]["AppointedAs"].ToString();
                ddlTrialPer.SelectedItem.Text = dt.Rows[0]["TrialExperience"].ToString();
                txtContract.Text = dt.Rows[0]["Contract"].ToString();
                txtDate.Text = dt.Rows[0]["Date"].ToString();
                conn.Close();
            }
            else
            {
                txtRgNo.Text = "NO RECORD FOUND";

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "update AddStaff Set Name='" + txtName.Text + "',FatherName='" + txtFather.Text + "',DOB='" + txtBirth.Text + "',CNIC='" + txtCnic.Text + "',PhoneNo='" + txtPhoneNo.Text + "',MobileNo='" + txtMobile.Text + "',Email='" + txtEmail.Text + "',Address='" + txtAddress.Text + "',Qualification='" + txtQualification.Text + "',BloodGroup='" + ddlBloodGroup.SelectedItem.Text + "',Gender='" + ddlGender.SelectedItem.Text + "',Hiringdate='" + txtHireDate.Text + "',Experience='" + txtExperience.Text + "',FavSubject='" + txtFavSbj.Text + "',Designation='" + txtDesignation.Text + "',Section='" + txtSection.Text + "',Institute='" + txtclg.Text + "',Salary='" + txtSalary.Text + "',AnnualIncreament='" + txtAnnualInc.Text + "',BPS='" + txtBps.Text + "',AppointedAs='" + ddlAppointedAs.SelectedItem.Text + "',TrialExperience='" + ddlTrialPer.Text + "',Contract='" + txtContract.Text + "',Date='" + txtDate.Text + "' where StaffId='"+txtSearchAdmission.Text+"' ";
            SqlCommand comm = new SqlCommand(query, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            

            UpdatedInfo.Text = "Record of  " + txtName.Text + "  has been Updated successfuly";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "UpdatedSuccessfuly", "$('#UpdatedSuccessfuly').modal();", true);
            emptyFields();
        }


    }
}