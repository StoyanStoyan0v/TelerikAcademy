using System;

class CoffeeMachine
{
    static void Main()
    {
        int firstTray = int.Parse(Console.ReadLine());
        int secondTray = int.Parse(Console.ReadLine());
        int thirdTray = int.Parse(Console.ReadLine());
        int fourthTray = int.Parse(Console.ReadLine());
        int fifthTray = int.Parse(Console.ReadLine());
        decimal moneyInput = decimal.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());

        decimal moneyAvailable = firstTray*0.05M +secondTray*0.10M + thirdTray*0.20M + fourthTray*0.50M + fifthTray*1.00M;
        decimal change = moneyInput - price;

        if (change < 0)
        {
            Console.WriteLine("More {0}", -change);
        }
        else
        {
            if (moneyAvailable >= change)
            {
                Console.WriteLine("Yes {0}", moneyAvailable - change);
            }
            else
            {
                Console.WriteLine("No {0}", change-moneyAvailable);
            }
        }

    }
}

