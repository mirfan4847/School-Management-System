

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using zeeshan.Models;


namespace zeeshan
{
    public partial class _1_8_8_Admin_Register_users : System.Web.UI.Page
    {
        public void BindUsers()
        {
            String constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            String query = "select Email from AspNetUsers order by Email ASC";

            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dap = new SqlDataAdapter(query, con);
            SqlCommandBuilder com = new SqlCommandBuilder(dap);
            DataTable dt = new DataTable();
            dap.Fill(dt);

            ddlDelete.DataSource = null;
            ddlDelete.DataSource = dt;
            ddlDelete.DataTextField = "Email";
            ddlDelete.DataValueField = "Email";
            ddlDelete.DataBind();

            ddlDelete.Items.Insert(0, new ListItem("-Select Role ", String.Empty));
            ddlDelete.SelectedIndex = 0;



        }

        public void ClearFields()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirm.Text = "";
            ddlRoles.SelectedIndex = 0;
            ddlDelete.SelectedIndex = 0;

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ClearFields();

                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("NotAuthenticated.aspx");
                }
                else if (!User.IsInRole("Admin"))
                {
                    Response.Redirect("Authorized.aspx");
                }
                else if (User.IsInRole("Admin"))
                {
                    var context = new ApplicationDbContext();
                    ddlRoles.DataSource = context.Roles.ToList();
                    ddlRoles.DataTextField = "Name";
                    ddlRoles.DataValueField = "Name";
                    ddlRoles.DataBind();

                    ddlRoles.Items.Insert(0, new ListItem("Select Role", String.Empty));
                    ddlRoles.SelectedIndex = 0;

                    BindUsers();

                }
            }
        }







        protected void btnRegister_Click(object sender, EventArgs e)
        {

            if (ddlRoles.SelectedIndex == 0)
            {
                string msg = "Select Role";
                ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "RecordNotFound", "showError1('" + msg + "')", true);

            }

            else
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = new ApplicationUser() { UserName = txtEmail.Text, Email = txtEmail.Text };
                IdentityResult result = manager.Create(user, txtPassword.Text);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");


                    manager.AddToRole(user.Id, ddlRoles.SelectedValue);
                    BindUsers();
                    //IdentityHelper.SignIn(manager, user, isPersistent: false);
                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    string msg = ' ' + txtEmail.Text + " has been Registered Successfully";
                    ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "myModal", "showError('" + msg + "')", true);
                   ClearFields();

                }
                else
                {
                    string msg = result.Errors.FirstOrDefault();

                    ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "RecordNotFound", "showError1('" + msg + "')", true);
                    ClearFields();

                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (ddlDelete.SelectedIndex == 0)
            {
                string msg = "Select Role";
                ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "RecordNotFound", "showError1('" + msg + "')", true);

            }
            else
            {
                String constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                String query = "delete from AspNetUsers where Email='" + ddlDelete.SelectedItem.Text + "'    ";

                SqlConnection con = new SqlConnection(constring);
                SqlCommand com = new SqlCommand(query, con);


                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                String msg = ddlDelete.SelectedValue.ToString();
                ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "myModal", "showError(' '+'" + msg + "'+' has been deleted successfully')", true);

                BindUsers();
            }



        }


    }
}