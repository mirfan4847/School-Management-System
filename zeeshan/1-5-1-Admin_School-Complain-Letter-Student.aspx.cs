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
    public partial class ComplainLetter : System.Web.UI.Page
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

                ddlClass.DataSource = Class;
                ddlClass.DataValueField = "classId";
                ddlClass.DataTextField = "className";

                ddlClass.DataBind();
            }
        }
        public void ClearField()
        {
            txtAdminId.Text = "";
            txtName.Text = "";
            txtFather.Text = "";
            ddlClass.SelectedIndex = 0;
            txtBirth.Text = "";

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

                txtAdminId.Text = rules.Rows[0]["AdmissionId"].ToString();
                txtName.Text = rules.Rows[0]["Name"].ToString();
                txtFather.Text = rules.Rows[0]["Father"].ToString();
                String Class = rules.Rows[0]["className"].ToString();

                ddlClass.SelectedIndex = ddlClass.Items.IndexOf
                      (ddlClass.Items.FindByText(Class));
                txtBirth.Text = rules.Rows[0]["DOB"].ToString();


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
            dt.Columns.Add("AdmissionID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Father");
            dt.Columns.Add("Class");
            dt.Columns.Add("DOB");
            dt.Columns.Add("one");
            dt.Columns.Add("two");
            dt.Columns.Add("three");
            dt.Columns.Add("four");
            dt.Columns.Add("five");
            dt.Columns.Add("six");
            dt.Columns.Add("seven");
            dt.Columns.Add("other");

                  String one;
                  String two;
                  String three;
                  String four;
                  String five;
                  String six;
                  String seven;

             if (CheckBox1.Checked)
            {
                one = "True";

            }
            else
            {
               one = "False";
            }

             if (CheckBox2.Checked)
            {
                two = "True";

            }
            else
            {
               two = "False";
            }
 if (CheckBox3.Checked)
            {
                three = "True";

            }
            else
            {
              three  = "False";
            }
 if (CheckBox4.Checked)
            {
                four = "True";

            }
            else
            {
                four= "False";
            }
 if (CheckBox5.Checked)
            {
              five   = "True";

            }
            else
            {
                five= "False";
            }
 if (CheckBox6.Checked)
            {
              six   = "True";

            }
            else
            {
                six= "False";
            }
 if (CheckBox7.Checked)
            {
              seven   = "True";

            }
            else
            {
               seven = "False";
            }



            dt.Rows.Add(txtAdminId.Text,txtName.Text,txtFather.Text,ddlClass.SelectedItem.Text,txtBirth.Text,one,two,three,four,five,six,seven,txtComplains.Text);

            Session["Complain-Letter"]=dt;
            Response.Redirect("~/Report-Student-Complain-Letter.aspx");

        }
    }
}