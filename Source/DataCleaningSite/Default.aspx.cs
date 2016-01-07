using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper.ExecutionDataObject;
using DBHelper.Entities;

namespace DataCleaningSite
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["logout"] != null && Request.QueryString["logout"].ToLower() == true.ToString().ToLower())
                {
                    Session[DataCleaningConstant.LoginInfoSession] = null;
                }
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserHelper userHelper = new UserHelper();
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            password = Utilities.EncryptMD5(password);
            User res = userHelper.DoLogin(username, password);
            if (res != null)
            {
                Login login = new Login();
                login.HasLogin = true;
                login.StartTime = DateTime.Now;
                login.UserLogin = res;
                Role role = new Role(res.role);
                login.UserRole = role;
                Session.Add(DataCleaningConstant.LoginInfoSession, login);
                if (role.HasVerifyRole && !role.HasSettingRole && !role.HasQCRole && !role.HasApproveRole)
                {
                    Response.Redirect("/verify.aspx");
                }
                else if (!role.HasVerifyRole && !role.HasSettingRole && role.HasQCRole && !role.HasApproveRole)
                {
                    Response.Redirect("/qc.aspx");
                }
                else if (!role.HasVerifyRole && !role.HasSettingRole && !role.HasQCRole && role.HasApproveRole)
                {
                    Response.Redirect("/approve.aspx");
                }
                else if (!role.HasVerifyRole && role.HasSettingRole && !role.HasQCRole && !role.HasApproveRole)
                {
                    Response.Redirect("/setting.aspx");
                }
                else
                {
                    Response.Redirect("/home.aspx");
                }
            }
            else
            {
                lblErrorMessage.Text = "Login failed!";
            }

        }
        
    }
}