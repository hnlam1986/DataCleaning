using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataCleaningSite
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            if (login != null)
            {
                lblDisplayname.Text = " " + login.UserLogin.display_name;
                lblStarttime.Text = login.StartTime.ToString("dd/MM/yyyy hh:mm:ss");

            }
        }
    }
}