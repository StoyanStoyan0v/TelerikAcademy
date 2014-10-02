using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Services.DataModels
{
    public class GameInfoModel
    {
        public GameInfoModel(Game game, string userId)
        {
            this.Id = game.Id;
            Name = game.Name;
            DateCreated = game.DateCreated;
            Red = game.RedPlayer.UserName;
            Blue = game.BluePlayer.UserName;
            bool isRed = game.RedPlayerId == userId;

            if (isRed)
            {
                YourNumber = game.RedNumber;
            }
            else
            {
                YourNumber = game.BlueNumber;
            }

            YourGuesses = game.Guesses.Where(g => g.UserId == userId).AsQueryable().Select(GuessDataModel.FromGuess).ToArray();
            OpponentGuesses = game.Guesses.Where(g => g.UserId != userId).AsQueryable().Select(GuessDataModel.FromGuess).ToArray();
            YourColour = isRed ? "red" : "blue";
            GameState = game.GameState;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public ICollection<GuessDataModel> YourGuesses { get; set; }

        public IEnumerable<GuessDataModel> OpponentGuesses { get; set; }

        public string YourColour { get; set; }

        public GameState GameState { get; set; }
    }
}