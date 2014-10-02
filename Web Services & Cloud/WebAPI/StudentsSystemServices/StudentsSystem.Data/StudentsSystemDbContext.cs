namespace StudentsSystem.Data
{
    using System.Data.Entity;
    using StudentsSystem.Data.Migrations;
    using StudentsSystem.Models;

    public class StudentsSystemDbContext : DbContext, IStudentSystemDbContext
    {
        public StudentsSystemDbContext() : base("StudentsSystem")
            
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsSystemDbContext, Configuration>());
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
        
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}