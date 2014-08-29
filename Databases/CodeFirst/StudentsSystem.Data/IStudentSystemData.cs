namespace StudentsSystem.Data
{
    using StudentsSystem.Data.Repositories;
    using StudentsSystem.Models;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }
    }
}