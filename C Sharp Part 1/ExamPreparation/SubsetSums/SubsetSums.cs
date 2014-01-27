using System;

class SubsetSums
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        byte n = byte.Parse(Console.ReadLine());
        long[] number = new long[n];
        int subSetCount = 0;
        long maxSum = 0;

        for (int i = 0; i < n; i++)
        {
            number[i] = long.Parse(Console.ReadLine());
            maxSum+=i;
        }
    
        int maxi = (int)Math.Pow(2, n) - 1;
        for (int i = 1; i <= maxi; i++)
        {
            long currentSum = 0;
            for (int j = 1; j <= n; j++)
            {
                if (((i >> (j - 1)) & 1) == 1)
                {

                    if (j == 1) currentSum += number[j-1];
                    if (j == 2) currentSum += number[j-1];
                    if (j == 3) currentSum += number[j-1];
                    if (j == 4) currentSum += number[j-1];
                    if (j == 5) currentSum += number[j-1];
                    if (j == 6) currentSum += number[j-1];
                    if (j == 7) currentSum += number[j-1];
                    if (j == 8) currentSum += number[j-1];;
                    if (j == 9) currentSum += number[j-1];
                    if (j == 10) currentSum += number[j-1];
                    if (j == 11) currentSum += number[j-1];
                    if (j == 12) currentSum += number[j-1];
                    if (j == 13) currentSum += number[j-1];
                    if (j == 14) currentSum += number[j-1];
                    if (j == 15) currentSum += number[j-1];
                    if (j == 16) currentSum += number[j-1];
                    
                }
            }
            if (currentSum == s) subSetCount++;
        }
            Console.WriteLine(subSetCount);
        
    }
}

