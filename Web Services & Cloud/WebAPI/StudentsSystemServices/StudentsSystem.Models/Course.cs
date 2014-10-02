namespace StudentsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        public Course()
        {
            this.Id = Guid.NewGuid();
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
            this.Materials = new HashSet<string>();
        }
        public Guid Id { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public ICollection<string> Materials { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}