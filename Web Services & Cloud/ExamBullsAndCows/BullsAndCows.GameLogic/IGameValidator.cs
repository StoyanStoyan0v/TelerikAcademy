using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.GameLogic
{
    public interface IGameValidator
    {
        int GetCows(string number, string NumberToGuess);

        int GetBulls(string number, string NumberToGuess);
    }
}