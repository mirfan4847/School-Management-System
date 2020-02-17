using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Entities;
using SchoolManagementSystem.Bll;
using System.Data.SqlClient;
using System.IO;

namespace Future
{
    public partial class SetFees : System.Web.UI.Page
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
                    DataTable Show = new DataTable();
                    Fees_bll bll = new Fees_bll();
                    Show = bll.ShowSetFess();
                    if (Show.Rows.Count != 0)
                    {

                        dgv.DataSource = null;
                        dgv.DataSource = Show;
                        dgv.DataBind();
                        ViewState["State"] = Show;
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

            SqlCommand comm = new SqlCommand("spSaveFeeInfo", conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@P1", xml));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        protected void dgv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)ViewState["State"];

            String a = ((TextBox)dgv.Rows[e.RowIndex].FindControl("txtEditFees")).Text;

            if (a == "")
            {
                dt.Rows[e.RowIndex]["Fees"] = 0;
            }
            else
            {
                dt.Rows[e.RowIndex]["Fees"] = ((TextBox)dgv.Rows[e.RowIndex].FindControl("txtEditFees")).Text;
            }
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


            String Fees = dt.Rows[e.NewEditIndex]["Fees"].ToString();

            ((TextBox)dgv.Rows[e.NewEditIndex].FindControl("txtEditFees")).Text = Fees;

            ViewState["State"] = dt;

        }

        protected void dgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["RSetFees"] = ViewState["State"];
            Response.Redirect("Report-SetFees.aspx");
        }
    }
}