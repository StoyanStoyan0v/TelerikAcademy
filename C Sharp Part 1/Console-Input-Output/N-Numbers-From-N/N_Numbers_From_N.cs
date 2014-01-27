using System;

class N_Numbers_From_N
{
    static void Main()
    {
        Console.Write("Enter numebr n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("You have to enter {0} more numbers. ",n);
        int sum = n;
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter the next number: ");
            int m = int.Parse(Console.ReadLine());
            sum += m;
        }
        Console.WriteLine(sum);
    }
}

