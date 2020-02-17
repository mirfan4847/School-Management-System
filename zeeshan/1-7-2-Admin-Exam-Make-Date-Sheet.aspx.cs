using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using SchoolManagementSystem.Entities;
using System.IO;
using System.Data.SqlClient;


namespace Future
{
    public partial class Make_Date_Sheet : System.Web.UI.Page
    {

        Student st = new Student();
        string dateSheetId = string.Empty;
        int rows = 0;
        int[] countUpdate;
        static int num = 0;
        static int j = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            st.termOfClass = 1;
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


                DataTable DateSheet = new DataTable();
                Exam_bll bll = new Exam_bll();
                DateSheet = bll.setDateSheet(st);

                ddlClass.DataSource = DateSheet;
                ddlClass.DataTextField = "className";
                ddlClass.DataValueField = "classId";
                ddlClass.DataBind();
            }
            st.termOfClass = 1;
            ViewState["upload"] = string.Empty;
            if (Request.QueryString["m"] != null)
            {
                st.termOfClass = Convert.ToInt32(Request.QueryString["m"]);

            }
            lblTerm.Text = st.termOfClass.ToString();
            dgvDateSheet.ShowHeaderWhenEmpty = true;


            btnSave.Enabled = false;


        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex == 0)
            {
                Print.Visible = false;
                lblStudentIdNotFound.Text = "Select Your Class";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }
            else
            {
                Print.Visible = true;

                if (Request.QueryString["m"] != null)
                {
                    st.termOfClass = Convert.ToInt32(Request.QueryString["m"]);

                }
                lblTerm.Text = st.termOfClass.ToString();
                st.classForDateSheet = ddlClass.SelectedItem.Value;
                Session["ClassofDateSheet"] = ddlClass.SelectedItem.Text;
                Session["termofDateSheet"] = st.termOfClass;
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
                        btnSave.Enabled = true;
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
        protected void Edit_Row(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["datesheet"];
            dgvDateSheet.EditIndex = e.NewEditIndex;

            dgvDateSheet.DataSource = dt;
            dgvDateSheet.DataBind();
            ViewState["datesheet"] = dt;
            string examDate = dt.Rows[e.NewEditIndex]["Date"].ToString();

            string startTime = dt.Rows[e.NewEditIndex]["Start_Time"].ToString();
            string endTime = dt.Rows[e.NewEditIndex]["End_Time"].ToString();

            ((TextBox)dgvDateSheet.Rows[e.NewEditIndex].FindControl("txtEditDate")).Text = examDate;

            ((TextBox)dgvDateSheet.Rows[e.NewEditIndex].FindControl("txtEditStartTime")).Text = startTime;
            ((TextBox)dgvDateSheet.Rows[e.NewEditIndex].FindControl("txtEditEndTime")).Text = endTime;



        }



        protected void Cancel_Editing(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["datesheet"];
            dgvDateSheet.EditIndex = -1;

            dgvDateSheet.DataSource = dt;
            dgvDateSheet.DataBind();
            ViewState["datesheet"] = dt;
        }

        protected void Update_Row(object sender, GridViewUpdateEventArgs e)
        {

            DataTable dt = (DataTable)ViewState["datesheet"];
            dt.Rows[e.RowIndex]["Date"] = ((TextBox)dgvDateSheet.Rows[e.RowIndex].FindControl("txtEditDate")).Text;

            dt.Rows[e.RowIndex]["Start_Time"] = ((TextBox)dgvDateSheet.Rows[e.RowIndex].FindControl("txtEditStartTime")).Text;
            dt.Rows[e.RowIndex]["End_Time"] = ((TextBox)dgvDateSheet.Rows[e.RowIndex].FindControl("txtEditEndTime")).Text;
            int size = dt.Rows.Count;
            dt.Rows[e.RowIndex]["ISUPDATE"] = 1;
            dgvDateSheet.EditIndex = -1;
            dgvDateSheet.DataSource = dt;
            dgvDateSheet.DataBind();


            countUpdate = new int[size];
            countUpdate[num] = e.RowIndex;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == num)
                {

                    j = j + 1;
                }
            }
            if (j == dt.Rows.Count)
            {
                btnSave.Enabled = true;
            }
            num = num + 1;



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {


            DataTable dt = (DataTable)ViewState["datesheet"];
            DataTable dtDelete = (DataTable)ViewState["datesheet"];
            rows = dt.Rows.Count;
            int l = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dateSheetId = dt.Rows[i]["DateSheetId"].ToString();
                if (dateSheetId != "")
                { l = l + 1; }
            }
            if (l < 1)
            {
                SqlConnection con = new SqlConnection("Data Source=(local);Database=School;Integrated Security=true;");
                for (int i = 0; i < rows; i++)
                {
                    string date = dt.Rows[i]["Date"].ToString();
                    string startTime = dt.Rows[i]["Start_Time"].ToString();
                    string endTime = dt.Rows[i]["End_Time"].ToString();
                    int isUpdate = Convert.ToInt32(dt.Rows[i]["ISUPDATE"].ToString());
                    if (date != "" && startTime != "" && endTime != "" && isUpdate == 1)
                    {
                        string query = "insert into DateSheet(Date,Subjectid,Start_Time,End_Time,Classid,Term) Values('" + dt.Rows[i]["Date"] + "','" + dt.Rows[i]["id"] + "','" + dt.Rows[i]["Start_Time"] + "','" + dt.Rows[i]["End_Time"] + "','" + dt.Rows[i]["ClassId1"] + "','" + dt.Rows[i]["Terms"] + "')";
                        SqlCommand comm = new SqlCommand(query, con);
                        con.Open();
                        comm.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Response.Redirect("1-7-2-Admin-Exam-Make-Date-Sheet.aspx");
            }
            else
            {

                dt.TableName = "MYTABLE";


                StringWriter sw = new StringWriter();
                dt.WriteXml(sw);
                string xml = sw.ToString();


                Student st = new Student();
                st.xmlRecord = xml;


                Exam_bll bll = new Exam_bll();
                bll.insertDateSheet(st);
                Response.Redirect("1-7-2-Admin-Exam-Make-Date-Sheet.aspx");
            }
        }

        protected void Print_Click(object sender, EventArgs e)
        {
            Session["RDateSheet"] = ViewState["datesheet"];
            Response.Redirect("Report-MakeDateSheet.aspx");
        }


    }
}