using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using zeeshan.Models;

namespace zeeshan.Account
{
    public partial class AddRole : System.Web.UI.Page
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
            if(!IsPostBack)
        { 
            ShowRoles();
        }
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            RoleManager createrole = new RoleManager();

            if (!createrole.RoleExists(txtEmail.Text))
            {

                createrole.Create(new ApplicationRole { Name = txtEmail.Text });

            }
            ShowRoles();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var selecteditem = ddlDelete.SelectedItem.ToString();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var role = roleManager.FindByName(selecteditem);
            roleManager.Delete(role);
            ShowRoles();

        }
    }
}