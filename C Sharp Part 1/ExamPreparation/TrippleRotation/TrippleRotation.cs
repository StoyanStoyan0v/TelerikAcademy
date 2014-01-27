using System;

class TrippleRotation
{
    static void Main()
    {
        string k = int.Parse(Console.ReadLine()).ToString();
        string restOfNumber=null;
        for (int i = 1; i <= 2; i++)
        {

            for (int l = 0; l < k.Length-1; l++)
            {
                restOfNumber += k[l];
            }
            k = int.Parse(k[k.Length - 1] + restOfNumber).ToString();
            restOfNumber = null;           
        }

        for (int i = 1; i <= 1; i++)
        {

            for (int l = 0; l < k.Length - 1; l++)
            {
                restOfNumber += k[l];
            }
            k = int.Parse(k[k.Length - 1] + restOfNumber).ToString();
            restOfNumber = null;
        }
        Console.WriteLine(k);       
    }
}

