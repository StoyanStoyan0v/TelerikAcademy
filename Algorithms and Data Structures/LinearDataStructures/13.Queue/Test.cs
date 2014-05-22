namespace Queue
{
    using System;

    class Test
    {
        static void Main(string[] args)
        {
            Queue<int> nums = new Queue<int>();

            for (int i = 1; i <= 15; i++)
            {
                nums.Enqueue(i);
            }

            Console.WriteLine(string.Join(" ", nums));

            Console.WriteLine("Dequeue: " + nums.Dequeue());
            Console.WriteLine("Dequeue: " + nums.Dequeue());
            Console.WriteLine("Dequeue: " + nums.Dequeue());
            Console.WriteLine("Dequeue: " + nums.Dequeue());

            Console.WriteLine(string.Join(" ", nums));
            Console.WriteLine("Queue's elements count is " + nums.Count);

            Console.WriteLine("Peek: " + nums.Peek());
            Console.WriteLine(string.Join(" ", nums));

            Console.WriteLine("Does the queue contains 10? " + nums.Contains(10));
            Console.WriteLine("Does the queue contains 18? " + nums.Contains(18));

            nums.Clear();

            Console.WriteLine("Queue's elements count is " + nums.Count);
        }
    }
}