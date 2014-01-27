using System;

class BitTris
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int score = 0;
        int bitCount = 0;
        bool isStuck = false;
        int[] grid = new int[4];
        grid[0] = grid[1] = grid[2] = grid[3] = 0;

        for (int i = 0; i < n / 4; i++)
        {
            isStuck = false;
            bitCount = 0;
            int number = int.Parse(Console.ReadLine());
            string directionOne = Console.ReadLine();
            string directionTwo = Console.ReadLine();
            string directionThree = Console.ReadLine();
            for (int j = 0; j < 8; j++)
            {
                if ((number >> j) %2 != 0 && (grid[0] >> j) %2!= 0)
                {
                    isStuck = true;
                    break;
                }
            }

            if (isStuck == true)
            {
                break;
            }

            for (int j = 0; j < 8; j++)
            {
                if ((number >> j) % 2 != 0)
                {
                    bitCount++;
                }
            }

            if (bitCount == 8)
            {
                score += 80;
                continue;
            }
            else if (grid[0] == 255)
            {
                score += bitCount * 10;
                grid[0] = 0;
                continue;
            }


            if (directionOne == "R" && number % 2 == 0)
            {
                number >>= 1;
            }
            else if (directionOne == "L" && (((number >> 7) & 1) == 0))
            {
                number <<= 1;
            }

            for (int j = 0; j < 8; j++)
            {
                if ((number >> j) % 2 != 0 && (grid[1] >> j) % 2 != 0)
                {
                    grid[0] |= number;
                    score += bitCount;
                    isStuck = true;
                    break;
                }
            }
            if (isStuck == true)
            {
                continue;
            }

            if ((grid[1] | number) == 255)
            {
                score += bitCount * 10;
                grid[1] = grid[0];
                grid[0] = 0;
                continue;

            }


            if (directionTwo == "R" && number % 2 == 0)
            {
                number >>= 1;
            }
            else if (directionTwo == "L" && (((number >> 7) & 1) == 0))
            {
                number <<= 1;
            }

            for (int j = 0; j < 8; j++)
            {
                if ((number >> j) % 2 != 0 && (grid[2] >> j) % 2 != 0)
                {
                    grid[1] |= number;
                    score += bitCount;
                    isStuck = true;
                    break;
                }
            }

            if (isStuck == true)
            {
                continue;
            }

            if ((grid[2] | number) == 255)
            {
                score += bitCount * 10;
                grid[2] = grid[1];
                grid[1] = grid[0];
                grid[0] = 0;
                continue;
            }


            if (directionThree == "R" && number % 2 == 0)
            {
                number >>= 1;
            }
            else if (directionThree == "L" && (((number >> 7) & 1) == 0))
            {
                number <<= 1;
            }

            for (int j = 0; j < 8; j++)
            {
                if ((number >> j) % 2 != 0 && (grid[3] >> j) % 2 != 0)
                {
                    grid[2] |= number;
                    score += bitCount;
                    isStuck = true;
                    break;
                }
            }

            if (isStuck == true)
            {
                continue;
            }

            if ((grid[3] | number) == 255)
            {
                score += bitCount * 10;
                grid[3] = grid[2];
                grid[2] = grid[1];
                grid[1] = grid[0];
                grid[0] = 0;

                continue;
            }
            grid[3] |= number;
            score += bitCount;
        }
        Console.WriteLine(score);
    }
}

