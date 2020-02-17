using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Data;
using SchoolManagementSystem.Bll;
using System.Data.SqlClient;
namespace zeeshan
{
    public partial class _2_11_Web_Teacher_Area : System.Web.UI.Page
    {
        int term = 1;
        String Class;
        String Section;
        string TeacherId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String Name = Context.User.Identity.GetUserName();
                if (Name == "")
                {
                    Response.Redirect("2-9-Web-login.aspx");
                }
                else if (!User.IsInRole("Teacher"))
                {
                    Response.Redirect("Authorized.aspx");
                }



                Admission_bll Admin = new Admission_bll();
                DataTable Section = new DataTable();
                Section = Admin.SectionOnload();
                ddlSection.DataSource = Section;
                ddlSection.DataValueField = "sectionId";
                ddlSection.DataTextField = "sectionName";
                ddlSection.DataBind();


                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();



                DataTable Cls = new DataTable();
                Web_Teacher_bll bll = new Web_Teacher_bll();

                String teacher = Context.User.Identity.GetUserName();


                string[] Id = teacher.Split('@');

                TeacherId = Id[0].ToString();

                Cls = bll.TeacherClassesOnload(TeacherId);

                ddlClass.DataSource = Cls;
                ddlClass.DataValueField = "classId";
                ddlClass.DataTextField = "className";

