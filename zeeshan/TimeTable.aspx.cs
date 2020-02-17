using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Bll;
using System.Data.SqlClient;
namespace zeeshan
{
    public partial class TimeTable : System.Web.UI.Page
    {
        DataTable dtView = new DataTable();

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
            // dgvClass.EditIndex = e.RowIndex;
            DataTable dt = (DataTable)ViewState["State"];

            dtView = (DataTable)ViewState["dtview"];


            string day = "Days = Monday";
            if (e.RowIndex == 1)
            {
                day = "Days = Monday";
            }
            if (e.RowIndex == 2)
            {
                day = "Days = Tuesday";
            }
            if (e.RowIndex == 3)
            {

            }
            if (e.RowIndex == 4)
            {

            }
            if (e.RowIndex == 5)
            {

            }
            if (e.RowIndex == 6)
            {

            }

            DataRow[] dtRow = dt.Select(day);
            for (int i = 0; i < 8; i++)
            {
                string subjcId = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod" + i)).SelectedValue;
                dtRow[i]["subjectId"] = subjcId;
                string query = "select * from Subject where subjectId='" + subjcId + "'";

                SqlConnection con = new SqlConnection("Data Source=.; DataBase=School;Integrated Security=true;");
                DataTable dtnew = new DataTable();

                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();

                SqlDataAdapter dap = new SqlDataAdapter(com);

                dap.Fill(dtnew);
                dtView.Rows[i]["Lec" + i] = dtnew.Rows[0]["Name"];
            }
            //dt.Rows[e.RowIndex]["Fees"] = ((DropDownList)dgvClass.Rows[e.RowIndex].FindControl("ddlEditPeriod1")).SelectedValue;

            dt.Rows[e.RowIndex]["ISUPDATE"] = "1";

            dgvClass.EditIndex = -1;

            dgvClass.DataSource = dtView;
            dgvClass.DataBind();
            ViewState["State"] = dt;
        }

