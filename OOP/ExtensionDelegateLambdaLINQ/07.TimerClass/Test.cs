using System;
using TimerClass;

//Using delegates write a class Timer that can execute certain method at each t seconds

class Test
{
    private static void Startwatch(int seconds)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(seconds + (seconds <= 1 ? " second." : " seconds."));
        Console.WriteLine("Press any key to stop the watch!");
    }

    private static void Stopwatch(int seconds)
    {
        Console.WriteLine("Timer stopped at {0} seconds!",seconds-1);
    }

    static void Main()
    {
        //Pass two methods and the interval to the timer class.
        Timer.StartTimer(Startwatch, Stopwatch, 1);                        
    }
}

