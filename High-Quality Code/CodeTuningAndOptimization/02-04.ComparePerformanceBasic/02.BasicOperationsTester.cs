using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComparePerformanceBasic
{
    public class BasicOperationsTester<T> where T : struct
    {
        private readonly IList<T> collection;
        private Stopwatch timer;

        public BasicOperationsTester(IList<T> collection)
        {
            timer = new Stopwatch();
            this.collection = collection;
        }

        public TimeSpan TestAddition()
        {
            this.timer.Restart();
            T sum = this.collection[0];

            for (int i = 1; i < this.collection.Count; i++)
            {
                sum += (dynamic)this.collection[i];
            }

            this.timer.Stop();
            return timer.Elapsed;
        }

        public TimeSpan TestSubtraction()
        {
            this.timer.Restart();
            T sum = this.collection[0];

            for (int i = 1; i < this.collection.Count; i++)
            {
                sum -= (dynamic)this.collection[i];
            }

            this.timer.Stop();
            return timer.Elapsed;         
        }

        public TimeSpan TestMultiplication()
        {
            this.timer.Restart();
            BigInteger sum = (dynamic)1;

            for (int i = 0; i < this.collection.Count; i++)
            {

                sum *= (BigInteger)(dynamic)this.collection[i];
            }

            this.timer.Stop();
            return timer.Elapsed;  
        }

        public TimeSpan TestDivision()
        {
            this.timer.Restart();
            T sum = this.collection[0];

            for (int i = 1; i < this.collection.Count; i++)
            {
                if (this.collection[i].Equals(0))
                {
                    throw new DivideByZeroException("Cannot divide number to 0.");
                }
                sum /= (dynamic)this.collection[i];
            }

            this.timer.Stop();
            return timer.Elapsed;  
        }

        public TimeSpan TestIncremention(int incrementCounter)
        {
            this.timer.Restart();
            T valueToIncrement = this.collection[0];

            int i = 0;
            while (i < incrementCounter)
            {
                valueToIncrement += (dynamic)1;
                i++;
            }

            this.timer.Stop();
            return timer.Elapsed;  
        }
    }
}