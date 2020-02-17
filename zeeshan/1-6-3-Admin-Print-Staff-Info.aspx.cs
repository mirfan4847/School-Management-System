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
    public partial class Print_Staff_Info : System.Web.UI.Page
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

            int seachid = Convert.ToInt32(txtSearchAdmission.Text);
            SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
            conn.Open();
            SqlCommand comm = new SqlCommand("select * from StaffAcademicInformation INNER JOIN AddStaff on StaffAcademicInformation.A_RegistrationNo=AddStaff.StaffId INNER JOIN StaffProfessionalInformation ON StaffProfessionalInformation.RegistrationNo=AddStaff.StaffId where StaffAcademicInformation.A_RegistrationNo='" + seachid + "'", conn);
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

                DataTable qua = new DataTable();
                qua.Columns.Add("Id");
                qua.Columns.Add("A_Qualification");
                qua.Columns.Add("A_PassingYear");
                qua.Columns.Add("A_RegistrationNo");
                qua.Columns.Add("A_Devision");
                qua.Columns.Add("A_Institution");
                qua.Columns.Add("ISNEW");
                qua.Columns.Add("ISUPDATE");

                qua.Rows.Add(dt.Rows[0]["Id"], dt.Rows[0]["A_Qualification"], dt.Rows[0]["A_PassingYear"], dt.Rows[0]["A_RegistrationNo"], dt.Rows[0]["A_Devision"], dt.Rows[0]["A_Institution"], 0, 0);
                ViewState["regNo"] = dt.Rows[0]["A_RegistrationNo"];
                gvAcademicQualification.DataSource = qua;
                gvAcademicQualification.DataBind();
                Session["AccQ"] = qua;

                DataTable pro = new DataTable();
                pro.Columns.Add("Id");
                pro.Columns.Add("P_Qualification");
                pro.Columns.Add("PassingYear");
                pro.Columns.Add("RegistrationNo");
                pro.Columns.Add("Devision");
                pro.Columns.Add("Institution");
                pro.Columns.Add("ISNEW");
                pro.Columns.Add("ISUPDATE");

                pro.Rows.Add(dt.Rows[0]["Id"], dt.Rows[0]["P_Qualification"], dt.Rows[0]["PassingYear"], dt.Rows[0]["RegistrationNo"], dt.Rows[0]["Devision"], dt.Rows[0]["Institution"], 0, 0);
                ViewState["regNo"] = dt.Rows[0]["RegistrationNo"];
                gvProfessionalQualification.DataSource = pro;
                gvProfessionalQualification.DataBind();
                Session["ProQ"] = pro;

                conn.Close();
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("FatherName");
            dt.Columns.Add(new DataColumn("DOB", typeof(DateTime)));

           
            dt.Columns.Add("CNIC");
            dt.Columns.Add("PhoneNo");
            dt.Columns.Add("MobileNo");
            dt.Columns.Add("Email");
            dt.Columns.Add("Address");
           

            dt.Columns.Add("Qualification");
            dt.Columns.Add("BloodGroup");
            dt.Columns.Add("Gender");
            dt.Columns.Add("HiringDate");
            dt.Columns.Add("Experience");
            dt.Columns.Add("FavSubject");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Section");
            dt.Columns.Add("Institute");
            dt.Columns.Add(new DataColumn("Salary", typeof(int)));

            dt.Columns.Add("AnnualIncreament");
            dt.Columns.Add("BPS");
            dt.Columns.Add("AppointedAs");
            dt.Columns.Add("TrialExperience");
            dt.Columns.Add("Contract");
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
           

        
            dt.Columns.Add("A_Qualification");
            dt.Columns.Add("A_PassingYear");
            dt.Columns.Add("A_RegistrationNo");
            dt.Columns.Add("A_Devision");
            dt.Columns.Add("A_Institution");



         

           string qua = ((Label)gvAcademicQualification.Rows[0].Cells[0].FindControl("lblQualification")).Text;
           string passyear = ((Label)gvAcademicQualification.Rows[0].Cells[1].FindControl("lblYearOfPassing")).Text;
           string A_Reg = ((Label)gvAcademicQualification.Rows[0].Cells[2].FindControl("lblRegistrationNo")).Text;
           string dev = ((Label)gvAcademicQualification.Rows[0].Cells[3].FindControl("lblDevision")).Text;
           string institute = ((Label)gvAcademicQualification.Rows[0].Cells[4].FindControl("lblInstitution")).Text;

         

            
            dt.Columns.Add("P_Qualification");
            dt.Columns.Add("PassingYear");
            dt.Columns.Add("RegistrationNo");
            dt.Columns.Add("Devision");
            dt.Columns.Add("Institution");

            string qual = ((Label)gvProfessionalQualification.Rows[0].Cells[0].FindControl("lblQualification")).Text;
            string passingyear = ((Label)gvProfessionalQualification.Rows[0].Cells[1].FindControl("lblYearOfPassing")).Text;
            string P_Reg = ((Label)gvProfessionalQualification.Rows[0].Cells[2].FindControl("lblRegistrationNo")).Text;

            string devison = ((Label)gvProfessionalQualification.Rows[0].Cells[3].FindControl("lblDevision")).Text;
            string inst = ((Label)gvProfessionalQualification.Rows[0].Cells[4].FindControl("lblInstitution")).Text;


            dt.Rows.Add(txtName.Text, txtFather.Text, txtBirth.Text, txtCnic.Text, txtPhoneNo.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, txtQualification.Text, ddlBloodGroup.SelectedItem.Text, ddlGender.SelectedItem.Text, txtHireDate.Text, txtExperience.Text, txtFavSbj.Text, txtDesignation.Text, txtSection.Text, txtclg.Text, txtSalary.Text, txtAnnualInc.Text, txtBps.Text, ddlAppointedAs.SelectedItem.Text, ddlTrialPer.Text, txtContract.Text, txtDate.Text, qua, passyear, A_Reg, dev, institute, qual, passingyear, P_Reg, devison, inst);

       

            Session["ZAddStaff"] = dt;

            Response.Redirect("~/Report-Staff-Info.aspx");
           

        }

        protected void btnEmptyPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("FatherName");
            dt.Columns.Add(new DataColumn("DOB", typeof(DateTime)));


            dt.Columns.Add("CNIC");
            dt.Columns.Add("PhoneNo");
            dt.Columns.Add("MobileNo");
            dt.Columns.Add("Email");
            dt.Columns.Add("Address");


            dt.Columns.Add("Qualification");
            dt.Columns.Add("BloodGroup");
            dt.Columns.Add("Gender");
            dt.Columns.Add("HiringDate");
            dt.Columns.Add("Experience");
            dt.Columns.Add("FavSubject");
            dt.Columns.Add("Designation");
            dt.Columns.Add("Section");
            dt.Columns.Add("Institute");
            dt.Columns.Add(new DataColumn("Salary", typeof(int)));

            dt.Columns.Add("AnnualIncreament");
            dt.Columns.Add("BPS");
            dt.Columns.Add("AppointedAs");
            dt.Columns.Add("TrialExperience");
            dt.Columns.Add("Contract");
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));



            dt.Columns.Add("A_Qualification");
            dt.Columns.Add("A_PassingYear");
            dt.Columns.Add("A_RegistrationNo");
            dt.Columns.Add("A_Devision");
            dt.Columns.Add("A_Institution");





            string qua = "";
            string passyear = "";
            string A_Reg = "";
            string dev = "";
            string institute = "";




            dt.Columns.Add("P_Qualification");
            dt.Columns.Add("PassingYear");
            dt.Columns.Add("RegistrationNo");
            dt.Columns.Add("Devision");
            dt.Columns.Add("Institution");

            string qual = "";
            string passingyear = "";
            string P_Reg = "";
            string devison = "";
            string inst = "";


            dt.Rows.Add(txtName.Text, txtFather.Text, "08/02/2015 6:04 PM", txtCnic.Text, txtPhoneNo.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, txtQualification.Text, ddlBloodGroup.SelectedItem.Text, ddlGender.SelectedItem.Text, txtHireDate.Text, txtExperience.Text, txtFavSbj.Text, txtDesignation.Text, txtSection.Text, txtclg.Text, 0, txtAnnualInc.Text, txtBps.Text, ddlAppointedAs.SelectedItem.Text, ddlTrialPer.Text, txtContract.Text, "08/02/2015 6:04 PM", qua, passyear, A_Reg, dev, institute, qual, passingyear, P_Reg, devison, inst);



            Session["ZAddStaff"] = dt;

            Response.Redirect("~/Report-Staff-Info.aspx");
        }
 
    }
}