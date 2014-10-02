using StudentsSystem.Models;
using StudentsSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace StudentsSystem.Services.Controllers
{
    public class HomeworksController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.Data.Homeworks
                               .All()
                               .Select(HomeworkModel.FromHomework);
            return Ok(homeworks);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var homework = this.Data.Homeworks
                              .All()
                              .Where(h => h.Id == id)
                              .Select(HomeworkModel.FromHomework)
                              .FirstOrDefault();

            if (homework == null)
            {
                return BadRequest("Homework does not exists - invalid id");
            }
            return Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult Create(Homework homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = new Homework()
            {
                Content=homework.Content,
                TimeSent=homework.TimeSent
                
            };

            this.Data.Homeworks.Add(newStudent);
            this.Data.SaveChanges();

            return Ok(newStudent);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingHomework = this.Data.Homeworks.All().FirstOrDefault(s => s.Id == id);

            if (existingHomework == null)
            {
                return BadRequest("Such homework does not exists!");
            }

            if (homework.Content != null)
            {
                existingHomework.Content = homework.Content;
            }
            if (homework.TimeSent != null)
            {
                existingHomework.TimeSent = homework.TimeSent;
            }
           
            this.Data.SaveChanges();
            homework.Id = id;
            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var homework = this.Data.Homeworks.All().FirstOrDefault(s => s.Id == id);
            if (homework == null)
            {
                return BadRequest("Such homework does not exist");
            }

            this.Data.SaveChanges();
            this.Data.Homeworks.Delete(homework);
            this.Data.SaveChanges();

            return Ok(homework);
        }

    }
}