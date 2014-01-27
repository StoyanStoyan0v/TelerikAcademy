using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BunnyFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();
            string line = Console.ReadLine();
            while (line != "END")
            {
                input.Append(line);
                line = Console.ReadLine();
            }

            string result = GetTotalBunnies(input.ToString());
            char[] resultAsChars = result.ToCharArray();

            Console.WriteLine(string.Join(" ", resultAsChars));
        }

        private static string GetTotalBunnies(string input)
        {
            StringBuilder result = new StringBuilder();

            int cycle = 1;
            int count = int.Parse(input[0].ToString());

            while (input.Length - cycle >= count)
            {
                BigInteger sum = 0;
                BigInteger product = 1;
                for (int i = cycle; i < count + cycle; i++)
                {
                    sum += BigInteger.Parse(input[i].ToString());
                    product *= BigInteger.Parse(input[i].ToString());
                }
                input = input.Substring(count + cycle, input.Length - count - cycle);
                result.Clear();
                result.Append(sum);
                result.Append(product);
                result.Append(input);

                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == '0' || result[i] == '1')
                    {
                        result.Remove(i, 1);
                        i--;
                    }
                }
                input = result.ToString();

                cycle++;
                count = 0;
                for (int i = 0; i < cycle; i++)
                {
                    count += int.Parse(input[i].ToString());
                }
            }
            return result.ToString();
        }
    }
}
