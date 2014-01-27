using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int dots = 0;
        int stars = n;

        for (int i = 0; i < n/2+1; i++)
        {
            Console.WriteLine(new string('.', dots) + new string('*', stars) + new string('.', dots));
            dots++;
            stars -= 2;
        }
        stars = 3;
        dots = n / 2 - 1;

        for (int i = 0; i < n/2; i++)
        {
            Console.WriteLine(new string('.', dots) + new string('*', stars) + new string('.', dots));
            dots--;
            stars += 2;

        }
    }
}

