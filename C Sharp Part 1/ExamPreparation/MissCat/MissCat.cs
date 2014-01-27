using System;

class MissCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] vote = new int[n];
        int[] catVotes = new int[10];
        int winnerVotes= 0;
        int secondVotes = 0;
        int winnerCat = 0;
        int secondCat = 0;
        
        for (int i = 0; i < n; i++)
        {
            vote[i] = int.Parse(Console.ReadLine());
            switch (vote[i])
            {
                case 1: catVotes[0]++; break;
                case 2: catVotes[1]++; break;
                case 3: catVotes[2]++; break;
                case 4: catVotes[3]++; break;
                case 5: catVotes[4]++; break;
                case 6: catVotes[5]++; break;
                case 7: catVotes[6]++; break;
                case 8: catVotes[7]++; break;
                case 9: catVotes[8]++; break;
                case 10: catVotes[9]++; break;
                default: break;
            }           
        }
        for (int i = 0; i < 10; i++)
        {
            if (catVotes[i] > winnerVotes)
            {
                winnerVotes = catVotes[i];
                winnerCat = i+1;
            }

        }

        for (int i = 0; i < 10; i++)
        {
            if (i == winnerCat)
            {
                continue;
            }
            if (catVotes[i] > secondVotes)
            {
                secondVotes = catVotes[i];
                secondCat = i+1;
            }
        }

        if (winnerVotes == secondVotes)
        {
            if (winnerCat < secondCat)
            {
                Console.WriteLine(winnerCat);
            }
            else
            {
                Console.WriteLine(secondCat);
            }
        }
        else
        {
            Console.WriteLine(winnerCat);
        }
    }
}

