using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;
using zeeshan.Models;
namespace zeeshan
{
    public partial class _2_9_Web_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                // RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<zeeshan.ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<zeeshan.ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(txtEmail.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                       // zeeshan.IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                        Response.Redirect("2-1-Web-Home.aspx");
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:


                    default:
                        FailureText.Text = "Incorrect Email/Password";
                        ErrorMessage.Visible = true;
                        String msg = "Invalid login attempt";
                        ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "RecordNotFound", "showError1('" + msg + "')", true);
                        //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

                        break;
                }
            }
        }
    }
}