using System;

class FighterAttack
{
    static void Main()
    {
        int firstPX = int.Parse(Console.ReadLine());
        int firstPY = int.Parse(Console.ReadLine());
        int secondPX = int.Parse(Console.ReadLine());
        int secondPY = int.Parse(Console.ReadLine());
        int fX = int.Parse(Console.ReadLine());
        int fY = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        int shotX = fX + d;
        int shotY = fY;

        int plantDamage=0;
        
        if((shotX>=Math.Min(firstPX,secondPX)&&shotX<=Math.Max(firstPX,secondPX)&&(shotY>Math.Min(firstPY,secondPY)&& shotY<Math.Max(firstPY,secondPY))))
        {
            if (shotX == Math.Max(firstPX, secondPX))
            {
                plantDamage = 200;
            }
            else
            {
                plantDamage = 275;
            }
        }
        else if((shotY==firstPY || shotY==secondPY)&&(shotX>=Math.Min(firstPX,secondPX)&&shotX<=Math.Max(firstPX,secondPX)))
        {
            if (shotX == Math.Max(firstPX, secondPX))
            {
                plantDamage = 150;
            }
            else
            {
                plantDamage = 225;
            }

        }
        else if (shotX == Math.Min(firstPX, secondPX) - 1 && (shotY >= Math.Min(firstPY, secondPY) && shotY<=Math.Max(firstPY,secondPY)))
        {
            plantDamage = 75;
        }
        else if (shotY == Math.Min(firstPY,secondPY)-1 || shotY == Math.Max(firstPY,secondPY)+1 && (shotX >= Math.Min(firstPX, secondPX) && shotX <= Math.Max(firstPX, secondPX)))
        {
            plantDamage = 50;
        }
        else
        {
            plantDamage = 0;
        }

        if (firstPX == secondPX && firstPY == secondPY && shotY == firstPY && shotX == firstPX)
        {
            plantDamage = 100;
        }

        Console.WriteLine(plantDamage+"%");
    }
}

