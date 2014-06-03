using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab) : base(courseName,teacherName,students)
        { 
            this.Lab = lab;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students) : this(courseName,teacherName,students,null)
        {
        }
        
        public LocalCourse(string courseName, string teacherName) : this(courseName, teacherName,null,null)
        {
        }

        public LocalCourse(string name) : this(name, null, null, null)
        {
        }

        public override string ToString()
        {
            return string.Format("{0}; {1} ", base.ToString(), this.Lab != null ? "Lab = " + this.Lab : "");
        }
    }
}