using System;

class BatGoikoTower
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        int outerDots = h-1;
        int innerSymbols = 0;

        for (int i = 0; i < h; i++)
        {
            if (i == 1 || i == 3 || i == 6 || i == 10 || i == 15 || i == 21 || i == 28 || i ==36)
            {
                Console.WriteLine(new string('.', outerDots) + "/" + new string('-', innerSymbols) + "\\" + new string('.', outerDots));
                outerDots--;
                innerSymbols += 2;
            }
            else
            {
                Console.WriteLine(new string('.', outerDots) + "/" + new string('.', innerSymbols) + "\\" + new string('.', outerDots));
                outerDots--;
                innerSymbols += 2;
            }
        }
    }
}

