using System;
using System.Numerics;

class CardWars
{
    static void Main()
    {
        BigInteger firstScore=0;
        BigInteger secondScore=0;
        int firstPlayerGamesWon = 0;
        int secondPlayerGamesWon = 0;
        int firstPlayerPoints = 0;
        int secondPlayerPoints = 0;
        bool firstPlayerX = false;
        bool secondPlayerX = false;
        bool xCardWinning = false;
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {           
            firstPlayerPoints = 0;
            secondPlayerPoints = 0;
            firstPlayerX = false;
            secondPlayerX = false;

            string firstPlayerFirstCard = Console.ReadLine();
            switch (firstPlayerFirstCard)
            {
                case "2": firstPlayerPoints += 10; break;
                case "3": firstPlayerPoints += 9; break;
                case "4": firstPlayerPoints += 8; break;
                case "5": firstPlayerPoints += 7; break;
                case "6": firstPlayerPoints += 6; break;
                case "7": firstPlayerPoints += 5; break;
                case "8": firstPlayerPoints += 4; break;
                case "9": firstPlayerPoints += 3; break;
                case "10": firstPlayerPoints += 2; break;
                case "A": firstPlayerPoints += 1; break;
                case "J": firstPlayerPoints += 11; break;
                case "Q": firstPlayerPoints += 12; break;
                case "K": firstPlayerPoints += 13; break;
                case "Z": firstScore *= 2; break;
                case "Y": firstScore -= 200; break;
                case "X": firstPlayerX = true; break;
                default: break;
            }

            string firstPlayerSecondCard = Console.ReadLine();
            switch (firstPlayerSecondCard)
            {
                case "2": firstPlayerPoints += 10; break;
                case "3": firstPlayerPoints += 9; break;
                case "4": firstPlayerPoints += 8; break;
                case "5": firstPlayerPoints += 7; break;
                case "6": firstPlayerPoints += 6; break;
                case "7": firstPlayerPoints += 5; break;
                case "8": firstPlayerPoints += 4; break;
                case "9": firstPlayerPoints += 3; break;
                case "10": firstPlayerPoints += 2; break;
                case "A": firstPlayerPoints += 1; break;
                case "J": firstPlayerPoints += 11; break;
                case "Q": firstPlayerPoints += 12; break;
                case "K": firstPlayerPoints += 13; break;
                case "Z": firstScore *= 2; break;
                case "Y": firstScore -= 200; break;
                case "X": firstPlayerX = true; break;
                default: break;
            }

            string firstPlayerThirdCard = Console.ReadLine();
            switch (firstPlayerThirdCard)
            {
                case "2": firstPlayerPoints += 10; break;
                case "3": firstPlayerPoints += 9; break;
                case "4": firstPlayerPoints += 8; break;
                case "5": firstPlayerPoints += 7; break;
                case "6": firstPlayerPoints += 6; break;
                case "7": firstPlayerPoints += 5; break;
                case "8": firstPlayerPoints += 4; break;
                case "9": firstPlayerPoints += 3; break;
                case "10": firstPlayerPoints += 2; break;
                case "A": firstPlayerPoints += 1; break;
                case "J": firstPlayerPoints += 11; break;
                case "Q": firstPlayerPoints += 12; break;
                case "K": firstPlayerPoints += 13; break;
                case "Z": firstScore *= 2; break;
                case "Y": firstScore -= 200; break;
                case "X": firstPlayerX = true; break;
                default: break;
            }

            string secondPlayerFirstCard = Console.ReadLine();
            switch (secondPlayerFirstCard)
            {
                case "2": secondPlayerPoints += 10; break;
                case "3": secondPlayerPoints += 9; break;
                case "4": secondPlayerPoints += 8; break;
                case "5": secondPlayerPoints += 7; break;
                case "6": secondPlayerPoints += 6; break;
                case "7": secondPlayerPoints += 5; break;
                case "8": secondPlayerPoints += 4; break;
                case "9": secondPlayerPoints += 3; break;
                case "10": secondPlayerPoints += 2; break;
                case "A": secondPlayerPoints += 1; break;
                case "J": secondPlayerPoints += 11; break;
                case "Q": secondPlayerPoints += 12; break;
                case "K": secondPlayerPoints += 13; break;
                case "Z": secondScore *= 2; break;
                case "Y": secondScore -= 200; break;
                case "X": secondPlayerX = true; break;
                default: break;
            }

            string secondPlayerSecondCard = Console.ReadLine();
            switch (secondPlayerSecondCard)
            {
                case "2": secondPlayerPoints += 10; break;
                case "3": secondPlayerPoints += 9; break;
                case "4": secondPlayerPoints += 8; break;
                case "5": secondPlayerPoints += 7; break;
                case "6": secondPlayerPoints += 6; break;
                case "7": secondPlayerPoints += 5; break;
                case "8": secondPlayerPoints += 4; break;
                case "9": secondPlayerPoints += 3; break;
                case "10": secondPlayerPoints += 2; break;
                case "A": secondPlayerPoints += 1; break;
                case "J": secondPlayerPoints += 11; break;
                case "Q": secondPlayerPoints += 12; break;
                case "K": secondPlayerPoints += 13; break;
                case "Z": secondScore *= 2; break;
                case "Y": secondScore -= 200; break;
                case "X": secondPlayerX = true; break;
                default: break;
            }

            string secondPlayerThirdCard = Console.ReadLine();
            switch (secondPlayerThirdCard)
            {
                case "2": secondPlayerPoints += 10; break;
                case "3": secondPlayerPoints += 9; break;
                case "4": secondPlayerPoints += 8; break;
                case "5": secondPlayerPoints += 7; break;
                case "6": secondPlayerPoints += 6; break;
                case "7": secondPlayerPoints += 5; break;
                case "8": secondPlayerPoints += 4; break;
                case "9": secondPlayerPoints += 3; break;
                case "10": secondPlayerPoints += 2; break;
                case "A": secondPlayerPoints += 1; break;
                case "J": secondPlayerPoints += 11; break;
                case "Q": secondPlayerPoints += 12; break;
                case "K": secondPlayerPoints += 13; break;
                case "Z": secondScore *= 2; break;
                case "Y": secondScore -= 200; break;
                case "X": secondPlayerX = true; break;
                default: break;
            }

            if (firstPlayerX == true && secondPlayerX == false)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                xCardWinning = true;
                break;
            }
            else if (firstPlayerX == false && secondPlayerX == true)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                xCardWinning = true;
                break;
            }
            else if(firstPlayerX ==true && secondPlayerX ==true)
            {
                firstScore += 50;
                secondScore += 50;
            }

            if (firstPlayerPoints < secondPlayerPoints)
            {
                secondScore += secondPlayerPoints;
                secondPlayerGamesWon++;
            }
            else if (firstPlayerPoints > secondPlayerPoints)
            {
                firstScore += firstPlayerPoints;
                firstPlayerGamesWon++;
            }

        }
        if (xCardWinning == false)
        {
            if (firstScore > secondScore)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", firstScore);
                Console.WriteLine("Games won: {0}", firstPlayerGamesWon);
            }
            else if (firstScore < secondScore)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", secondScore);
                 Console.WriteLine("Games won: {0}", secondPlayerGamesWon);
            }
           
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}",firstScore);
            }
        }
    }
}

