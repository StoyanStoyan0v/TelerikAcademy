using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Decode_and_Decrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            // Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher
            var digits = new List<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i]))
                // if (input[i] >= '0' && input[i] <= '9')
                {
                    // digits.Add(int.Parse(input[i].ToString()));
                    digits.Add(input[i] - '0');
                }
                else
                {
                    break;
                }
            }

            digits.Reverse();
            int lengthOfCypher = 0;
            foreach (var digit in digits)
            {
                lengthOfCypher *= 10;
                lengthOfCypher += digit;
            }

            // Encode(Encrypt(message, cypher) + cypher)
            var encodedMessagage = input.Substring(0, input.Length - digits.Count);

            // Encrypt(message, cypher) + cypher
            var decodedMessage = Decode(encodedMessagage);

            // Encrypt(message, cypher)
            var encryptedMessage = decodedMessage.Substring(0,
                                        decodedMessage.Length - lengthOfCypher);

            // cypher
            var cypher = decodedMessage.Substring(decodedMessage.Length - lengthOfCypher, lengthOfCypher);

            var message = Encrypt(encryptedMessage, cypher);

            Console.WriteLine(message);
            
            /*     ABBAA6BA7
             * Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher

ABBAA6BA             7   => Encode(Encrypt(message, cypher) + cypher)

ABBAABBBBBBA             => Encrypt(message, cypher) + cypher

BBBBBBA => cypher
ABBAA => Encrypt(message, cypher)
Encrypt("ABBAABBBBBBA", cypher) => message
             */
        }

        public static string Encrypt(string message, string cypher)
        {
            var result = new StringBuilder(message);

            var steps = Math.Max(message.Length, cypher.Length);
            for (int step = 0; step < steps; step++)
            {
                var messageIndex = step % message.Length;
                var cypherIndex = step % cypher.Length;
                result[messageIndex] =
                    (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
            }
            
            return result.ToString();;
        }

        public static string Decode(string encodedMessage)
        {
            // ABBAA6BA => ABBAABBBBBBA
            var result = new StringBuilder();
            var count = 0;
            foreach (var ch in encodedMessage)
            {
                if (char.IsDigit(ch))
                {
                    count *= 10;
                    count += int.Parse(ch.ToString()); // ch - '0'
                }
                else
                {
                    if (count == 0)
                    {
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(ch, count);
                        count = 0;
                    }
                }
            }

            return result.ToString();
        }
    }
}
