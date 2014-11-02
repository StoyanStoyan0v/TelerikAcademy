using System;
using System.Linq;
using System.Reflection;
using System.Web.UI;

namespace HelloAsp
{
    public partial class hello : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AnotherHelloAspLabel.Text = "Hello, ASP.NET (from code-behind)";
            this.Location.Text = Assembly.GetExecutingAssembly().Location;
        }
    }
}