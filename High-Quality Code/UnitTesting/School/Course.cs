namespace School
{
    using System;
    using System.Collections.Generic;
    
    public class Course 
    {
        private const byte MAX_STUDENTS_IN_COURSE = 29;

        private string name;

        private readonly IList<Student> students;

        public int StudentsCount
        {
            get
            {
                return this.students.Count;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name cannit be null or empty!","name");
                }
                this.name = value;
            }
        }

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>(MAX_STUDENTS_IN_COURSE);
        }

        public void AddStudent(Student student)
        {
            if (this.students.Contains(student))
            {
                throw new ArgumentException("Inappropriate addition! The course has already such student!");
            }
            if (this.students.Count == 29)
            {
                throw new ArgumentOutOfRangeException("Inappropriate addition! The course has too many students!");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.Contains(student))
            {
                throw new ArgumentException("Inappropriate removal! The course has no such student!");
            }
            this.students.Remove(student);
        }
        
        public override bool Equals(Object obj)
        {
            Course other = obj as Course;

            if (other == null)
            {
                return false;
            }

            for (int i = 0; i < this.students.Count; i++)
            {
                if (!this.students[i].Equals(other.students[i]))
                {
                    return false;
                }
            }

            if (this.students.Count != other.students.Count)
            {
                return false;
            }

            return true;
        }
        
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}