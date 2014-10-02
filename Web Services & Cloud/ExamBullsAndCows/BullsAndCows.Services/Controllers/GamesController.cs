using BullsAndCows.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BullsAndCows.Services.DataModels;
using BullsAndCows.Models;

namespace BullsAndCows.Services.Controllers
{
    public class GamesController : BaseApiController
    {
        public GamesController(IBullsAndCowsData data) : base(data)
        {
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameDataModel model)
        {
            var userid = this.User.Identity.GetUserId();
            var newGame = new Game()
            {
                Name = model.Name,
                DateCreated = DateTime.Now,
                RedPlayerId = userid
            };
            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();
            
            model.Red = this.Data.Users.All().FirstOrDefault(u => u.Id == userid).Email;
            model.Blue = "No blue player yet";
            model.Id = newGame.Id;
            model.GameState = newGame.GameState.ToString();
            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0);
        }
        
        [HttpGet]
        public IHttpActionResult All(int page)
        {
            var games = this.GetAllSorted()
                            .Skip(10 * page)
                            .Take(10)
                            .Select(GameDataModel.FromGame)
                            .ToList();

            return Ok(games);
        }
        
        [HttpGet]
        [Authorize]
        public IHttpActionResult Details(int id)
        {
            var userid = this.User.Identity.GetUserId();

            var game = this.Data.Games.All().FirstOrDefault(g => g.Id == id && (g.GameState == GameState.RedInTurn || g.GameState == GameState.BlueInTurn));
            if (game == null)
            {
                return NotFound();
            }

            var articleModel = new GameInfoModel(game,userid);
            return Ok(articleModel);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Join(int id, InitialNumber number)
        {
            var userid = this.User.Identity.GetUserId();

            var game = this.Data.Games.All().FirstOrDefault(g => g.Id == id && g.GameState == GameState.WaitingForOpponent && g.RedPlayerId != userid);
            if (game == null)
            {
                return NotFound();
            }
            game.BluePlayerId = userid;
            game.BlueNumber = number.Number;
            var rand = new Random();
            var turn = rand.Next(0, 10);
            if (turn % 2 == 0)
            {
                game.GameState = GameState.RedInTurn;
            }
            else
            {
                game.GameState = GameState.BlueInTurn;
            }

            var notification = new Notification()
            {
                GameId = game.Id,
                DateCreated = DateTime.Now,
                UserId = game.RedPlayerId,
                Type = NotificationType.GameJoined,
                Message = string.Format("{0} joined your game {1}", this.User.Identity.GetUserName(), game.Name)
            };

            this.Data.Notifications.Add(notification);
            this.Data.SaveChanges();
            return Ok(id);
        }

        private IQueryable<Game> GetAllSorted()
        {
            return this.Data.Games.All().Where(g=>g.GameState==GameState.WaitingForOpponent)
                       .OrderBy(g => g.GameState)
                       .ThenBy(g => g.Name)
                       .ThenBy(g => g.DateCreated)
                       .ThenBy(g => g.RedPlayer.UserName);
        }
    }
}