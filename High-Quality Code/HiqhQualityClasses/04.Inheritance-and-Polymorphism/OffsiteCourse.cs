using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town) : base(courseName,teacherName,students)
        { 
            this.Town = town;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students) : this(courseName,teacherName,students,null)
        {
        }
        
        public OffsiteCourse(string courseName, string teacherName) : this(courseName, teacherName,null,null)
        {
        }

        public OffsiteCourse(string name) : this(name, null, null, null)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}; {1} ", base.ToString(), this.Town != null ? "Town = " + this.Town : "");
        }
    }
}