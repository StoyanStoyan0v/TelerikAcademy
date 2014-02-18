namespace RangeValidation
{
    using System;
    using System.Linq;

    public class InvalidRangeException <T> : ApplicationException
    {
        public T Start { get; private set; }

        public T End { get; private set; }

        public InvalidRangeException(string msg, T start, T end) : base(msg)
        {
            this.Start = start;
            this.End = end;
        }
    }
}