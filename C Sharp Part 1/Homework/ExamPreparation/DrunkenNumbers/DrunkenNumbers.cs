using System;

class DrunkenNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int leftSum = 0;
        int rightSum = 0;
        for (int drunkenNumberInd = 0; drunkenNumberInd < n; drunkenNumberInd++)
        {
            long absNumber = long.Parse(Console.ReadLine());
            absNumber = Math.Abs(absNumber);
            string input = absNumber.ToString();
            for (int i = 0; i < (input.Length + 1) / 2; i++)
            {
                int digit = input[i] - '0';
                leftSum += digit;
            }
            for (int i = input.Length / 2; i < input.Length; i++)
            {
                int digit = input[i] - '0';
                rightSum += digit;
            }
        }

        if (leftSum < rightSum)
        {
            Console.WriteLine("V " + (rightSum-leftSum));
        }
        else if (leftSum > rightSum)
        {
            Console.WriteLine("M " + (leftSum - rightSum));
        }
        else
        {
            Console.WriteLine("No " + (leftSum + rightSum));
        }

    }
}
    


