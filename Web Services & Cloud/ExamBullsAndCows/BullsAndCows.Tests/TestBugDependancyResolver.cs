using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using BullsAndCows.Data;
using BullsAndCows.Data.Repositories;
using BullsAndCows.Models;
using BullsAndCows.Services.Controllers;

namespace BullsAndCows.Tests
{
    class TestBugsDependencyResolver:  IDependencyResolver
    {
        private IBullsAndCowsData data;

        public IBullsAndCowsData  Repository
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            //add all controllers
            if (serviceType == typeof(GamesController))
            {
                return new GamesController(this.data);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {

        }
    }
}
