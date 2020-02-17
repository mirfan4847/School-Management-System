using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Future
{
    public partial class Staff_Time_Table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("Time");
                dt.Columns.Add("Period1");
                dt.Columns.Add("Period2");
                dt.Columns.Add("Period3");
                dt.Columns.Add("Period4");
                dt.Columns.Add("Period5");
                dt.Columns.Add("Period6");
                dt.Columns.Add("Period7");
                dt.Columns.Add("Period8");

                dt.Rows.Add("Time", "8.30", "9.05", "9.40", "10.15", "10.50", "12.00", "12.35", "1.10");
                dt.Rows.Add("Monday", "English", "Urdu", "Math", "Islamiyat", "Chemistry", "Physics", "Bio", "Pak-Study");
                dt.Rows.Add("Tuesday", "English", "Urdu", "Math", "Islamiyat", "Chemistry", "Physics", "Bio", "Pak-Study");
                dt.Rows.Add("Wednesday", "English", "Urdu", "Math", "Islamiyat", "Chemistry", "Physics", "Bio", "Pak-Study");
                dt.Rows.Add("Thursday", "English", "Urdu", "Math", "Islamiyat", "Chemistry", "Physics", "Bio", "Pak-Study");
                dt.Rows.Add("Friday", "English", "Urdu", "Math", "Islamiyat", "Chemistry", "Physics", "Bio", "Pak-Study");
                dt.Rows.Add("Saturday", "English", "Urdu", "Math", "Islamiyat", "Chemistry", "Physics", "Bio", "Pak-Study");



                dgvTeacher.DataSource = null;
                dgvTeacher.DataSource = dt;
                dgvTeacher.DataBind();

                DataTable subject = new DataTable();

                subject.Columns.Add("Sr");
                subject.Columns.Add("Instructor");
                subject.Columns.Add("Class");

                subject.Rows.Add("1","Qamar", "English");
                subject.Rows.Add("2", "Qamar", "English");
                subject.Rows.Add("3", "Qamar", "English");
                subject.Rows.Add("4", "Qamar", "English");
                subject.Rows.Add("5", "Qamar", "English");
                subject.Rows.Add("6", "Qamar", "English");
                subject.Rows.Add("7", "Qamar", "English");
                subject.Rows.Add("8", "Qamar", "English");
               

                dgv.DataSource = null;
                dgv.DataSource = subject;
                dgv.DataBind();

            }

        }

        protected void dgvTeacher_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvTeacher_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvTeacher_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void dgvTeacher_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void Print_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}