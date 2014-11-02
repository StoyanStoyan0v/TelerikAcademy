using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinksMenu
{
    public partial class TestMenuListaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var links = new List<Link>()
            {
                new Link()
                {
                    Title = "Google",
                    Url = "http://www.google.com"
                },
                new Link()
                {
                    Title = "ASP.NET",
                    Url = "http://www.asp.net"
                },
                new Link()
                {
                    Title = "Facebook",
                    Url = "http://www.facebook.com"
                },
                new Link()
                {
                    Title = "Microsoft",
                    Url = "http://www.microsoft.com"
                }

            };
            this.LinksMenuList.DataSource = links;
            this.LinksMenuList.DataBind();
            
        }
    }
}