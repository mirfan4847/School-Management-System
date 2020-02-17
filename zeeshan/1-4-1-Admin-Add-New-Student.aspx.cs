using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.Data.SqlClient;
using System.IO;
using zeeshan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace Future
{
    public partial class _1_4_Admin_Add_New_Student : System.Web.UI.Page
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
            txtAdminId.Text = "";
            ddlClass.SelectedIndex = 0;
            ddlSection.SelectedIndex = 0;
            //ddlGroup.SelectedIndex = 0;
            ddlMedium.SelectedIndex = 0;
            //txtAdminId.Text = "";
            txtSession.Text = "";
            txtFee.Text = "";
            txtFamilyNo.Text = "";
            txtAdmissionDate.Text = "";
            txtRemarks.Text = "";
            ddlApproved.SelectedIndex = 0;

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            //DataTable stu = new DataTable();
            //stu.Columns.Add("New_Stu_Id");
            //stu.Columns.Add("Name");
            //stu.Columns.Add("Father");
            //stu.Columns.Add("DOB");
            //stu.Columns.Add("Place");
            //stu.Columns.Add("BForm");
            //stu.Columns.Add("Blood");
            //stu.Columns.Add("Gender");
            //stu.Columns.Add("FCnic");
            //stu.Columns.Add("FOccupation");
            //stu.Columns.Add("FIncome");
            //stu.Columns.Add("Religion");
            //stu.Columns.Add("GName");
            //stu.Columns.Add("GCnic");
            //stu.Columns.Add("GEducation");
            //stu.Columns.Add("Email");
            //stu.Columns.Add("Mobile");
            //stu.Columns.Add("HomeTel");
            //stu.Columns.Add("Hostel");
            //stu.Columns.Add("Care");
            //stu.Columns.Add("Address");
            //stu.Columns.Add("PInstitutionName");
            //stu.Rows.Add(0, Name, Father, DOB, Place, BForm, Blood, Gender, FCnic, FOccupation, FIncome, Religion, GName, GCnic, GEducation, Email, Mobile, HomeTel, Hostel, Care, Address);

            //Session["AddStudent"] = stu;

            //GridView1.DataSource = null;
            //GridView1.DataSource = stu;
            //GridView1.DataBind();


            //Form1
            Student addstu = new Student();

            ////For file upload

            //String fileupload = Path.GetFileName(fuPicture.PostedFile.FileName);

            ////TO save file in hard disk or in profile_pics folder


            //string filepic = "profile_pics/" + fileupload;

            //fuPicture.SaveAs(Server.MapPath(filepic));
            string dbPath = string.Empty;

            if (fuPicture.HasFile)
            {
                string filePath = Server.MapPath("~/Profile_Pic/");
                string fileName = fuPicture.FileName;

                filePath += fileName;

                fuPicture.SaveAs(filePath);
                dbPath = "~/Profile_Pic/" + fileName;
            }

            addstu.Image = dbPath;

            addstu.Name = txtName.Text;
            addstu.Father = txtFather.Text;
            addstu.DOB = Convert.ToDateTime(txtBirth.Text);
            addstu.Place = ddlPlaceOfBirth.SelectedItem.Text;
            addstu.BForm = txtBform.Text;
            addstu.Blood = ddlBloodGroup.SelectedItem.Text;
            addstu.Gender = ddlGender.SelectedItem.Text;
            addstu.FCnic = txtCnic.Text;
            addstu.FOccupation = txtOcupation.Text;
            addstu.FIncome = txtIncome.Text;
            addstu.Religion = txtReligion.Text;
            addstu.GName = txtGuardian.Text;
            addstu.GCnic = txtGuardianCnic.Text;
            addstu.GEducation = txtGuardianEducation.Text;
            addstu.Email = txtEmail.Text;
            addstu.Mobile = txtMobile.Text;
            addstu.HomeTel = txtHomeTel.Text;
            addstu.Hostel = ddlHostel.SelectedItem.Text;
            addstu.Care = ddlCare.SelectedItem.Text;
            addstu.Address = txtHome.Text;

            //Form2
            addstu.PInstitutionName = txtInstitute.Text;
            addstu.PAdmissionId = txtInstituteAdmissionNo.Text;
            addstu.PInstitutionAddress = txtAddress.Text;
            addstu.PInstitutionClass = txtClass.Text;


            if (txtCertificate.Text != "")
            {
                addstu.PInstitutionCertificate = txtCertificate.Text;
            }
            else
            {
                addstu.PInstitutionCertificate = "";

            }

            addstu.Curricular = ddlCurricular.SelectedItem.Text;
            addstu.SiblingName1 = txtSiblingName1.Text;
            addstu.SiblingStatus1 = ddlStatus1.SelectedItem.Text;
            addstu.SiblingId1 = txtAdminNo1.Text;
            addstu.SiblingName2 = txtSiblingName2.Text;
            addstu.SiblingStatus2 = ddlStatus2.SelectedItem.Text;
            addstu.SiblingId2 = txtAdminNo2.Text;
            addstu.SiblingName3 = txtSiblingName3.Text;
            addstu.SiblingStatus3 = ddlStatus3.SelectedItem.Text;
            addstu.SiblingId3 = txtAdminNo3.Text;


            //Form3
            addstu.Class = ddlClass.SelectedItem.Value;
            addstu.Section = ddlSection.SelectedItem.Value;
            addstu.Medium = ddlMedium.SelectedItem.Text;
            addstu.AdmissionId = txtAdminId.Text;
            addstu.Session = txtSession.Text;
            addstu.FeeStatus = Convert.ToInt32(txtFee.Text);


            addstu.FamilyNo = txtFamilyNo.Text;
            addstu.AdmissionDate = Convert.ToDateTime(txtAdmissionDate.Text);
            addstu.Remarks = txtRemarks.Text;
            addstu.Approval = ddlApproved.SelectedItem.Text;

            Admission_bll bll = new Admission_bll();

            bll.AddStudent_bll(addstu);

            var manager = Context.GetOwinContext().GetUserManager<zeeshan.ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = txtAdminId.Text + "@zamp.com", Email = txtAdminId.Text + "@zamp.com" };
            IdentityResult result = manager.Create(user, "123456");
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");


                manager.AddToRole(user.Id, "Student");
            }
            else
            {
                lblLastAdmission.Text = "Something goes wrong";
            }



            ClearField();
            Response.Redirect("1-4-1-Admin-Add-New-Student.aspx");

        }


        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlSection.Enabled = true;
            ddlSection.SelectedIndex = 0;
            String className = ddlClass.SelectedItem.Text;

            Admission_bll bll = new Admission_bll();

            DataTable Fees = new DataTable();
            Fees = bll.FeesOnload(className);
            if (Fees.Rows.Count != 0)
            {
                txtFee.Text = Fees.Rows[0]["Fees"].ToString();
            }
            else
            {
                txtFee.Text = "";

            }
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }
            else
            {
                lblTotalStudents.Visible = true;
                lblLastAdmission.Visible = true;
                //ddlAdminId.Enabled = true;
                //    string prefixForClass=string.Empty;
                //int prefixForSection = 0;
                int currentclass = Convert.ToInt32(ddlClass.SelectedItem.Value);
                ViewState["currentclass"] = currentclass;
                //string currentyear=DateTime.Now.ToString("yy");
                //switch (currentclass)
                //{
                //    case 1:
                //        {
                //            prefixForClass = "PG";
                //            break;
                //        }
                //    case 2:
                //        {
                //            prefixForClass = "NR";
                //            break;
                //        }
                //    case 3:
                //        {
                //            prefixForClass = "PR";
                //            break;
                //        }
                //    case 4:
                //        {
                //            prefixForClass = "FR";
                //            break;
                //        }
                //    case 5:
                //        {
                //            prefixForClass = "SC";
                //            break;
                //        }
                //    case 6:
                //        {
                //            prefixForClass = "TR";
                //            break;
                //        }
                //    case 7:
                //        {
                //            prefixForClass = "FR";
                //            break;
                //        }
                //    case 8:
                //        {
                //            prefixForClass = "FF";
                //            break;
                //        }
                //    case 9:
                //        {
                //            prefixForClass = "SX";
                //            break;
                //        }
                //    case 10:
                //        {
                //            prefixForClass = "SV";
                //            break;
                //        }
                //    case 11:
                //        {
                //            prefixForClass = "EG";
                //            break;
                //        }
                //    case 12:
                //        {
                //            prefixForClass = "NN";
                //            break;
                //        }
                //    case 13:
                //        {
                //            prefixForClass = "TN";
                //            break;
                //        }
                //    default:
                //        break;
                //}
                int classSection = Convert.ToInt32(ddlSection.SelectedItem.Value);
                ViewState["classSection"] = classSection;
                //switch (classSection)
                //{
                //    case 1:
                //        {
                //            prefixForSection = 1;
                //            break;

                //        }
                //    case 2:
                //        {
                //            prefixForSection = 2;
                //            break;

                //        }
                //    case 3:
                //        {
                //            prefixForSection = 3;
                //            break;

                //        }
                //    default:
                //        break;

                //}
                SqlConnection con = new SqlConnection("database=School; Data source=(local); Integrated Security=true;");
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("select TOP 1 AdmissionId from AddStudent where Class='" + currentclass + "' and Section='" + classSection + "' order by AdmissionId DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string stRollNo;
                //DataTable adminid = new DataTable();
                //adminid.Columns.Add("AdminId");
                //if (dt.Rows.Count < 1)
                //{


                //    for (int i = 1; i < 51; i++)
                //    {
                //        if (i < 10)
                //        {
                //            adminid.Rows.Add(prefixForClass + currentyear + classSection + "0" + i);
                //        }
                //        else
                //        {
                //            adminid.Rows.Add(prefixForClass + currentyear + classSection + i);
                //        }
                //        lblTotalStudents.Text = "0";
                //        lblLastAdmission.Text = "No AdmissionId";
                //    }
                //    stRollNo = adminid.Rows[0]["AdminId"].ToString();
                //    txtAdminId.Text = stRollNo;

                //}
                //else 
                //{
                string fullnum = string.Empty;
                //    string studentId = dt.Rows[0][0].ToString();
                //    lblLastAdmission.Text = studentId;
                //    char[] array = studentId.ToCharArray();
                //    for (int h = 5; h < 7; h++)
                //    {
                //        fullnum = fullnum + array[h].ToString();
                //    }
                //    int fullnum1 = Convert.ToInt32(fullnum);
                //    int num1 = (int)Char.GetNumericValue(array[5]);
                //    int num2 = (int)Char.GetNumericValue(array[6]);
                //     da = new SqlDataAdapter();
                //    da.SelectCommand = new SqlCommand("select Count(AdmissionId) from AddStudent where Class='" + currentclass + "' and Section='" + classSection + "' and StudyStatus NOT IN ('Left')", con);
                //     dt = new DataTable();
                //    da.Fill(dt);
                //    int totalavailblestud = Convert.ToInt32(dt.Rows[0][0].ToString());
                //    totalavailblestud = 50 - totalavailblestud;
                //    if (num2 < 9)
                //    {
                //        lblTotalStudents.Text = num2.ToString();
                //    }
                //    else 
                //    {
                //        lblTotalStudents.Text = fullnum1.ToString();
                //    }
                //    for (int j = 0; j < totalavailblestud; j++)
                //    {
                //        if (num2 < 9)
                //        {
                //            num2 = num2 + 1;
                //            adminid.Rows.Add(prefixForClass + currentyear + classSection + "0" + num2);
                //        }
                //        else
                //        {
                //            num2 = num2 + 1;
                //            adminid.Rows.Add(prefixForClass + currentyear + classSection + num2);

                //        }
                //    }
                //    stRollNo = adminid.Rows[0]["AdminId"].ToString();
                //    txtAdminId.Text = stRollNo;
                //    DataTable LastRollNo = adminid.Clone();
                //    if (adminid.Rows.Count > 0)
                //    {
                //        LastRollNo.ImportRow(adminid.Rows[dt.Rows.Count-1]);
                //    }
                //    string lastrollno = LastRollNo.Rows[0]["AdminId"].ToString();

                //    if (studentId.Equals(lastrollno))
                //    {

                //        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                //    }

                //}



                //}
                string currentyear = DateTime.Now.ToString("yy");

                DataTable adminId = new DataTable();
                adminId.Columns.Add("AdminId");
                if (ddlClass.SelectedItem.Value == "1" && ddlSection.SelectedItem.Value == "1")
                {
                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1, 51);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0050"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "1" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 51, 101);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0100"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "1" && ddlSection.SelectedItem.Value == "3")
                {
                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 101, 151);

                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0150"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }


                    }

                }
                else if (ddlClass.SelectedItem.Value == "2" && ddlSection.SelectedItem.Value == "1")
                {
                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 151, 201);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0200"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "2" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 201, 251);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0250"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "2" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 251, 301);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0300"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "3" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 301, 351);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0350"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "3" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 351, 401);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0400"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "3" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 401, 451);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0450"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "4" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 451, 501);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0500"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "4" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 501, 551);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0550"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "4" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 551, 601);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0600"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "5" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 601, 651);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0650"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "5" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 651, 701);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0700"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "5" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 701, 751);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0750"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "6" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 751, 801);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0800"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "6" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 801, 851);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0850"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "6" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 851, 901);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0900"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "7" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 901, 951);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "0950"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "7" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 951, 1001);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1000"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "7" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1001, 1051);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1050"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }

                }
                else if (ddlClass.SelectedItem.Value == "8" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1051, 1101);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1100"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "8" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1101, 1151);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1150"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "8" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1151, 1201);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1200"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "9" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1201, 1251);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1250"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "9" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1251, 1301);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1300"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "9" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1301, 1351);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1350"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "10" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1351, 1401);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1400"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "10" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1401, 1451);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1450"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "10" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1451, 1501);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1500"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "11" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1501, 1511);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1550"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "11" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1511, 1601);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1600"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "11" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1601, 1651);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1650"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "12" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1651, 1701);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1700"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "12" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1701, 1751);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1750"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "12" && ddlSection.SelectedItem.Value == "3")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1751, 1801);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1800"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "13" && ddlSection.SelectedItem.Value == "1")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1801, 1851);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1850"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else if (ddlClass.SelectedItem.Value == "13" && ddlSection.SelectedItem.Value == "2")
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1851, 1901);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1900"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }
                else
                {

                    if (dt.Rows.Count < 1)
                    {
                        adminId = SetRollNumber(currentyear, 1901, 1951);
                        stRollNo = adminId.Rows[0]["AdminId"].ToString();
                        txtAdminId.Text = stRollNo;
                        lblTotalStudents.Text = "0";
                        lblLastAdmission.Text = "No Last Id";
                    }
                    else
                    {
                        stRollNo = SetRollNumberNext(dt, ref fullnum, currentyear, adminId);
                        if (stRollNo.Equals(currentyear + "1950"))
                        {

                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                        }
                    }
                }

            }










        }

        private string SetRollNumberNext(DataTable dt, ref string fullnum, string currentyear, DataTable adminId)
        {
            string stRollNo;
            stRollNo = dt.Rows[0][0].ToString();
            lblLastAdmission.Text = stRollNo;
            char[] array = stRollNo.ToCharArray();
            for (int h = 2; h < 6; h++)
            {
                fullnum = fullnum + array[h].ToString();
            }

            int fullnum1 = Convert.ToInt32(fullnum);
            SqlConnection con = new SqlConnection("database=School; Data source=(local); Integrated Security=true;");
            SqlDataAdapter da = new SqlDataAdapter();
            int currentclass = (int)ViewState["currentclass"];
            int classSection = (int)ViewState["classSection"];
            da.SelectCommand = new SqlCommand("select Count(AdmissionId) from AddStudent where Class='" + currentclass + "' and Section='" + classSection + "'", con);
            dt = new DataTable();
            da.Fill(dt);
            lblTotalStudents.Text = dt.Rows[0][0].ToString();
            fullnum1 = fullnum1 + 1;
            //int num1 = (int)Char.GetNumericValue(array[5]);
            //int num2 = (int)Char.GetNumericValue(array[6]);
            if (fullnum1 < 10)
            {
                adminId.Rows.Add(currentyear + "000" + fullnum1);
            }
            else if (fullnum1 > 9 && fullnum1 < 100)
            {
                adminId.Rows.Add(currentyear + "00" + fullnum1);
            }
            else if (fullnum1 > 99 && fullnum1 < 1000)
            {
                adminId.Rows.Add(currentyear + "0" + fullnum1);

            }
            else
            {
                adminId.Rows.Add(currentyear + fullnum1);
            }
            stRollNo = adminId.Rows[0][0].ToString();
            txtAdminId.Text = stRollNo;
            return stRollNo;
        }

        private static DataTable SetRollNumber(string currentyear, int start, int end)
        {
            DataTable adminId = new DataTable();
            adminId.Columns.Add("AdminId");
            for (int i = start; i < end; i++)
            {
                if (i < 10)
                {
                    adminId.Rows.Add(currentyear + "000" + i);
                }
                else if (i > 9 && i < 100)
                {
                    adminId.Rows.Add(currentyear + "00" + i);
                }
                else if (i > 99 && i < 1000)
                {
                    adminId.Rows.Add(currentyear + "0" + i);

                }
                else
                {
                    adminId.Rows.Add(currentyear + i);
                }

            }
            return adminId;
        }
    }
}