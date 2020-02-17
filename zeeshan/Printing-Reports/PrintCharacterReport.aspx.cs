using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace zeeshan.Printing_Reports
{
    public partial class PrintCharacterReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["Character-Certificate"];

                DataSet1 ds = new DataSet1();
                ds.Tables["Character-Certificate"].Merge(dt);
                ds.AcceptChanges();

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports.rdlc/Student-Character-Certificate.rdlc");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables["Character-Certificate"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                


              
            }
        }
    }
}