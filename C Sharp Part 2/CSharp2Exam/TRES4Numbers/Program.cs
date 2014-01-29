using System;
using System.Text;

class Program
{
    static string ConvertToNum(ulong dec)
    {
        StringBuilder num = new StringBuilder();
        do
        {
            switch (dec % 9)
            {
                case 0: num.Append("+NOL"); break;
                case 1: num.Append("-KV"); break;
                case 2: num.Append("DACA*"); break;
                case 3: num.Append("MIM^"); break;
                case 4: num.Append("|KIRE"); break;
                case 5: num.Append("&YES"); break;
                case 6: num.Append(">>YME"); break;
                case 7: num.Append("LET/"); break;
                case 8: num.Append("NOD<<"); break;
            }
            dec /= 9;
        }
        while (dec != 0);

        char[] numAsChars = num.ToString().ToCharArray();
        Array.Reverse(numAsChars);
        return new string(numAsChars);
    }       

    static void Main(string[] args)
    {
        ulong dec = ulong.Parse(Console.ReadLine());
        Console.WriteLine(ConvertToNum(dec));
    }
}

