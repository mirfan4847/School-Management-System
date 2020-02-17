using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace zeeshan
{
    public partial class My_Admin_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (HttpContext.Current.User.IsInRole("Accountant"))
            {
                accountant.Visible = false;

            }
            else if (HttpContext.Current.User.IsInRole("Admin"))
            {
                accountant.Visible = true;

            }
              else if(!IsPostBack)
            {

            }
          //  HttpContext.Current.User.Identity.Name.ToString();


           
        }

        protected void btnlogout_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();

        }


        public void Account()
        {

        }

        protected void lnkbtnAdmisForm_Click(object sender, EventArgs e)
        {
            string fileName = "Admission_Form.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string fullPath = Server.MapPath("~/Pdf_Forms/" + fileName);
            Response.TransmitFile(fullPath);
            Response.End();
            Response.Redirect("1-1-Admin_Home.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string fileName = "Admission_Form.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string fullPath = Server.MapPath("~/Pdf_Forms/" + fileName);
            Response.TransmitFile(fullPath);
            Response.End();
            Response.Redirect("1-1-Admin_Home.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string fileName = "Admission_Form.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string fullPath = Server.MapPath("~/Pdf_Forms/" + fileName);
            Response.TransmitFile(fullPath);
            Response.End();
            Response.Redirect("1-1-Admin_Home.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string fileName = "Admission_Form.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string fullPath = Server.MapPath("~/Pdf_Forms/" + fileName);
            Response.TransmitFile(fullPath);
            Response.End();
            Response.Redirect("1-1-Admin_Home.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            string fileName = "Admission_Form.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string fullPath = Server.MapPath("~/Pdf_Forms/" + fileName);
            Response.TransmitFile(fullPath);
            Response.End();
            Response.Redirect("1-1-Admin_Home.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            string fileName = "Admission_Form.pdf";
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            string fullPath = Server.MapPath("~/Pdf_Forms/" + fileName);
            Response.TransmitFile(fullPath);
            Response.End();
            Response.Redirect("1-1-Admin_Home.aspx");
        }
    }
}