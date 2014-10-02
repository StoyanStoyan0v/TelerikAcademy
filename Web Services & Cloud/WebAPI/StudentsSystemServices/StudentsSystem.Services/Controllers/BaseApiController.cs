namespace StudentsSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentsSystem.Data;

    public class BaseApiController : ApiController
    {
        protected BaseApiController() : this(new StudentsSystemData())
        {
        }
        
        protected BaseApiController(IStudentSystemData data)
        {
            this.Data = data;
        }

        protected IStudentSystemData Data { get; private set; }
    }
}