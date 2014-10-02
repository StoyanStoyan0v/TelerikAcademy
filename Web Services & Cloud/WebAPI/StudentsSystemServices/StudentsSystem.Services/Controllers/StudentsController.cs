namespace StudentsSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentsSystem.Models;
    using StudentsSystem.Services.Models;

    public class StudentsController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.Data.Students
                               .All()
                               .Select(StudentModel.FromStudent);
            return this.Ok(students);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var student = this.Data.Students
                              .All()
                              .Where(s => s.Id == id)
                              .Select(StudentModel.FromStudent)
                              .FirstOrDefault();

            if (student == null)
            {
                return this.BadRequest("Student does not exists - invalid id");
            }
            return this.Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Number = student.Number
            };

            this.Data.Students.Add(newStudent);
            this.Data.SaveChanges();

            return this.Ok(newStudent);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingStudent = this.Data.Students.All().FirstOrDefault(s => s.Id == id);

            if (existingStudent == null)
            {
                return this.BadRequest("Such student does not exists!");
            }

            if (student.FirstName != null)
            {
                existingStudent.FirstName = student.FirstName;
            }
            if (student.LastName != null)
            {
                existingStudent.LastName = student.LastName;
            }
            if (student.Number != null)
            {
                existingStudent.Number = student.Number;
            }
            this.Data.SaveChanges();
            student.Id = id;
            return this.Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var student = this.Data.Students.All().FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return this.BadRequest("Such student does not exist");
            }
            student.Homeworks.Clear();
            student.Courses.Clear();
            this.Data.SaveChanges();
            this.Data.Students.Delete(student);
            this.Data.SaveChanges();

            return this.Ok(student);
        }

        [HttpPost]
        public IHttpActionResult AddHomework(int id, int homeworkId)
        {
            var student = this.Data.Students.All().FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return this.BadRequest("Such student does not exists - invalid id!");
            }

            var homework = this.Data.Homeworks.All().FirstOrDefault(h => h.Id == homeworkId);
            if (homework == null)
            {
                return this.BadRequest("Such bunny does not exists - invalid id!");
            }

            student.Homeworks.Add(homework);
            this.Data.SaveChanges();

            return this.Ok();
        }
        
        [HttpPost]
        public IHttpActionResult RemoveHomework(int id, int homeworkId)
        {
            var student = this.Data.Students.All().FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return this.BadRequest("Such student does not exists - invalid id!");
            }

            var homework = student.Homeworks.FirstOrDefault(h => h.Id == homeworkId);
            if (homework == null)
            {
                return this.BadRequest("Such bunny does not exists - invalid id!");
            }

            student.Homeworks.Remove(homework);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCourse(int id, string courseName)
        {
            var student = this.Data.Students.All().FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return this.BadRequest("Such student does not exists - invalid id!");
            }

            var course = this.Data.Courses.All().FirstOrDefault(h => h.CourseName == courseName);
            if (course == null)
            {
                return this.BadRequest("Such course does not exists - invalid id!");
            }

            student.Courses.Add(course);
            this.Data.SaveChanges();

            return this.Ok();
        }
        
        [HttpPost]
        public IHttpActionResult RemoveCourse(int id, string couseName)
        {
            var student = this.Data.Students.All().FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return this.BadRequest("Such student does not exists - invalid id!");
            }

            var course = student.Courses.FirstOrDefault(h => h.CourseName == couseName);
            if (course == null)
            {
                return this.BadRequest("Such course does not exists - invalid id!");
            }

            student.Courses.Remove(course);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}