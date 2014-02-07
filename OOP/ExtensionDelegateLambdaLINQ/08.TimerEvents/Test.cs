using TimerEvents;
using System;
    
class Test
{      
    /*Read in MSDN about the keyword event in C# and how to publish events. 
        * Re-implement the above using .NET events and following the best practices.*/

    static void Main(string[] args)
    {
        Timer timer = new Timer(1);
        timer.StartTimer();
    }
}

