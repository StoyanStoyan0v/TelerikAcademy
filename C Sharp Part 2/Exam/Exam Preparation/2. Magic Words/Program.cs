using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Magic_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 3
hi
academy
exam	eahxciaamdemy
             */

            int n = int.Parse(Console.ReadLine());
            var words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }

            // Reorder
            //for (int i = 0; i < n; i++)
            //{
            //    var word = words[i];
            //    var newIndex = word.Length % (n + 1);

            //    // words[i] = null;
            //    words.Insert(newIndex, word);
            //    // words.Remove(null);
            //    if (newIndex < i)
            //    {
            //        words.RemoveAt(i + 1);
            //    }
            //    else
            //    {
            //        words.RemoveAt(i);
            //    }
            //}
            words.Reverse();

            // Print
            var maxLength = 0;
            foreach (var word in words)
            {
                maxLength = Math.Max(maxLength, word.Length);
            }

            // var maxLength = words.Max(x => x.Length);

            var result = new StringBuilder();
            for (int i = 0; i < maxLength; i++)
            {
                foreach (var word in words)
                {
                    if (word.Length > i) // i = 1 len = 1;
                    {
                        result.Append(word[i]);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
