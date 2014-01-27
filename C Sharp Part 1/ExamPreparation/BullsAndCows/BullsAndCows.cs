using System;

class BullsAndCows
{
    static void Main()
    {
        //66/100
        int number = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());

        bool isFirstBull = false;
        bool isSecondBull = false;
        bool isThirdBull = false;
        bool isFourthBull = false;

        bool isFirstCow = false;
        bool isSecondCow = false;
        bool isThirdCow = false;
        bool isFourthCow = false;

        int currentBulls = 0;
        int currentCows = 0;

        int[] numberArray = new int[4];
        numberArray[3] = number % 10;
        numberArray[2] = (number / 10) % 10;
        numberArray[1] = (number / 100) % 10;
        numberArray[0] = (number / 1000) % 10 ;

        int matches = 0;

        for (int i = 1111; i <= 9999 ; i++)
        {
            if ((i / 1000) % 10 == 0 || (i / 100) % 10 == 0 || (i / 10) % 10==0 || i % 10 ==0)
            {
                continue;
            }
            currentBulls = 0;
            currentCows = 0;
            isFirstBull = false;
            isSecondBull = false;
            isThirdBull = false;
            isFourthBull = false;

            isFirstCow = false;
            isSecondCow = false;
            isThirdCow = false;
            isFourthCow = false;

            if ((i / 1000) % 10 == numberArray[0])
            {
                isFirstBull=true;
                currentBulls++;           
            }

            if (i % 10 == numberArray[3])
            {
                isFourthBull = true;
                currentBulls++;                
            }

            if ((i / 100) % 10 == numberArray[1])
            {
                isSecondBull = true;
                currentBulls++;               
            }


            if ((i / 10) % 10 == numberArray[2])
            {
                isThirdBull = true;
                currentBulls++;
            }
            if (isFirstBull == false)
            {
                if ((i / 1000) % 10 == numberArray[1])
                {
                    if (isSecondBull == false && isSecondCow==false)
                    {
                        
                        currentCows++;
                        isSecondCow = true;
                        
                    }
                }

                if ((i / 1000) % 10 == numberArray[2])
                {
                    if (isThirdBull == false && isThirdCow==false)
                    {
                        
                        currentCows++;
                        isThirdCow = true;
                    }
                }

                if ((i / 1000) % 10 == numberArray[3])
                {
                    if (isFourthBull == false && isFourthCow==false)
                    {
                        currentCows++;
                        isFourthCow = true;
                    }
                }
            }
            if (isSecondBull == false)
            {
                if ((i / 100) % 10 == numberArray[2])
                {
                    if (isThirdBull == false && isThirdCow==false)
                    {
                        currentCows++;
                        isThirdCow=true;
                    }
                }

                if ((i / 100) % 10 == numberArray[3])
                {
                    if (isFourthBull == false && isFourthCow==false)
                    {
                        currentCows++;
                        isFourthCow=true;
                    }
                }

                if ((i / 100) % 10 == numberArray[0])
                {
                    if (isFirstBull == false && isFirstCow==false)
                    {
                        currentCows++;
                        isFirstCow = true;
                    }
                }
            }
            if (isThirdBull == false)
            {
                if ((i / 10) % 10 == numberArray[1])
                {
                    if (isSecondBull == false && isSecondCow==false)
                    {
                        currentCows++;
                        isSecondCow = true;
                    }
                }

                if ((i / 10) % 10 == numberArray[0])
                {
                    if (isFirstBull == false && isFirstCow==false)
                    {
                        currentCows++;
                        isFirstCow = true;
                    }
                }

                if ((i / 10) % 10 == numberArray[3])
                {
                    if (isFourthBull == false && isFourthCow==false)
                    {
                        currentCows++;
                        isFourthCow = true;
                    }
                }
            }
            if (isFourthBull == false)
            {
                if (i % 10 == numberArray[1])
                {
                    if (isSecondBull == false && isSecondCow==false)
                    {
                        currentCows++;
                        isSecondCow = true;
                    }
                }

                if (i % 10 == numberArray[2])
                {
                    if (isThirdBull == false && isThirdCow==false)
                    {
                        currentCows++;
                        isThirdCow = true;
                    }
                }

                if (i % 10 == numberArray[0])
                {
                    if (isFirstBull == false && isFirstCow==false)
                    {
                        currentCows++;
                        isFirstCow = true;
                    }
                }
            }
            

            if (currentBulls == bulls && currentCows == cows)
            {
                matches++;
                Console.Write("{0} ", i);

            }          
 
        }
        if (matches == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine();
        }
    }
}

