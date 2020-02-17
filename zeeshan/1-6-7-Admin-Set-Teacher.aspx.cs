using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace zeeshan
{
    public partial class SetTeacher : System.Web.UI.Page
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

                    if (!IsPostBack)
                    {



                        SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");

                        String query = "select classId,ClassName,teacherId,StaffId,Name,'0' AS ISUPDATE from  Class Left JOIN AddStaff ON Class.teacherId=AddStaff.StaffId";

                        SqlCommand comm = new SqlCommand(query, conn);
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(comm);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgv.DataSource = dt;
                        dgv.DataBind();

                        ViewState["State"] = dt;
                    }

                }






            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];

            dt.TableName = "MYTABLE";

            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);

            String xml = sw.ToString();


            SqlConnection conn = new SqlConnection("Data Source=.;  DataBase=School;  Integrated Security=true;");

            SqlCommand comm = new SqlCommand("UpdateSetTeacher", conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@P1", xml));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        protected void dgv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];

            String Name = ((DropDownList)dgv.Rows[e.RowIndex].FindControl("ddlEditTeacherName")).SelectedItem.Text;
          

            String Staffid = ((DropDownList)dgv.Rows[e.RowIndex].FindControl("ddlEditTeacherName")).SelectedValue;


            

           
            dt.Rows[e.RowIndex]["Name"] = ((DropDownList)dgv.Rows[e.RowIndex].FindControl("ddlEditTeacherName")).SelectedItem.Text;

             dt.Rows[e.RowIndex]["teacherId"] = Staffid;
          
            dt.Rows[e.RowIndex]["ISUPDATE"] = "1";

            dgv.EditIndex = -1;

            dgv.DataSource = dt;
            dgv.DataBind();
            ViewState["State"] = dt;


        }

        protected void dgv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            DataTable dt = (DataTable)ViewState["State"];
            dgv.EditIndex = -1;

            dgv.DataSource = dt;
            dgv.DataBind();
            ViewState["State"] = dt;

        }

        protected void dgv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];
            dgv.EditIndex = e.NewEditIndex;
            dgv.DataSource = dt;
            dgv.DataBind();



            SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
            string que = "select Distinct Name,StaffId from AddStaff";
            SqlCommand com = new SqlCommand(que, conn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable nm = new DataTable();
            da.Fill(nm);
            ((DropDownList)dgv.Rows[e.NewEditIndex].FindControl("ddlEditTeacherName")).DataSource = nm;
            ((DropDownList)dgv.Rows[e.NewEditIndex].FindControl("ddlEditTeacherName")).DataTextField = "Name";
            ((DropDownList)dgv.Rows[e.NewEditIndex].FindControl("ddlEditTeacherName")).DataValueField = "StaffId";
            ((DropDownList)dgv.Rows[e.NewEditIndex].FindControl("ddlEditTeacherName")).DataBind();

            String Name = dt.Rows[e.NewEditIndex]["StaffId"].ToString();

            int i = ((DropDownList)dgv.Rows[e.NewEditIndex].FindControl("ddlEditTeacherName")).Items.IndexOf(((DropDownList)dgv.Rows[e.NewEditIndex].FindControl("ddlEditTeacherName")).Items.FindByValue(Name));


            ((DropDownList)dgv.Rows[e.NewEditIndex].FindControl("ddlEditTeacherName")).SelectedIndex = i;


            ViewState["State"] = dt;

        }

       

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["RSetTeacher"] = ViewState["State"];
            Response.Redirect("Report-SetTeacher.aspx");
        }

        protected void dgv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          //  DataTable dt = (DataTable)ViewState["sname"];

            SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
            string que = "select Distinct Name ,StaffId from AddStaff";
         
            SqlCommand com = new SqlCommand(que, conn);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable nm = new DataTable();
            da.Fill(nm);



            String rowstate = e.Row.RowState.ToString();
            rowstate = rowstate.Trim();
            if ((rowstate == "Edit") || (rowstate == "Alternate,Edit"))
            {


                ((DropDownList)e.Row.FindControl("ddlEditTeacherName")).DataSource = nm;
                ((DropDownList)e.Row.FindControl("ddlEditTeacherName")).DataTextField = "Name";
                ((DropDownList)e.Row.FindControl("ddlEditTeacherName")).DataValueField = "StaffId";
                ((DropDownList)e.Row.FindControl("ddlEditTeacherName")).DataBind();
            }


        }
    }
}