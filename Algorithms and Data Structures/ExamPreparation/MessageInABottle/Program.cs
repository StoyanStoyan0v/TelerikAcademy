using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace MessageInABottle
{
    class Program
    {
        private static string secretMessage;

        private static SortedSet<string> messages = new SortedSet<string>();

        private static MultiDictionary<char, string> ciphers = new MultiDictionary<char, string>(true);

        static void Main(string[] args)
        {
            secretMessage = Console.ReadLine();
            GetCiphers();
            GetMessage(0, new StringBuilder());
            if (messages.Count != 0)
            {
                Console.WriteLine(messages.Count);
                Console.WriteLine(string.Join(Environment.NewLine, messages));
            }
            else
            {
                Console.WriteLine(0);
            }
        }
        
        private static void GetMessage(int index, StringBuilder sb)
        {
            if (index == secretMessage.Length)
            {
                if (!messages.Contains(sb.ToString()))
                {
                    messages.Add(sb.ToString());
                }
            }
            else
            {
                foreach (var item in ciphers)
                {
                    if (secretMessage.Length >= index + item.Value.First().Length && secretMessage.Substring(index, item.Value.First().Length) == item.Value.First())
                    {
                        sb.Append(item.Key);
                        GetMessage(index + item.Value.First().Length, sb);
                        sb.Remove(sb.Length - 1, 1);
                    }
                }
            }
        }

        private static void GetCiphers()
        {
            var cipher = Console.ReadLine();

            for (int i = 0; i < cipher.Length; i++)
            {
                char letter = '0';
                if (!char.IsDigit(cipher[i]))
                {
                    letter = cipher[i];
                }

                i++;
                
                var sb = new StringBuilder();
                while (i < cipher.Length && char.IsDigit(cipher[i]))
                {
                    sb.Append(cipher[i]);
                    i++;
                }
                i--;
                if (!ciphers.ContainsKey(letter))
                {
                    ciphers.Add(letter, sb.ToString());
                }
            }
        }
    }
}