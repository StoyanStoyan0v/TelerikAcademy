using System;
using System.Collections.Generic;
using System.Text;

class Task
{
    static void Main()
    {
        string[] xyz = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int x = int.Parse(xyz[0]);
        int y = int.Parse(xyz[1]);
        int z = int.Parse(xyz[2]);

        string[] red = StringImport(Console.ReadLine().Replace(" ", "M")).ToString().Split(new char[] { 'M' });
        string[] blue = StringImport(Console.ReadLine().Replace(" ", "M")).ToString().Split(new char[] { 'M' });

        bool[,] field = new bool[y + 1, 2 * (x + z) + 1];

        int redRow = y / 2;
        int redCol = x / 2;
        string redDirection = "right";

        int blueRow = y / 2;
        int blueCol = x + z + x / 2;
        string blueDirection = "left";

        bool redDie = false;
        bool blueDie = false;

        field[redRow, redCol] = true;
        field[blueRow, blueCol] = true;

        for (int i = 0; i < red.Length - 1; i++)
        {
            redDirection = Direction(red, redDirection, i);
            blueDirection = Direction(blue, blueDirection, i);

            Motion(x, y, z, field, ref redRow, ref redCol, redDirection);
            if (redRow < 0 || redRow > y)
            {
                if (redRow < 0) redRow++;
                if (redRow > y) redRow--;
                redDie = true;
            }
            else
            {
                if (field[redRow, redCol]) redDie = true;
                field[redRow, redCol] = true;
            }
            Motion(x, y, z, field, ref blueRow, ref blueCol, blueDirection);
            if (blueRow < 0 || blueRow > y)
            {
                if (blueRow < 0) blueRow++;
                if (blueRow > y) blueRow--;
                blueDie = true;
            }
            else
            {
                if (field[blueRow, blueCol]) blueDie = true;
                field[blueRow, blueCol] = true;
            }
            if (redDie || blueDie)
            {
                if ((redRow == blueRow && redCol == blueCol) || (redDie && blueDie)) Console.WriteLine("DRAW");
                else if (!redDie) Console.WriteLine("RED");
                else if (!blueDie) Console.WriteLine("BLUE");
                break;
            }
            else if (i == red.Length - 2) Console.WriteLine("DRAW");
        }

        int distanceX = Math.Abs(redCol - x / 2);
        if (distanceX > x + z) distanceX = 2 * (x + z) - distanceX;
        Console.WriteLine(distanceX + Math.Abs(redRow - y / 2));
    }

    private static void Motion(int X, int Y, int Z, bool[,] playfield, ref int row, ref int col, string direction)
    {
        switch (direction)
        {
            case "right": col++; break;
            case "left": col--; break;
            case "up": row--; break;
            case "down": row++; break;
            default: break;
        }
        if (col < 0) col = 2 * (X + Z) - 1;
        else if (col > 2 * (X + Z) - 1) col = 0;
    }

    private static StringBuilder StringImport(string input)
    {
        StringBuilder result = new StringBuilder();
        int last = -1;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == 'M')
            {
                string curr = input.Substring(last + 1, i - last - 1);
                if (curr.Length > 0)
                {
                    if (curr[0] != 'L' && curr[0] != 'R')
                    {
                        for (int n = 1; n <= int.Parse(curr); n++) result.Append('M');
                    }
                    else
                    {
                        result.Append(curr[0]);
                        if (curr.Length == 1)
                        {
                            result.Append('M');
                        }
                        if (curr.Length > 1)
                        {
                            for (int m = 1; m <= int.Parse(curr.Substring(1)); m++) result.Append('M');
                        }
                    }
                }
                else result.Append('M');
                last = i;
            }
        }
        return result;
    }

    private static string Direction(string[] player, string direction, int i)
    {
        if (player[i].Length > 0)
        {
            switch (direction)
            {
                case "right":
                    if (player[i][0] == 'L') direction = "up";
                    if (player[i][0] == 'R') direction = "down";
                    break;
                case "left":
                    if (player[i][0] == 'L') direction = "down";
                    if (player[i][0] == 'R') direction = "up";
                    break;
                case "up":
                    if (player[i][0] == 'L') direction = "left";
                    if (player[i][0] == 'R') direction = "right";
                    break;
                case "down":
                    if (player[i][0] == 'L') direction = "right";
                    if (player[i][0] == 'R') direction = "left";
                    break;
                default: break;
            }
        }
        return direction;
    }

    public static int blueRow { get; set; }

    public static int blueCol { get; set; }
}