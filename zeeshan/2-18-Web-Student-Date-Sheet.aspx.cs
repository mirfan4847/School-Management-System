using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using SchoolManagementSystem.Entities;
using System.Data;
using SchoolManagementSystem.Bll;

namespace zeeshan
{
    public partial class _2_18_Web_Student_Date_Sheet : System.Web.UI.Page
    {
        int term = 1;
        int Class;
        string StudentId;



        Student st = new Student();
        string dateSheetId = string.Empty;
        int rows = 0;
        int[] countUpdate;
        static int num = 0;
        static int j = 0;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            st.termOfClass = 1;
            if (!IsPostBack)
            {
                String Name = Context.User.Identity.GetUserName();
                if (Name == "")
                {
                    Response.Redirect("2-9-Web-login.aspx");
                }
                else if (!User.IsInRole("Student"))
                {
                    Response.Redirect("Authorized.aspx");
                }
                


                  DataTable Cls = new DataTable();
                  Web_Student_bll bll = new Web_Student_bll();

                  String student = Context.User.Identity.GetUserName();


                  string[] Id = student.Split('@');

                  StudentId = Id[0].ToString();

                  Cls = bll.StudentClassesOnload(StudentId);

                  ddlClass.DataSource = Cls;
                  ddlClass.DataValueField = "ClassId";
                  ddlClass.DataTextField = "className";

                  ddlClass.DataBind();







                  st.termOfClass = 1;
                  ViewState["upload"] = string.Empty;
                  if (Request.QueryString["m"] != null)
                  {
                      st.termOfClass = Convert.ToInt32(Request.QueryString["m"]);

                  }
                  lblTerm.Text = st.termOfClass.ToString();
                  dgvDateSheet.ShowHeaderWhenEmpty = true;
            }
           
            







            }



        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex == 0)
            {
                lblStudentIdNotFound.Text = "Select Your Class";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }
            else
            {
                

                if (Request.QueryString["m"] != null)
                {
                    st.termOfClass = Convert.ToInt32(Request.QueryString["m"]);

                }
                lblTerm.Text = st.termOfClass.ToString();
                st.classForDateSheet = ddlClass.SelectedItem.Value;
                //Session["ClassofDateSheet"] = ddlClass.SelectedItem.Text;
                //Session["termofDateSheet"] = st.termOfClass;
                DataTable dt = new DataTable();
                Exam_bll bll = new Exam_bll();
                dt = bll.selectDateSheet(st);
                int l = 0;
                if (dt.Rows.Count >= 1)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dateSheetId = dt.Rows[i]["DateSheetId"].ToString();
                        if (dateSheetId != "")
                        { l = l + 1; }
                    }
                    if (l >= 1)
                    {

                    }

                }
                if (!IsPostBack)
                {
                    rows = dt.Rows.Count;
                }
                if (dt.Rows.Count < 1)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                }
                else
                {
                    dgvDateSheet.DataSource = dt;
                    dgvDateSheet.DataBind();

                }
                ViewState["datesheet"] = dt;
                num = 0;
                j = 0;

            }

        }

        
        }
    }
