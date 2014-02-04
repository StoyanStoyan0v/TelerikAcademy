using System;
using System.Collections.Generic;
using System.Text;

class FallingRocksGame
{
    static int dwarfPosition;
    static char[] dwarf = new char[Console.WindowWidth];
    static char[] rocks = new char[] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
    static char[,] rocksPositions = new char[Console.WindowWidth, Console.WindowHeight - 1];
    static Random randomGenerator = new Random();
    static int result = 0;
    static int rowsOfRocks = 0;
    static int level = 1;
    static int speed = 300;
    static int rockIntensity = 1;

    static void printSymbol(int x, int y, char ch)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(ch);
    }
    static void MoveDwarf()
    {
        if (Console.KeyAvailable)
        {

            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.RightArrow)
            {
                System.Threading.Thread.Sleep(0);
                if (dwarfPosition + 2 < Console.WindowWidth - 1)
                {
                    dwarfPosition++;
                    PrintDwarf();
                }
            }
            if (keyPressed.Key == ConsoleKey.LeftArrow)
            {
                System.Threading.Thread.Sleep(0);
                if (dwarfPosition > 0)
                {
                    dwarfPosition--;
                    PrintDwarf();
                }
            }
        }
    }
    static void PrintDwarf()
    {

        dwarf[dwarfPosition] = '(';
        dwarf[dwarfPosition + 1] = '0';
        dwarf[dwarfPosition + 2] = ')';
        for (int i = 0; i < dwarf.Length; i++)
        {
            if (i < dwarfPosition || i > dwarfPosition + 2)
            {
                dwarf[i] = ' ';
            }
        }
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.Write(dwarf);
        PrintScore();
    }

    static void MoveRocks()
    {
        if (rowsOfRocks < Console.WindowHeight - 2)
        {
            for (int y = rowsOfRocks; y >= 0; y--)
            {
                {
                    for (int i = 0; i < Console.WindowWidth; i++)
                    {
                        rocksPositions[i, y + 1] = rocksPositions[i, y];
                    }

                }
            }
        }
        else
        {
            for (int i = Console.WindowHeight - 2; i > 0; i--)
            {
                for (int y = 0; y < Console.WindowWidth; y++)
                {
                    rocksPositions[y, i] = rocksPositions[y, i - 1];
                }
            }
        }
        PrintRocks();

    }

    static void PrintScore()
    {
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.Write("Level {0}", level);
        Console.SetCursorPosition(Console.WindowWidth / 2 - 1, Console.WindowHeight - 1);
        Console.Write("Your score: {0}", result);
    }

    static void GenerateRocksOnRow(int row)
    {
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            int randomNumber = randomGenerator.Next(0, 100);
            int randomChar = randomGenerator.Next(0, 11);
            if (randomNumber < rockIntensity)
            {
                rocksPositions[i, row] = rocks[randomChar];
            }
            else
            {
                rocksPositions[i, row] = ' ';
            }
        }
    }

    static void PrintRocks()
    {
        for (int i = 0; i < Console.WindowHeight - 2; i++)
        {
            for (int y = 0; y < Console.WindowWidth; y++)
            {
                if (rocksPositions[y, i] != ' ')
                {
                    printSymbol(y, i, rocksPositions[y, i]);
                }
            }
        }
        PrintDwarf();
    }

    static void CollisionDetection()
    {
        for (int i = dwarfPosition; i <= dwarfPosition + 2; i++)
        {
            if (rocksPositions[i, rowsOfRocks] != ' ')
            {
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.Write("Your result is {0}.", result);
                result = 0;
                level = 1;
                rockIntensity = 1;
                speed = 300;

                for (int y = 0; y < Console.WindowHeight - 1; y++)
                {
                    {
                        for (int a = 0; a < Console.WindowWidth; a++)
                        {
                            rocksPositions[a, y] = ' ';
                        }

                    }
                }
                for (int seconds = 5; seconds >= 0; seconds--)
                {
                    Console.SetCursorPosition(10, 11);
                    System.Threading.Thread.Sleep(1000);
                    Console.Write("{0} seconds until a new game starts!", seconds);
                }
            }
            else
            {

                if (result > level * (level * 0.25) * 1000)
                {
                    level++;
                    if (level == 2 || level == 6 || level == 10)
                    {
                        rockIntensity++;
                    }
                    if (level == 3 || level == 5 || level == 7 || level == 8 || level == 9)
                    {
                        speed -= 15;
                    }

                    for (int seconds = 1; seconds >= 0; seconds--)
                    {
                        if (level < 11)
                        {
                            Console.SetCursorPosition(10, 10);
                            Console.Write("Level {0}", level);
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
            }
        }
    }

    static void StartNewGame()
    {
        Console.Title = "Falling Rocks Game! ";
        Console.Clear();
        result = 0;
        rowsOfRocks = 0;
        Console.SetWindowSize(50, 25);
        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        dwarfPosition = Console.WindowWidth / 2 - 1;
    }

    static void Main()
    {
        StartNewGame();
        while (true)
        {
            Console.Clear();
            PrintDwarf();
            MoveDwarf();
            GenerateRocksOnRow(0);
            MoveRocks();
            if (rowsOfRocks == Console.WindowHeight - 2)
            {
                for (int a = 0; a < Console.WindowWidth; a++)
                {
                    if (rocksPositions[a, rowsOfRocks] != ' ')
                    {
                        result += 10;
                    }
                }
                CollisionDetection();
            }
            if (rowsOfRocks < Console.WindowHeight - 2)
            {
                rowsOfRocks++;
            }
            if (level == 11)
            {
                break;
            }
            System.Threading.Thread.Sleep(speed);
        }
        Console.Clear();
        Console.SetCursorPosition(5, 10);
        Console.Write("Congratulations!");
        Console.Write("You have comepleted all 10 levels!");
        Console.SetCursorPosition(5, 12);
        Console.Write("Press any key to exit.");
        Console.ReadKey();
    }
}