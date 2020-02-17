using SchoolManagementSystem.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Future
{
    public partial class View_Result : System.Web.UI.Page
    {
        int term = 1;
        String Class;
        String Section;
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
            else if (!IsPostBack)
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




                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();
                dgvEnterMarks.ShowHeaderWhenEmpty = true;


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
                while (p < 15)
                {
                    dgvEnterMarks.Columns[p].Visible = false;
                    p++;

                }

            }
            else
            {

                Class = ddlClass.SelectedIndex.ToString();
                Section = ddlSection.SelectedIndex.ToString();
                Session["classForViewResult"] = ddlClass.SelectedItem.Text;
                Session["sectionForViewResult"] = ddlSection.SelectedItem.Text;
                


                Exam_bll bll = new Exam_bll();

                if (Request.QueryString["m"] != null)
                {
                    term = Convert.ToInt32(Request.QueryString["m"]);


                }
                lblTerm.Text = term.ToString();
                Session["termForViewResult"] = term;
                DataTable Collection = new DataTable();

                Collection = bll.ViewMarks(Class, Section, term);
                ViewState["gvData"] = Collection;

                if (Collection.Rows.Count != 0)
                {
                    int p = 0;
                    while (p < 15)
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
                    while (p < 15)
                    {
                        dgvEnterMarks.Columns[p].Visible = false;
                        p++;

                    }
                }
                ViewState["gvData"] = Collection;

            }
        }

       
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["RViewResult"] = ViewState["gvData"];
            Response.Redirect("Report-ViewResult.aspx");
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
            maindt = bll.ViewMarks(cls, section, trm);



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
            // dgvEnterMarks.Columns[2].HeaderText = maindt.Columns["S0"].DefaultValue.ToString();





        }
        
    }
}