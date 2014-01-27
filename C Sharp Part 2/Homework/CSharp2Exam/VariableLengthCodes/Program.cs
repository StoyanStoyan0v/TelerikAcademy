using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableLengthCodes
{
    class Program
    {
        static Dictionary<int, char> charCodes = new Dictionary<int, char>();

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            StringBuilder numsAsBytes = new StringBuilder();
           
            foreach (var num in nums)
            {
                numsAsBytes.Append(Convert.ToString(int.Parse(num), 2).PadLeft(8,'0'));
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                char letter = line[0];
                int num = int.Parse(line.Substring(1));
                charCodes.Add(num, letter);
            }

            string result = Encode(numsAsBytes);
            Console.WriteLine(result);
        }

        private static string Encode(StringBuilder numsAsBytes)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder currentLetterCode = new StringBuilder();
            for (int i = 0; i < numsAsBytes.Length; i++)
            {
                if (numsAsBytes[i] != '0')
                {
                    currentLetterCode.Append(numsAsBytes[i]);
                }
                else
                {
                    try
                    {
                        result.Append((char)charCodes[currentLetterCode.Length]);
                        currentLetterCode.Clear();
                    }
                    catch(KeyNotFoundException)
                    {

                    }
                }                               
            }

            if(currentLetterCode.Length>0)
            {
                result.Append((char)charCodes[currentLetterCode.Length]);
            }
            return result.ToString();
        }
    }
}
