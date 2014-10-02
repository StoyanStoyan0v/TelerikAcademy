namespace StudentsSystem.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    using StudentsSystem.Models;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Number = s.Number,
                    Courses = s.Courses.Select(c => c.CourseName),
                    Homeworks = s.Homeworks.Select(h => h.Content)
                };
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Number { get; set; }

        public IEnumerable<string> Courses { get; set; }

        public IEnumerable<string> Homeworks { get; set; }
    }
}