using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloName
{
    public partial class hello : System.Web.UI.Page
    {
        public void Click(object sender, EventArgs e)
        {
            Label1.Text = "Hello, "+TextBox1.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}