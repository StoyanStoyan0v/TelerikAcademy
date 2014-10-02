using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.GameLogic
{
    public class GameValidator : IGameValidator
    {
        public int GetCows(string number, string NumberToGuess)
        {
            int count = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != NumberToGuess[i] && NumberToGuess.Contains(number[i]))
                {
                    count++;
                }
            }
            return count;
        }

        public int GetBulls(string number, string NumberToGuess)
        {
            int count = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (NumberToGuess[i] == number[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
}