using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Routing;
using BugLogger.DataLayer;
using BugLogger.Repositories;
using BugLogger.RestApi.Controllers;
using BugLogger.RestApi.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using BugLogger.RestApi.Models;

namespace BugLogger.RestApi.Tests
{
    [TestClass]
    public class BugsControllerTests
    {
        private Bug[] bugs;

        [TestInitialize]
        public void InitializeBugs()
        {
            this.bugs = new Bug[]
            {
                new Bug()
                {
                    Id = 1,
                    LogDate = new DateTime(2014,12,25),
                    Status = Status.Assigned,
                    Text = "Sample Bug"
                },
                new Bug()
                {
                    Id = 2,
                    LogDate = new DateTime(2014,01,20),
                    Status = Status.Fixed,
                    Text = "Fixed bug"
                }
            };
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            //arrange
            FakeRepository<Bug> fakeRepo = new FakeRepository<Bug>();

            var bugs = new List<Bug>()
            {
                new Bug()
                {
                    Text = "TEST NEW BUG 1"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 2"
                },
                new Bug()
                {
                    Text = "TEST NEW BUG 3"
                }
            };            
            
            fakeRepo.Entities = bugs;

            var controller = new BugsController(fakeRepo as IRepository<Bug>);

            //act

            var result = controller.GetAll();

            //assert

            CollectionAssert.AreEquivalent(bugs, result.ToList<Bug>());
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            //arrange
            var repo = new FakeRepository<Bug>();
            repo.IsSaveCalled = false;
            repo.Entities = new List<Bug>();
            var bug = new Bug()
            {
                Text = "NEW TEST BUG"
            };
            var controller = new BugsController(repo);
            this.SetupController(controller);

            //act
            controller.PostBug(bug);

            //assert
            Assert.AreEqual(repo.Entities.Count, 1);
            var bugInDb = repo.Entities.First();
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(Status.Pending, bugInDb.Status);
            Assert.IsTrue(repo.IsSaveCalled);
        }

        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection_WithMocks()
        { 
            //arrange
            var repo = Mock.Create<IRepository<Bug>>();

            Bug[] bugs =
            {
                new Bug() { Text = "Bug1" },
                new Bug() { Text = "Bug2" }
            };

            Mock.Arrange(() => repo.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(repo);
            //act
            var result = controller.GetAll();

            //assert
            CollectionAssert.AreEquivalent(bugs, result.ToArray<Bug>());
        }

        [TestMethod]
       
        public void GetBugWithHigherDate_WhenValidDate_ShouldReturnBugsCollection()
        {
            var repo = Mock.Create<IRepository<Bug>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => this.bugs.AsQueryable());
            var controller = new BugsController(repo);
            this.SetupController(controller);
            var actionResult = controller.Get("12/25/2014");
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = this.bugs.AsQueryable().Where(x => x.LogDate == new DateTime(2014,12,25)).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }
        
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void GetBugWithHigherDate_WhenInvalidDate_ShouldThrowException()
        {
            var repo = Mock.Create<IRepository<Bug>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => this.bugs.AsQueryable());
            var controller = new BugsController(repo);
            this.SetupController(controller);
            var actionResult = controller.Get("123/25/2014");
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = this.bugs.AsQueryable().Where(x => x.LogDate == new DateTime(2014,12,25)).Select(a => a.Id).ToList();

            CollectionAssert.AreNotEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetBugWithStatusType_WhenValidStatus_ShouldReturnBugsCollection()
        {
            var repo = Mock.Create<IRepository<Bug>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => this.bugs.AsQueryable());
            var controller = new BugsController(repo);
            this.SetupController(controller);
            var actionResult = controller.GetByStatus("fixed");
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = this.bugs.AsQueryable().Where(x => x.Status == Status.Fixed).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void ChangeBugStatus_WhenValidId_ShouldChangeBugStatus()
        {
            var repo = Mock.Create<IRepository<Bug>>();
            Mock.Arrange(() => repo.All())
                .Returns(() => this.bugs.AsQueryable());
            var controller = new BugsController(repo);
            this.SetupController(controller);

            var bug = repo.All().FirstOrDefault(x => x.Id == 2);
            var oldStatus = bug.Status;
            controller.ChangeStatus(bug.Id);
            Assert.AreNotEqual(oldStatus, bug.Status);
            Assert.AreEqual(Status.Assigned,bug.Status);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;
            
            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}