        protected void dgvClass_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvClass.EditIndex = e.NewEditIndex;
        }

        protected void dgvClass_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvClass.EditIndex = -1;
        }

        protected void dgvClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex.Equals(0))
            {
                ddlSection.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);



            }



            else
            {

                String Class = ddlClass.SelectedIndex.ToString();
                String Section = ddlSection.SelectedIndex.ToString();


                dtView.Columns.Add("Days");
                dtView.Columns.Add("Lec1");
                dtView.Columns.Add("Lec2");
                dtView.Columns.Add("Lec3");
                dtView.Columns.Add("Lec4");
                dtView.Columns.Add("Lec5");
                dtView.Columns.Add("Lec6");
                dtView.Columns.Add("Lec7");
                dtView.Columns.Add("Lec8");



                SqlConnection con = new SqlConnection("Data Source=.; DataBase=School;Integrated Security=true;");
                DataTable dt = new DataTable();

                String query = "select * from LectureTiming";
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();

                SqlDataAdapter dap = new SqlDataAdapter(com);

                dap.Fill(dt);

                DataRow dtRow = dtView.NewRow();
                dtView.Rows.Add(dtRow);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        dtView.Rows[0]["Lec1"] = dt.Rows[i]["Time"];
                    }
                    if (i == 1)
                    {
                        dtView.Rows[0]["Lec2"] = dt.Rows[i]["Time"];
                    }
                    if (i == 2)
                    {
                        dtView.Rows[0]["Lec3"] = dt.Rows[i]["Time"];
                    }
                    if (i == 3)
                    {
                        dtView.Rows[0]["Lec4"] = dt.Rows[i]["Time"];

                    }
                    if (i == 4)
                    {
                        dtView.Rows[0]["Lec5"] = dt.Rows[i]["Time"];

                    }
                    if (i == 5)
                    {
                        dtView.Rows[0]["Lec6"] = dt.Rows[i]["Time"];

                    }
                    if (i == 6)
                    {
                        dtView.Rows[0]["Lec7"] = dt.Rows[i]["Time"];

                    }
                    if (i == 7)
                    {
                        dtView.Rows[0]["Lec8"] = dt.Rows[i]["Time"];

                    }
                }

                String Mainquery = "select '0' AS ISUPDATE,Class.className,Class.classId,Section.sectionName,Section.sectionId,AddStaff.Name,Subject.Name,TimeTable.Days,TimeTable.LecNo from TimeTable INNER JOIN Class ON TimeTable.classId=Class.classId INNER JOIN Section ON TimeTable.sectionId=Section.sectionId INNER JOIN AddStaff ON TimeTable.teacherId=AddStaff.StaffId INNER JOIN Subject ON TimeTable.subjectId=Subject.id  INNER JOIN LectureTiming ON TimeTable.LecNo=LectureTiming.id  where TimeTable.classId='" + Class + "' AND TimeTable.sectionId='" + Section + "'   ";

                SqlCommand Maincom = new SqlCommand(Mainquery, con);
                Maincom.ExecuteNonQuery();




                SqlDataAdapter dapmain = new SqlDataAdapter(Maincom);
                DataTable main = new DataTable();
                dapmain.Fill(main);
                ViewState["State"] = main;
                DataRow[] monday = main.Select("Days='Monday'");
                for (int i = 0; i < monday.Count(); i++)
                {
                    DataRow row = dtView.NewRow();
                    dtView.Rows.Add(row);
                    if (i == 0)
                    {
                        dtView.Rows[1]["Days"] = "Monday";
                        dtView.Rows[1]["Lec1"] = monday[i]["Name1"];
                    }
                    if (i == 1)
                    {
                        dtView.Rows[1]["Lec2"] = monday[i]["Name1"];
                    }
                    if (i == 2)
                    {
                        dtView.Rows[1]["Lec3"] = monday[i]["Name1"];
                    }
                    if (i == 3)
                    {
                        dtView.Rows[1]["Lec4"] = monday[i]["Name1"];

                    }
                    if (i == 4)
                    {
                        dtView.Rows[1]["Lec5"] = monday[i]["Name1"];

                    }
                    if (i == 5)
                    {
                        dtView.Rows[1]["Lec6"] = monday[i]["Name1"];

                    }
                    if (i == 6)
                    {
                        dtView.Rows[1]["Lec7"] = monday[i]["Name1"];

                    }
                    if (i == 7)
                    {
                        dtView.Rows[1]["Lec8"] = monday[i]["Name1"];

                    }
                }


                DataRow[] Tuesday = main.Select("Days='Tuesday'");
                for (int i = 0; i < Tuesday.Count(); i++)
                {
                    DataRow row = dtView.NewRow();
                    dtView.Rows.Add(row);
                    if (i == 0)
                    {
                        dtView.Rows[2]["Days"] = "Tuesday";
                        dtView.Rows[2]["Lec1"] = Tuesday[i]["Name1"];
                    }
                    if (i == 1)
                    {
                        dtView.Rows[2]["Lec2"] = Tuesday[i]["Name1"];
                    }
                    if (i == 2)
                    {
                        dtView.Rows[2]["Lec3"] = Tuesday[i]["Name1"];
                    }
                    if (i == 3)
                    {
                        dtView.Rows[2]["Lec4"] = Tuesday[i]["Name1"];

                    }
                    if (i == 4)
                    {
                        dtView.Rows[2]["Lec5"] = Tuesday[i]["Name1"];

                    }
                    if (i == 5)
                    {
                        dtView.Rows[2]["Lec6"] = Tuesday[i]["Name1"];

                    }
                    if (i == 6)
                    {
                        dtView.Rows[2]["Lec7"] = Tuesday[i]["Name1"];

                    }
                    if (i == 7)
                    {
                        dtView.Rows[2]["Lec8"] = Tuesday[i]["Name1"];

                    }
                }

                DataRow[] Wednesday = main.Select("Days='Wednesday'");
                for (int i = 0; i < Wednesday.Count(); i++)
                {
                    DataRow row = dtView.NewRow();
                    dtView.Rows.Add(row);
                    if (i == 0)
                    {
                        dtView.Rows[3]["Days"] = "Wednesday";
                        dtView.Rows[3]["Lec1"] = Wednesday[i]["Name1"];
                    }
                    if (i == 1)
                    {
                        dtView.Rows[3]["Lec2"] = Wednesday[i]["Name1"];
                    }
                    if (i == 2)
                    {
                        dtView.Rows[3]["Lec3"] = Wednesday[i]["Name1"];
                    }
                    if (i == 3)
                    {
                        dtView.Rows[3]["Lec4"] = Wednesday[i]["Name1"];

                    }
                    if (i == 4)
                    {
                        dtView.Rows[3]["Lec5"] = Wednesday[i]["Name1"];

                    }
                    if (i == 5)
                    {
                        dtView.Rows[3]["Lec6"] = Wednesday[i]["Name1"];

                    }
                    if (i == 6)
                    {
                        dtView.Rows[3]["Lec7"] = Wednesday[i]["Name1"];

                    }
                    if (i == 7)
                    {
                        dtView.Rows[3]["Lec8"] = Wednesday[i]["Name1"];

                    }
                }





                DataRow[] Thursday = main.Select("Days='Thursday'");
                for (int i = 0; i < Thursday.Count(); i++)
                {
                    DataRow row = dtView.NewRow();
                    dtView.Rows.Add(row);
                    if (i == 0)
                    {
                        dtView.Rows[4]["Days"] = "Thursday";
                        dtView.Rows[4]["Lec1"] = Thursday[i]["Name1"];
                    }
                    if (i == 1)
                    {
                        dtView.Rows[4]["Lec2"] = Thursday[i]["Name1"];
                    }
                    if (i == 2)
                    {
                        dtView.Rows[4]["Lec3"] = Thursday[i]["Name1"];
                    }
                    if (i == 3)
                    {
                        dtView.Rows[4]["Lec4"] = Thursday[i]["Name1"];

                    }
                    if (i == 4)
                    {
                        dtView.Rows[4]["Lec5"] = Thursday[i]["Name1"];

                    }
                    if (i == 5)
                    {
                        dtView.Rows[4]["Lec6"] = Thursday[i]["Name1"];

                    }
                    if (i == 6)
                    {
                        dtView.Rows[4]["Lec7"] = Thursday[i]["Name1"];

                    }
                    if (i == 7)
                    {
                        dtView.Rows[4]["Lec8"] = Thursday[i]["Name1"];

                    }
                }


                DataRow[] Friday = main.Select("Days='Friday'");
                for (int i = 0; i < Friday.Count(); i++)
                {
                    DataRow row = dtView.NewRow();
                    dtView.Rows.Add(row);
                    if (i == 0)
                    {
                        dtView.Rows[5]["Days"] = "Friday";
                        dtView.Rows[5]["Lec1"] = Friday[i]["Name1"];
                    }
                    if (i == 1)
                    {
                        dtView.Rows[5]["Lec2"] = Friday[i]["Name1"];
                    }
                    if (i == 2)
                    {
                        dtView.Rows[5]["Lec3"] = Friday[i]["Name1"];
                    }
                    if (i == 3)
                    {
                        dtView.Rows[5]["Lec4"] = Friday[i]["Name1"];

                    }
                    if (i == 4)
                    {
                        dtView.Rows[5]["Lec5"] = Friday[i]["Name1"];

                    }
                    if (i == 5)
                    {
                        dtView.Rows[5]["Lec6"] = Friday[i]["Name1"];

                    }
                    if (i == 6)
                    {
                        dtView.Rows[5]["Lec7"] = Friday[i]["Name1"];

                    }
                    if (i == 7)
                    {
                        dtView.Rows[5]["Lec8"] = Friday[i]["Name1"];

                    }
                }

                DataRow[] Saturday = main.Select("Days='Saturday'");
                for (int i = 0; i < Saturday.Count(); i++)
                {
                    DataRow row = dtView.NewRow();
                    dtView.Rows.Add(row);
                    if (i == 0)
                    {
                        dtView.Rows[6]["Days"] = "Saturday";
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];
                    }
                    if (i == 1)
                    {
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];

                    }
                    if (i == 2)
                    {
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];

                    }
                    if (i == 3)
                    {
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];


                    }
                    if (i == 4)
                    {
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];


                    }
                    if (i == 5)
                    {
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];


                    }
                    if (i == 6)
                    {
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];


                    }
                    if (i == 7)
                    {
                        dtView.Rows[6]["Lec" + Saturday[i]["LecNo"]] = Saturday[i]["Name1"];

                    }
                }

                ViewState["dtview"] = dtView;


                dgvClass.DataSource = null;
                dgvClass.DataSource = dtView;
                dgvClass.DataBind();


                dgv.DataSource = null;
                dgv.DataSource = main;
                dgv.DataBind();







            }




        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void Print_Click(object sender, EventArgs e)
        {

        }

    }
}