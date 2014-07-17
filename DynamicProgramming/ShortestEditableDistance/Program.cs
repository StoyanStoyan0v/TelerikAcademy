namespace ShortestEditableDistance
{
    using System;
    using System.Linq;

    internal class Program
    {
        private const double DELETE_COST = 0.9;

        private const double INSERT_COST = 0.8;

        private const double REPLACE_COST = 1;

        private static void Main(string[] args)
        {
            Console.WriteLine(string.Format("Delete cost : {0}", DELETE_COST));
            Console.WriteLine(string.Format("Replace cost: {0}", REPLACE_COST));
            Console.WriteLine(string.Format("Insert cost: {0}", INSERT_COST));
            Console.WriteLine("Input:");
            string input = Console.ReadLine();
            Console.WriteLine("Output: ");
            string output = Console.ReadLine();
            
            double[,] dp = new double[input.Length + 1, output.Length + 1];

            dp[0, 0] = 0;

            for (int i = 1; i <= input.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + DELETE_COST;
            }

            for (int i = 1; i <= output.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] + INSERT_COST;
            }

            for (int i = 1; i <= input.Length; i++)
            {
                for (int j = 1; j <= output.Length; j++)
                {
                    double replaceCost = 0;
                    if (input[i - 1] != output[j - 1])
                    {
                        replaceCost = REPLACE_COST;
                    }

                    replaceCost += dp[i - 1, j - 1];

                    double insertCost = dp[i, j - 1] + INSERT_COST;

                    double deleteCost = dp[i - 1, j] + DELETE_COST;
                    
                    dp[i, j] = GetMinOfThree(replaceCost, insertCost, deleteCost);
                }
            }

            Console.WriteLine("{0} to {1} -> cost {2}", input, output, dp[input.Length, output.Length]);
        }

        private static double GetMinOfThree(double first, double second, double third)
        {
            double minOfTwo = Math.Min(first, second);
            return Math.Min(minOfTwo, third);
        }
    }
}