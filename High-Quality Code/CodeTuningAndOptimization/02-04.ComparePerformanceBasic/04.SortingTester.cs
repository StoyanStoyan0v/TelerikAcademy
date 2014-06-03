using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparePerformanceBasic
{
    public class SortingTester<T> where T : IComparable<T>
    {
        private readonly IList<T> elements;
        private readonly Stopwatch timer;

        public SortingTester(IList<T> elements)
        {
            this.elements = elements;
            this.timer = new Stopwatch();
        }

        public TimeSpan QuickSort()
        {
            this.timer.Restart();

            QuickSort(0, this.elements.Count - 1);

            this.timer.Stop();

            return timer.Elapsed;
        }

        public TimeSpan InsertionSort()
        {
            this.timer.Restart();

            for (int i = 1; i < this.elements.Count; i++)
            {
                T x = (dynamic)this.elements[i];
                int j = i;
                while (j > 0 && this.elements[j - 1].CompareTo(x) == 1)
                {
                    this.elements[j] = this.elements[j - 1];
                    j--;
                }
                this.elements[j] = x;
            }

            this.timer.Stop();

            return timer.Elapsed;
        }

        public TimeSpan SelectionSort()
        {
            this.timer.Restart();
            for (int i = 0; i < elements.Count - 1; i++)
            {
                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (elements[i].CompareTo(elements[j]) > 0)
                    {
                        T newValue = elements[i];
                        elements[i] = elements[j];
                        elements[j] = newValue;
                    }
                }
            }
            this.timer.Stop();
            return timer.Elapsed;
        }

        private void QuickSort(int left, int right)
        {
            if (left < right)
            {
                int i = left, j = right;
                T pivot = elements[(left + right) / 2];

                while (i <= j)
                {
                    while (elements[i].CompareTo(pivot) < 0)
                    {
                        i++;
                    }

                    while (elements[j].CompareTo(pivot) > 0)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        // Swap
                        T tmp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = tmp;

                        i++;
                        j--;
                    }
                }

                // Recursive calls
                if (left < j)
                {
                    QuickSort(left, j);
                }

                if (i < right)
                {
                    QuickSort(i, right);
                }
            }
        }
    }
}