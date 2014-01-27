using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspichanNumbers
{
    class KaspichanNumbers
    {
        static StringBuilder numb = new StringBuilder();

        static string ConvertToKaspichanNumeral(ulong dec)
        {
            do
            {
                ulong number = dec % 256;


                CheckFirstDigit(number % 26);
                CheckSecondDigit(number / 26 - 1);

                dec /= 256;
            }
            while (dec != 0);

            string result = numb.ToString();
            char[] arr = result.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static void CheckFirstDigit(ulong dec)
        {
            switch (dec)
            {
                case 0: numb.Append('A'); break;
                case 1: numb.Append('B'); break;
                case 2: numb.Append('C'); break;
                case 3: numb.Append('D'); break;
                case 4: numb.Append('E'); break;
                case 5: numb.Append('F'); break;
                case 6: numb.Append('G'); break;
                case 7: numb.Append('H'); break;
                case 8: numb.Append('I'); break;
                case 9: numb.Append('J'); break;
                case 10: numb.Append('K'); break;
                case 11: numb.Append('L'); break;
                case 12: numb.Append('M'); break;
                case 13: numb.Append('N'); break;
                case 14: numb.Append('O'); break;
                case 15: numb.Append('P'); break;
                case 16: numb.Append('Q'); break;
                case 17: numb.Append('R'); break;
                case 18: numb.Append('S'); break;
                case 19: numb.Append('T'); break;
                case 20: numb.Append('U'); break;
                case 21: numb.Append('V'); break;
                case 22: numb.Append('W'); break;
                case 23: numb.Append('X'); break;
                case 24: numb.Append('Y'); break;
                case 25: numb.Append('Z'); break;
            }
        }

        static void CheckSecondDigit(ulong dec)
        {
            switch (dec)
            {
                case 0: numb.Append('a'); break;
                case 1: numb.Append('b'); break;
                case 2: numb.Append('c'); break;
                case 3: numb.Append('d'); break;
                case 4: numb.Append('e'); break;
                case 5: numb.Append('f'); break;
                case 6: numb.Append('g'); break;
                case 7: numb.Append('h'); break;
                case 8: numb.Append('i'); break;              
            }
        }

        static void Main(string[] args)
        {
            ulong num = ulong.Parse(Console.ReadLine());
            string result = ConvertToKaspichanNumeral(num);
            Console.WriteLine(result);
        }
    }
}
