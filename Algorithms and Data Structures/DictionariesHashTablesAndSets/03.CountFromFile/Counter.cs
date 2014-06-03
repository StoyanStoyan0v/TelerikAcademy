namespace CountFromFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    
    using System.IO;

    class Counter
    {
        static void Main(string[] args)
        {
            var nums = ReadWordsFromFile();
            
            var numsCount = CountNumbers(nums);
            
            foreach (var num in numsCount.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("{0} -> {1} time(s).", num.Key, num.Value);
            }
        }

        private static string[] ReadWordsFromFile()
        {
            List<string> words = new List<string>();
            char[] separators = { ',', ' ', '.', '-', (char)65533, '?', '!' };
            StreamReader reader = new StreamReader("words.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                    words.AddRange(line.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(word => word.ToLower()));
                    line = reader.ReadLine();
                }
            }

            return words.ToArray();
        }
  
        private static Dictionary<string, int> CountNumbers(string[] words)
        {
            Dictionary<string, int> numbersCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!numbersCount.ContainsKey(word))
                {
                    numbersCount.Add(word, 0);
                }
                numbersCount[word]++;
            }
            
            return numbersCount;
        }
    }
}