namespace Sequence
{
    using System;
    using System.Collections.Generic;
    
    static class Sequence
    {
        private static readonly Queue<int> sequence = new Queue<int>();

        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(n + " ");
            sequence.Enqueue(n);

            for (int i = 1; i < 50; i++)
            {
                int num = sequence.Dequeue();                
                sequence.Enqueue(num + 1);
                sequence.Enqueue(2 * num + 1);
                sequence.Enqueue(num + 2);

                Console.Write(num + " ");
            }
        }
    }
}