using System;
using System.Numerics;

class NaBabaMiSmetalnika
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        width -= 1;
        int[] numbers = new int[8];
        int counter = 0;
        for (int i = 0; i < 8; i++)
        {

            numbers[i] = int.Parse(Console.ReadLine()); 
        }
        while (true)
        {
            string command = Console.ReadLine();
                     
            if (command == "stop")
            {
                break;
            }
            else if (command == "reset")
            {
                for (int i = 0; i < 8; i++)
                {
                    int fullBitsCounter = 0;
                    for (int k = 0; k <= width; k++)
                    {
                        if ((numbers[i] >> k) % 2 != 0)
                        {
                            fullBitsCounter++;
                        }
                    }

                    int tempNumber = 0;
                    for (int j = width; j >= (width-fullBitsCounter)+1; j--)
                    {
                        
                        tempNumber |= (1 << j);
                        
                    }
                    numbers[i] = tempNumber;
                }
                continue;
            }
            else if (command == "right" || command == "left")
            {
                int fingeRow = int.Parse(Console.ReadLine());
                int fingerPos = int.Parse(Console.ReadLine());   
                 
                if (command == "right")
                {
                    int pos=0;
                    if (fingerPos < 0)
                    {
                        pos = width;
                    }
                    else if (fingerPos > width)
                    {
                        continue;
                    }
                    else
                    {
                        pos = width - fingerPos;
                    }

                    counter = 0;
                    for (int i = pos; i >= 0; i--)
                    {
                        if ((numbers[fingeRow] >> i) % 2 != 0)
                        {
                            numbers[fingeRow] &= (~(1 << i));
                            counter++;
                        }

                    }
                    for (int i = 0; i < counter; i++)
                    {
                        numbers[fingeRow] |= (1 << i);
                    }

                }
                else
                {
                    int pos = 0;
                    if (fingerPos > width)
                    {
                        pos = 0;
                    }
                    else if (fingerPos < 0)
                    {
                        continue;
                    }
                    else
                    {
                        pos = width - fingerPos;
                    }

                    counter = 0;
                    for (int i = pos; i <= width; i++)
                    {
                        if ((numbers[fingeRow] >> i) % 2 != 0)
                        {
                            numbers[fingeRow] &=(~(1 << i));
                            counter++;
                        }

                    }
                    for (int i = width; i > width-counter; i--)
                    {
                        numbers[fingeRow] |= (1 << i);
                    }

                }                                  
            }          
        }

        int emptyColumns = 0;
        bool isColEmpty = true;
        for (int i = 0; i <= width; i++)
        {
            isColEmpty = true;
            for (int j = 0; j < 8; j++)
            {
                if ((numbers[j] >> i) % 2 != 0)
                {
                    isColEmpty = false;
                }
            }
            if (isColEmpty == true)
            {
                emptyColumns++;
            }
        }
        BigInteger numsSum = 0;
        for (int i = 0; i < 8; i++)
        {
            numsSum += numbers[i];
        }
        BigInteger sum = numsSum*emptyColumns;
        Console.WriteLine(sum);

    }
}

