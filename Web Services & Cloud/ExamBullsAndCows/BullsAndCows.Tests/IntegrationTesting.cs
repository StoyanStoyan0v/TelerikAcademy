using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Data;
using BullsAndCows.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class IntegrationTesting
    {

        private readonly string inMemoryServerUrl = "http://localhost:12345";

        [TestMethod]
        public void TestMethod()
        {
            IBullsAndCowsData data = Mock.Create<IBullsAndCowsData>();
            Game[] games = { new Game(), new Game(), new Game() };

            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var server = new InMemoryHttpServer(this.inMemoryServerUrl, data);

            var response = server.CreateGetRequest("/api/games");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}