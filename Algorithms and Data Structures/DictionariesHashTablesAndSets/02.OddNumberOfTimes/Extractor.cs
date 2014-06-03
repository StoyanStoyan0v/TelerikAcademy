namespace OddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    static class Extractor
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers separated by whitespaces:");
            var words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var wordsCount = ExtractWords(words);
            var oddCountWords = wordsCount.Where(word => word.Value % 2 != 0);
            Console.WriteLine(string.Join(" ", oddCountWords.Select(word => word.Key)));
        }
  
        private static Dictionary<string, int> ExtractWords(string[] words)
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