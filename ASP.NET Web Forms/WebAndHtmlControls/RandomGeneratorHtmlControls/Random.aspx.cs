using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomGeneratorHtmlControls
{
    public partial class Random : System.Web.UI.Page
    {
        public void Btn_Click(object sender, EventArgs e)
        {
            System.Random random=new System.Random();
            int firstNumber = int.Parse(this.Lower.Value);
            int secondNumber = int.Parse(this.Upper.Value);

            Label label = new Label();

            if (firstNumber > secondNumber)
            {
                label.Text = "Lower bound must not be greater than the upper!";
            }
            else
            {
                label.Text = random.Next(firstNumber, secondNumber).ToString();
            }

            this.Controls.Add(label);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}