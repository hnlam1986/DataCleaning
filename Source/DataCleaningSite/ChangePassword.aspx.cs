using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBHelper.Entities;
using DBHelper.ExecutionDataObject;

namespace DataCleaningSite
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            lblResMessage.Text = "";
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            UserHelper hepler = new UserHelper();
            User loginUser = new User();
            loginUser = login.UserLogin;
            loginUser.password = Utilities.EncryptMD5(txtRetype.Text);
            int res = hepler.UpdateUserInfo(loginUser);
            if (res > 0)
            {
                lblResMessage.Text = "Change password is successful";
                lblResMessage.CssClass = "success-message";
                txtPassword.Text = "";
                txtRetype.Text = "";
                Response.Redirect("/Home.aspx");
            }
            else
            {
                lblResMessage.Text = "Change password is unsuccessful";
                lblResMessage.CssClass = "error-message";
            }
        }
    }
}