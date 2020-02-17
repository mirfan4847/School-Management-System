using SchoolManagementSystem.Bll;
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
    public partial class ClassTimeTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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




        protected void dgvClass_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];

            String Lec1 = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod1")).Text;




            dt.Rows[e.RowIndex]["Lec1"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod1")).Text;


            dt.Rows[e.RowIndex]["Lec2"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod2")).Text;
            dt.Rows[e.RowIndex]["Lec3"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod3")).Text;
            dt.Rows[e.RowIndex]["Lec4"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod4")).Text;
            dt.Rows[e.RowIndex]["Lec5"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod5")).Text;
            dt.Rows[e.RowIndex]["Lec6"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod6")).Text;
            dt.Rows[e.RowIndex]["Lec7"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod7")).Text;
            dt.Rows[e.RowIndex]["Lec8"] = ((TextBox)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod8")).Text;

            //dt.Rows[e.RowIndex]["Lec2"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod2")).SelectedItem.Text;
            //dt.Rows[e.RowIndex]["Lec3"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod3")).SelectedItem.Text;
            //dt.Rows[e.RowIndex]["Lec4"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod4")).SelectedItem.Text;
            //dt.Rows[e.RowIndex]["Lec5"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod5")).SelectedItem.Text;
            //dt.Rows[e.RowIndex]["Lec6"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod6")).SelectedItem.Text;
            //dt.Rows[e.RowIndex]["Lec7"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod7")).SelectedItem.Text;
            //dt.Rows[e.RowIndex]["Lec8"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod8")).SelectedItem.Text;




            dt.Rows[e.RowIndex]["ISUPDATE"] = "1";

            dgvClass.EditIndex = -1;

            dgvClass.DataSource = dt;
            dgvClass.DataBind();
            ViewState["State"] = dt;



        }

        protected void dgvClass_RowEditing(object sender, GridViewEditEventArgs e)
        {


            DataTable dt = (DataTable)ViewState["State"];
            dgvClass.EditIndex = e.NewEditIndex;
            dgvClass.DataSource = dt;
            dgvClass.DataBind();

            //SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
            //string que = "select Distinct Name,ClassId from Subject where ClassId='" + ddlClass.SelectedItem.Value + "' ";

            //SqlCommand com = new SqlCommand(que, conn);
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable nm = new DataTable();
            //da.Fill(nm);






            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod1")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod1")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod1")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod1")).DataBind();



            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).DataBind();



            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod3")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod3")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod3")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod3")).DataBind();




            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod4")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod4")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod4")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod4")).DataBind();




            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod5")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod5")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod5")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod5")).DataBind();



            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod6")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod6")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod6")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod6")).DataBind();



            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod7")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod7")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod7")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod7")).DataBind();



            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod8")).DataSource = nm;
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod8")).DataTextField = "Name";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod8")).DataValueField = "ClassId";
            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod8")).DataBind();


            //String Name1 = dt.Rows[e.NewEditIndex]["Lec1"].ToString();



            //int i1 = ((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod1")).Items.IndexOf(((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod1")).Items.FindByText(Name1));


            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod1")).SelectedIndex = i1;



            //String Name2 = dt.Rows[e.NewEditIndex]["Lec2"].ToString();

            //int  i2= ((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).Items.IndexOf(((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).Items.FindByText(Name2));


            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).SelectedIndex = i2;






            //int ii = ((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).Items.IndexOf(((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).Items.FindByValue(Name));


            //((DropDownList)dgvClass.Rows[e.NewEditIndex].FindControl("ddlEditPeriod2")).SelectedIndex = ii;






            ViewState["State"] = dt;



        }

        protected void dgvClass_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];
            dgvClass.EditIndex = -1;

            dgvClass.DataSource = dt;
            dgvClass.DataBind();
            ViewState["State"] = dt;

        }




        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (ddlClass.SelectedIndex.Equals(0))
            {
                ddlSection.SelectedIndex = 0;

                lblStudentIdNotFound.Text = "Select your Class";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

                


            }
            else
            {

                String Class = ddlClass.SelectedIndex.ToString();
                String Section = ddlSection.SelectedIndex.ToString();
                DataTable TimeTable = new DataTable();
                Admission_bll bll = new Admission_bll();
                TimeTable = bll.ClassTimeTable(Class, Section);

                if(TimeTable.Rows.Count!=0)
                {
                    dgvClass.DataSource = null;

                    dgvClass.DataSource = TimeTable;
                    dgvClass.DataBind();

                    ViewState["State"] = TimeTable;
                }

                else
                {
                    lblStudentIdNotFound.Text = "Record Not Found";

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

                }





            }
        }

        protected void Print_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];

            dt.TableName = "MYTABLE";

            StringWriter sw = new StringWriter();
            dt.WriteXml(sw);

            String xml = sw.ToString();


            SqlConnection conn = new SqlConnection("Data Source=.;  DataBase=School;  Integrated Security=true;");

            SqlCommand comm = new SqlCommand("UpdateClassTimeTable", conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@P1", xml));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            lblStudentIdNotFound.Text = "Record Has Been Saved";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

        }



        protected void dgvClass_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            //String rowstate = e.Row.RowState.ToString();
            //rowstate = rowstate.Trim();
            //if ((rowstate == "Edit") || (rowstate == "Alternate,Edit"))
            //{


            //    SqlConnection conn = new SqlConnection("Data Source=.;Database=School;integrated Security=true;");
            //    string que = "select Distinct Name,ClassId from Subject where ClassId='" + ddlClass.SelectedItem.Value + "' ";

            //    SqlCommand com = new SqlCommand(que, conn);
            //    SqlDataAdapter da = new SqlDataAdapter(com);
            //    DataTable nm = new DataTable();
            //    da.Fill(nm);




            //    ((DropDownList)e.Row.FindControl("ddlEditPeriod1")).DataSource = nm;
            //    ((DropDownList)e.Row.FindControl("ddlEditPeriod1")).DataTextField = "Name";
            //    ((DropDownList)e.Row.FindControl("ddlEditPeriod1")).DataValueField = "ClassId";
            //    ((DropDownList)e.Row.FindControl("ddlEditPeriod1")).DataBind();



            //((DropDownList)e.Row.FindControl("ddlEditPeriod2")).DataSource = nm;
            //((DropDownList)e.Row.FindControl("ddlEditPeriod2")).DataTextField = "Name";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod2")).DataValueField = "ClassId";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod2")).DataBind();



            //((DropDownList)e.Row.FindControl("ddlEditPeriod3")).DataSource = nm;
            //((DropDownList)e.Row.FindControl("ddlEditPeriod3")).DataTextField = "Name";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod3")).DataValueField = "ClassId";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod3")).DataBind();




            //((DropDownList)e.Row.FindControl("ddlEditPeriod4")).DataSource = nm;
            //((DropDownList)e.Row.FindControl("ddlEditPeriod4")).DataTextField = "Name";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod4")).DataValueField = "ClassId";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod4")).DataBind();




            //((DropDownList)e.Row.FindControl("ddlEditPeriod5")).DataSource = nm;
            //((DropDownList)e.Row.FindControl("ddlEditPeriod5")).DataTextField = "Name";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod5")).DataValueField = "ClassId";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod5")).DataBind();



            //((DropDownList)e.Row.FindControl("ddlEditPeriod6")).DataSource = nm;
            //((DropDownList)e.Row.FindControl("ddlEditPeriod6")).DataTextField = "Name";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod6")).DataValueField = "ClassId";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod6")).DataBind();



            //((DropDownList)e.Row.FindControl("ddlEditPeriod7")).DataSource = nm;
            //((DropDownList)e.Row.FindControl("ddlEditPeriod7")).DataTextField = "Name";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod7")).DataValueField = "ClassId";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod7")).DataBind();



            //((DropDownList)e.Row.FindControl("ddlEditPeriod8")).DataSource = nm;
            //((DropDownList)e.Row.FindControl("ddlEditPeriod8")).DataTextField = "Name";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod8")).DataValueField = "ClassId";
            //((DropDownList)e.Row.FindControl("ddlEditPeriod8")).DataBind();


        }





    }






}
