using System;

class Sheets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int smallestSheetNumber = 10;
        for (int i = 0; i <= smallestSheetNumber; i++)
        {
            if ((n >> i) % 2 == 0)
            {
                Console.WriteLine("A{0}",smallestSheetNumber-i);
            }
        }
    }
}

