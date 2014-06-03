namespace PriorityQueue
{
    using System;
    using System.Collections.Generic;

    class Test
    {
        static void Main(string[] args)
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();

            queue.Enqueue("Pesho");
            queue.Enqueue("Ivan");
            queue.EnqueueMany(new[] { "Gosho", "Ivan", "Dragan", "Petkan", "Asen" });

            PrintCollection(queue);

            string name = queue.Dequeue();
            Console.WriteLine(name);
            name = queue.Dequeue();
            Console.WriteLine(name);

            PrintCollection(queue);

            Console.WriteLine(queue.Count);
        }

        private static void PrintCollection<T>(IEnumerable<T> queue)
        {
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}