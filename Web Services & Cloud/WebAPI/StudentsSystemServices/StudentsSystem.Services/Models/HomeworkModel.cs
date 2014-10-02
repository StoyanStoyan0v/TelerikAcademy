namespace StudentsSystem.Services.Models
{
    using System;    
    using System.Linq.Expressions;

    using StudentsSystem.Models;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return h => new HomeworkModel
                {
                    Id = h.Id,
                    Content = h.Content,
                    TimeSent = h.TimeSent,
                    CourseId = h.CourseId,
                    StudentId = h.StudentId
                };
            }
        }

        public int Id { get; set; }
        
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public int? StudentId { get; set; }

        public Guid? CourseId { get; set; }
    }
}