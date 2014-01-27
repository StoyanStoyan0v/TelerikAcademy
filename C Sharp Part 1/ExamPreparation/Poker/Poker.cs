using System;

class Poker
{
    static void Main()
    {
        int[] cardIndex = new int[5];
        int[] cardCounter = {1,1,1,1,1};
        for (int i = 0; i < 5; i++)
        {
            string card = Console.ReadLine();
            switch (card)
            {
                case "2": cardIndex[i] = 2; break;
                case "3": cardIndex[i] = 3; break;
                case "4": cardIndex[i] = 4; break;
                case "5": cardIndex[i] = 5; break;
                case "6": cardIndex[i] = 6; break;
                case "7": cardIndex[i] = 7; break;
                case "8": cardIndex[i] = 8; break;
                case "9": cardIndex[i] = 9; break;
                case "10": cardIndex[i] = 10; break;
                case "J": cardIndex[i] = 11; break;
                case "Q": cardIndex[i] = 12; break;
                case "K": cardIndex[i] = 13; break;
                case "A": cardIndex[i] = 1; break;
                default:
                    break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (j!=i && cardIndex[i] == cardIndex[j])
                {                    
                    cardCounter[i]++;
                }
            }
        }
        int firstCardValue = Math.Min(cardIndex[0],Math.Min(cardIndex[1],Math.Min(cardIndex[2],Math.Min(cardIndex[3],cardIndex[4]))));

        if (cardCounter[0] == 5)
        {
            Console.WriteLine("Impossible");
        }
        else if (cardCounter[0] == 4 || cardCounter[1] == 4)
        {
            Console.WriteLine("Four of a Kind");
        }
        
        else if (cardCounter[0] == 3 || cardCounter[1] == 3 || cardCounter[2] == 3)
        {
            if (cardCounter[0]==2 || cardCounter[1]==2 ||cardCounter[2]==2 ||cardCounter[3]==2)
            {
                Console.WriteLine("Full House");
            }
            else
            {
                Console.WriteLine("Three of a Kind");
            }
        }
        else if ((cardCounter[0] == 2 && cardCounter[1] == 2 && (cardIndex[0] != cardIndex[1])) || (cardCounter[2] == 2 && cardCounter[3] == 2 && (cardIndex[2] != cardIndex[3])) || (cardCounter[0] == 2 && cardCounter[2] == 2 && (cardIndex[0] != cardIndex[2])) || (cardCounter[0] == 2 && cardCounter[3] == 2 && (cardIndex[0] != cardIndex[3])) || (cardCounter[1] == 0 && cardCounter[2] == 0 && (cardIndex[1] != cardIndex[2])) || (cardCounter[1] == 0 && cardCounter[3] == 2 && (cardIndex[1] != cardIndex[3])))
        {
            Console.WriteLine("Two Pairs");
        }
        else if (cardCounter[0] == 2 || cardCounter[1] == 2 || cardCounter[2] == 2 || cardCounter[3] == 2)
        {
            Console.WriteLine("One Pair");
        }
        else
        {
            int x = 0;
            for (int i = 0; i < 5; i++)
            {
                x ^= cardIndex[i];
            }
            if (firstCardValue % 2 != 0)
            {
                if (x == firstCardValue)
                {
                    Console.WriteLine("Straight");
                }
                else
                {
                    Console.WriteLine("Nothing");
                }
            }
            else
            {
                if (x == firstCardValue + 4)
                {
                    Console.WriteLine("Straight");
                }
                else
                {
                    Console.WriteLine("Nothing");
                }
            }
        }

    }
}

