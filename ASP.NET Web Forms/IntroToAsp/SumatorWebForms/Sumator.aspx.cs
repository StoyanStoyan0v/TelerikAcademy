using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SumatorWebForms
{
    public partial class Sumator : System.Web.UI.Page
    {
        public void btn_Click(object sender, EventArgs e)
        {
            try
            {
                var firstNum = float.Parse(TextBox1.Text);
                var secondNum = float.Parse(TextBox2.Text);
                TextBox3.Text = (firstNum + secondNum).ToString();
            }
            catch (Exception ex)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                Context.Response.Write(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}