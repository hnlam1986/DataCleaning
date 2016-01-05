using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataCleaningSite.Controls
{
    public partial class SubMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigurationUrl != null)
            {
                lnkConfig.NavigateUrl = ConfigurationUrl;
            }
            else
            {
                lnkConfig.CssClass = "sub-menu-inactive";
            }
            if (UserManagementUrl != null)
            {
                lnkUsermanagement.NavigateUrl = UserManagementUrl;
            }
            else
            {
                lnkUsermanagement.CssClass = "sub-menu-inactive";
            }
        }
        public string ConfigurationUrl { get; set; }
        public string UserManagementUrl { get; set; }

    }
}