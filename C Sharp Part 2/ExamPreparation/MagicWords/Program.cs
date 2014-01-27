using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }

            for (int i = 0; i < words.Count; i++)
            {
                int pos = words[i].Length % (words.Count + 1);
                string word = words[i];
                words[i] = null;
                words.Insert(pos, word);
                words.Remove(null);
            }

            int longest = 0;
            for (int i = 0; i < words.Count; i++)
            {
                if(words[i].Length>longest)
                {
                    longest = words[i].Length;
                }
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < longest; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if(words[j].Length>i)
                    {
                        result.Append(words[j][i]);
                    }
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
