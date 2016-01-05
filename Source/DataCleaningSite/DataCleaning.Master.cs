using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataCleaningSite
{
    public partial class DataCleaning : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login login = (Login)Session[DataCleaningConstant.LoginInfoSession];
            if (login == null)
            {
                Response.Redirect("/Default.aspx");
            }
            else
            {
                string buildNavi = "";
                buildNavi += login.UserRole.HasVerifyRole ? "<a href=\"/verify.aspx\">" +
                        "<div id=\"btnVerify\" class=\"left-button navi-button\">verify</div>" +
                        "</a>" : "";
                buildNavi += login.UserRole.HasQCRole ? "<a href=\"/qc.aspx\">"+
                        "<div id=\"btnQc\" class=\"middle-button navi-button\">qc</div>"+
                    "</a>" : "";
                buildNavi += login.UserRole.HasApproveRole ? "<a href=\"/approve.aspx\">"+
                        "<div id=\"btnApprove\" class=\"middle-button navi-button\">approve</div>"+
                    "</a>" : "";
                buildNavi += login.UserRole.HasSettingRole ? "<a href=\"/usermanagement.aspx\">"+
                        "<div id=\"btnSetting\" class=\"right-button navi-button\">setting</div>"+
                    "</a>" : "";
                innerNavi.InnerHtml = buildNavi;
            }
        }
    }
}