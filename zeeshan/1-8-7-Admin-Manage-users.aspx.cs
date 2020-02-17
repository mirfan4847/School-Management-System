using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using zeeshan;
using zeeshan.Models;

namespace Future
{
    public partial class _1_8_7_Admin_Manage_users : System.Web.UI.Page
    {

        public void ShowRoles()
        {

            var context = new ApplicationDbContext();

            {

               


                ddlDelete.DataSource = context.Roles.ToList();
                ddlDelete.DataTextField = "Name";
                ddlDelete.DataValueField = "Name";
                ddlDelete.DataBind();

                ddlDelete.Items.Insert(0, new ListItem("-Select Role", String.Empty));
                ddlDelete.SelectedIndex = 0;



            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    ShowRoles();
                }


                
            }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            RoleManager createrole = new RoleManager();

            if (!createrole.RoleExists(txtName.Text))
            {
                string msg = "Roll of " + txtName.Text + " has been Added";
                ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "myModal", "showError('"+msg+"')", true);

                createrole.Create(new ApplicationRole { Name = txtName.Text });
                txtName.Text = "";
            }
            else
            {
               
               string msg = "Roll of " + txtName.Text + " Already Exists";
               // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecordNotFound", "$('#RecordNotFound').modal();", true);

               ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "RecordNotFound", "showError1('" + msg + "')", true);

                txtName.Text = "";
                

                

                
            }
            ShowRoles();
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
               String msg= "Roll of " + ddlDelete.SelectedValue + " has been Deleted";

                ScriptManager.RegisterStartupScript((sender as Control), Page.GetType(), "myModal", "showError('" + msg + "')", true);


                var selecteditem = ddlDelete.SelectedItem.ToString();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
                var role = roleManager.FindByName(selecteditem);
                roleManager.Delete(role);
                ShowRoles();
                
            }

        }
    }
}