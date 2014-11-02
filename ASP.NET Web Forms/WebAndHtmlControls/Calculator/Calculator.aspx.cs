using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : Page
    {
        private static string input = "";

        private static int firstOpperand = -1;

        private static int secondOpperand = -1;

        private static string operation = "";

        public void ChangeInput(object sender, EventArgs e)
        { 
            input = this.Input.Text;
        }

        public void Click_One(object sender, EventArgs e)
        {
            var currentInput = HttpUtility.HtmlEncode((sender as Button).Text.ToString());

            int number;
            if (int.TryParse(currentInput, out number))
            {
                input += currentInput;
                this.Input.Text = input;
            }
            else
            {
                this.Calculate(currentInput);
            }
        }

        public void Calculate()
        {
            int secondOpperand = int.Parse(this.Input.Text);
            if (firstOpperand != -1 && secondOpperand != -1)
            {
                switch (operation)
                {
                    case "+":
                        this.Input.Text = (firstOpperand + secondOpperand).ToString();
                        break;
                    case "-":
                        this.Input.Text = (firstOpperand - secondOpperand).ToString();
                        break;
                    case "*":
                        this.Input.Text = (firstOpperand * secondOpperand).ToString();
                        break;
                    case "/":
                        if (secondOpperand != 0)
                        {
                            this.Input.Text = (firstOpperand / secondOpperand).ToString();
                        }
                        else
                        {
                            this.Input.Text = "Division by 0 not allowed!";
                        }
                        break;
                    default:
                        break;
                }
                input = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void Calculate(string op)
        {
            int number;
            if (int.TryParse(this.Input.Text, out number))
            {
                switch (op)
                {
                    case "+":
                        operation = "+";
                        firstOpperand = number;
                        break;
                    case "-":
                        operation = "-";
                        firstOpperand = number;
                        break;
                    case "*":
                        operation = "*";
                        firstOpperand = number;
                        break;
                    case "/":
                        operation = "/";
                        firstOpperand = number;
                        input = "";
                        break;
                    case "Clear":
                        this.Input.Text = "";
                        break;
                    case "√":
                        this.Input.Text = Math.Sqrt((double)number).ToString();
                        break;
                    case "=":
                        this.Calculate();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.Input.Text = "Invalid number entered!";
            }
            input = "";
        }
    }
}