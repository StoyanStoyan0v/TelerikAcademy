using System;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            if(month==12)
            {
                if (day == 31)
                {
                    Console.WriteLine("{0}.{1}.{2}", 1, 1, year + 1);
                }
                else
                {
                    Console.WriteLine("{0}.{1}.{2}", day + 1, month, year);
                }
            }
            
            else 
            {
                if (day == 31)
                {
                    Console.WriteLine("{0}.{1}.{2}", 1, month + 1, year);
                }
                else
                {
                    Console.WriteLine("{0}.{1}.{2}", day + 1, month, year);
                }          
            }
        }
        else
        {
            if (month == 2 && (year == 2012 || year==2008 || year==2004 || year ==2000))
            {
                if (day < 29)
                {
                    Console.WriteLine("{0}.{1}.{2}", day + 1, month, year);
                }
                else
                {
                    Console.WriteLine("{0}.{1}.{2}",1, month+1, year);
                }
            }
            else if (month == 2)
            {
                if (day < 28)
                {
                    Console.WriteLine("{0}.{1}.{2}", day + 1, month, year);
                }
                else
                {
                    Console.WriteLine("{0}.{1}.{2}", 1, month + 1, year);
                }
            }
            else
            {
                if (day < 30)
                {
                    Console.WriteLine("{0}.{1}.{2}", day + 1, month, year);
                }
                else
                {
                    Console.WriteLine("{0}.{1}.{2}", 1, month + 1, year);
                }
            }
        }
    }
}

