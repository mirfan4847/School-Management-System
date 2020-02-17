using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace zeeshan
{
    public partial class My_Master_Page : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String Name = Context.User.Identity.GetUserName();
                if (Name == "")
                {
                    student.Visible = false;
                    teacher.Visible = false;
                }

                else if (HttpContext.Current.User.IsInRole("Accountant") || HttpContext.Current.User.IsInRole("Admin"))
                {
                    student.Visible = false;
                    teacher.Visible = false;

                }
                else if (HttpContext.Current.User.IsInRole("Student"))
                {
                    student.Visible = true;
                    teacher.Visible = false;


                }
                else if( HttpContext.Current.User.IsInRole("Teacher"))
                {
                    student.Visible = false;
                    teacher.Visible = true;
                }
                

            }
        }

        protected void btnLogout_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();

        }


        protected void lnkbtnAdmisForm_Click(object sender, EventArgs e)
        {
            string fileName = "Admission_Form.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string fullPath = Server.MapPath("~/Pdf_Forms/" + fileName);
            Response.TransmitFile(fullPath);
            Response.End();
            Response.Redirect("2-1-Web-Home.aspx");
        }
    }
}