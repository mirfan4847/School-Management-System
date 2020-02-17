using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class Report_Staff_Info : System.Web.UI.Page
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

            else if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["ZAddStaff"];

                DataSet1 ds = new DataSet1();
                ds.Tables["AddStaff"].Merge(dt);
                ds.AcceptChanges();

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports.rdlc/Report-Staff-Info.rdlc");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables["AddStaff"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);




            }
        }
    }
}