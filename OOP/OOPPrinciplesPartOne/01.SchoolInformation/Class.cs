namespace SchoolInformation
{
    using System;
    using System.Collections.Generic;

    public class Class : ICommentable
    {
        private string comment;
        private string classId;
        private readonly List<Teacher> teachers;

        public Class(string classId)
        {
            this.ClassId = classId;
            this.teachers = new List<Teacher>();
        }

        public string ClassId
        {
            get
            {
                return this.classId;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The class id cannot be empty!");
                }

                this.classId = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                if (value.Length < 10 || value.Length > 30)
                {
                    throw new ArgumentException("The comment must be between 10 and 30 characters long!");
                }

                this.comment = value;
            }
        }

        public void AddTeacher(params Teacher[] teachers)
        {
            foreach (var teacher in teachers)
            {
                if (this.teachers.Contains(teacher))
                {
                    throw new ArgumentException("This class already has this teacher!");
                }

                this.teachers.Add(teacher);
            }
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (!this.teachers.Contains(teacher))
            {
                throw new ArgumentException("This cass does not have such teacher!");
            }

            this.teachers.Add(teacher);
        }

        public override string ToString()
        {
            return string.Format("Class ID: {0}\n\n{1}{2}", this.ClassId, string.Join(" ", this.Teachers), this.Comment);
        }
    }
}
