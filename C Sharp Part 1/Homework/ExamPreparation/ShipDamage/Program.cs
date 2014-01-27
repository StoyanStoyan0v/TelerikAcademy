using System;

class Program
{
    static void Main()
    {
        int firstSX = int.Parse(Console.ReadLine());
        int firstSY = int.Parse(Console.ReadLine());

        int secondSX = int.Parse(Console.ReadLine());
        int secondSY = int.Parse(Console.ReadLine());

        int h = int.Parse(Console.ReadLine());

        int firstCX = int.Parse(Console.ReadLine());
        int firstCY = int.Parse(Console.ReadLine());

        int secondCX = int.Parse(Console.ReadLine());
        int secondCY = int.Parse(Console.ReadLine());
        int thirdCX = int.Parse(Console.ReadLine());
        int thirdCY = int.Parse(Console.ReadLine());

        int firstShotX = firstCX;        
        int firstShotY = h +(h-(firstCY));
        
        

        int secondShotX = secondCX;
        int secondShotY = h + (h - (secondCY));

        int thirdShotX = thirdCX;
        int thirdShotY = h + (h - (thirdCY));
       

        int totalShipDamage =0;

        //Calculate damage of the first catapult:
        if ((firstShotY < Math.Max(firstSY,secondSY) && firstShotY > Math.Min(firstSY, secondSY)) && (firstShotX < Math.Max(firstSX, secondSX) && firstShotX > Math.Min(firstSX, secondSX)))
        {
            totalShipDamage += 100;
        }
        else if ((firstShotY == Math.Max(firstSY, secondSY) || firstShotY == Math.Min(firstSY, secondSY)))
        {
            if (firstShotX < Math.Max(firstSX, secondSX) && firstShotX > Math.Min(firstSX, secondSX))
            {
                totalShipDamage += 50;
            }
            else if (firstShotX == Math.Max(firstSX, secondSX) || firstShotX == Math.Min(firstSX, secondSX))
            {
                totalShipDamage += 25;
            }
            else
            {
                totalShipDamage += 0;
            }
        }
        else if ((firstShotX == Math.Max(firstSX, secondSX) || firstShotX == Math.Min(firstSX, secondSX)))
        {
            if (firstShotY < Math.Max(firstSY, secondSY) && firstShotY > Math.Min(firstSY, secondSY))
            {
                totalShipDamage += 50;
            }
            else if (firstShotY == Math.Max(firstSY, secondSY) || firstShotY ==Math.Min(firstSY, secondSY))
            {
                totalShipDamage += 25;
            }
            else
            {
                totalShipDamage += 0;
            }
        }
        else
        {
            totalShipDamage += 0;
        }

        //Calculate damage of the second catapult:
        if ((secondShotY < Math.Max(firstSY, secondSY) && secondShotY > Math.Min(firstSY, secondSY)) && (secondShotX < Math.Max(firstSX, secondSX) && secondShotX > Math.Min(firstSX, secondSX)))
        {
            totalShipDamage += 100;
        }
        else if ((secondShotY == Math.Max(firstSY, secondSY) || secondShotY == Math.Min(firstSY, secondSY)))
        {
            if (secondShotX < Math.Max(firstSX, secondSX) && secondShotX > Math.Min(firstSX, secondSX))
            {
                totalShipDamage += 50;
            }
            else if (secondShotX == Math.Max(firstSX, secondSX) || secondShotX == Math.Min(firstSX, secondSX))
            {
                totalShipDamage += 25;
            }
            else
            {
                totalShipDamage += 0;
            }
        }
        else if ((secondShotX == Math.Max(firstSX, secondSX) || secondShotX == Math.Min(firstSX, secondSX)))
        {
            if (secondShotY < Math.Max(firstSY, secondSY) && secondShotY > Math.Min(firstSY, secondSY))
            {
                totalShipDamage += 50;
            }
            else if (secondShotY == Math.Max(firstSY, secondSY) || secondShotY == Math.Min(firstSY, secondSY))
            {
                totalShipDamage += 25;
            }
            else
            {
                totalShipDamage += 0;
            }
        }
        else
        {
            totalShipDamage += 0;
        }

        //Calculate damage of the third catapult:
        if ((thirdShotY < Math.Max(firstSY, secondSY) && thirdShotY > Math.Min(firstSY, secondSY)) && (thirdShotX < Math.Max(firstSX, secondSX) && thirdShotX > Math.Min(firstSX, secondSX)))
        {
            totalShipDamage += 100;
        }
        else if ((thirdShotY == Math.Max(firstSY, secondSY) || thirdShotY == Math.Min(firstSY, secondSY)))
        {
            if (thirdShotX < Math.Max(firstSX, secondSX) && thirdShotX > Math.Min(firstSX, secondSX))
            {
                totalShipDamage += 50;
            }
            else if (thirdShotX == Math.Max(firstSX, secondSX) || thirdShotX == Math.Min(firstSX, secondSX))
            {
                totalShipDamage += 25;
            }
            else
            {
                totalShipDamage += 0;
            }
        }
        else if ((thirdShotX == Math.Max(firstSX, secondSX) || thirdShotX == Math.Min(firstSX, secondSX)))
        {
            if (thirdShotY < Math.Max(firstSY, secondSY) && thirdShotY > Math.Min(firstSY, secondSY))
            {
                totalShipDamage += 50;
            }
            else if (thirdShotY == Math.Max(firstSY, secondSY) || thirdShotY == Math.Min(firstSY, secondSY))
            {
                totalShipDamage += 25;
            }
            else
            {
                totalShipDamage += 0;
            }
        }
        else
        {
            totalShipDamage += 0;
        }
        Console.WriteLine(totalShipDamage+"%");
    }
}

