using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace Future
{
    public partial class Add_Staff_Info : System.Web.UI.Page
    {
        int enableAddbutton = 0;
        int enableProAddButton = 0;
        public void emptyFields()
        {
            Image1.ImageUrl = "~/Images/Student_Img.jpg";

            ddlCatogary.SelectedIndex = 0;
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
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("A_Qualification");
                dt.Columns.Add("A_PassingYear");
                dt.Columns.Add("A_RegistrationNo");
                dt.Columns.Add("A_Devision");
                dt.Columns.Add("A_Institution");
                dt.Columns.Add("ISNEW");
                dt.Rows.Add(0, "F.A", "2012", "1234", "A", "PU", 0);

                gvAcademicQualification.DataSource = dt;
                gvAcademicQualification.DataBind();

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Id");
                dt1.Columns.Add("P_Qualification");
                dt1.Columns.Add("PassingYear");
                dt1.Columns.Add("RegistrationNo");
                dt1.Columns.Add("Devision");
                dt1.Columns.Add("Institution");
                dt1.Columns.Add("ISNEW");
                dt1.Rows.Add(0, "B.Ed", "2013", "1212", "A", "UOG", 0);


                gvProfessionalQualification.DataSource = dt1;
                gvProfessionalQualification.DataBind();

                Session["AcademicQualification"] = dt;

                Session["ProfessionalQualification"] = dt1;
                SqlConnection con = new SqlConnection("data source=.;database=School;integrated security=true;");
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select StaffId from AddStaff where StaffId=(Select MAX(StaffId) from AddStaff)", con);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                string curDate;
                if (dt2.Rows.Count < 1)
                {
                    curDate = DateTime.Now.ToString("yy");
                    curDate = curDate + "000";


                }
                else
                {
                    curDate = dt2.Rows[0][0].ToString();
                }
                lblLastCodeNo.Text = curDate;
                int staffid = Convert.ToInt32(curDate);
                staffid = staffid + 1;
                lblCurrentCodeNo.Text = staffid.ToString();
                ViewState["sid"] = staffid;

            }
        }


        protected void lnkbtnAddAccQ_Click1(object sender, EventArgs e)
        {
            if (enableAddbutton == 0)
            {
                DataTable dt = (DataTable)Session["AcademicQualification"];

                string qua = ((DropDownList)gvAcademicQualification.FooterRow.FindControl("ddlFooterQualification")).Text;
                string passyear = ((TextBox)gvAcademicQualification.FooterRow.FindControl("txtFooterYearOfPassing")).Text;
                string regno = lblCurrentCodeNo.Text;
                string dev = ((TextBox)gvAcademicQualification.FooterRow.FindControl("txtFooterDevision")).Text;
                string institute = ((TextBox)gvAcademicQualification.FooterRow.FindControl("txtFooterInstitution")).Text;

                dt.Rows.Add(0, qua, passyear, regno, dev, institute, 1);

                gvAcademicQualification.DataSource = dt;
                gvAcademicQualification.DataBind();

                Session["AcademicQualification"] = dt;
                enableAddbutton = enableAddbutton + 1;
                ((LinkButton)gvAcademicQualification.FooterRow.FindControl("lnkbtnAddAccQ")).Visible = false;
            }
        }


        protected void Edit_AccQ(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)Session["AcademicQualification"];

            gvAcademicQualification.EditIndex = e.NewEditIndex;
            gvAcademicQualification.DataSource = dt;
            gvAcademicQualification.DataBind();

            string qua = dt.Rows[e.NewEditIndex]["A_Qualification"].ToString();
            string passyear = dt.Rows[e.NewEditIndex]["A_PassingYear"].ToString();
            //string regno = dt.Rows[e.NewEditIndex]["A_RegistrationNo"].ToString();
            string dev = dt.Rows[e.NewEditIndex]["A_Devision"].ToString();
            string inst = dt.Rows[e.NewEditIndex]["A_Institution"].ToString();

            ((DropDownList)gvAcademicQualification.Rows[e.NewEditIndex].FindControl("ddlEditQualification")).SelectedItem.Text = qua;
            ((TextBox)gvAcademicQualification.Rows[e.NewEditIndex].FindControl("txtEditYearOfPassing")).Text = passyear;

            ((TextBox)gvAcademicQualification.Rows[e.NewEditIndex].FindControl("txtEditDevision")).Text = dev;
            ((TextBox)gvAcademicQualification.Rows[e.NewEditIndex].FindControl("txtEditInstitution")).Text = inst;


        }

        protected void Delete_AccQ(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["AcademicQualification"];
            DataTable dtDelete = new DataTable();
            dtDelete.Columns.Add("RegistrationNo");
            dtDelete.Rows.Add(dt.Rows[e.RowIndex]["A_RegistrationNo"]).ToString();
            dt.Rows[e.RowIndex].Delete();

            gvAcademicQualification.DataSource = dt;
            gvAcademicQualification.DataBind();

            Session["AcademicQualification"] = dt;
            Session["deleteAcademicQualification"] = dtDelete;


        }

        protected void Update_AccQ(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)Session["AcademicQualification"];

            dt.Rows[e.RowIndex]["A_Qualification"] = ((DropDownList)gvAcademicQualification.Rows[e.RowIndex].FindControl("ddlEditQualification")).SelectedItem.Text;
            dt.Rows[e.RowIndex]["A_PassingYear"] = ((TextBox)gvAcademicQualification.Rows[e.RowIndex].FindControl("txtEditYearOfPassing")).Text;
            //dt.Rows[e.RowIndex]["A_RegistrationNo"] = ((TextBox)gvAcademicQualification.Rows[e.RowIndex].FindControl("txtEditRegistrationNo")).Text;
            dt.Rows[e.RowIndex]["A_Devision"] = ((TextBox)gvAcademicQualification.Rows[e.RowIndex].FindControl("txtEditDevision")).Text;
            dt.Rows[e.RowIndex]["A_Institution"] = ((TextBox)gvAcademicQualification.Rows[e.RowIndex].FindControl("txtEditInstitution")).Text;

            gvAcademicQualification.EditIndex = -1;

            gvAcademicQualification.DataSource = dt;
            gvAcademicQualification.DataBind();

            Session["AcademicQualification"] = dt;
        }

        protected void Cancel_AccQ(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)Session["AcademicQualification"];
            gvAcademicQualification.EditIndex = -1;
            gvAcademicQualification.DataSource = dt;
            gvAcademicQualification.DataBind();

            Session["AcademicQualification"] = dt;

        }

        protected void lnkbtnAddProQ_Click(object sender, EventArgs e)
        {

            if(enableProAddButton==0)
            { 
            DataTable dt = (DataTable)Session["ProfessionalQualification"];

            string qua = ((TextBox)gvProfessionalQualification.FooterRow.FindControl("txtFooterQualification")).Text;
            string passyear = ((TextBox)gvProfessionalQualification.FooterRow.FindControl("txtFooterYearOfPassing")).Text;
            string regno = lblCurrentCodeNo.Text;
            string dev = ((TextBox)gvProfessionalQualification.FooterRow.FindControl("txtFooterDevision")).Text;
            string institute = ((TextBox)gvProfessionalQualification.FooterRow.FindControl("txtFooterInstitution")).Text;

            dt.Rows.Add(0, qua, passyear, regno, dev, institute, 1);

            gvProfessionalQualification.DataSource = dt;
            gvProfessionalQualification.DataBind();

            Session["ProfessionalQualification"] = dt;
            enableProAddButton = enableProAddButton + 1;
            ((LinkButton)gvProfessionalQualification.FooterRow.FindControl("lnkbtnAddProQ")).Visible = false;

            }
        }

        protected void Delete_ProfQ(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["ProfessionalQualification"];

            DataTable dtDelete = new DataTable();
            dtDelete.Columns.Add("RegistrationNo");
            dtDelete.Rows.Add(dt.Rows[e.RowIndex]["RegistrationNo"]).ToString();
            dt.Rows[e.RowIndex].Delete();

            gvProfessionalQualification.DataSource = dt;
            gvProfessionalQualification.DataBind();

            Session["ProfessionalQualification"] = dt;

            Session["DeleteProfessionalQualification"] = dtDelete;

        }

        protected void Edit_ProfQ(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)Session["ProfessionalQualification"];

            gvProfessionalQualification.EditIndex = e.NewEditIndex;
            gvProfessionalQualification.DataSource = dt;
            gvProfessionalQualification.DataBind();

            string qua = dt.Rows[e.NewEditIndex]["P_Qualification"].ToString();
            string passyear = dt.Rows[e.NewEditIndex]["PassingYear"].ToString();
            string inst = dt.Rows[e.NewEditIndex]["Institution"].ToString();
            //string regno = dt.Rows[e.NewEditIndex]["RegistrationNo"].ToString();
            string dev = dt.Rows[e.NewEditIndex]["Devision"].ToString();

            ((TextBox)gvProfessionalQualification.Rows[e.NewEditIndex].FindControl("txtEditQualification")).Text = qua;
            ((TextBox)gvProfessionalQualification.Rows[e.NewEditIndex].FindControl("txtEditYearOfPassing")).Text = passyear;
            ((TextBox)gvProfessionalQualification.Rows[e.NewEditIndex].FindControl("txtEditInstitution")).Text = inst;
            ((TextBox)gvProfessionalQualification.Rows[e.NewEditIndex].FindControl("txtEditDevision")).Text = dev;
        }

        protected void Update_ProfQ(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)Session["ProfessionalQualification"];

            dt.Rows[e.RowIndex]["P_Qualification"] = ((TextBox)gvProfessionalQualification.Rows[e.RowIndex].FindControl("txtEditQualification")).Text;
            dt.Rows[e.RowIndex]["PassingYear"] = ((TextBox)gvProfessionalQualification.Rows[e.RowIndex].FindControl("txtEditYearOfPassing")).Text;
            //dt.Rows[e.RowIndex]["RegistrationNo"] = ((TextBox)gvProfessionalQualification.Rows[e.RowIndex].FindControl("txtEditRegistrationNo")).Text;
            dt.Rows[e.RowIndex]["Devision"] = ((TextBox)gvProfessionalQualification.Rows[e.RowIndex].FindControl("txtEditDevision")).Text;
            dt.Rows[e.RowIndex]["Institution"] = ((TextBox)gvProfessionalQualification.Rows[e.RowIndex].FindControl("txtEditInstitution")).Text;

            gvProfessionalQualification.EditIndex = -1;

            gvProfessionalQualification.DataSource = dt;
            gvProfessionalQualification.DataBind();

            Session["ProfessionalQualification"] = dt;
        }

        protected void Cancel_ProfQ(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)Session["ProfessionalQualification"];
            gvProfessionalQualification.EditIndex = -1;
            gvProfessionalQualification.DataSource = dt;
            gvProfessionalQualification.DataBind();

            Session["ProfessionalQualification"] = dt;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int a = (int)ViewState["sid"];

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("StaffId");
            dt2.Columns.Add("Name");
            dt2.Columns.Add("FatherName");
            dt2.Columns.Add("DOB");
            dt2.Columns.Add("CNIC");
            dt2.Columns.Add("PhoneNo");
            dt2.Columns.Add("MobileNo");
            dt2.Columns.Add("Email");
            dt2.Columns.Add("Address");
            dt2.Columns.Add("Qualification");
            dt2.Columns.Add("BloodGroup");
            dt2.Columns.Add("Gender");
            dt2.Columns.Add("HiringDate");
            dt2.Columns.Add("Experience");
            dt2.Columns.Add("FavSubject");
            dt2.Columns.Add("Designation");
            dt2.Columns.Add("Section");
            dt2.Columns.Add("Institute");
            dt2.Columns.Add("Salary");
            dt2.Columns.Add("AnnualIncreament");
            dt2.Columns.Add("BPS");
            dt2.Columns.Add("AppointedAs");
            dt2.Columns.Add("TrialExperience");
            dt2.Columns.Add("Contract");
            dt2.Columns.Add("Date");
            dt2.Columns.Add("Catogary");
            dt2.Columns.Add("Picture");

            string dbPath="";

            if (fuPicture.HasFile)
            {
                string filePath = Server.MapPath("~/Profile_Pic/");
                string fileName = fuPicture.FileName;

                filePath += fileName;

                fuPicture.SaveAs(filePath);
                dbPath = "~/profile_pic/" + fileName;
            }



            dt2.Rows.Add(a, txtName.Text, txtFather.Text, txtBirth.Text, txtCnic.Text, txtPhoneNo.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, txtQualification.Text, ddlBloodGroup.SelectedItem.Text,
                ddlGender.SelectedItem.Text, txtHireDate.Text, txtExperience.Text, txtFavSbj.Text, txtDesignation.Text, txtSection.Text, txtclg.Text, txtSalary.Text,
                txtAnnualInc.Text, txtBps.Text, ddlAppointedAs.SelectedItem.Text, ddlTrialPer.Text, txtContract.Text, txtDate.Text, ddlCatogary.SelectedItem.Text, dbPath);
            SqlConnection conn = new SqlConnection("data source=.;database=School;integrated security=true;");


            SqlCommand comm;
            conn.Open();


            DataTable dt1 = (DataTable)Session["ProfessionalQualification"];
            dt1.TableName = "ProfQualification";
            StringWriter sw1 = new StringWriter();
            dt1.WriteXml(sw1);
            string sxml = sw1.ToString();

            DataTable dt = (DataTable)Session["AcademicQualification"];
            dt.TableName = "AcQualification";
            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);
            string xml = sw.ToString();

            dt2.TableName = "FieldValues";
            StringWriter sw2 = new StringWriter();
            dt2.WriteXml(sw2);
            string fields = sw2.ToString();

            comm = new SqlCommand("storedPro", conn);
            comm.CommandType = CommandType.StoredProcedure;



            comm.Parameters.Add(new SqlParameter("@P1", sxml));
            comm.Parameters.Add(new SqlParameter("@P2", xml));
            comm.Parameters.Add(new SqlParameter("@P3", fields));

            comm.ExecuteNonQuery();
            conn.Close();
            emptyFields();
            lblAdded.Text = "Record of Teacher has been added";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "addedRecord", "$('#addedRecord').modal();", true);
            Response.Redirect("1-6-1-Admin-Add-Staff-Info.aspx");

        }


    }
}