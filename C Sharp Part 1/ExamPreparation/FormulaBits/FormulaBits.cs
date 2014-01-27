using System;

class FormulaBits
{
    //Score: 50/100
    static void Main()
    {
        byte[] number = new byte[8];

        int pos = 0;
        int cellCounter = 0, turnCounter = 0;
        int num = 0;
        bool canProceed=true;

        //        2 38 20 48 111 15 3 43
        for (int i = 0; i < number.Length; i++)
        {
            number[i] = byte.Parse(Console.ReadLine());
        }

        while (true)
        {
            for (int i = num; i < number.Length; i++)
            {
                if (((number[i] >> pos) % 2 != 0) || i == 7)
                {
                    if (i == 0)
                    {
                        canProceed = false;
                        break;
                    }
                    if (i == num + 1)
                    {
                        canProceed = false;
                        break;
                    }

                    if (pos != 7)
                    {
                        turnCounter++;
                        pos++;
                    }

                    if ((number[i] >> pos) % 2 != 0)
                    {
                        num = i - 1;
                    }
                    else
                    {
                        num = i;
                        cellCounter++;
                    }

                    if (pos == 7)
                    {
                        break;
                    }

                    for (int j = pos; j < 8; j++)
                    {

                        if (((number[num] >> j) % 2 != 0) || j == 7)
                        {
                            if (j == pos)
                            {
                                turnCounter--;
                                canProceed = false;
                                break;
                            }
                            turnCounter++;
                            if ((number[num] >> j) % 2 != 0)
                            {
                                pos = j - 1;
                            }
                            else
                            {
                                pos = j;
                            }
                            break;
                        }
                        cellCounter++;
                    }
                    break;
                }
                cellCounter++;
            }

            if (canProceed == false)
            {
                Console.WriteLine("No "+cellCounter);
                break;
            }
            if (pos == 7 && num == 7)
            {
                Console.WriteLine(cellCounter + " " + turnCounter);
                break;
            }
            else
            {
                num--;

                for (int i = num; i >= 0; i--)
                {
                    if (((number[i] >> pos) % 2 != 0) || i == 0)
                    {
                        if (i == num)
                        {
                            turnCounter--;
                            canProceed = false;
                            break;
                        }
                        turnCounter++;
                        pos++;
                        if ((number[i] >> pos) % 2 != 0)
                        {
                            num = i + 1;
                        }
                        else
                        {
                            num = i; 
                            cellCounter++;

                        }

                        for (int j = pos; i < 8; j++)
                        {
                            if (((number[num] >> j) % 2 != 0) || j == 7)
                            {
                                if (j == pos)
                                {
                                    turnCounter--;
                                    canProceed = false;
                                    break;
                                }
                                turnCounter++;

                                if ((number[num] >> j) % 2 != 0)
                                {
                                    pos = j - 1;
                                }
                                else
                                {
                                    pos = j;
                                }

                                break;
                            }
                            cellCounter++;
                        }
                        break;
                    }
                    cellCounter++;
                }
            }
            if (canProceed == false)
            {
                Console.WriteLine("No "+cellCounter );
                break;
            }
        }
    }
}

