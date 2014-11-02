using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace State_Management
{
    public partial class Loging : System.Web.UI.Page
    {
        public void LogIn(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("UserName", this.TextBox1.Text);
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            if (!string.IsNullOrEmpty(Request.Cookies["UserName"].ToString()))
            {
                Response.Redirect("Authorized.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}