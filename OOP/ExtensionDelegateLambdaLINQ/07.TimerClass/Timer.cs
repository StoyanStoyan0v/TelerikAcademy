namespace TimerClass
{
    using System;

    public delegate void Time(int seconds);

    public static class Timer
    {

        public static void StartTimer(Time methodStart, Time methodEnd, int t)
        {
            int seconds = 0;

            while (true)
            {
                //Invoke a method if key is pressed.
                if (Console.KeyAvailable)
                {
                    methodEnd(seconds);
                    break;
                }

                //Invoke a method each t seconds.
                if (seconds % t == 0)
                {
                    methodStart(seconds);
                }

                seconds++;

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}

