using StudentsSystem.Models;
using StudentsSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentsSystem.Services.Controllers
{
    public class CoursesController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.Data.Courses
                              .All()
                              .Select(CourseModel.FromCourse);
            return this.Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult GetById(Guid id)
        {
            var course = this.Data.Courses
                             .All()
                             .Where(s => s.Id == id)
                             .Select(CourseModel.FromCourse)
                             .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Course does not exists - invalid id");
            }
            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newCourse = new Course()
            {
                CourseName = course.CourseName,
                Description = course.Description
            };

            this.Data.Courses.Add(newCourse);
            this.Data.SaveChanges();

            return this.Ok(newCourse);
        }

        [HttpPut]
        public IHttpActionResult Update(Guid id, CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingCourse = this.Data.Courses.All().FirstOrDefault(s => s.Id == id);

            if (existingCourse == null)
            {
                return this.BadRequest("Such student does not exists!");
            }

            if (course.CourseName != null)
            {
                existingCourse.CourseName = course.CourseName;
            }
            if (course.Description != null)
            {
                existingCourse.Description = course.Description;
            }

            this.Data.SaveChanges();
            course.Id = id;
            return this.Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var course = this.Data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (course == null)
            {
                return this.BadRequest("Such course does not exist");
            }
            course.Homeworks.Clear();
            course.Students.Clear();
            this.Data.SaveChanges();
            this.Data.Courses.Delete(course);
            this.Data.SaveChanges();

            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult AddHomework(Guid id, int homeworkId)
        {
            var course = this.Data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (course == null)
            {
                return this.BadRequest("Such course does not exists - invalid id!");
            }

            var homework = this.Data.Homeworks.All().FirstOrDefault(h => h.Id == homeworkId);
            if (homework == null)
            {
                return this.BadRequest("Such bunny does not exists - invalid id!");
            }

            course.Homeworks.Add(homework);
            this.Data.SaveChanges();

            return this.Ok();
        }
        
        [HttpPost]
        public IHttpActionResult RemoveHomework(Guid id, int homeworkId)
        {
            var course = this.Data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (course == null)
            {
                return this.BadRequest("Such course does not exists - invalid id!");
            }

            var homework = course.Homeworks.FirstOrDefault(h => h.Id == homeworkId);
            if (homework == null)
            {
                return this.BadRequest("Such bunny does not exists - invalid id!");
            }

            course.Homeworks.Remove(homework);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddStudent(Guid id, int studentId)
        {
            var course = this.Data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (course == null)
            {
                return this.BadRequest("Such course does not exists - invalid id!");
            }

            var student = this.Data.Students.All().FirstOrDefault(h => h.Id == studentId);
            if (student == null)
            {
                return this.BadRequest("Such student does not exists - invalid id!");
            }

            course.Students.Add(student);
            this.Data.SaveChanges();

            return this.Ok();
        }
        
        [HttpPost]
        public IHttpActionResult RemoveStudent(Guid id, int studentId)
        {
             var course = this.Data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (course == null)
            {
                return this.BadRequest("Such course does not exists - invalid id!");
            }

            var student = this.Data.Students.All().FirstOrDefault(h => h.Id == studentId);
            if (student == null)
            {
                return this.BadRequest("Such student does not exists - invalid id!");
            }

            course.Students.Remove(student);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}