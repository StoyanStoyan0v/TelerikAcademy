using System;
namespace TimerEvents
{
    public delegate void Time(object sender, SecondsChangedEventArgs args);

    public class Timer
    {       
        private int interval;
        public event Time SecondsChanged; // Declare the event handler where to hook the events to.

        //Constructor with seconds change rate interval.
        public Timer(int interval)
        {
            this.interval = interval;
        }

        protected void OnChanged(int seconds) //Subscribe for the events.
        {
            // If an event is hooked, make instance of the event arguments and pass them to the event handler.
            if(SecondsChanged!=null)
            {
                
                SecondsChangedEventArgs args = new SecondsChangedEventArgs(seconds);
                SecondsChanged(this, args); 
            }
        }

        public void StartTimer()
        {
            int seconds = 0;

            while (true)
            {
                System.Threading.Thread.Sleep(this.interval*1000);
                this.SecondsChanged = Startwatch; //Hook an event.
                OnChanged(seconds);//Fire up the event.
                seconds++;  
      
                //If key is presed hook up another event, fire it up and stop the timer.
                if(Console.KeyAvailable)
                {
                    this.SecondsChanged = Stopwatch;
                    OnChanged(seconds);
                    break;
                }
            }
        }

        //Events (which are hooked to the event handler) with two parametters: event sender(publisher) and event arguments.
        private void Startwatch(object sender, SecondsChangedEventArgs args)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(args.Seconds + (args.Seconds == 1 ? " second." : " seconds."));
            Console.WriteLine("Press any key to stop the timer!");
        }

        private void Stopwatch(object sender, SecondsChangedEventArgs args)
        {
            Console.WriteLine("Timer stopped at {0} seconds!", args.Seconds - 1);
        }
    }
}
