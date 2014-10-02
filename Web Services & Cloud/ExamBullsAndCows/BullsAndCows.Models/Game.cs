using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public class Game
    {
        private ICollection<Guess> guesses;

        public Game()
        {
            this.GameState = GameState.WaitingForOpponent;
            this.guesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string RedPlayerId { get; set; }

        public virtual User RedPlayer { get; set; }

        public string BluePlayerId { get; set; }

        public virtual User BluePlayer { get; set; }

        public GameState GameState { get; set; }

        public string RedNumber { get; set; }

        public string BlueNumber { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get
            {
                return this.guesses;
            }
            set
            {
                this.guesses = value;
            }
        }
    }
}