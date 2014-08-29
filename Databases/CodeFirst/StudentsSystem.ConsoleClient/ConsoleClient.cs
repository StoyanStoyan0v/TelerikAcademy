namespace StudentsSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentsSystem.Data;
    using StudentsSystem.Models;

    internal class ConsoleClient
    {
        private static void Main(string[] args)
        {
            var context = new StudentsSystemData();
            context.Courses.Add(new Course()
            {
                CourseName = "JavaScript",
                Description = "Me no like"
            });
            context.SaveChanges();
            Console.WriteLine("Item added!");

            context.Homeworks.Add(new Homework()
            {
                Content = "The best homeworkever",
                TimeSent = DateTime.Now,
                CourseId = context.Courses.All().First(x => x.CourseName == "JavaScript").Id,
                StudentId = context.Students.All().First().Id
            });
            context.SaveChanges();
            Console.WriteLine("Item added!");

            var student = context.Students.All().First();
            var course = context.Courses.All().First(x => x.CourseName == "JavaScript");
            student.Courses.Add(course);
            context.SaveChanges();
            Console.WriteLine("Course added to student!");
        }
    }
}