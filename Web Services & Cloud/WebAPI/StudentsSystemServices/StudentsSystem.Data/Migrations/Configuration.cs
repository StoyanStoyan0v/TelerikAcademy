namespace StudentsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentsSystem.Data;
    using StudentsSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentsSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentsSystem.Data.StudentsSystemDbContext";
        }

        protected override void Seed(StudentsSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
            this.SeedHomeworks(context);
        }

        private void SeedHomeworks(StudentsSystemDbContext context)
        {
            if (context.Homeworks.Any())
            {
                return;
            }

            context.Homeworks.Add(new Homework
            {
                Content = "Sample Homework3",
                TimeSent = DateTime.Now
            });
        }

        private void SeedStudents(StudentsSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Number = "123123123"
            });

            context.Students.Add(new Student
            {
                FirstName = "George",
                LastName = "Stamatov",
                Number = "126723123"
            });

            context.Students.Add(new Student
            {
                FirstName = "Kebapcho",
                LastName = "Nadenichkov",
                Number = "126723123"
            });

            context.Students.Add(new Student
            {
                FirstName = "Nikolay",
                LastName = "Kostov",
                Number = "1245123123"
            });
        }

        private void SeedCourses(StudentsSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {               
                CourseName = "Seeded course",
                Description = "Initial course for testing",
            });
        }
    }
}