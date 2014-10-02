using Albums.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Albums.Services.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController() : this(new AlbumsData())
        {
        }

        protected BaseApiController(IAlbumsData data)
        {
            this.Data = data;
        }
        
        protected IAlbumsData Data { get; private set; }
    }
}