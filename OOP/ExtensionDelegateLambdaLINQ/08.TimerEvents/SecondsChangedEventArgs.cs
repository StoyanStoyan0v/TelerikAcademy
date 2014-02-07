namespace TimerEvents
{
    using System;

    //Class with the arguments of an event.
    public class SecondsChangedEventArgs : EventArgs
    {
        private int seconds;

        public SecondsChangedEventArgs(int seconds)
        {
            this.seconds = seconds;
        }

        public int Seconds { get { return this.seconds; }  }
    }
}
