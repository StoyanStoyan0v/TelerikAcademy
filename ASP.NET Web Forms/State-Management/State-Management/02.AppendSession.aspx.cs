using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace State_Management
{
    public partial class AppendSession : System.Web.UI.Page
    {


        public void Btn_Clicked(object sender, EventArgs e)
        {
            Session.Add(this.TextBox1.Text,0);
            var items = new List<string>();
            foreach (var item in Session.Keys)
            {
                items.Add(item.ToString());
            }
            this.Label1.Text = string.Join("<br/>", items);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}