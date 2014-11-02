using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace State_Management
{
    public partial class BrowserTypeAndId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var browserType = Request.Browser.Type;
            var ip = Request.UserHostName;
            Response.Write(browserType);
            Response.Write("<br/>");
            Response.Write(ip);
        }
    }
}