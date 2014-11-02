using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace HtmlEscaping
{
    public partial class Escaper : Page
    {
        public void Btn_Click(object sender, EventArgs e)
        {
            string text = HttpUtility.HtmlEncode(this.TextToShow.Text);

            this.ShowLabel.Text = text;
            this.ShowText.Text = text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}