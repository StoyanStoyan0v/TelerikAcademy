using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MultiverseCommunication
{
    class MultiverseCommunication
    {


        static BigInteger ConvertToDec(string input)
        {
            BigInteger dec = 0;
            BigInteger power = 1;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if ((i + 1) % 3 == 0)
                {
                    string digit = input[i - 2] + "" + input[i - 1] + "" + input[i];
                    BigInteger digitValue = DigitValue(digit);
                    dec += digitValue * power;
                    power *= 13;
                }

            }
            return dec;
        }

        static BigInteger DigitValue(string number)
        {
            BigInteger digitValue = 0;
            switch (number)
            {
                case "CHU": digitValue = 0; break;
                case "TEL": digitValue = 1; break;
                case "OFT": digitValue = 2; break;
                case "IVA": digitValue = 3; break;
                case "EMY": digitValue = 4; break;
                case "VNB": digitValue = 5; break;
                case "POQ": digitValue = 6; break;
                case "ERI": digitValue = 7; break;
                case "CAD": digitValue = 8; break;
                case "K-A": digitValue = 9; break;
                case "IIA": digitValue = 10; break;
                case "YLO": digitValue = 11; break;
                case "PLA": digitValue = 12; break;
            }
            return digitValue;
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            BigInteger dec = ConvertToDec(input);
            Console.WriteLine(dec);

        }
    }
}
