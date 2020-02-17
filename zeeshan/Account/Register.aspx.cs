using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using zeeshan.Models;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace zeeshan.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                var context = new ApplicationDbContext();
                ddlRoles.DataSource = context.Roles.ToList();
                ddlRoles.DataTextField = "Name";
                ddlRoles.DataValueField = "Name";
                ddlRoles.DataBind();

                ddlRoles.Items.Insert(0, new ListItem("-Select Role", String.Empty));
                ddlRoles.SelectedIndex = 0;

                BindUsers();
            }



        }


    public void BindUsers()
        {
            String constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            String query = "select Email from AspNetUsers";

            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dap = new SqlDataAdapter(query,con);
            SqlCommandBuilder com = new SqlCommandBuilder(dap);
            DataTable dt = new DataTable();
            dap.Fill(dt);

            ddlDeleteUser.DataSource = null;
            ddlDeleteUser.DataSource = dt;
            ddlDeleteUser.DataTextField = "Email";
            ddlDeleteUser.DataValueField = "Email";
            ddlDeleteUser.DataBind();

            ddlDeleteUser.Items.Insert(0, new ListItem("Select ", String.Empty));
            ddlDeleteUser.SelectedIndex = 0;



        }



        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");


                manager.AddToRole(user.Id,ddlRoles.SelectedValue);
                BindUsers();
                //IdentityHelper.SignIn(manager, user, isPersistent: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

      

       

        protected void delete_Click(object sender, EventArgs e)
        {

            String constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            String query = "delete from AspNetUsers where Email='"+ddlDeleteUser.SelectedValue.ToString()+"'    ";

            SqlConnection con = new SqlConnection(constring);
            SqlCommand com = new SqlCommand(query, con);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            BindUsers();




        }

        

        
    }
}