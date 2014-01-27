using System;

class Garden
{
    static void Main()
    {
        short tomatoSeeds = short.Parse(Console.ReadLine());
        byte tomatoArea = byte.Parse(Console.ReadLine());
        short cucumberSeeds = short.Parse(Console.ReadLine());
        byte cucumberArea = byte.Parse(Console.ReadLine());
        short potatoSeeds = short.Parse(Console.ReadLine());
        byte potatoArea = byte.Parse(Console.ReadLine());
        short carrotSeeds = short.Parse(Console.ReadLine());
        byte carrotArea = byte.Parse(Console.ReadLine());
        short cabbageSeeds = short.Parse(Console.ReadLine());
        byte cabbageArea = byte.Parse(Console.ReadLine());
        short beanSeeds = short.Parse(Console.ReadLine());

        decimal totalPriceSeeds = tomatoSeeds * 0.5M + cucumberSeeds * 0.4M + potatoSeeds * 0.25M + carrotSeeds*0.6M + cabbageSeeds * 0.3M + beanSeeds * 0.4M;

        int areaForBeans = 250 - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
        Console.WriteLine("Total costs: {0:F2}",totalPriceSeeds);
        if (areaForBeans < 0)
        {
            Console.WriteLine("Insufficient area");
        }
        else if (areaForBeans == 0)
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Beans area: {0}", areaForBeans);
            
        }
    }
}

