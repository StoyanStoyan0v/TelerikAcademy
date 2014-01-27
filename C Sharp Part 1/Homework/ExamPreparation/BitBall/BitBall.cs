using System;

class BitBall
{
    static void Main()
    {
        byte[] topTeam = new byte[8];
        byte[] botTeam = new byte[8];
        int topGoals = 0;
        int botGoals = 0;

        for (int top = 0; top < 8; top++)
        {
            topTeam[top] = byte.Parse(Console.ReadLine());
        }

        for (int bot = 0; bot < 8; bot++)
        {
            botTeam[bot] = byte.Parse(Console.ReadLine());
        }

        //Clear the cells with both top and bottom player inside: 
        for (int num = 0; num < 8; num++)
        {
            for (int pos = 0; pos <= 7; pos++)
            {
                if ((((topTeam[num] >> pos) & 1) & ((botTeam[num] >> pos) & 1)) == 1)
                {
                    topTeam[num] &= (byte)(~(1 << pos));
                    botTeam[num] &= (byte)(~(1 << pos));
                }
            }
        }


        //Keep bool variables if there are many than one player in a row and one of them has already scored. If the first is scored the variable will get "true" value and the rest will not be counted. Keep other variable for the size of the column which can possibly have a bottom player over a top one...

        bool topScored = false;
        bool botScored = false;
        int checkBotOverTop = 0;

        //Move the players:
        for (int pos = 0; pos <= 7; pos++)
        {
            topScored = false;
            botScored = false;
            checkBotOverTop = 0;

            for (int checkBot = 7; checkBot >= 0; checkBot--)
            {              
                if (checkBot != 0)
                {
                    if (((botTeam[checkBot] >> pos) & 1) == 1)
                    {
                        for (int checkTop = 0; checkTop < checkBot; checkTop++)
                        {
                            if (((topTeam[checkTop] >> pos) & 1) == 1)
                            {
                                checkBotOverTop = checkTop;
                                break;
                            }
                            if (checkTop == checkBot-1)
                            {
                                botGoals++;
                            }

                        }
                        if (checkBotOverTop != 0)
                        {
                            for (int i = 0; i < checkBotOverTop; i++)
                            {
                                if ((((botTeam[i] >> pos) & 1) == 1) && botScored == false)
                                {
                                    botScored = true;
                                    botGoals++;
                                }
                            }
                        }
                        break;
                    }
                    if ((((topTeam[checkBot] >> pos) & 1) == 1) && topScored == false)
                    {
                        topScored = true;
                        topGoals++;
                    }
                }
                else
                {
                    if ((((botTeam[checkBot] >> pos) & 1) == 1)&& botScored==false)
                    {
                        botGoals++;
                    }
                    if ((((topTeam[checkBot] >> pos) & 1) == 1)& topScored==false)
                    {                       
                        topGoals++;
                    }
                }
            }
        }

        Console.WriteLine("{0}:{1}", topGoals, botGoals);
    }
}

