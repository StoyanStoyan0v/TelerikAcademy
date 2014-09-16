using System;

namespace Bussinessmen
{
    internal class Program
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            ulong[,] dp = new ulong[n + 1, n + 2];

            dp[0, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                dp[i, 0] = dp[i - 1, 1];

                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j + 1];
                }
            }

            Console.WriteLine(dp[n, 0]);
        }
    }
}