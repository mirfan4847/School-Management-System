using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
namespace Future
{
    public partial class _2_8_Web_Contact_us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                MailMessage Msg = new MailMessage();

                Msg.From = new MailAddress(txtEmail.Text);
                Msg.To.Add("zeeshanchogtai@gmail.com");

                Msg.Subject = "User Message";
                Msg.IsBodyHtml = false;
                Msg.Body = " User  " + txtName.Text + " Said That  " + txtComments.InnerText;




                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("zeeshanchogtai@gmail.com", "Chaireman@me");
                smtp.EnableSsl = true;
                smtp.Send(Msg);

                txtComments.InnerText = "";
                txtEmail.Text = "";
                txtName.Text = "";

                lblStudentIdNotFound.Text = "Email Has been Send";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
            }
            catch (Exception)
            {
                lblStudentIdNotFound.Text = "Something Goes Wrong";

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);
                
                throw;
            }
            
           
        }
    }
}