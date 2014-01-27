using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Multiverse_Communication
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabet = new List<string> { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
            var input = Console.ReadLine();
            long decimalRepresentation = 0;
            for (int i = 0; i < input.Length; i += 3)
            {
                var digitIn13 = input.Substring(i, 3);
                // Array.IndexOf
                var decimalValue = alphabet.IndexOf(digitIn13);

                decimalRepresentation *= 13;
                decimalRepresentation += decimalValue;
            }

            Console.WriteLine(decimalRepresentation);
        }
    }
}
