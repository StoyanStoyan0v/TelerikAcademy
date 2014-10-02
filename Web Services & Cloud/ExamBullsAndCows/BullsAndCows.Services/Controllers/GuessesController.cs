using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BullsAndCows.Models;
using BullsAndCows.Services.DataModels;
using BullsAndCows.GameLogic;
using BullsAndCows.Data;

namespace BullsAndCows.Services.Controllers
{
    public class GuessesController : BaseApiController
    {
        private readonly IGameValidator validator;

        public GuessesController(IBullsAndCowsData data, IGameValidator validator) : base(data)
        {
            this.validator = validator;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(int id, GuessDataModel guess)
        {
            var userId = this.User.Identity.GetUserId();

            var game = this.Data.Games.All().FirstOrDefault(g => g.Id == id && g.GameState != GameState.Finnished && g.GameState != GameState.WaitingForOpponent);

            if (game == null)
            {
                return NotFound();
            }

            int cows = 0;
            int bulls = 0;
            bool isRed = game.RedPlayerId == userId;

            if ((isRed && game.GameState == GameState.BlueInTurn) || (!isRed && game.GameState == GameState.RedInTurn))
            {
                return BadRequest("It is not your turn");
            }

            if (isRed)
            {
                cows = validator.GetCows(guess.Number, game.BlueNumber);
                bulls = validator.GetBulls(guess.Number, game.BlueNumber);
            }
            else
            {
                cows = validator.GetCows(guess.Number, game.RedNumber);
                bulls = validator.GetBulls(guess.Number, game.RedNumber);
            }

            var newGuess = new Guess()
            {
                UserId = userId,
                GameId = game.Id,
                Number = guess.Number,
                DateMade = DateTime.Now,
                BullsCount = bulls,
                CowsCount = cows
            };
            
            this.Data.Guesses.Add(newGuess);
            this.UpdateGameStatus(game, bulls, isRed);
            this.Data.SaveChanges();

            guess.Id = newGuess.Id;
            guess.Username = this.Data.Users.Find(userId).Email;
            guess.DateMade = newGuess.DateMade;
            guess.UserId = newGuess.UserId;
            guess.GameId = newGuess.GameId;
            guess.BullsCount = newGuess.BullsCount;
            guess.CowsCount = newGuess.CowsCount;
            
            return Ok(guess);
        }

        private void UpdateGameStatus(Game game, int bullsCount, bool isRed)
        {
            if (bullsCount == 4)
            {
                game.GameState = GameState.Finnished;
                if (isRed)
                {
                    this.Data.Users.Find(game.RedPlayerId).Wins++;
                    this.Data.Users.Find(game.BluePlayerId).Looses++;
                    var winNotification = new Notification()
                    {
                        GameId = game.Id,
                        DateCreated = DateTime.Now,
                        UserId = game.RedPlayerId,
                        Type = NotificationType.GameWon,
                        Message = string.Format("You beat {0} in game {1}", game.BluePlayer.UserName, game.Name)
                    };

                    var looseNotification = new Notification()
                    {
                        GameId = game.Id,
                        DateCreated = DateTime.Now,
                        UserId = game.BluePlayerId,
                        Type = NotificationType.GameLost,
                        Message = string.Format("{0} beat you in game {1}", game.RedPlayer.UserName, game.Name)
                    };

                    this.Data.Notifications.Add(winNotification);
                    this.Data.Notifications.Add(looseNotification);
                }
                else
                {
                    this.Data.Users.Find(game.RedPlayerId).Looses--;
                    this.Data.Users.Find(game.BluePlayerId).Wins++;

                    var winNotification = new Notification()
                    {
                        GameId = game.Id,
                        DateCreated = DateTime.Now,
                        UserId = game.BluePlayerId,
                        Type = NotificationType.GameWon,
                        Message = string.Format("You beat {0} in game {1}", game.RedPlayer.UserName, game.Name)
                    };

                    var looseNotification = new Notification()
                    {
                        GameId = game.Id,
                        DateCreated = DateTime.Now,
                        UserId = game.RedPlayerId,
                        Type = NotificationType.GameLost,
                        Message = string.Format("{0} beat you in game {1}", game.BluePlayer.UserName, game.Name)
                    };

                    this.Data.Notifications.Add(winNotification);
                    this.Data.Notifications.Add(looseNotification);
                }
            }
            else
            {
                if (game.GameState == GameState.RedInTurn)
                {
                    game.GameState = GameState.BlueInTurn;
                    var turnNotification = new Notification()
                    {
                        GameId = game.Id,
                        DateCreated = DateTime.Now,
                        UserId = game.BluePlayerId,
                        Type = NotificationType.YourTurn,
                        Message = string.Format("It is your turn in game \"{0}\"", game.Name)
                    };
                    this.Data.Notifications.Add(turnNotification);
                }
                else
                {
                    game.GameState = GameState.RedInTurn;
                    var turnNotification = new Notification()
                    {
                        GameId = game.Id,
                        DateCreated = DateTime.Now,
                        UserId = game.RedPlayerId,
                        Type = NotificationType.YourTurn,
                        Message = string.Format("It is your turn in game \"{0}\"", game.Name)
                    };
                    this.Data.Notifications.Add(turnNotification);
                }
            }

            this.Data.SaveChanges();
        }
    }
}