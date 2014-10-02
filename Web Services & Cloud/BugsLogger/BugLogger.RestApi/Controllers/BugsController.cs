using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Cors;
using BugLogger.DataLayer;
using BugLogger.Repositories;
using BugLogger.RestApi.Models;

namespace BugLogger.RestApi.Controllers
{
    public class BugsController : ApiController
    {
        private readonly IRepository<Bug> repo;

        public BugsController() : this(new DbBugsRepository())
        {
        }

        public BugsController(IRepository<Bug> repository)
        {
            this.repo = repository;
        }

        [EnableCors("*", "*", "*")]
        public IQueryable<Bug> GetAll()
        {
            var bugs = this.repo.All();
            return bugs;
        }

        public IHttpActionResult Get(string date)
        {
            DateTime d;
            if (!DateTime.TryParse(date, out d))
            {
                return BadRequest("Invalid date format");
            }
            var bugs = this.repo.All().Where(b => b.LogDate >= d).Select(BugModel.FromBug);
            return Ok(bugs);
        }


        public IHttpActionResult GetByStatus(string status)
        {
            Status s;
            if (!Enum.TryParse(status, true, out s))
            {
                return BadRequest("Invalid date format");
            }
            var bugs = this.repo.All().Where(b => b.Status >= s).Select(BugModel.FromBug);
            return Ok(bugs);
        }

        public IQueryable<Bug> GetCount(int count)
        {
            return this.GetAll()
                       .Take(count);
        }

        public HttpResponseMessage PostBug(Bug bug)
        {
            if (string.IsNullOrEmpty(bug.Text))
            {
                var ex = new ArgumentException();
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            bug.LogDate = DateTime.Now;
            bug.Status = Status.Pending;
            this.repo.Add(bug);
            this.repo.Save();

            var response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bug.Id }));
            return response;
        }

        [HttpPut]
        public IHttpActionResult ChangeStatus(int id)
        {
            var existingBug = this.repo.All()
                                  .Where(b => b.Id == id)
                                  .FirstOrDefault();

            existingBug.Status = Status.Assigned;
            this.repo.Save();

            var response = this.Ok();
            return response;
        }
    }
}