                ddlClass.DataBind();




            }
        }

        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (ddlClass.SelectedIndex.Equals(0))
            {
                ddlSection.SelectedIndex = 0;
                lblStudentIdNotFound.Text = "Select Your Class";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);


                int p = 0;
                while (p < 16)
                {
                    dgvEnterMarks.Columns[p].Visible = false;
                    p++;

                }

            }
            else
            {

                Class = ddlClass.SelectedIndex.ToString();
                Section = ddlSection.SelectedIndex.ToString();


                Exam_bll bll = new Exam_bll();

                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();
                DataTable Collection = new DataTable();

                Collection = bll.EnterMarks(Class, Section, term);
                ViewState["gvData"] = Collection;

                if (Collection.Rows.Count != 0)
                {
                    int p = 0;
                    while (p < 16)
                    {
                        dgvEnterMarks.Columns[p].Visible = true;
                        p++;

                    }
                    dgvEnterMarks.DataSource = null;
                    dgvEnterMarks.DataSource = Collection;
                    dgvEnterMarks.DataBind();




                }
                else
                {
                    ddlClass.SelectedIndex = 0;
                    ddlSection.SelectedIndex = 0;
                    Collection.Clear();
                    dgvEnterMarks.DataSource = null;

                    lblStudentIdNotFound.Text = "No Record to Show";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

                    int p = 0;
                    while (p < 16)
                    {
                        dgvEnterMarks.Columns[p].Visible = false;
                        p++;

                    }
                }

            }

        }

        protected void Update_Row(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["gvData"];



            string Sub1 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject1")).Text;

            if (String.IsNullOrWhiteSpace(Sub1))
            {
                dt.Rows[e.RowIndex]["Sub1"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub1"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject1")).Text;
            }




            string Sub2 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject2")).Text;

            if (String.IsNullOrWhiteSpace(Sub2))
            {
                dt.Rows[e.RowIndex]["Sub2"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub2"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject2")).Text;
            }



            string Sub3 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject3")).Text;

            if (String.IsNullOrWhiteSpace(Sub3))
            {
                dt.Rows[e.RowIndex]["Sub3"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub3"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject3")).Text;
            }



            string Sub4 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject4")).Text;

            if (String.IsNullOrWhiteSpace(Sub4))
            {
                dt.Rows[e.RowIndex]["Sub4"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub4"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject4")).Text;
            }



            string Sub5 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject5")).Text;

            if (String.IsNullOrWhiteSpace(Sub5))
            {
                dt.Rows[e.RowIndex]["Sub5"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub5"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject5")).Text;
            }



            string Sub6 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject6")).Text;

            if (String.IsNullOrWhiteSpace(Sub6))
            {
                dt.Rows[e.RowIndex]["Sub6"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub6"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject6")).Text;
            }



            string Sub7 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject7")).Text;

            if (String.IsNullOrWhiteSpace(Sub7))
            {
                dt.Rows[e.RowIndex]["Sub7"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub7"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject7")).Text;
            }



            string Sub8 = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject8")).Text;

            if (String.IsNullOrWhiteSpace(Sub8))
            {
                dt.Rows[e.RowIndex]["Sub8"] = "0";


            }
            else
            {
                dt.Rows[e.RowIndex]["Sub8"] = ((TextBox)dgvEnterMarks.Rows[e.RowIndex].FindControl("txtEditSubject8")).Text;
            }







            if (String.IsNullOrWhiteSpace(Sub1))
            {
                Sub1 = "0";
            }


            if (String.IsNullOrWhiteSpace(Sub2))
            {
                Sub2 = "0";
            }


            if (String.IsNullOrWhiteSpace(Sub3))
            {
                Sub3 = "0";
            }


            if (String.IsNullOrWhiteSpace(Sub4))
            {
                Sub4 = "0";
            }


            if (String.IsNullOrWhiteSpace(Sub5))
            {
                Sub5 = "0";
            }


            if (String.IsNullOrWhiteSpace(Sub6))
            {
                Sub6 = "0";
            }


            if (String.IsNullOrWhiteSpace(Sub7))
            {
                Sub7 = "0";
            }


            if (String.IsNullOrWhiteSpace(Sub8))
            {
                Sub8 = "0";
            }

            int sum = Convert.ToInt32(Sub1) + Convert.ToInt32(Sub2) + Convert.ToInt32(Sub3) + Convert.ToInt32(Sub4) + Convert.ToInt32(Sub5) + Convert.ToInt32(Sub6) + Convert.ToInt32(Sub7) + Convert.ToInt32(Sub8);


            string res = sum.ToString();


            if (String.IsNullOrWhiteSpace(res))
            {
                dt.Rows[e.RowIndex]["ObtainedMarks"] = "0";
            }
            else
            {
                dt.Rows[e.RowIndex]["ObtainedMarks"] = res;

            }


            String total = ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblTotalMarks")).Text;
            dt.Rows[e.RowIndex]["TotalMarks"] = ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblTotalMarks")).Text;



            float ob = Convert.ToInt32(res);

            float to = Convert.ToInt32(total);

            float Total = (ob / to) * 100;

            ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblPercentage")).Text = Total.ToString();


            dt.Rows[e.RowIndex]["Percentage"] = ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblPercentage")).Text;



            //Muneeb 
            SqlConnection con = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt2 = new DataTable();
            int first = 0;
            int last = 0;

            double per = Math.Ceiling(Total);
            string perc = per.ToString();
            int perc1 = int.Parse(perc);

            string query = "select TOP 1 GradeName,Percentage,Status from SetGrades";
            da.SelectCommand = new SqlCommand(query, con);
            DataTable FirstRecord = new DataTable();
            da.Fill(FirstRecord);
            int firstrecord = int.Parse(FirstRecord.Rows[0]["Percentage"].ToString());

            query = "select TOP 1 GradeName,Percentage,Status from SetGrades order by Percentage asc";

            da.SelectCommand = new SqlCommand(query, con);
            DataTable LastRecord = new DataTable();
            da.Fill(LastRecord);
            int lastRecord = int.Parse(LastRecord.Rows[0]["Percentage"].ToString());



            if (perc1 == firstrecord || perc1 > firstrecord)
            {
                query = "select TOP 1 GradeName,Percentage,Status from SetGrades";

                da.SelectCommand = new SqlCommand(query, con);

                da.Fill(dt2);
            }
            else if (perc1 < lastRecord || perc1 == lastRecord)
            {
                query = "select TOP 1 GradeName,Percentage,Status from SetGrades order by Percentage asc";

                da.SelectCommand = new SqlCommand(query, con);

                da.Fill(dt2);
            }
            else
            {


                if (perc1 % 5 != 0)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        if (perc1 % 5 != 0)
                        {
                            perc1 = perc1 + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    last = perc1 - 1;
                    first = perc1 - 5;

                }
                else
                {
                    first = perc1;
                    last = perc1 + 4;
                }






                query = "select GradeName,Percentage,Status from SetGrades where Percentage Between " + first + " and " + last + " ";

                da.SelectCommand = new SqlCommand(query, con);

                da.Fill(dt2);

            }






            ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblGrade")).Text = dt2.Rows[0]["GradeName"].ToString();

            ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblStatus")).Text = dt2.Rows[0]["Status"].ToString();




            dt.Rows[e.RowIndex]["Grade"] = ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblGrade")).Text;
            dt.Rows[e.RowIndex]["PromotedStatus"] = ((Label)dgvEnterMarks.Rows[e.RowIndex].FindControl("lblStatus")).Text;



            dt.Rows[e.RowIndex]["ISUPDATE"] = "1";
            dgvEnterMarks.EditIndex = -1;

            dgvEnterMarks.DataSource = dt;
            dgvEnterMarks.DataBind();
            ViewState["gvData"] = dt;


        }

        protected void Edit_Row(object sender, GridViewEditEventArgs e)
        {

            //DataTable rowbound = (DataTable)ViewState["RowBound"];

            //int t = Convert.ToInt32(rowbound.Columns["TotalSubject"].DefaultValue.ToString());

            //int q = Convert.ToInt32(rowbound.Columns["TotalSubject"].DefaultValue.ToString());

            //(e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit ;



            ////Code Like Row DataBound


            //int i;
            //for (i = 0; i < q; i++)
            //{
            //    if (e.NewEditIndex.GetType == da.Header)
            //        ((Label)e.Row.FindControl("lblSub" + i) as Label).Text = zee.Columns["S" + i].DefaultValue.ToString();
            //}

            //int j = t;

            //if (j < 8)
            //{
            //    int z = i + 1;
            //    while (z < 10)
            //    {
            //        dgvEnterMarks.Columns[z].Visible = false;
            //        z++;

            //    }
            //    j = 9;
            //}
            ////End Code Like Row DataBound


            DataTable dt = (DataTable)ViewState["gvData"];
            dgvEnterMarks.EditIndex = e.NewEditIndex;

            dgvEnterMarks.DataSource = dt;
            dgvEnterMarks.DataBind();

            String Sub1 = dt.Rows[e.NewEditIndex]["Sub1"].ToString();


            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject1")).Text = Sub1;



            String Sub2 = dt.Rows[e.NewEditIndex]["Sub2"].ToString();

            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject2")).Text = Sub2;



            String Sub3 = dt.Rows[e.NewEditIndex]["Sub3"].ToString();


            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject3")).Text = Sub3;




            String Sub4 = dt.Rows[e.NewEditIndex]["Sub4"].ToString();

            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject4")).Text = Sub4;




            String Sub5 = dt.Rows[e.NewEditIndex]["Sub5"].ToString();
            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject5")).Text = Sub5;
             String Sub6 = dt.Rows[e.NewEditIndex]["Sub6"].ToString();
            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject6")).Text = Sub6;
             String Sub7 = dt.Rows[e.NewEditIndex]["Sub7"].ToString();
            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject7")).Text = Sub7;

             String Sub8 = dt.Rows[e.NewEditIndex]["Sub8"].ToString();

            ((TextBox)dgvEnterMarks.Rows[e.NewEditIndex].FindControl("txtEditSubject8")).Text = Sub8; 
             ViewState["gvData"] = dt;
        }



        protected void Cancel_Editing(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["gvData"];

            dgvEnterMarks.EditIndex = -1;

            dgvEnterMarks.DataSource = dt;
            dgvEnterMarks.DataBind();
            ViewState["gvData"] = dt;


        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["gvData"];

            Exam_bll bll = new Exam_bll();
            bll.UpdateEnterMarks(dt);
        }

       

        protected void dgvEnterMarks_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            String cls = ddlClass.SelectedIndex.ToString();
            String section = ddlSection.SelectedIndex.ToString();
            int trm = 1;

            if (Request.QueryString["m"] != null)
            {
                trm = Convert.ToInt32(Request.QueryString["m"]);


            }

            DataTable maindt = new DataTable();
            Exam_bll bll = new Exam_bll();
            maindt = bll.EnterMarks(cls, section, trm);



            int q = Convert.ToInt32(maindt.Columns["TotalSubject"].DefaultValue.ToString());
            int z = 0;



            for (z = 0; z < q; z++)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                    ((Label)e.Row.FindControl("lblSub" + z) as Label).Text = maindt.Columns["S" + z].DefaultValue.ToString();
            }

            int j = q;

            if (j < 8)
            {
                int p = z + 1;
                while (p < 10)
                {
                    dgvEnterMarks.Columns[p].Visible = false;
                    p++;

                }
                j = 9;

            }





        }



    }
}