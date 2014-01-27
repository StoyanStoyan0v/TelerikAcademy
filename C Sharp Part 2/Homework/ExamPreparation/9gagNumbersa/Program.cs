using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _9gagNumbersa
{
    class Program
    {

        static ulong ConvertToDec(string gag)
        {
            StringBuilder dig = new StringBuilder();
            StringBuilder numeral = new StringBuilder();
            ulong dec = 0;

            for (int i = 0; i < gag.Length; i++)
            {
                dig.Append(gag[i]);
                string num = CheckDigit(dig.ToString());
                if(num!="")
                {
                    numeral.Append(num);
                    dig.Clear();
                }
            }

            string numm = numeral.ToString();
            ulong power = 1;
            for (int i = numm.Length-1; i >= 0; i--)
            {
                dec += ulong.Parse(numm[i].ToString()) * power;
                power *= 9;
            }
            return dec;
        }

        static string CheckDigit(string gag)
        {
            switch (gag)
            {
                case "-!": return "0";
                case "**": return "1";
                case "!!!": return "2";
                case "&&": return "3";
                case "&-": return "4";
                case "!-": return "5";
                case "*!!!": return "6";
                case "&*!": return "7";
                case "!!**!-": return "8";  
                default: return "";
            }
            
        }

        static void Main(string[] args)
        {
            string gag = Console.ReadLine();
            ulong result = ConvertToDec(gag);
            Console.WriteLine(result);
        }
    }
}
