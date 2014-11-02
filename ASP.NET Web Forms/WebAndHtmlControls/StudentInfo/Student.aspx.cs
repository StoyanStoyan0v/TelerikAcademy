using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentInfo
{
    public partial class Student : System.Web.UI.Page
    {
        public void Submit(object sender, EventArgs e)
        {
            var fullName = this.FirstName.Text + " " + this.LastName.Text;
            var number = this.FacNumber.Text;
            var university = this.University.Text;
            var spec = this.Specialty.Text;
            var courses = this.Courses.Items;
            HtmlContainerControl header = new HtmlGenericControl("h3");
            header.InnerText = "Full Name: " + fullName;
            this.Controls.Add(header);
            HtmlContainerControl paragraph = new HtmlGenericControl("p");
            paragraph.InnerHtml = "<b>Faculty Number: </b>" + number;
            this.Controls.Add(paragraph);
            paragraph = new HtmlGenericControl("p");
            paragraph.InnerHtml = "<b>University: </b>" + university;
            this.Controls.Add(paragraph);
            paragraph = new HtmlGenericControl("p");
            paragraph.InnerHtml = "<b>Specialty: </b>" + spec;
            this.Controls.Add(paragraph);
            var ul = new HtmlGenericControl("ul");
            ul.InnerHtml += "<b>Selected courses: </b>";
            foreach (ListItem course in courses)
            {
                if (course.Selected)
                {
                    ul.InnerHtml += "<li>" + course.Text + "</li>";
                }
            }
            
            this.Controls.Add(ul);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}