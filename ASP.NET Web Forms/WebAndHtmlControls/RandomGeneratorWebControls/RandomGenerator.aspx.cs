using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorWebControls
{
    public partial class RandomGenerator : System.Web.UI.Page
    {
        public void Btn_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int lower = int.Parse(this.Lower.Text);
            int upper = int.Parse(this.Upper.Text);
            if (lower > upper)
            {
                this.Result.Text = "Lower bound cannot be greater than the upper one!";
            }
            else
            {
                this.Result.Text = random.Next(lower, upper).ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}