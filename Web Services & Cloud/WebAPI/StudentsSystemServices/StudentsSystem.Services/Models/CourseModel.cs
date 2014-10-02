namespace StudentsSystem.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using StudentsSystem.Models;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return c => new CourseModel
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    Students = c.Students.Select(s => s.FirstName + " " + s.LastName),
                    Homeworks = c.Homeworks.Select(h => h.Content)
                };
            }
        }

        public Guid Id { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Students { get; set; }

        public IEnumerable<string> Homeworks { get; set; }
    }
}