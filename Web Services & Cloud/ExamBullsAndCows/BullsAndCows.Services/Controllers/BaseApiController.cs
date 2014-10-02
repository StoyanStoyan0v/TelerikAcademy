using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BullsAndCows.Data;

namespace BullsAndCows.Services.Controllers
{
    public class BaseApiController : ApiController
    {

        public BaseApiController(IBullsAndCowsData data)
        {
            this.Data = data;
        }

        protected IBullsAndCowsData Data { get; private set; }
    }
}