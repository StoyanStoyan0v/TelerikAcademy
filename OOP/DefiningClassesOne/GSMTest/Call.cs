using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMTest
{
    public class Call
    {
        private DateTime callDateAndTime;
        private string calledNumber;
        private int duration;

        public Call(DateTime calledDateAndTime, string number, int duration)
        {
            this.callDateAndTime = calledDateAndTime;
            this.calledNumber = number;
            this.duration = duration;
        }

        public DateTime TimeOfCall
        {
            get { return this.callDateAndTime; }
        }

        public string CalledNumber
        {
            get { return this.calledNumber; }
        }

        public int Duration
        {
            get { return this.duration; }
        }

        public override string ToString()
        {
            return string.Format("Date and time of call: {0}\nNumber dialed: {1}\nDuation of call: {2} seconds.",
                this.callDateAndTime,this.calledNumber,this.duration);
        }
    }
}
