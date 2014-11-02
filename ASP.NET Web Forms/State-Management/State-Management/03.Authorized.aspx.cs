using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace State_Management
{
    public partial class Authorized : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Write("Hello, " + Request.Cookies["UserName"].Value);
            }
            catch (Exception)
            {
                Response.Redirect("Loging.aspx");
            }
            
        }
    }
}