﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zeeshan
{
    public partial class Report_Staff_Experience_Letter : System.Web.UI.Page
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
                DataTable dt = (DataTable)Session["StaffExperienceLetter"];

                DataSet1 ds = new DataSet1();
                ds.Tables["StaffExperienceLetter"].Merge(dt);
                ds.AcceptChanges();

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports.rdlc/Report-Staff-Experience-Letter.rdlc");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables["StaffExperienceLetter"]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);




            }
        }
    }
}