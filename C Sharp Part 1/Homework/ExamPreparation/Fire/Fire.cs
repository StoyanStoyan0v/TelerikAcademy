using System;

class Fire
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int outerDots = n / 2 - 1;
        int innerDots = 0;

        //Upper part of the torch:
        for (int i = 0; i < n/2; i++)
        {
            Console.WriteLine(new string('.',outerDots) + "#" + new string('.',innerDots) +"#" + new string('.',outerDots));
            outerDots--;
            innerDots += 2;
        }

        outerDots++;
        innerDots -= 2;
        //Lower part of the torch:
        for (int i = 0; i < n/4; i++)
        {
            Console.WriteLine(new string('.',outerDots) + "#" + new string('.',innerDots) +"#" + new string('.',outerDots));
            outerDots++;
            innerDots -= 2;

        }

        Console.WriteLine(new string('-',n));

        //Cup:
        outerDots = 0;
        int leftDashCount = n / 2;
        int rightDashCount = n / 2;
        for (int i = 0; i < n/2; i++)
        {
            Console.WriteLine(new string('.', outerDots) +  new string('\\', leftDashCount) + new string('/', rightDashCount)+ new string('.', outerDots));

            leftDashCount--;
            rightDashCount--;
            outerDots++;
        }

    }
}

