﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataCleaningSite
{
    public partial class GoogleSuggestAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string time = ""; 
            if (Session["GoogleSession"] != null)
            {
                time = Session["GoogleSession"].ToString();
            }
            Session["GoogleSession"] = DateTime.Now.ToShortDateString() + DateTime.Now.ToShortTimeString();
        }
    }
}