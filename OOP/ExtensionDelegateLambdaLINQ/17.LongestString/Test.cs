using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestString
{
    class Test
    {
        static void Main()
        {
            string[] words = { "Interface", "Implementation", "Program", "Visual Studio Ultimate 2013" };

            //With LINQ:
            var longestWord =
                (from word in words
                 orderby word.Length descending
                 select word).ToArray().First();
            Console.WriteLine("Longest word: " + longestWord);

            //With Lambda and extensions: "
            var shortestWord = words.Aggregate((min, current) => min.Length < current.Length ? min : current);
            Console.WriteLine("Shortest word: " + shortestWord);
        }
    }
}
