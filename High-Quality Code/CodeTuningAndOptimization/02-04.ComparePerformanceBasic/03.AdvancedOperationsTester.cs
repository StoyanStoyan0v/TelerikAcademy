using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparePerformanceBasic
{
    public class AdvancedOperationsTester<T> where T : struct
    {
        private readonly T item;
        private Stopwatch timer;

        public AdvancedOperationsTester(T item)
        {
            timer = new Stopwatch();
            this.item = item;
        }
        
        public TimeSpan TestSquareRoot()
        {
            this.timer.Restart();
            Math.Sqrt((double)(dynamic)this.item);

            this.timer.Stop();
            return timer.Elapsed;
        }

        public TimeSpan TestLogarithm()
        {
            this.timer.Restart();

            Math.Log((double)(dynamic)this.item);
            
            this.timer.Stop();
            return timer.Elapsed;         
        }
        
        public TimeSpan TestSinus()
        {
            this.timer.Restart();
            Math.Sin((double)(dynamic)this.item);
            this.timer.Stop();
            return timer.Elapsed;  
        }
    }
}