using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Future
{
    public partial class NewAdmissionCapacity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("Class");
                dt.Columns.Add("Period1");
                dt.Columns.Add("Period2");
                dt.Columns.Add("Period3");
                dt.Columns.Add("Period4");
                dt.Columns.Add("Period5");
                

                dt.Rows.Add("Time", "8.30", "9.05", "9.40", "10.15", "10.50");
                dt.Rows.Add("Monday", "English", "Urdu", "Math", "Islamiyat", "Chemistry");
                dt.Rows.Add("Tuesday", "English", "Urdu", "Math", "Islamiyat", "Chemistry");
                dt.Rows.Add("Wednesday", "English", "Urdu", "Math", "Islamiyat", "Chemistry");
                dt.Rows.Add("Thursday", "English", "Urdu", "Math", "Islamiyat", "Chemistry");
                dt.Rows.Add("Friday", "English", "Urdu", "Math", "Islamiyat", "Chemistry");
                dt.Rows.Add("Saturday", "English", "Urdu", "Math", "Islamiyat", "Chemistry");



                dgvNewCapacity.DataSource = null;
                dgvNewCapacity.DataSource = dt;
                dgvNewCapacity.DataBind();
            }

        }

        protected void Print_Click(object sender, EventArgs e)
        {

        }

        protected void dgvNewCapacity_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvNewCapacity_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvNewCapacity_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void dgvNewCapacity_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}