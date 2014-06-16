namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private readonly List<Course> courses;

        public int CoursesCount
        {
            get
            {
                return this.courses.Count;
            }
        }

        public School()
        {
            this.courses = new List<Course>();
        }

        public void AddCourse(Course course)
        {
            if (this.courses.Contains(course))
            {
                throw new ArgumentException("The course is already contained in the school!");
            }
            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("The course cannot be removed from school! It does not exist!");
            }
            this.courses.Remove(course);
        }
    }
}