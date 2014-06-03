namespace CountNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    static class NumberCounter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by whitespaces:");
            var numsAsStinrgArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var nums = numsAsStinrgArray.Select(num => double.Parse(num)).ToArray();
            
            var numsCount = CountNumbers(nums);
            
            foreach (var num in numsCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("{0} -> {1} time(s).", num.Key, num.Value);
            }
        }
  
        private static Dictionary<double, int> CountNumbers(double[] numsArray)
        {
            Dictionary<double, int> numbersCount = new Dictionary<double, int>();

            foreach (var num in numsArray)
            {
                if (!numbersCount.ContainsKey(num))
                {
                    numbersCount.Add(num, 0);
                }
                numbersCount[num]++;
            }
            
            return numbersCount;
        }
    }
}