namespace _02.ColourfulRabits
{
    using System;
    using System.Collections.Generic;

    internal class Rabits
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            var stack = new Stack<int>(arr);

            var sum = 0;

            while (stack.Count > 0)
            {
                var count = stack.Pop();
                sum += count + 1;
                var toPop = count;
                while (stack.Count > 0 && stack.Peek() == count && toPop > 0)
                {
                    stack.Pop();
                    toPop--;
                }
            }

            Console.WriteLine(sum);
        }
    }
}