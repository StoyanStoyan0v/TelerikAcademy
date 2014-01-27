using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int outerDots = n;

        for (int i = 0; i < n; i++)
        {
            outerDots--;
            Console.WriteLine(new string('.',i) + '*' + new string('.',outerDots));     
       
        }

        for (int i = n-2; i >= 0; i--)
        {
            outerDots++;
            Console.WriteLine(new string('.', i) + '*' + new string('.', outerDots));     
        }
    }
}
