using System;

class AngryBits
{
    //Score 70/100
    static void Main()
    {
     
        string input = null;
        ushort[] numbers = new ushort[8];
        for (int i = 0; i < numbers.Length; i++)
        {
            input = Console.ReadLine();
            numbers[i] = ushort.Parse(input);
            
        }
        
        const ushort mask = 1;
        int cellCounter = 0;
        int score = 0;
        int pigs = 0;
        bool isPigHit = false;

        for (int i = 8; i <= 15; i++)
        {
            for (int j = 7; j >= 0; j--)
            {
                if (((numbers[j] >> i) & mask) == 1)
                {
                    numbers[j] &= (ushort)(~(mask << i));
                    int position = i - 1;
                    isPigHit = false;
                    if (j != 0)
                    {
                        for (int l = j; l >= 1; l--)
                        {
                            if (((numbers[l - 1] >> position) & mask) == 1)
                            {
                                numbers[l - 1] &= (ushort)(~(mask << position));
                                pigs++;

                                if (((numbers[l] >> position) & mask) == 1)
                                {
                                    pigs++;
                                    numbers[l] &= (ushort)(~(mask << position));
                                }
                                if (((numbers[l] >> (position - 1)) & mask) == 1)
                                {
                                    numbers[l] &= (ushort)(~(mask << (position - 1)));
                                    pigs++;
                                }
                                if (((numbers[l - 1] >> (position + 1)) & mask) == 1)
                                {
                                    numbers[l - 1] &= (ushort)(~(mask << (position + 1)));
                                    pigs++;
                                }
                                if (((numbers[l - 1] >> (position - 1)) & mask) == 1)
                                {
                                    numbers[l - 1] &= (ushort)(~(mask << (position - 1)));
                                    pigs++;
                                }
                                if (l != 1)
                                {
                                    if (((numbers[l - 2] >> position) & mask) == 1)
                                    {
                                        numbers[l - 2] &= (ushort)(~(mask << position));
                                        pigs++;
                                    }
                                    if (((numbers[l - 2] >> (position + 1)) & mask) == 1)
                                    {
                                        numbers[l - 2] &= (ushort)(~(mask << position + 1));
                                        pigs++;
                                    }
                                    if (((numbers[l - 2] >> (position - 1)) & mask) == 1)
                                    {
                                        numbers[l - 2] &= (ushort)(~(mask << position-1));
                                        pigs++;
                                    }
                                }
                                cellCounter++;
                                score += pigs * cellCounter;
                                isPigHit = true;
                                cellCounter = 0;
                                pigs = 0;
                                break;
                            }
                            else
                            {
                                
                                if (position == 0)
                                {
                                    cellCounter = 0;
                                    break;
                                }
                                position--;
                                cellCounter++;
                            }
                        }
                    }

                    for (int l = 0; l <= 6; l++)
                    {
                        if (isPigHit == true)
                        {
                            break;
                        }
                        if (((numbers[l + 1] >> position) & mask) == 1)
                        {
                            numbers[l + 1] &= (ushort)(~(mask << position));
                            pigs++;
                            if (((numbers[l] >> position) & mask) == 1)
                            {
                                numbers[l] &= (ushort)(~(mask << position));
                                pigs++;
                            }
                            if (((numbers[l] >> (position - 1)) & mask) == 1)
                            {
                                numbers[l] &= (ushort)(~(mask << (position - 1)));
                                pigs++;
                            }
                            if (((numbers[l + 1] >> (position + 1)) & mask) == 1)
                            {
                                numbers[l + 1] &= (ushort)(~(mask << (position + 1)));
                                pigs++;
                            }
                            if (((numbers[l + 1] >> (position - 1)) & mask) == 1)
                            {
                                numbers[l + 1] &= (ushort)(~(mask << (position - 1)));
                                pigs++;
                            }
                            if (l != 6)
                            {
                                if (((numbers[l + 2] >> position) & mask) == 1)
                                {
                                    numbers[l + 2] &= (ushort)(~(mask << position));
                                    pigs++;
                                }
                                if (((numbers[l + 2] >> (position + 1)) & mask) == 1)
                                {
                                    numbers[l + 2] &= (ushort)(~(mask << (position + 1)));
                                    pigs++;
                                }
                                if (((numbers[l + 2] >> (position - 1)) & mask) == 1)
                                {
                                    numbers[l + 2] &= (ushort)(~(mask << (position - 1)));
                                    pigs++;
                                }
                            }
                            cellCounter++;
                            score += pigs * cellCounter;
                            isPigHit = true;
                            cellCounter = 0;
                            pigs = 0;
                            break;
                        }
                        else
                        {
                            
                            if (position == 0)
                            {
                                cellCounter = 0;
                                break;
                            }
                            position--;
                            cellCounter++;
                        }

                    }
                    for (int l = 7; l >= 1; l--)
                    {
                        if (isPigHit == true)
                        {
                            break;
                        }
                        if (((numbers[l - 1] >> position) & mask) == 1)
                        {
                            numbers[l - 1] &= (ushort)(~(mask << position));
                            pigs++;

                            if (((numbers[l] >> position) & mask) == 1)
                            {
                                pigs++;
                                numbers[l] &= (ushort)(~(mask << position));
                            }
                            if (((numbers[l] >> (position - 1)) & mask) == 1)
                            {
                                numbers[l] &= (ushort)(~(mask << (position - 1)));
                                pigs++;
                            }
                            if (((numbers[l - 1] >> (position + 1)) & mask) == 1)
                            {
                                numbers[l - 1] &= (ushort)(~(mask << (position + 1)));
                                pigs++;
                            }
                            if (((numbers[l - 1] >> (position - 1)) & mask) == 1)
                            {
                                numbers[l - 1] &= (ushort)(~(mask << (position - 1)));
                                pigs++;
                            }
                            if (l != 1)
                            {
                                if (((numbers[l - 2] >> position) & mask) == 1)
                                {
                                    numbers[l - 2] &= (ushort)(~(mask << position));
                                    pigs++;
                                }
                                if (((numbers[l - 2] >> (position + 1)) & mask) == 1)
                                {
                                    numbers[l - 2] &= (ushort)(~(mask << position + 1));
                                    pigs++;
                                }
                                if (((numbers[l - 2] >> (position - 1)) & mask) == 1)
                                {
                                    numbers[l - 2] &= (ushort)(~(mask << position-1));
                                    pigs++;
                                }
                            }
                            cellCounter++;
                            score += pigs * cellCounter;
                            cellCounter = 0;
                            pigs = 0;
                            break;
                        }
                        else
                        {
                            
                            if (position == 0)
                            {
                                cellCounter = 0;
                                break;
                            }
                            position--;
                            cellCounter++;
                        }

                    }
                    break;
                }
            }
        }
        string result = null;
        if (numbers[0] == 0 && numbers[1] == 0 && numbers[2] == 0 && numbers[3] == 0 && numbers[4] == 0 && numbers[5] == 0 && numbers[6] == 0 && numbers[7] == 0)
        {
            result = "Yes";
        }
        else
        {
            result = "No";
        }
        Console.WriteLine(score + " " + result);
    }
}

