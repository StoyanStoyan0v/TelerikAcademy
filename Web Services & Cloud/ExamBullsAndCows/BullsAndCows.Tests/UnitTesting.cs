using System;
using System.Linq;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using BullsAndCows.Data;
using BullsAndCows.Models;
using System.Net.Http;
using System.Web.Http;
using BullsAndCows.Services.Controllers;
using System.Threading;
using System.Collections.Generic;
using BullsAndCows.Services.DataModels;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void GetHighScoreBoard_WhenScoresNotEmpty_ShouldReturnSortedUsersByRank()
        {
            User[] users = new User[]
            {
                new User()
                {
                    Wins = 10,
                    Looses = 6,
                },
                new User()
                {
                    Wins = 5,
                    Looses = 5
                }
            };

            var data = Mock.Create<IBullsAndCowsData>();
            Mock.Arrange(() => data.Users.All())
                .Returns(() => users.AsQueryable());

            var controller = new ScoresController(data);
            this.SetupController(controller);
            var actionResult = controller.All();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<UserRankDataModel>>().Result.Select(a => a.Rank).ToList();

            var expected = users.AsQueryable().OrderByDescending(a => a.Rank).Select(a => a.Rank).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetAvailableGames_WhenThereAreGames_ShouldReturnCollectionOfAvailableGames()
        {
            var games = new Game[]
            {
                new Game()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    GameState = GameState.WaitingForOpponent
                },
                new Game()
                {
                    Id = 3,
                    DateCreated = DateTime.Now,
                    GameState = GameState.WaitingForOpponent
                },
                new Game()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    GameState = GameState.BlueInTurn
                }
            };

            var data = Mock.Create<IBullsAndCowsData>();
            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data);
            this.SetupController(controller);
            var actionResult = controller.All();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<GameDataModel>>().Result.Select(a => a.Id).ToList();
            
            var expected = games.AsQueryable().Where(g => g.GameState == GameState.WaitingForOpponent).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;
            
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

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