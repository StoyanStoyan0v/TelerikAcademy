namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    
    static class ShortestSequenceOfOperations
    {
        private static readonly Stack<int> sequence = new Stack<int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            while (m != n)
            {
                sequence.Push(m);
                if (m / 2 >= n)
                {
                    if (m % 2 != 0 && m / 2 != n)
                    {
                        m--;
                        sequence.Push(m);
                    }
                    m /= 2;
                }
                else if (m - 2 >= n)
                {
                    m -= 2;
                }
                else if (m - 1 >= n)
                {
                    m--;
                }
            }
            sequence.Push(m);

            Console.WriteLine(string.Join("->", sequence));
        }
    }
}